using System;
using System.IO;
using System.Security.Cryptography;

namespace Sitech_ProgrammingExercise
{
    public partial class MainWindow
    {
        // this method will be called several times with paths to 2 files.
        // the method should return true if the file contents match (files are equal)
        // and false if the file contents do not match.
        public bool Exercise2(string filePath1, string filePath2)
        {
            string str1 = string.Empty, str2 = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(filePath1))
                {
                    str1 = File.ReadAllText(filePath1);
                }
                else
                {
                    Console.WriteLine("Can't read from empty path");
                }
                if (!string.IsNullOrEmpty(filePath2))
                {
                    str2 = File.ReadAllText(filePath2);
                }
                else
                {
                    Console.WriteLine("Can't read from an empty path");
                }

            }
            catch( Exception ex)
            {
                Console.WriteLine($"unable to read content from files {ex.Message}");
            }

            return string.Equals(str1, str2);
        }
    }
}
