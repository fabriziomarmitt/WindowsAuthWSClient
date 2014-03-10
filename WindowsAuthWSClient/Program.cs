using System;
using System.Net;

namespace WindowsAuthWSClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Domínio AD:");
            string domain = Console.ReadLine();

            Console.Write("Usuário AD:");
            string user = Console.ReadLine();


            Console.Write("Senha:");
            string pass = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    Console.Write("\b");
                }
            }

            while (key.Key != ConsoleKey.Enter);

            Console.Clear();


            WebService2.Service service = new WebService2.Service();

            NetworkCredential credentials = new NetworkCredential(user, pass, domain);

            service.Credentials = credentials;
            service.PreAuthenticate = true;

            Console.WriteLine(service.HelloWorld());
            Console.ReadKey();



        }
    }
}
