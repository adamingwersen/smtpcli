using System;
using System.Collections.Generic;

namespace HTMLMake
{
    public class HTMLTable
    {
        /// <summary>
        /// Instantiate TextMapper object
        /// </summary>
        TextMapper txtmp = new TextMapper();

        /// <summary>
        /// Sets a style to be used with HTML Table
        /// </summary>
        /// <returns>A styled table</returns>
        /// <param name="table">A string body html</param>
        public string TableStyle(string table)
        {
            string styledTable = "<!DOCTYPE html" +
                "<html>" +
                "<head>" +
                "<style>" +
                "table{font-family: arial, sans-serif;border-collapse:collapse;width:100%;}" +
                "td, th{border: 1px solid #dddddd;text-align: left; padding: 8px;}" +
                "tr:nth-child(even) {background-color: #dddddd;}" +
                "</style></head><body>" + table + "</body></html>";
            return (styledTable);
            
        }

        /// <summary>
        /// Creates the HTML Table.
        /// </summary>
        /// <returns>The HTMLT able.</returns>
        public string CreateHTMLTable(List<string> log)
        {
            string head = "<table>";
            string tail = "</table>";
            string body = "";

            string rowHeader = "<tr>" +
                "<th><strong>Date</strong></th>" +
                "<th><strong>Process</strong></th>" +
                "<th><strong>Module</strong></th>" +
                "<th><strong>Level</strong></th>" +
                "<th><strong>Message</strong></th>" +
                "<th><strong>Status</strong></th></tr>";
            
            foreach (var elem in log)
            {
                Table tbl = txtmp.LogToHtmlTable(elem);
                string srow = "<tr>";
                string erow = "</tr>";
                string ftbl = srow +
                    CreateHTMLTableRow(tbl.date) +
                    CreateHTMLTableRow(tbl.process) +
                    CreateHTMLTableRow(tbl.module) +
                    CreateHTMLTableRow(tbl.level) +
                    CreateHTMLTableRow(tbl.message) +
                    CreateHTMLTableRow(tbl.status) +
                    erow;
                body += ftbl;
            }
            string complete = head + rowHeader + body + tail;
            string styled = TableStyle(complete);
            return (styled);
        }

        /// <summary>
        /// Utility method for generating a HTML table row/column
        /// </summary>
        /// <returns>The HTMLT able row.</returns>
        /// <param name="input">A string containing the necessary information from the Table object</param>
        private string CreateHTMLTableRow(string input)
        {
            string output = "";
            if(input == "Failed")
            {
                output = @"<th><font color=""#ff3200"">" + input + @"</font></th>";  
            }
            else if(input == "Success")
            {
                output = @"<th><font color=""#008000"">" + input + @"</font></th>";
            }
            else
            {
				output = @"<th>" + input + @"</th>";
			}
            return (output); 
        }
    }

    /// <summary>
    /// HTML Header.
    /// </summary>
    public class HTMLHeader
    {
        public string CreateHTMLHeader(string reciever, string frmwk)
        {
            string recv = reciever.Split(new[] { "@" }, StringSplitOptions.None)[0];
            string htmlHeader = "Hi,<strong>" + recv + "</strong><br />" +
                "Below are the diagnosticts for <strong>" + frmwk + "</strong><br />";
            return (htmlHeader);
        }
    }
}
