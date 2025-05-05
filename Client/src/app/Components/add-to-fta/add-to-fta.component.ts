import { Component, Input } from '@angular/core';
import { IChannel, IProblemType } from '../../Models/channel';
import { IHierarchyPathType } from '../../Models/hierarchyPathType';
import { FTA } from '../../Models/fta';
import { IncidentsService } from '../../Services/incidents.service';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AdvancedSearchComponent } from "../advanced-search/advanced-search.component";

@Component({
  selector: 'app-add-to-fta',
  imports: [FormsModule, RouterModule, CommonModule, AdvancedSearchComponent],
  templateUrl: './add-to-fta.component.html',
  styleUrl: './add-to-fta.component.css'
})
export class AddToFtaComponent {
  affectedElements?:number[]=[]
  problemTypes:IProblemType[] = []
  channels:IChannel[] = []
  pthTypes:IHierarchyPathType[] = []
  networkHierarchy:string[] = []
  fta:FTA = new FTA()
  constructor(private incidentsService: IncidentsService, private router:Router)  {

  }
  ngOnInit(): void {
    this.loadChannels();
    this.loadProblemTypes();
    this.loadHierarchyPathTyps();
    this.incidentsService.getNetworkHierarchy().subscribe({
      next:res=>{
        this.networkHierarchy = res
      },
      error:err=>console.log(err)
    })

    this.fta.affectedElements = this.affectedElements
  }


  addToFta(){
    console.log(this.affectedElements)
    this.incidentsService.addCuttingDownToFta(this.fta).subscribe({
      next:res=>{
        // this.router.navigate(['/search',{tab:0}])
      },
      error:err=>console.log(err)
    })
  }


  loadHierarchyPathTyps(){
    this.incidentsService.getHierarchyPathTyps().subscribe({
      next:res=>{
        this.pthTypes = res;
      },
      error:err=>console.log(err)
    })
  }

    loadChannels(){
      this.incidentsService.getChannels().subscribe({
        next:res=>{
          this.channels = res;
          // console.log(this.channels)
        },
        error:err=>console.log(err)
      })
    }

    loadProblemTypes(){
      this.incidentsService.getProblemTypes().subscribe({
        next:res=>{
          this.problemTypes = res;
        },
        error:err=>console.log(err)
      })
    }

    setAffectedKeys(keys:number[]){
      this.affectedElements = keys;
    }

}
