using System;
using System.Collections.Generic;
using System.Text;

namespace KDATFFS
{
    /// <summary>
    /// elementcommand type
    /// </summary>
        [Flags]
        public enum ElementCommandTypes
        {
            /// <summary>
            /// 
            /// </summary>
            Clear=1,

            /// <summary>
            /// 
            /// </summary>
            Click=2,

            /// <summary>
            /// 
            /// </summary>
            SendKeys,

            /// <summary>
            /// 
            /// </summary>
            Submit,

            /// <summary>
            /// 
            /// </summary>
            Select,


            GetAttribute,


            GetText,

        }
    
}
