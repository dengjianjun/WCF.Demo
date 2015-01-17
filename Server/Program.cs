using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义一个ServiceHost，注意参数中要使用契约实现类而不是接口
            using (ServiceHost host = new ServiceHost(typeof(Server.DataProvider)))
            {
                host.Open();
                Console.WriteLine("Service Running ...");
                Console.ReadKey();
                host.Close();
            } 
        }
    }
}
