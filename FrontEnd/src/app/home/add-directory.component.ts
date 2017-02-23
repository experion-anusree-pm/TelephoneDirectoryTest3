import { Component, OnInit } from '@angular/core';
import { Subscription } from "rxjs/Rx"
import { Router, ActivatedRoute } from '@angular/router';
import { DirectoryServeService } from '../directory-serve.service';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-add-directory',
  templateUrl: './add-directory.component.html',
  styles: []
})
export class AddDirectoryComponent {


  //Variable Declaration
  indexvalue: number;
  directoryName: String;
  validDirectory: Boolean;
  private subscription: Subscription;

  //Constructor
  constructor(private route: ActivatedRoute, private directoryserv: DirectoryServeService, private routes: Router) {

  }

  ngOnInit() {

    //Get ID
    this.subscription = this.route.params.subscribe(
      (param: any) => {
        this.indexvalue = param['id'];
      });

    //Submit ID by call service Function
    if (this.indexvalue > 0) {
      this.directoryserv.EditDirectory(this.indexvalue)
        .subscribe(
        directoryJson => {
          this.directoryName = directoryJson.Data.Name          //Get Directory Value
        },
        error => console.log(error)
        );
    }
  }

  //Submit Form
  onSubmit(form: NgForm) {

    this.directoryName = form.value.txtDirectoryName;
    this.directoryserv.DirectorySubmit({ DirectoryName: this.directoryName, Id: this.indexvalue })
      .subscribe(
      data => {
        this.validDirectory = data;
        if (!(this.validDirectory)) {
          this.routes.navigate(['/Home']);
        }
        else {
          this.validDirectory = true;
        }
      },
      error => console.log(error)
      );
  }
}
