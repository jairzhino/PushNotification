import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root',
})
export class WorkerS {
  constructor(private http:HttpClient) {


  }

  //This key must be in the environment File, not here.
  key = "BOTGKgG4fRUTQL1AWjC6edfI-K_bQGhm55ojisEXt5P10Zqgy4JIRpspW8Z2KRTNdK2tXKEs4dsRCvTBPD51uS0";
  register = null;
  async registerService(){
    if(!('serviceWorker' in navigator)){
      return null;
    }
    console.log('Registering service worker');
    this.register = await navigator.serviceWorker.register('/serviceworker.js',{scope:'/'});
  }

  async registerPushNotification(){
    if(this.register && Notification.permission !== 'denied'){

      console.log("register",Notification.permission);
      console.log("registerJSON",JSON.stringify(Notification));
      const subscriptionSW = await this.register.pushManager.subscribe({
        userVisibleOnly:true,
        applicationServerKey:this.urlBase64ToUint8Array(this.key)
      });
      ///
      /// CALL ENDPOINT FOR SAVE THE NEW SUBSCRIPTION.
      ///
      this.http.post("http://localhost:5000/Notification",subscriptionSW).subscribe(()=>{
        console.log("Sending Subscription")
      })
      console.log('subscription',subscriptionSW);
      console.log(JSON.stringify(subscriptionSW));
    }
  }
  urlBase64ToUint8Array(base64String){
    const padding = '='.repeat((4 - base64String.length % 4) % 4);
    const base64 = (base64String + padding)
      .replace(/-/g, '+')
      .replace(/_/g, '/');

    const rawData = window.atob(base64);
    const outputArray = new Uint8Array(rawData.length);

    for (let i = 0; i < rawData.length; ++i) {
      outputArray[i] = rawData.charCodeAt(i);
    }
    return outputArray;
  }
}
