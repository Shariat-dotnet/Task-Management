import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-task-item',
  templateUrl: './task-item.component.html',
  styleUrls: ['./task-item.component.css']
})
export class TaskItemComponent implements OnInit {

  public isEdit: boolean=false;
  @Input() taskId: number = 0;
  @Input() taskName: string = '';
  @Input() taskProgress: number = 0;
  constructor() { }

  ngOnInit(): void {
  }
  editGet() {
    this.isEdit = true;
  }
   delete() {
   alert('deleted')
  }
  editPost() {
    alert('Modified')
    this.isEdit = false;
}
}
