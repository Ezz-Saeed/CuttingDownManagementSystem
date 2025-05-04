import { Component, OnInit } from '@angular/core';
import { IHeader } from '../../Models/header';
import { SearchParams } from '../../Models/searchParams';
import { IncidentsService } from '../../Services/incidents.service';

@Component({
  selector: 'app-search',
  imports: [],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent implements OnInit {
  headers:IHeader[] = []
  serchParams = new SearchParams();
  constructor(private incidentsService:IncidentsService){}

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  search(){
    this.incidentsService.getIncidentHeaders(this.serchParams).subscribe({
      next:res=>{
        this.headers = res.body ?? []
      },
      error:err=>console.log(err)
    })
  }

}
