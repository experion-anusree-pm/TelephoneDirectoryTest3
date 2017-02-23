import { Routes, RouterModule } from '@angular/router';
import { DirectoryListComponent } from './directory-list.component';
import { ModuleWithProviders } from '@angular/core';
import { AddDirectoryComponent } from './add-directory.component';
import { AddContactComponent } from '../contact/add-contact.component';
import { EditContactComponent } from '../contact/edit-contact.component';
import { ViewContactComponent } from '../contact/view-contact.component';

export const Home_Routes: Routes = [
  { path: 'AddDirectory', component: AddDirectoryComponent },
  { path: 'EditDirectory/:id', component:AddDirectoryComponent},
  { path: 'AddContact/:id', component: AddContactComponent },
  { path: 'EditContact/:id', component: EditContactComponent },
  { path: 'ViewContact/:id', component: ViewContactComponent }
];

export const route: ModuleWithProviders = RouterModule.forRoot(Home_Routes);