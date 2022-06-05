import { Component } from '@angular/core';
import { ITaskModel } from './Models/TaskModel';
import {TaskHubService} from './services/task-hub.service'
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TaskManagement-Client';
  public taskList: ITaskModel[];
/**
 *
 */
constructor(private hubService:TaskHubService) {
  this.taskList = hubService.getTaskList();
  console.log(this.taskList);
  
}
  
}

