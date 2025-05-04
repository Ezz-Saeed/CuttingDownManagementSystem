import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TabDirective, TabsetComponent, TabsModule } from 'ngx-bootstrap/tabs';
import { IgnoredIncidentsComponent } from "../ignored-incidents/ignored-incidents.component";

@Component({
  selector: 'app-master',
  imports: [TabsModule, IgnoredIncidentsComponent],
  templateUrl: './master.component.html',
  styleUrl: './master.component.css'
})
export class MasterComponent implements OnInit {

  @ViewChild('master', {static:true}) master!:TabsetComponent;
  activeTab?:TabDirective;
  constructor(private activatedRoute:ActivatedRoute){}

  ngOnInit(): void {
    this.activatedRoute.queryParamMap.subscribe(params=>{
      params.get('tab') ?
      this.selectedTab(Number(params.get('tab'))) : this.selectedTab(0);
    })
  }

  selectedTab(id:number){
    this.master.tabs[id].active = true;
  }

  onTabActivated(data:TabDirective){
    this.activeTab = data;
  }

}
