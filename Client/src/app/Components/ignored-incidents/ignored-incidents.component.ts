import { Component, OnInit } from '@angular/core';
import { IIgnoredIncident } from '../../Models/ignoredIncident';
import { IncidentsService } from '../../Services/incidents.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ignored-incidents',
  imports: [CommonModule],
  templateUrl: './ignored-incidents.component.html',
  styleUrl: './ignored-incidents.component.css'
})
export class IgnoredIncidentsComponent implements OnInit{
  ignoredIncidents:IIgnoredIncident[] = [];

  constructor(private incidentsService:IncidentsService){}

  ngOnInit(): void {
    this.loadIncidents();
  }

  loadIncidents(){
    this.incidentsService.getIgnoredIncidents().subscribe({
      next:res=>{
        this.ignoredIncidents = res
        // console.log(this.ignoredIncidents);
      },
      error:err=>console.log(err)
    })
  }

  deleteIgnoredIncident(id:number){
    this.incidentsService.deleteIgnoredIncident(id).subscribe({
      next:res=>{
        // console.log(res)
        const index = this.ignoredIncidents.findIndex(i=>i.cuttingDownIgnoredKey==id)
        // console.log(this.ignoredIncidents[index])
        this.ignoredIncidents.splice(index,1)
      },
      error:err=>console.log(err)
    })
  }

}
