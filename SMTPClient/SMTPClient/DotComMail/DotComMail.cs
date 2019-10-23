using System;
using System.Net.Mail;

namespace SMTPMailConnections
{
	public class OutlookDotComMail
	{
		string _sender = "";
		string _pwd = "";
		public OutlookDotComMail(string sender, string pwd)
		{
			_sender = sender;
			_pwd = pwd;
		}

		public void SendMail(string recipient, string subject, string message)
		{
			SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

			client.Port = 587;
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			client.UseDefaultCredentials = false;
			System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(_sender, _pwd);
			client.EnableSsl = true;
			client.Credentials = credentials;

			try
			{
				var mail = new MailMessage(_sender.Trim(), recipient.Trim());
				mail.Subject = subject;
				mail.Body = message;
                mail.IsBodyHtml = true;
				client.Send(mail);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw e;
			}
		}
	}
}
