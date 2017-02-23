import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login.component';
import { DirectoryListComponent } from './home/directory-list.component';
import { AddDirectoryComponent } from './home/add-directory.component';
import { Home_Routes } from './home/app-home-routing';

const App_Routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    {path: 'Home', component: HomeComponent},
    {path: 'Home', component: HomeComponent,children:Home_Routes}
];

export const route: ModuleWithProviders = RouterModule.forRoot(App_Routes);




