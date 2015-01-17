﻿using System;
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
            //定义一个http方式的代理，配置使用httpDataService中的定义 
            var httpProxy = new ChannelFactory<Server.IData>("httpDataService").CreateChannel();
            Console.WriteLine(httpProxy.SayHello("WCF"));
            ((IChannel)httpProxy).Close();

            //定义一个tcp方式的代理，配置使用tcpDataService中的定义 
            var tcpProxy = new ChannelFactory<Server.IData>("tcpDataService").CreateChannel();
            Console.WriteLine(tcpProxy.SayHello("WCF"));
            ((IChannel)tcpProxy).Close();
            Console.ReadKey();
        }
    }
}
