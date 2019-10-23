using System;
using System.IO;
using System.Text;

using Services;

namespace Services
{
    public class ClientCredentials: IFileReader
    {
		/// <summary>
		/// A set of mail/pwd credentials 
		/// </summary>
		private Tuple<string, string> _mailCredentials;
		private string _usr;
		private string _pwd;

		public string[] FindFile(string directory_file)
		{
			string[] _path = null;
			try
			{
				var currentDir = AppDomain.CurrentDomain.BaseDirectory;
                //var parentDir = Directory.GetParent(currentDir).Parent.Parent.Parent.Parent.Parent.Parent.FullName;
                var credDir = directory_file;
				_path = Directory.GetFiles(credDir, "secret");
				return _path;
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine(e.Message);
			}

			return _path;
		}

		public void ReadFromFile(TextReader reader)
		{
            string inp = reader.ReadToEnd();
            byte[] left = Convert.FromBase64String(inp.Split(new[] { "," }, StringSplitOptions.None)[0]);
            byte[] right = Convert.FromBase64String(inp.Split(new[] { "," }, StringSplitOptions.None)[1]);
            @_usr = Encoding.UTF8.GetString(left);
			@_pwd = Encoding.UTF8.GetString(right);
		}

		public void SetValue(string directory_file)
		{
			var file = FindFile(directory_file);
			Console.WriteLine (file);
			using (var reader = File.OpenText(file[0]))
			{
				ReadFromFile(reader);
			}
			_mailCredentials = new Tuple<string, string>(_usr, _pwd);
		}

		/// <summary>
		/// Enables other classes/projects to retrieve the credentials
		/// </summary>
		/// <value>Mail Client Credentials</value>
		public Tuple<string, string> GetMailCredentials
		{
			get => _mailCredentials;
		}
    }
}
