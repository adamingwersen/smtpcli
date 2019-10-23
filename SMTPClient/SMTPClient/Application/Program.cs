using System;

using SMTPMailConnections;
using Services;
using HTMLMake;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // This solution takes 3 command-line arguments: receiver email, directory to your email-secret, path to a python-generated log-file
			if (args.Length < 2) {
				Console.WriteLine ("Usage: {reciever e-mail} {directory to secret} {path to log-file}");
				return;
			} else if (args.Length == 2) {
				// Fetch email credentials
				ClientCredentials ccr = new Services.ClientCredentials ();
				ccr.SetValue (args [1]);
				var credentials = ccr.GetMailCredentials;
				Console.WriteLine (credentials);
				// Setup mail client with credentials
				var cli = new OutlookDotComMail (credentials.Item1, credentials.Item2);
				cli.SendMail (args [0], "Jenkins is working", "Hello!");
			} else if (args.Length == 3) {
				// Fetch email credentials
				ClientCredentials ccr = new Services.ClientCredentials ();
				ccr.SetValue (args [1]);
				var credentials = ccr.GetMailCredentials;
				Console.WriteLine (credentials);
				// Setup mail client with credentials
				var cli = new OutlookDotComMail (credentials.Item1, credentials.Item2);

				// Instantiate log-reader in provided directory
				var logReader = new Services.LogReader ();
				logReader.SetValue (args [2]);
				var log = logReader.GetLog;

				// Create HTML table from provided log-file
				var html = new HTMLMake.HTMLTable ();
				var tbl = html.CreateHTMLTable (log);

				// Use SMTP client to send the table with a subject to provided receiver
				cli.SendMail (args [0], "Error Log", tbl);
			} else {
				Console.WriteLine ("Input parameters not understood");
			}
        }
    }
}
