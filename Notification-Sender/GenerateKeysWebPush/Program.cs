using System;
using WebPush;

namespace GenerateKeysWebPush
{
    class Program
    {
        static void Main(string[] args)
        {
            var vapidkeys = VapidHelper.GenerateVapidKeys();
            Console.WriteLine($"Public Key : {vapidkeys.PublicKey}");
            Console.WriteLine($"Private key : {vapidkeys.PrivateKey}");

            Console.Read();
        }
    }
}