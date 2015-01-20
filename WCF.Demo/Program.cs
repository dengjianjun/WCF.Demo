using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using ContractModel;

namespace WCF.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义一个实现回调接口的类实例 
            var context = new DataCallbackImp();
            //创建代理的时候变了，要用DuplexChannelFactory，因为IData契约已经标识了有回调，所以必须要用支持双向通讯的ChannelFactory，传入刚才创建的回调实例 
            var proxy = new DuplexChannelFactory<Server.IData>(context, "httpDataService").CreateChannel();

            //调用Sleep 
            proxy.Sleep();
            //调用SayHello方法  
            Console.WriteLine(proxy.SayHello("WCF"));

            //等待按任意键，先不要关连接 
            Console.ReadKey();
            ((IChannel)proxy).Close();
        }

        /// <summary> 
        /// 实现回调接口中的类，图省事写到这里了 
        /// </summary> 
        class DataCallbackImp : Server.IDataCallback
        {
            /// <summary> 
            /// 实现SleepCallback方法 
            /// </summary> 
            public void SleepCallback(string text)
            {
                Console.WriteLine("收到回调了：" + text);
            }
        } 
    }
}
