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
            //客户端访问有多种方式，此处只显示一种
            //利用ChannelFactory的CreateChannel方法创建一个IData的代理对象，其中参数“DataService”就是刚才在App.config中定义的endpoint的名称
            var proxy = new ChannelFactory<Server.IData>("DataService").CreateChannel();
            //调用SayHello方法
            Console.WriteLine(proxy.SayHello("WCF"));
            //用完后一定要关闭，因为服务端有最大连接数，不关闭会在一定时间内一直占着有效连接
            ((IChannel)proxy).Close(); 
            Console.ReadKey();
        }
    }
}
