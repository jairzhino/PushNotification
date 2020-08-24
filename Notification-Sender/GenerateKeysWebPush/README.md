This is a Console project for generate the keys private and public
that are necessary for the communication between server and client.

in this code we can generate a publicKey and privateKey
public Key is for the client-project Angular, React, etc.
Private Key is for the Server-Project
```c#
        static void Main(string[] args)
        {
            var vapidkeys = VapidHelper.GenerateVapidKeys();
            Console.WriteLine($"Public Key : {vapidkeys.PublicKey}");
            Console.WriteLine($"Private key : {vapidkeys.PrivateKey}");

            Console.Read();
        }
```