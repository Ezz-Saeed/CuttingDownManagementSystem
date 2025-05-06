import { Component, OnInit, ViewChild } from '@angular/core';
import { IHeader } from '../../Models/header';
import { SearchParams } from '../../Models/searchParams';
import { IncidentsService } from '../../Services/incidents.service';
import { IChannel, IProblemType } from '../../Models/channel';
import { FormGroup, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AdvancedSearchComponent } from "../advanced-search/advanced-search.component";

@Component({
  selector: 'app-search',
  imports: [FormsModule, CommonModule, AdvancedSearchComponent],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent implements OnInit {
  @ViewChild('form', {static:true})form!:FormGroup
  headers:IHeader[] = []
  problemTypes:IProblemType[] = []
  channels:IChannel[] = []
  serchParams = new SearchParams();
  constructor(private incidentsService:IncidentsService){}

  ngOnInit(): void {
    this.loadChannels();
    this.loadProblemTypes();
  }

  loadChannels(){
    this.incidentsService.getChannels().subscribe({
      next:res=>{
        this.channels = res;
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

  search(){
    // console.log(this.serchParams)
    this.incidentsService.getIncidentHeaders(this.serchParams).subscribe({
      next:res=>{
        this.headers = res.body ?? []
        // this.form.reset();
        // console.log(this.headers)
      },
      error:err=>console.log(err)
    })
  }

  resetForm(){
    this.form.reset();
  }

}
