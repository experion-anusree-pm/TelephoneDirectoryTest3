import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DirectoryServeService } from '../directory-serve.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  //Variables
  searchKey: string = "";
  keyPress: Boolean = false;
  searchList: any[] = [];
  valid: String;

  constructor(private routes: Router, private directoryserv: DirectoryServeService) {
    //Check whether user logged
    this.valid = localStorage.getItem("uservalid")
    if (this.valid != "valid") {
      alert("You Should Login First");
      this.routes.navigate(['login']);
    }
  }


  //Function for search on each key up
  onKey(event: any) {
    this.keyPress = true;
    this.searchKey = event.target.value;

    //Check whether the search text are deleted
    if (this.searchKey.length == 0) {
      this.keyPress = false;
    }
    //Invoke the method in service
    this.directoryserv.search(this.searchKey)
      .subscribe(
      searchListJson => {
        const searchArray = [];

        for (let Data in searchListJson) {
          searchArray.push(searchListJson[Data]);
        }
        this.searchList = searchArray[0]
        console.log(this.searchList);
      });
  }

  ngOnInit() {
  }
  //For LogOut
  logOut() {
    localStorage.clear();
    this.routes.navigate(['login']);
  }

}
