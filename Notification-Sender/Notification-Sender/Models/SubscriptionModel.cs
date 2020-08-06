namespace Notification_Sender.Models
{
    public class SubscriptionModel
    {
        public string endpoint { get; set; }
        public string expirationTime { get; set; }
        public SubscriptionDetailModel keys { get; set; }
    }
}