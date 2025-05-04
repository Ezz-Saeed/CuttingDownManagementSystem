import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IIgnoredIncident } from '../Models/ignoredIncident';

@Injectable({
  providedIn: 'root'
})
export class IncidentsService {
  baseUrl = 'http://localhost:5288/api/incidents'

  constructor(private http:HttpClient) { }

  getIgnoredIncidents(){
    return this.http.get<IIgnoredIncident[]>(`${this.baseUrl}/ignoredIncidents`)
  }

  deleteIgnoredIncident(id:number){
    return this.http.delete(`${this.baseUrl}/deleteIgnoredIncident/${id}`);
  }

}
