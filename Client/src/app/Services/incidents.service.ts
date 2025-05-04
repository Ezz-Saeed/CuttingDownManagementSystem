import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IIgnoredIncident } from '../Models/ignoredIncident';
import { IHeader } from '../Models/header';
import { SearchParams } from '../Models/searchParams';
import { IChannel, IProblemType } from '../Models/channel';

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

  getChannels(){
    return this.http.get<IChannel[]>(`${this.baseUrl}/channels`)
  }

  getProblemTypes(){
    return this.http.get<IProblemType[]>(`${this.baseUrl}/problemTypes`)
  }


  getIncidentHeaders(searchParams:SearchParams){
    let params = this.getHttpParams(searchParams);
    return this.http.get<IHeader[]>(`${this.baseUrl}/search`,{observe:'response',params})
  }

  getHttpParams(params:SearchParams):HttpParams{
    let httpParams = new HttpParams();
    if(params.problemTypeId)
      httpParams = httpParams.append("problemTypeId", params.problemTypeId.toString())

    if(params.sourceId)
      httpParams = httpParams.append("sourceId", params.sourceId.toString())

    if(params.status)
      httpParams = httpParams.append("status", params.status.toString())

    return httpParams;
  }

}
