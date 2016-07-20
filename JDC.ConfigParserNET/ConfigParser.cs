namespace JDC.ConfigParser
{
    using JDC.ConfigParser.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ConfigParser
    {
        private string ConfigPath { get; set; }

        /// <summary>
        /// List of Section/Key/Values each value
        /// </summary>
        public IList<ConfigFile> SectionKeyValues { get; set; }

        /// <summary>
        /// List of Sections on the file
        /// </summary>
        public IList<string> Sections {
            get {
                var query = from skv in this.SectionKeyValues
                            select skv.Section;

                return query.Distinct().ToList<string>();
            }

            private set
            {
            }
        }

        /// <summary>
        /// Constructor to load the file into memory
        /// </summary>
        /// <param name="configPath">string with the absolute path</param>
        public ConfigParser(string configPath)
        {
            this.ConfigPath = configPath;
            this.SectionKeyValues = new List<ConfigFile>();

            TextReader reader = null;
            string strLine = string.Empty;
            string[] keyPair = null;
            string currentSection = string.Empty;
            string currentKey = string.Empty;

            if (File.Exists(this.ConfigPath))
            {
                try
                {
                    reader = new StreamReader(this.ConfigPath);

                    this.SectionKeyValues = new List<ConfigFile>();

                    strLine = reader.ReadLine();

                    while (strLine != null)
                    {
                        strLine = strLine.ToUpper().Trim();

                        if (strLine.StartsWith("#"))    //commented line
                        {
                            strLine = reader.ReadLine();
                            continue;
                        }                           

                        if (strLine.StartsWith("[") && strLine.EndsWith("]"))
                        {
                            currentSection = strLine.Substring(1, strLine.Length - 2);
                        }
                        else if ((strLine.StartsWith("[") && !strLine.EndsWith("]")) || (!strLine.StartsWith("[") && strLine.EndsWith("]")))
                        {
                            throw new SyntaxErrorException("Error - There's an open braket");
                        }
                        else if (strLine.IndexOf("=") > 0)
                        {
                            keyPair = strLine.Split(new char[] { '=' }, 2);
                            currentKey = keyPair[0].Trim();

                            this.SectionKeyValues.Add(new ConfigFile { Section = currentSection, Key = currentKey, Value = keyPair[1].Trim() });
                        }
                        else if (!string.IsNullOrEmpty(strLine) && !string.IsNullOrEmpty(currentSection) && !string.IsNullOrEmpty(currentKey))
                        {
                            this.SectionKeyValues.Add(new ConfigFile { Section = currentSection, Key = currentKey, Value = strLine.Trim() });
                        }

                        strLine = reader.ReadLine();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("An error has ocurred while reading the file", e);
                }
            }
            else
            {
                throw new FileNotFoundException("Unable to find the configuration file");
            }
        }
    }
}