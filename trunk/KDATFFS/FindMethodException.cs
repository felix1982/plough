using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Globalization;

namespace KDATFFS
{
    [Serializable]
    public class FindMethodException:Exception
    {

        private FindMethod findmethod;

        public FindMethod FindMethod
        {
            get { return this.findmethod; }
            set { this.findmethod = value; }
        }


        /// <summary>
        /// Creates a new instace of the <see cref="FindMethodException"/> class
        /// </summary>
        public FindMethodException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FindMethodException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public FindMethodException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FindMethodException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public FindMethodException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public FindMethodException(string message, Exception innerException,FindMethod findmethod)
            : base(message, innerException)
        {

        }


        /// <summary>
        /// Initializes a new instance of the <see cref="FindMethodException"/> class.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <param name="findMethodName">Name of the find method.</param>
        /// <param name="findMethodArgs">The find method args.</param>
        public FindMethodException(string findMethodName, string findMethodArgs)
            : base(string.Format(CultureInfo.InvariantCulture, "使用方法{0},参数为{1},无法找到元素",  findMethodName, findMethodArgs))
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FindMethodException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0). </exception>
        /// <exception cref="T:System.ArgumentNullException">The info parameter is null. </exception>
        protected FindMethodException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
