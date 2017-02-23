import { Injectable } from '@angular/core';
import { Http, Response, Headers } from "@angular/http";
import 'rxjs/Rx';
import { Observable } from "rxjs/Rx";



@Injectable()
export class DirectoryServeService {

  //constructor
  constructor(private http: Http) {
  }

  //Login validation
  LoginValidate(user: any) {
    const userLogged = JSON.stringify({ username: user.username, password: user.password });
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    return this.http.post('http://localhost:11683/login', userLogged, {
      headers: headers
    })
      .map((data: Response) => data.json());
  }


  //Get All Directory
  getAllDirectory() {
    return this.http.get('http://localhost:11683/api/listDirectory')
      .map((directoryListJson: Response) => directoryListJson.json());
  }

  //Get values to Edit Directory
  EditDirectory(ID: Number) {
    var fullUrl = 'http://localhost:11683//api/EditDirectory/' + ID;
    return this.http.get(fullUrl)
      .map((directoryJson: Response) => directoryJson.json());
  }

  //Submitting directory Values
  DirectorySubmit(directory: any) {
    const directorySave = JSON.stringify({ Name: directory.DirectoryName, Id: directory.Id });
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');

    //For Add Directory
    if (directory.Id > 0) {
      return this.http.post('http://localhost:11683/api/EditDirectory', directorySave, {
        headers: headers
      })
        .map((data: Response) => data.json());
    }

    //For Edit Directory
    else {
      const directorySave = JSON.stringify({ Name: directory.DirectoryName });
      return this.http.post('http://localhost:11683/api/AddDirectory', directorySave, {
        headers: headers
      })
        .map((data: Response) => data.json());
    }
  }


  //Add Contact
  AddContact(contact: any) {
    const ContactSave = JSON.stringify({ FirstName: contact.firstName, LastName: contact.lastName, PhoneNumber: contact.phoneNumber, Address: contact.address, DirectoryId: contact.directoryId });
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    return this.http.post('http://localhost:11683/api/AddContact', ContactSave, {
      headers: headers
    })
      .map((data: Response) => data.json());
  }

  //List Contact
  getAllContact(index: Number) {
    var fullUrl = 'http://localhost:11683/api/ListContact/' + index;
    return this.http.get(fullUrl)
      .map((contactListJson: Response) => contactListJson.json());
  }

  //Get values to Edit Contact
  GetContact(ID: Number) {
    var fullUrl = 'http://localhost:11683//api/ContactDetail/' + ID;
    return this.http.get(fullUrl)
      .map((contactJson: Response) => contactJson.json());
  }

  //Edit Directory
  EditContactSubmit(contact: any) {
    const contactSave = JSON.stringify({ Id: contact.Id, FirstName: contact.firstName, LastName: contact.lastName, PhoneNumber: contact.phoneNumber, Address: contact.address });
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    return this.http.post('http://localhost:11683/api/EditContact', contactSave, {
      headers: headers
    })
      .map((data: Response) => data.json());
  }

  //Search Function
  search(searchKey: String) {
    var fullUrl = 'http://localhost:11683/api/SearchContact/' + searchKey;
    return this.http.get(fullUrl)
      .map((searchListJson: Response) => searchListJson.json());

  }
}
