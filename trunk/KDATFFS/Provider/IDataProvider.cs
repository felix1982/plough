using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KDATFFS.Provider
{
     /// <summary>
     /// 
     /// </summary>
     public interface IDataProvider
    {
         /// <summary>
         /// 
         /// </summary>
         /// <param name="dataSource"></param>
         /// <returns></returns>
         Dictionary<string, TestSheet> ParseData(string dataSource);
         
    }
}
