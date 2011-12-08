using System;
using System.Collections.Generic;
using System.Text;

namespace KDATFFS
{
    [Flags]
    public enum FindMethodTypes
    {
        /// <summary>
        /// 
        /// </summary>
        None=0,

        /// <summary>
        /// 
        /// </summary>
        Id = 1,
        /// <summary>
        /// 
        /// </summary>
        Name = 2,

        /// <summary>
        /// 
        /// </summary>
        Xpath = 4,
        /// <summary>
        /// 
        /// </summary>
        ClassName=8,

        /// <summary>
        /// 
        /// </summary>
        CssSelector=16,

        /// <summary>
        /// 
        /// </summary>
        LinkText=32,

        /// <summary>
        /// 
        /// </summary>
        PartiaLinkText=64,

        /// <summary>
        /// 
        /// </summary>
        TagName=128,

    }
}
