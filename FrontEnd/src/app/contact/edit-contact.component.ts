import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DirectoryServeService } from '../directory-serve.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styles: []
})
export class EditContactComponent implements OnInit {

 //Variable Declaration
  indexvalue: number;
  firstName: String;
  lastName:String;
  address:String;
  validContact:Boolean;
  phoneNumber:String;

  //Constructor
  constructor(private route: ActivatedRoute, private directoryserv: DirectoryServeService, private routes: Router) {}

ngOnInit() {
  
    this.indexvalue = this.route.snapshot.params['id']              //Get ID

    //Submit ID by call service Function
    this.directoryserv.GetContact(this.indexvalue)
      .subscribe(
      contactJson => {
        this.firstName = contactJson.Data.FirstName;          //Get Directory Value
        this.lastName=contactJson.Data.LastName;
        this.phoneNumber=contactJson.Data.PhoneNumber;
        this.address=contactJson.Data.Address;

      },
      error => console.log(error)
      );
  }
  //Submit Form
  onSubmit(form: NgForm) {

   this.firstName = form.value.txtFirstName;
    this.lastName = form.value.txtLastName;
    this.phoneNumber = form.value.txtPhoneNumber;
    this.address = form.value.txtAddress;
    this.directoryserv.EditContactSubmit({ firstName: this.firstName, lastName: this.lastName, phoneNumber: this.phoneNumber, address: this.address, Id: this.indexvalue  })
    .subscribe(
        data=> { 
          console.log(data);
          this.validContact=data;
          if( !(this.validContact))
          {
             this.routes.navigate(['/Home']);
          }
          else
          {
              this.validContact=true;
          }
          
        },
        error => console.log(error)
      );

}
}
