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
    [ServiceContract(Namespace = "WCF.Demo")]
    public interface IData
    {
        /// <summary>
        /// 用OperationContract来标记此方法是操作契约
        /// </summary>
        [OperationContract(Name = "SayHello1")]
        string SayHello(string userName);

        [OperationContract(Name = "SayHello2")]
        UserEntity SayHello(UserEntity userEntity);
    } 
}
