import { Component } from '@angular/core';
import { IncidentsService } from '../../Services/incidents.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  errorMessage?:string | null;
  name!:string
  pass!:string
  constructor(private incidentsService:IncidentsService, private router:Router){}

  login(){
    this.incidentsService.login(this.name, this.pass).subscribe({
      next:res=>{
        this.router.navigate(['/master', {tab:0}])
        this.errorMessage = null
      },
      error:err=>{
        this.errorMessage = err.error.message;
      }
    })
  }

}
