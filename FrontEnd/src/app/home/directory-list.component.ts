import { Component, OnInit } from '@angular/core';
import { DirectoryServeService } from '../directory-serve.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-directory-list',
  templateUrl: './directory-list.component.html',
  styles: []
})
export class DirectoryListComponent implements OnInit {

  //variable declaration
  directoryList: any[] = [];
  contacts: Boolean = false;
  directoryId: Number;
  ContactList: any[] = [];
  id: Number;

  //Constructor
  constructor(private directoryserv: DirectoryServeService, private router: Router) {
  }

  ngOnInit() {

    //Get All Directory Details
    this.directoryserv.getAllDirectory()
      .subscribe(
      directoryListJson => {
        const directoryArray = [];

        for (let Data in directoryListJson) {
          directoryArray.push(directoryListJson[Data]);
        }
        this.directoryList = directoryArray[0];

      });
  }
  //Edit Directory
  editDirectory(directoryId: Number) {
    this.router.navigate(['EditDirectory', directoryId]);
  }
  //Display Contact Details
  ContactDisplay(directoryId) {
    this.directoryId = directoryId;
    if (this.contacts) {
      this.contacts = false
    }
    else {
      this.id = directoryId;
      this.contacts = true;
      //Function for contacts
      this.directoryserv.getAllContact(this.directoryId).subscribe(
        contactListJson => {
          const ContactArray = [];
          for (let Data in contactListJson) {
            ContactArray.push(contactListJson[Data]);
          }
          this.ContactList = ContactArray[0]
          console.log(this.ContactList);

        });
    }

  }

}


