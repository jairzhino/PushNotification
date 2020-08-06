using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notification_Sender.BusinessLogic;
using Notification_Sender.Models;

namespace Notification_Sender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        //with this Controller, get the subscription and save in the database as you want.
        [HttpPost]
        public async Task<bool> Post(SubscriptionModel subscription)
        {
            //The keys must be in the appsettings.json, for this example i use here in this controller
            var privateKey = "KgAcoZjoSUc4gLXgNl4HxoHa1LXZGUT8JLnNfKKCg7E";
            var publicKey = "BOTGKgG4fRUTQL1AWjC6edfI-K_bQGhm55ojisEXt5P10Zqgy4JIRpspW8Z2KRTNdK2tXKEs4dsRCvTBPD51uS0";
            
            
            
            //Here we create a NotificationSender for send the notification at every subscription in the database
            //this depend of the business logic.
            var sender = new NotificationSender();
            var payload = new {title = "Message Title", payload = "Content of Message"};
            var result = await sender.Sender(subscription, 
                Newtonsoft.Json.JsonConvert.SerializeObject(payload), 
                "mailto:MyEmail@gmail.com", 
                privateKey, 
                publicKey);
            return result;
        }
    }
}