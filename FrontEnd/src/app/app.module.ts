import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { DirectoryServeService } from './directory-serve.service';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { route } from './app.routing';
import { LoginComponent } from './login.component';
import { AddDirectoryComponent } from './home/add-directory.component';
import { DirectoryListComponent } from './home/directory-list.component';
import { AddContactComponent } from './contact/add-contact.component';
import { EditContactComponent } from './contact/edit-contact.component';
import { ViewContactComponent } from './contact/view-contact.component';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    AddDirectoryComponent,
    DirectoryListComponent,
    AddContactComponent,
    EditContactComponent,
    ViewContactComponent,


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
