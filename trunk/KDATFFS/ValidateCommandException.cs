using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace KDATFFS
{
    [Serializable]
    public class ValidateCommandException:Exception
    {
        private ValidateCommand validateCommand;

        public ValidateCommand ValidateCommand
        {
            get { return validateCommand; }
            set { validateCommand = value; }
        }

        public ValidateCommandException()
        {
        }

        public ValidateCommandException(string message):base(message)
        {
        }


        public ValidateCommandException(string message, Exception innerException)
            : base(message, innerException)
        { 
        }

        public ValidateCommandException(string message, Exception innerException,ValidateCommand validatecommand)
            : base(message, innerException)
        {
            this.ValidateCommand = validatecommand;
        }


        public ValidateCommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                this.validateCommand = (ValidateCommand)info.GetValue("validatecommand", typeof(ValidateCommand));
            }
        }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            if (info != null)
            {
                info.AddValue("validatecommand", this.validateCommand);
            }
        }



    }
}
