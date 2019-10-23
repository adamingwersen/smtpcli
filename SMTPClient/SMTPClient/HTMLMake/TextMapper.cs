using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HTMLMake
{
    public class TextMapper
    {
        public Table LogToHtmlTable(string textElement)
        {
            // Instantiate table object
            Table tbl = new Table();

            // Set date
            tbl.date = textElement.Substring(0, 19).Trim();

            // Set log level
            Regex regx_level = new Regex(@"(\s-\s([A-Z]*)\s-\s)");
            tbl.level = regx_level.Match(textElement).ToString().Replace(" - ", "").Trim();

            // Set log status
            if (tbl.level.Contains("WARNING")
                | tbl.level.Contains("ERROR"))
            {
                tbl.status = "Failed";
            }
            else
            {
                tbl.status = "Success";
            }

            // Splitting strings
            Regex regx_substr = new Regex(@"(?<=\<).+?(?=\>)");
            var substr = regx_substr.Match(textElement).ToString();

            // Set subprocess - the actual script
            Regex regx_module = new Regex(@"((?<=module).[']\w+.)");
            tbl.module = regx_module.Match(substr).ToString().Replace("'", "").Trim();

            // Set error message
            Regex regx_msg = new Regex(@"((?<=Message:).*)");
            tbl.message = regx_msg.Match(textElement).ToString().Trim();

            // Set process
            Regex regx_strip = new Regex(@"((?=\/home/\w).*(\'>))");
            Regex regx_process = new Regex(@"((\/[^/]*\w[^/]*){4})");
            var strip = regx_strip.Match(textElement).ToString();
            tbl.process = regx_process.Match(strip).ToString().Trim();

            return (tbl);
        }
    }
}
