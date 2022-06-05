export interface ITaskModel{
    id: number;  
    taskName: string;  
  progress: number;
  createdByUser: string;
  updatedByUser: string;
  deletedtedByUser: string;
  createDate: Date;
  updateDate: Date;
  deleteDate: Date;
  isDeleted: Boolean;

}
export class TaskModel implements ITaskModel{
       public id: number;
  public taskName: string;
  public progress: number;
   public createdByUser: string;
  public updatedByUser: string;
  public deletedtedByUser: string;
  public createDate: Date;
  public updateDate: Date;
  public deleteDate: Date;
  public isDeleted: Boolean;

constructor(id:number, taskName:string,progress:number) {
  this.id = id;
  this.taskName = taskName;
  this.progress = progress;
  this.createdByUser="";
  this.updatedByUser="";
  this.deletedtedByUser="";
  this.createDate=new Date();
  this.updateDate=new Date();
  this.deleteDate=new Date();
  this.isDeleted=false;
    
}
}