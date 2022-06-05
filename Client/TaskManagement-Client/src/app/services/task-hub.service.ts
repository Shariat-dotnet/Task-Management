import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {ITaskModel,TaskModel} from '../Models/TaskModel';
import { HttpClientService } from './http-client.service';
@Injectable({
  providedIn: 'root'
})
export class TaskHubService {

  constructor(private client:HttpClient) { }


   getTaskList():ITaskModel[] {
     let data = this.client.get("https://localhost:7230/api/TasksManagement/");
     alert(JSON.stringify( data))
     return [];
  }
}
