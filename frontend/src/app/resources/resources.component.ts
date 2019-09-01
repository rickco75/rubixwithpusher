import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Resources } from '../models/resources';


@Component({
  selector: 'app-resources',
  templateUrl: './resources.component.html',
  styleUrls: ['./resources.component.css']
})
export class ResourcesComponent implements OnInit {
  
  
  constructor(private http: HttpClient) { }
  resources: Resources[] = [];
  newResource: Resources = new Resources();
  
  getResources(){
    this.http
      .get<Resources[]>("https://localhost:5001/api/angular/")
      .subscribe(result => (this.resources = result));
      console.log(this.resources);
  }

  addResource() {
    this.http
      .post<Resources>("https://localhost:5001/api/angular/", this.newResource)
      .subscribe(result => this.getResources());
  }

  deleteResource(id) {
    if (confirm('Are you sure? This operation cannot be undone.')){      
      this.http
        .delete("https://localhost:5001/api/angular/" + id)
        .subscribe(result => this.getResources());
    }
  }

  ngOnInit() {
    this.getResources();
  }
  
  
    //  apiData;
  
  //   getApi() {
  //     const url = 'https://localhost:5001/api/angular';
  //     fetch(url)
  //         .then(resp => resp.json())
  //         .then(resp => (this.apiData = resp));
  // }

}
