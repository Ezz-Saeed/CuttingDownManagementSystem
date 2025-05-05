import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { INetworkElement } from '../../Models/networkElement';
import { firstValueFrom } from 'rxjs';
import { IncidentsService } from '../../Services/incidents.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IIncicentDetails } from '../../Models/incidentDetails';
import { IChannel, IProblemType } from '../../Models/channel';
import { IHierarchyPathType } from '../../Models/hierarchyPathType';
import { FTA } from '../../Models/fta';
import { Router, RouterModule } from '@angular/router';
import { AddToFtaComponent } from "../add-to-fta/add-to-fta.component";

@Component({
  selector: 'app-advanced-search',
  imports: [CommonModule, FormsModule, RouterModule],
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
  problemTypes:IProblemType[] = []
  channels:IChannel[] = []
  pthTypes:IHierarchyPathType[] = []
  fta:FTA = new FTA()
  errorMessage?:string | null
  @Output()SelectedKeysOutput = new EventEmitter<number[]>();

  constructor(private incidentsService: IncidentsService, private router:Router)  {}
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
        this.errorMessage = null
        // console.log(res)
      },
      error:err=>{
        console.log(err)
        this.errorMessage = err.error.message
      }
    })
  }

  expandNode(node: INetworkElement) {
    if (node.expanded) {
      node.expanded = false;
      node.children = []; // Optionally keep children if you want to preserve them
      return;
    }

    this.incidentsService.getChildElements(node.networkElementName, node.networkElementType).subscribe({
      next: res => {
        node.children = res.children?.map(child => ({
          ...child,
          checked: node.checked, // Propagate checked state
          expanded: false,
          children: []
        }));
        node.expanded = true;
      },
      error: err => console.error(err)
    });
  }

  collectCheckedNodes(node: INetworkElement): number[] {
    const selected: number[] = [];

    const collect = (n: INetworkElement) => {
      if (n.checked) {
        selected.push(n.networkElementKey);
      }
      if (n.children) {
        n.children.forEach(collect);
      }
    };

    collect(node);
    return selected;
  }


  onNavigate() {
    if (!this.rootNode) return;

    this.selectedKeys = this.collectCheckedNodes(this.rootNode);
    this.fta.affectedElements = this.selectedKeys;
    console.log(this.fta.affectedElements)
    this.SelectedKeysOutput.emit(this.fta.affectedElements);
    const requests = this.selectedKeys.map(id => this.incidentsService.getIncidentDetails(id));

    Promise.all(requests.map(r => firstValueFrom(r)))
      .then(results => {
        this.incidentResults = results.flat();
      })
      .catch(err => console.error(err));
  }




  loadHierarchyPathTyps(){
    this.incidentsService.getHierarchyPathTyps().subscribe({
      next:res=>{
        this.pthTypes = res;
      },
      error:err=>console.log(err)
    })
  }

  allSelected = false;

toggleAllChecked() {
  this.setCheckedRecursive(this.rootNode!, this.allSelected);
}

setCheckedRecursive(node: INetworkElement, checked: boolean) {
  node.checked = checked;
  if (node.children) {
    for (let child of node.children) {
      this.setCheckedRecursive(child, checked);
    }
  }
}

onNodeCheckedChange(node: INetworkElement) {
  // Optional: implement logic to update `allSelected` checkbox state dynamically
  this.updateAllSelectedStatus();
}

updateAllSelectedStatus() {
  const total = this.countTotalNodes(this.rootNode!);
  const selected = this.collectCheckedNodes(this.rootNode!).length;
  this.allSelected = total === selected;
}

countTotalNodes(node: INetworkElement): number {
  let count = 1; // count self
  if (node.children) {
    for (const child of node.children) {
      count += this.countTotalNodes(child);
    }
  }
  return count;
}


}
