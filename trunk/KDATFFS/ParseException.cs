using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace KDATFFS
{
    [Serializable]
    public class ParseException:Exception
    {
        /// <summary>
        /// initialize
        /// </summary>
        public ParseException()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ParseException(string message):base(message)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ParseException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public ParseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
