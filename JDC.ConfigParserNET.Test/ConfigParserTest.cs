namespace JDC.ConfigParserNET.Test
{
    using ConfigParser;
    using JDC.ConfigParser.Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;
    using System.Linq;

    [TestClass]
    public class ConfigParserTest
    {
        //http://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx/

        [TestMethod]
        public void PassingEmpty_FileNotFoundException()
        {
            var isFileNotFoundException = false;

            try
            {
                var result = new ConfigParser(string.Empty);
            }
            catch (FileNotFoundException)
            {
                isFileNotFoundException = true;
            }
            finally
            {
                Assert.IsTrue(isFileNotFoundException);   
            }
        }

        [TestClass]
        public class FileOK
        {
            private string fileok = string.Format(@"{0}\TestData\File_ok.ini", Directory.GetCurrentDirectory());

            public ConfigParser Parser { get; set; }

            public FileOK()
            {
                this.Parser = new ConfigParser(fileok);
            }

            [TestMethod]
            public void LoadingFile()
            {
                var result = new ConfigParser(fileok);

                Assert.IsNotNull(result);
            }

            [TestMethod]
            public void CountingSections()
            {
                var sections = this.Parser.Sections.Count;

                Assert.AreEqual(2, sections, 0, "The amount of sections is wrong");
            }

            [TestMethod]
            public void CountingKeys()
            {
                var query = from res in this.Parser.SectionKeyValues select res.Key;
                var keyscount = query.Distinct().ToList<string>().Count;

                Assert.AreEqual(2, keyscount, 0, "The amount of keys is wrong");            
            }

            [TestMethod]
            public void CountingValues()
            {
                var values = this.Parser.SectionKeyValues.Count;

                Assert.AreEqual(4, values, 0, "The amount of values is wrong");
            }

            [TestMethod]
            public void FileOk_CommentedValue()
            {
                var commentedValue = this.Parser.SectionKeyValues.FirstOrDefault(v => v.Value == "value2c");

                Assert.IsNull(commentedValue);
            }
        
        }

        [TestMethod]        
        public void FileBadFormat_Fails() 
        {
            var fileBadFormat = string.Format(@"{0}\TestData\File_badformat.ini", Directory.GetCurrentDirectory());

            try
            {
                var result = new ConfigParser(fileBadFormat);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.InnerException.GetType(), typeof(SyntaxErrorException));
            }
            
        }
    }
}
