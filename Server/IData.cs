using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ContractModel;

namespace Server
{
    /// <summary>
    /// 用ServiceContract来标记此接口是WCF的服务契约，可以像WebService一样指定一个Namespace，如果不指定，就是默认的http://tempuri.org
    /// </summary>
    [ServiceContract(Namespace = "WCF.Demo", CallbackContract = typeof(IDataCallback), SessionMode = SessionMode.Allowed)]
    public interface IData
    {
        /// <summary>
        /// 用OperationContract来标记此方法是操作契约
        /// </summary>
        [OperationContract(Name = "SayHello1")]
        string SayHello(string userName);

        [OperationContract(Name = "SayHello2")]
        UserEntity SayHello(UserEntity userEntity);

        /// <summary> 
        /// IsOneWay = true 表明这是一个单向调用，注意返回值是void，因为既然是单向调用，客户端肯定不会等待接收返回值的 
        /// </summary> 
        [OperationContract(IsOneWay = true)]
        void Sleep(); 
    }

    /// <summary> 
    /// 定义服务回调契约，注意它没有契约标识，只是个一般接口 
    /// </summary> 
    public interface IDataCallback
    {
        /// <summary> 
        /// 定义一个回调方法，由于回调不可能要求对方再响应，所以也标识成OneWay的调用，同样不需要有返回值 
        /// </summary> 
        [OperationContract(IsOneWay = true)]
        void SleepCallback(string text); 
    }
}
