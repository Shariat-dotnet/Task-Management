import { NgModule, Component, OnInit } from '@angular/core';
import { ITaskModel, TaskModel } from '../Models/TaskModel';
import { FormControl,FormGroup} from '@angular/forms';
import { HttpClientService } from '../services/http-client.service';

@Component({
  selector: 'app-new-task',
  templateUrl: './new-task.component.html',
  styleUrls: ['./new-task.component.css']
})
export class NewTaskComponent implements OnInit {
  baseurl = 'https://localhost:7230/api/TasksManagement/';
  taskModel = new FormGroup({
    id: new FormControl(''),
    taskName: new FormControl(''),
    progress: new FormControl('')
  });
  constructor(private client:HttpClientService) { 
    
  }

  ngOnInit(): void {
  }
  CreateTask($event: Event) {
    $event.preventDefault();
  let data = this.taskModel.value as ITaskModel;
//save data
    let task = new TaskModel(data.id, data.taskName, data.progress);
    console.log(task);
  this.client.post(this.baseurl, task);
   }
}
