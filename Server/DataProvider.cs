using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ContractModel;

namespace Server
{
    /// <summary> 
    /// 用ServiceBehavior为契约实现类标定行为属性，此处指定并发模型为ConcurrencyMode.Multiple，即并发访问 
    /// </summary> 
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)] 
    public class DataProvider : IData
    {
        public string SayHello(string userName)
        {
            return string.Format("Hello {0}.", userName);
        }

        public UserEntity SayHello(UserEntity userEntity)
        {
            userEntity.Age++;
            return userEntity;
        }

        /// <summary> 
        /// 实现Sleep方法，暂时不做任何事情，只是睡眠5秒 
        /// </summary> 
        public void Sleep()
        {
            //先睡5秒
            Thread.Sleep(5000);

            //用OperationContext.Current来获取指定类型的回调对象 
            var callback = OperationContext.Current.GetCallbackChannel<IDataCallback>();
            //回调SleepCallback方法，并传递参数 
            callback.SleepCallback("睡醒了"); 
        }
    } 
}
