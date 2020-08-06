import {Component, OnInit} from '@angular/core';
import {WorkerS} from "./Service/workerS";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'AngularNotification';

  constructor(private worker: WorkerS) {
  }
  ngOnInit(): void {
    this.worker.registerService().then(()=>{
      console.log("Service worker registered");
    }).catch(err=>console.error("register",err));
  }

  onNotificationClick(){
    this.worker.registerPushNotification().then(()=>console.log("send Notification"))
      .catch(err=>console.error("notification",err));
  }


}
