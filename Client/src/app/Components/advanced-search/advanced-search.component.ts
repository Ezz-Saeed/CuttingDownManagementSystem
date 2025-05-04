import { Component, OnInit } from '@angular/core';
import { INetworkElement } from '../../Models/networkElement';
import { firstValueFrom } from 'rxjs';
import { IncidentsService } from '../../Services/incidents.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IIncicentDetails } from '../../Models/incidentDetails';

@Component({
  selector: 'app-advanced-search',
  imports: [CommonModule, FormsModule],
  templateUrl: './advanced-search.component.html',
  styleUrl: './advanced-search.component.css'
})
export class AdvancedSearchComponent implements OnInit {
  rootNode?: INetworkElement;
  children?:INetworkElement[];
  networkHierarchy:string[] = []
  elementName = '';
  elementType = ''
  selectedKeys: number[] = [];
  incidentResults: IIncicentDetails[] = [];

  constructor(private incidentsService: IncidentsService)  {}
  ngOnInit(): void {
    this.incidentsService.getNetworkHierarchy().subscribe({
      next:res=>{
        this.networkHierarchy = res
      },
      error:err=>console.log(err)
    })
  }

  async onSearch(name:string, type:string) {
    this.incidentsService.getChildElements(name, type).subscribe({
      next:res=>{
        this.rootNode = res
        this.children = res.children
        // console.log(res)
      },
      error:err=>console.log(err)
    })
  }

  expandNode(node: INetworkElement) {
    if (node.expanded) {
      node.expanded = false;
      node.children = [];
      return;
    }

    this.incidentsService.getChildElements(node.networkElementName, node.networkElementType).subscribe({
      next: res => {
        node.children = res.children;
        node.expanded = true;
      },
      error: err => console.log(err)
    });
  }


  collectCheckedNodes(node: INetworkElement) {
    if (node.checked) {
      this.selectedKeys.push(node.networkElementKey);
    }
    if (node.children) {
      node.children.forEach(child => this.collectCheckedNodes(child));
    }
  }

  onNavigate() {
    this.selectedKeys = [];
    if (this.rootNode) {
      this.collectCheckedNodes(this.rootNode);
    }

    // Fetch incident details for all selected keys
    const requests = this.selectedKeys.map(id => this.incidentsService.getIncidentDetails(id));

    Promise.all(requests.map(r => firstValueFrom(r)))
      .then(results => {
        this.incidentResults = results.flat(); // Flatten the array if each call returns a list
      })
      .catch(err => console.error(err));
  }

}
