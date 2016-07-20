# ConfigParser .NET
Small assembly to read .ini configuration files

### Summary
Small project to load an .ini file in a list of Section/Key/Values to iterate

You will need **.NET framework 4.5**

### Usage
just compile and add the resulting dll into your project

### Background
A configuration file (.ini) consists of sections, each led by a [section] header, followed by key/value entries separated by a specific string (= or : by default [1]). By default, section names are case sensitive but keys are not. Leading and trailing whitespace is removed from keys and values. Values can be omitted, in which case the key/value delimiter may also be left out. Values can also span multiple lines, as long as they are indented deeper than the first line of the value. Depending on the parser’s mode, blank lines may be treated as parts of multiline values or ignored.

Source: 
https://docs.python.org/3/library/configparser.html#supported-ini-file-structure