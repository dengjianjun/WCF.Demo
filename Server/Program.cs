using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义两个基地址，一个用于http，一个用于tcp 
            Uri httpAddress = new Uri("http://localhost:8080/wcf");
            Uri tcpAddress = new Uri("net.tcp://localhost:8081/wcf");
            //服务类型，注意同样是实现类的而不是契约接口的 
            Type serviceType = typeof(Server.DataProvider);

            //定义一个ServiceHost，与之前相比参数变了 
            using (ServiceHost host = new ServiceHost(serviceType, new Uri[] { httpAddress, tcpAddress }))
            {
                //定义一个basicHttpBinding，地址为空 
                Binding basicHttpBinding = new BasicHttpBinding();
                string address = "";
                //用上面定义的binding和address，创建endpoint 
                host.AddServiceEndpoint(typeof(Server.IData), basicHttpBinding, address);

                //再来一个netTcpBinding 
                Binding netTcpBinding = new NetTcpBinding();
                address = "";
                host.AddServiceEndpoint(typeof(Server.IData), netTcpBinding, address);

                //开始服务 
                host.Open();
                Console.WriteLine("Service Running ...");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
