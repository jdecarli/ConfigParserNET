namespace JDC.ConfigParserNET.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using JDC.ConfigParser;

    [TestClass]
    public class ConfigFileTest
    {
        [TestMethod]
        public void CheckAllPropertiesAreWritableAndReadable()
        {
            var obj = new ConfigFile();

            obj.Section = "Value for Section";
            obj.Key = "Value for Key";
            obj.Value = "Value for Section";

            Assert.IsTrue(!string.IsNullOrEmpty(obj.Section));
            Assert.IsTrue(!string.IsNullOrEmpty(obj.Key));
            Assert.IsTrue(!string.IsNullOrEmpty(obj.Value));
        }
    }
}
