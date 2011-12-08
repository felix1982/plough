using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace KDATFFS
{
    /// <summary>
    /// BrowserCommand Exception Class
    /// </summary>
    [Serializable]
    public class BrowserCommandException:Exception
    {
        private BrowserCommand browserCommand;

        public BrowserCommand BrowserCommand
        {
            get { return browserCommand; }
            set { browserCommand = value; }
        }

        public BrowserCommandException()
        {
        }

        public BrowserCommandException(string message):base(message)
        {
        }


        public BrowserCommandException(string message, Exception innerException)
            : base(message, innerException)
        { 
        }

        public BrowserCommandException(string message, Exception innerException, BrowserCommand browserCommand)
            : base(message, innerException)
        {
            this.BrowserCommand = browserCommand;
        }


        public BrowserCommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                this.browserCommand = (BrowserCommand)info.GetValue("browsercommand", typeof(BrowserCommand));
            }
        }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            if (info != null)
            {
                info.AddValue("browsercommand", this.browserCommand);
            }
        }



    }
}
