using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Reflection;

namespace KDATFFS.Provider
{
    public class DataProviderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataProvider"></param>
        /// <returns></returns>
        public IDataProvider MakeDataProvider(string dataProvider)
        {
            Type type = Type.GetType(dataProvider, true);
            IDataProvider iDataProvider = (IDataProvider)Activator.CreateInstance(type);
            return iDataProvider;
            
        }
    }
   
}
