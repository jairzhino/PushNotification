using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Notification_Sender.Models;
using WebPush;

namespace Notification_Sender.BusinessLogic
{
    public class NotificationSender
    {
        public async Task<bool> Sender(SubscriptionModel item, string payload, string subject, string privatekey,
            string publickey)
        {
            
            var subscription = new PushSubscription(item.endpoint, item.keys.p256dh, item.keys.auth);
            var vapidDetalis = new VapidDetails(subject, publickey, privatekey);
            
            var webPushClient = new WebPushClient();
            try
            {
                Console.WriteLine($"payload {payload}");
                Console.WriteLine($"data: ${JsonConvert.SerializeObject(item)}");
                await webPushClient.SendNotificationAsync(subscription,payload,vapidDetalis);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"WEB-PUSH SENDMESSAGE : {e.Message}");
                return false;
            }
        }
    }
}