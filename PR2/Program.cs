using System;

namespace PRlab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string multicastIP = "239.5.6.7";
            int port = 5002;

            UDPChat chat = new UDPChat(multicastIP, port);

            chat.StartReceiveLoop();

            Console.WriteLine("Input format: <IP>:<TEXT>");
            Console.WriteLine("IP=0 - MULTICAST");
            //adaugat try, catch 
            while (true)
            {
                var input = Console.ReadLine() ?? "";
                var splitted = input.Split(':');
                var toIP = splitted[0];
                var text = splitted[1];
                
                if (toIP != "0")
                {
                    chat.SendTo(toIP, text);
                }
                else
                {
                    chat.SendGeneral(text);
                }
            }
        }
    }
}