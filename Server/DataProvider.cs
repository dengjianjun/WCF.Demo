using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractModel;

namespace Server
{
    /// <summary>
    /// 实现IData接口，此处不需要写契约标记
    /// </summary>
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
    } 
}
