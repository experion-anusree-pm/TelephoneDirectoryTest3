import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { DirectoryServeService } from './directory-serve.service';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
//import { Routes, RouterModule } from '@angular/router';
import { route } from './app.routing';
import { LoginComponent } from './login.component';
import { EditDirectoryComponent } from './home/edit-directory.component';
import { AddDirectoryComponent } from './home/add-directory.component';
import { SearchComponent } from './search.component';
import { DirectoryListComponent } from './home/directory-list.component';
import { AddContactComponent } from './contact/add-contact.component';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    EditDirectoryComponent,
    AddDirectoryComponent,
    SearchComponent,
    DirectoryListComponent,
    AddContactComponent,


  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    route
  ],
  providers: [DirectoryServeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
