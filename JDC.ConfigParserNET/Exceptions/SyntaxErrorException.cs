namespace JDC.ConfigParser.Exceptions
{
    using System;

    /// <summary>
    /// Class for Exceptions related for the syntax inside the file
    /// </summary>
    public class SyntaxErrorException : Exception
    {
        public SyntaxErrorException()
            : base()
        {
        }

        /// <summary>
        /// Create the exception with description
        /// </summary>
        /// <param name="message">Exception description</param>
        public SyntaxErrorException(String message)
            : base(message)
        {
        }
    }
}
