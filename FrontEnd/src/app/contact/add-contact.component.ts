import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DirectoryServeService } from '../directory-serve.service';
import { Router } from '@angular/router';



@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styles: []
})
export class AddContactComponent {

  //Variable Declaration
  indexvalue: number;
  validContact: Boolean;
  name: String;
  firstName: String;
  phoneNumber: Number;
  lastName: String;
  Address: String;

  //Constructor
  constructor(private route: ActivatedRoute, private directoryserv: DirectoryServeService, private routes: Router) {}

  ngOnInit() {
     this.indexvalue = this.route.snapshot.params['id'];         //Get ID
  }

  //Submit contact
  onSubmit(form: NgForm) {

    this.firstName = form.value.txtFirstName;
    this.lastName = form.value.txtLastName;
    this.phoneNumber = form.value.txtPhoneNumber;
    this.Address = form.value.txtAddress;
    this.directoryserv.AddContact({ firstName: this.firstName, lastName: this.lastName, phoneNumber: this.phoneNumber, address: this.Address, directoryId: this.indexvalue })
      .subscribe(
      data => {
        this.validContact = data;
        if (!(this.validContact)) {
          this.routes.navigate(['/Home']);
        }
        else {
          this.validContact = true;
        }

      },
      error => console.log(error)
      );
  }

}