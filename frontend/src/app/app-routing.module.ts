import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AboutComponent } from './about/about.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './user/login/login.component';
import { ResourcesComponent } from './resources/resources.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { AuthGuard } from './auth/auth.guard';
import { AdminComponent } from './admin/admin.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { ChatComponent } from './chat/chat.component';


const routes: Routes = [
  {
    path: 'about',
    component: AboutComponent
  },
  {
    path: 'home',
    component: HomeComponent,canActivate:[AuthGuard]
  },
  {
    path: 'chat',
    component: ChatComponent,canActivate:[AuthGuard]
  },
  {
    path: 'user',component: UserComponent,
    children: [
      { path: 'registration', component:RegistrationComponent },
      { path: 'login', component:LoginComponent } ,     
      { path: 'admin', component:AdminComponent,canActivate:[AuthGuard],data: {permittedRoles:['ADMIN']} } 
    ]
  },  
  {
    path: 'resources',
    component: ResourcesComponent,canActivate:[AuthGuard]
  },
  {
    path: 'forbidden',
    component: ForbiddenComponent
  },            
  {
    path: '',
    redirectTo: '/user/login',
    pathMatch: 'full'
  }  
];

@NgModule({
  imports: [RouterModule.forRoot(routes), CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
