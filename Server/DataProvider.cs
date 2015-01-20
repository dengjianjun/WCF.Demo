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
    /// Single并发模式 + PerCall实例模式，针对后面的测试要修改这两个值的组合 
    /// </summary> 
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerCall)] 
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

        //定义一个计数器，对每个新生成的服务实例，它都是0，我们通过它来判断是否新实例 
        public int Counter { get; set; }

        /// <summary>
        /// 获取计数器，并自增计数器
        /// </summary>
        /// <returns></returns>
        public int GetCounter()
        {
            return ++Counter;
        } 

        /// <summary> 
        /// 实现Sleep方法，暂时不做任何事情，只是睡眠5秒 
        /// </summary> 
        public void Sleep()
        {
            //先睡5秒
            Thread.Sleep(2000);

            ////用OperationContext.Current来获取指定类型的回调对象 
            //var callback = OperationContext.Current.GetCallbackChannel<IDataCallback>();
            ////回调SleepCallback方法，并传递参数 
            //callback.SleepCallback("睡醒了"); 
        }
    } 
}
