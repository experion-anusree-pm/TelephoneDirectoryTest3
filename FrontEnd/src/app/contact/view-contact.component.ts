import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DirectoryServeService } from '../directory-serve.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-contact',
  templateUrl: './view-contact.component.html',
  styles: []
})
export class ViewContactComponent {

  //Variable Declaration
  indexvalue: number;
  firstName: String;
  lastName: String;
  address: String;
  validContact: Boolean;
  phoneNumber: String;

  //Constructor
  constructor(private route: ActivatedRoute, private directoryserv: DirectoryServeService, private routes: Router) { }

  ngOnInit() {
    this.indexvalue = this.route.snapshot.params['id']              //Get ID

    //Submit ID by call service Function
    this.directoryserv.GetContact(this.indexvalue)
      .subscribe(
      contactJson => {
        this.firstName = contactJson.Data.FirstName;          //Get Directory Value
        this.lastName = contactJson.Data.LastName;
        this.phoneNumber = contactJson.Data.PhoneNumber;
        this.address = contactJson.Data.Address;

      },
      error => console.log(error)
      );
  }

}
