import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IIgnoredIncident } from '../Models/ignoredIncident';
import { IHeader } from '../Models/header';
import { SearchParams } from '../Models/searchParams';
import { IChannel, IProblemType } from '../Models/channel';
import { INetworkElement } from '../Models/networkElement';
import { IIncicentDetails } from '../Models/incidentDetails';
import { FTA } from '../Models/fta';
import { IHierarchyPathType } from '../Models/hierarchyPathType';

@Injectable({
  providedIn: 'root'
})
export class IncidentsService {
  baseUrl = 'http://cuttingdownmanagementsystem.runasp.net/api/incidents'

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

  getChildElements(name:string, type:string){
    return this.http.get<INetworkElement>(`${this.baseUrl}/getChildren`, {params:{name, type}})
  }

  getNetworkHierarchy(){
    return this.http.get<string[]>(`${this.baseUrl}/getHierarchy`)
  }

  getIncidentHeaders(searchParams:SearchParams){
    let params = this.getHttpParams(searchParams);
    return this.http.get<IHeader[]>(`${this.baseUrl}/search`,{observe:'response',params})
  }

  getHierarchyPathTyps(){
    return this.http.get<IHierarchyPathType[]>(`${this.baseUrl}/getHierarchyPathTyps`)
  }

  addCuttingDownToFta(fta:FTA){
    return this.http.post(`${this.baseUrl}/addCuttingDownToFta`, fta)
  }


  login(userName:string,password:string){
    let model = {userName:userName, password:password}
    return this.http.post(`${this.baseUrl}/login`, model)
  }

  getIncidentDetails(id:number){
    return this.http.get<IIncicentDetails>(`${this.baseUrl}/getIncidentDetails/${id}`)
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
