import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Users } from '../models/users';
import { UserService } from '../shared/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private http: HttpClient, service: UserService) { }

  readonly BaseURI = 'https://localhost:5001/api';

  userDetails;

  users: Users[] = [];

  getUserProfile() {
    return this.http.get(this.BaseURI + '/UserProfile');
  }


  getUsers() {
    this.http
      .get<Users[]>("https://localhost:5001/api/User/getFullUserProfile/")
      .subscribe(result => (this.users = result));
  }

  deleteUser(id, deleteUsername, currentUserName) {
    if (deleteUsername != currentUserName) {

      if (confirm('Are you sure? this operation cannot be undone.')) {
        this.http
          .delete("https://localhost:5001/api/userprofile/" + id)
          .subscribe(result => this.getUsers());
      }
    } else {
      alert('You may not delete your self, please login as a different user to delete this account!');
    }
  }

  getCurrentUser(){
    this.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
        console.log(this.userDetails);
      },
      err => {
        console.log(err);
      }
    )
  }

  ngOnInit() {
    this.getCurrentUser();
    this.getUsers();
  }


}
