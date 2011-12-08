using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace KDATFFS
{
    [Serializable]
    public class ElementCommandException:Exception
    {
     
        private ElementCommand elementCommand;

        /// <summary>
        ///  trigger ElementCommandException's ElementCommand
        /// </summary>
        public ElementCommand ElementCommand
        {
            get { return elementCommand; }
            set { elementCommand = value; }
        }

        /// <summary>
        /// initialize
        /// </summary>
        public ElementCommandException()
        {
        }

        /// <summary>
        /// initialize
        /// </summary>
        /// <param name="message">exception message</param>
        public ElementCommandException(string message):base(message)
        {
        }


        public ElementCommandException(string message, Exception innerException)
            : base(message, innerException)
        { 
        }

        public ElementCommandException(string message, Exception innerException,ElementCommand elementcommand)
            : base(message, innerException)
        {
            this.ElementCommand = elementcommand;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public ElementCommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                this.elementCommand = (ElementCommand)info.GetValue("elementcommand", typeof(ElementCommand));
            }
        }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            if (info != null)
            {
                info.AddValue("elementcommand", this.elementCommand);
            }
        }



    }
}
