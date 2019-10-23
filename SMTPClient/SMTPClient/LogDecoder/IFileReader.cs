using System;
using System.IO;

namespace Services
{
    public interface IFileReader
    {
		/// <summary>
		/// Identify path to token file. Method to be used as submethod - therefore private scope.
		/// </summary>
		string[] FindFile(string directory_file);

		/// <summary>
		/// Read relevant content from file
		/// </summary>
		/// <param name="reader">TextReader Objecet.</param>
		void ReadFromFile(TextReader reader);

		/// <summary>
		/// Makes the value accessible
		/// </summary>
		void SetValue(string directory_file);
	}
}
