using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using Services;

namespace Services
{
    public class LogReader: IFileReader
    {
        private List<string> _log = new List<string>();

        /// <summary>
        /// Finds log file
        /// </summary>
        /// <returns>The log file</returns>
        /// <param name="directory_file">Exact path to file</param>
		public string[] FindFile(string directory_file)
		{
			string[] _path = null;
			try
			{
				var credDir = directory_file;
				_path = Directory.GetFiles(credDir, "*.log");
				return _path;
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine(e.Message);
			}

			return _path;
		}

        /// <summary>
        /// Reads and parses a log file. Disregards obsolete lines(not starting with date)
        /// </summary>
        /// <param name="reader">A TextReader object.</param>
		public void ReadFromFile(TextReader reader)
        {
            List<string> story = new List<string>();
            Regex letterLine = new Regex("(^[A-z])");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("  ") | letterLine.IsMatch(line))
                {
                    continue;
                }
                else
                {
                    if(line.Length > 0)
                    {
                        story.Add(line.Trim());
                    }
                }
            }
            _log = story;
        }

		/// <summary>
		/// Executes the above methods in succession
		/// </summary>
		/// <param name="directory_file">Exact path to file</param>
		public void SetValue(string directory_file)
		{
			var file = FindFile(directory_file);
			using (var reader = new System.IO.StreamReader(file[0]))
			{
				ReadFromFile(reader);
			}
		}

        /// <summary>
        /// Gets the log.
        /// </summary>
        /// <value>Parsed log.</value>
		public List<string> GetLog
		{
			get => _log;
		}
        
    }
}
