import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DirectoryServeService } from './directory-serve.service';
import { route } from './app.routing';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  //Variable Declaration
  UserName: String;
  password: String;
  validUser: Boolean=false;
 
  //Constructor
  constructor(private directoryserv: DirectoryServeService, private routes: Router) {
  }


  //Submit method
  onSubmit(form: NgForm) {

    this.UserName = form.value.txtUserName;
    this.password = form.value.txtPassword;

    this.directoryserv.LoginValidate({ username: this.UserName, password: this.password }).subscribe(
      data => {
        this.validUser = data.Data.IsValid;
        
        //Check user is valid
        if (this.validUser) {
          localStorage.setItem('uservalid',"valid");
          this.routes.navigate(['/Home']);
        }
        else {
        this.validUser=true ;
        }
        console.log(this.validUser);
      },
      error => console.log(error)
    );



  }

}
