import { Routes } from '@angular/router';
import { IgnoredIncidentsComponent } from './Components/ignored-incidents/ignored-incidents.component';
import { MasterComponent } from './Components/master/master.component';

export const routes: Routes = [
  {path:'ignoredIncidents', component:IgnoredIncidentsComponent},
  {path:'master', component:MasterComponent},
];
