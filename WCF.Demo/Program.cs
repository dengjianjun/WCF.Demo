using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义绑定与服务地址 
            Binding httpBinding = new BasicHttpBinding();
            EndpointAddress httpAddr = new EndpointAddress("http://localhost:8080/wcf");
            //利用ChannelFactory创建一个IData的代理对象，指定binding与address，而不用配置文件中的  
            var proxy = new ChannelFactory<Server.IData>(httpBinding, httpAddr).CreateChannel();
            //调用SayHello方法并关闭连接 
            Console.WriteLine(proxy.SayHello("WCF"));
            ((IChannel)proxy).Close();

            //换TCP绑定试试 
            Binding tcpBinding = new NetTcpBinding();
            EndpointAddress tcpAddr = new EndpointAddress("net.tcp://localhost:8081/wcf");
            var proxy2 = new ChannelFactory<Server.IData>(httpBinding, httpAddr).CreateChannel();
            Console.WriteLine(proxy2.SayHello("WCF"));
            ((IChannel)proxy2).Close();
            Console.ReadKey();
        }
    }
}
