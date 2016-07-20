namespace JDC.ConfigParser
{
    /// <summary>
    /// Class to hold a Value with his Section and Key
    /// 
    /// A configuration file consists of sections, each led by a [section] header, followed by 
    /// key/value entries separated by a specific string (= or : by default [1]). By default, 
    /// section names are case sensitive but keys are not. Leading and trailing whitespace is 
    /// removed from keys and values. Values can be omitted, in which case the key/value delimiter 
    /// may also be left out. Values can also span multiple lines, as long as they are indented 
    /// deeper than the first line of the value. Depending on the parser’s mode, blank lines may 
    /// be treated as parts of multiline values or ignored.
    /// 
    /// https://docs.python.org/3/library/configparser.html#supported-ini-file-structure
    /// </summary>
    public class ConfigFile
    {
        /// <summary>
        /// Section of the Value
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Key of the Value
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Value of the config file
        /// </summary>
        public string Value { get; set; }
    }
}