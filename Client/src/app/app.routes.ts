import { Routes } from '@angular/router';
import { IgnoredIncidentsComponent } from './Components/ignored-incidents/ignored-incidents.component';
import { MasterComponent } from './Components/master/master.component';
import { AdvancedSearchComponent } from './Components/advanced-search/advanced-search.component';
import { SearchComponent } from './Components/search/search.component';
import { LoginComponent } from './Components/login/login.component';

export const routes: Routes = [
  {path:'ignoredIncidents', component:IgnoredIncidentsComponent},
  {path:'master', component:MasterComponent},
  {path:'advancedSearch', component:AdvancedSearchComponent},
  {path:'search', component:SearchComponent},
  {path:'**', component:LoginComponent},
];
