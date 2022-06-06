using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;


namespace RSI_7
{
   
    public class MyData
    {
        public static void info()
        {
            Console.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
            Console.WriteLine("Jaromir Bączkiewicz, 254591");
            Console.WriteLine(System.Environment.UserName);
            Console.WriteLine(System.Environment.OSVersion);
            Console.WriteLine(System.Environment.Version.ToString());
            Console.WriteLine(ip());
        }

        public static string string_info()
        {
            string info = "";
            info +=DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            info+="  Michalina Janik 254564, Jaromir Bączkiewicz, 254591  ";
            info+=System.Environment.UserName;
            info+="\n   ";
            info+=System.Environment.OSVersion;
            info+="\n   ";
            info+=System.Environment.Version.ToString();
            info+="\n   ";
            info+=ip();
            return info;
        }

        static string ip()
        {
            foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    return ip.ToString();
                }
            }
            return "";
        }
    }
}
