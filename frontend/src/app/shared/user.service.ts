import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder,private http:HttpClient) { }

  readonly BaseURI = 'https://localhost:5001/api';

  formModel = this.fb.group({
    UserName: ['',Validators.required],
    Email: ['',Validators.email],
    FullName: [''],
    PhoneNumber: [''],
    Avatar: [''],
    Passwords: this.fb.group({
      Password: ['',[Validators.required,Validators.minLength(4)]],
      ConfirmPassword: ['',Validators.required]
    },{validator: this.comparePasswords})
  });

  comparePasswords(fb:FormGroup){
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    //passwordMismatch
    //confirmPswrdCtrl.errors={required: true}
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors){
      if (fb.get('Password').value!=confirmPswrdCtrl.value)
        confirmPswrdCtrl.setErrors({passwordMismatch:true });
      else
        confirmPswrdCtrl.setErrors(null);      
    }
  }

  register(){
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password,
      PhoneNumber: this.formModel.value.PhoneNumber,
      Avatar: this.formModel.value.Avatar
    };
    
    return this.http.post(this.BaseURI+'/ApplicationUser/Register',body);
  }

  login(formData){
    return this.http.post(this.BaseURI+'/ApplicationUser/Login',formData);
  }

  getUserProfile(){
    //var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' +localStorage.getItem('token')});
    // return this.http.get(this.BaseURI+'/UserProfile',{headers : tokenHeader});
    return this.http.get(this.BaseURI+'/UserProfile');
  }

  roleMatch(allowedRoles): boolean {
    var isMatch = false;
    var payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
    var userRole = payLoad.role;
    allowedRoles.forEach(element => {
      if (userRole == element){
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }
}
