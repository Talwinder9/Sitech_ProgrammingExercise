using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sitech_ProgrammingExercise
{
    public partial class MainWindow
    {

        // this handler will tell the main thread that we have completed processing, and is ok to add the result to the UI.
        public delegate void CompleteHandler(string[] files);

        // create a method that will scan a directory (including all sub folders)
        // looking for all files that have the .txt or .doc extension
        // the start path is passed into the "startPath" parameter.
        // note the method must not block the main thread and should process the data in the background.
        // the code must call the "done" handler with an array of file names when complete.
        public void Exercise4(string startPath, CompleteHandler done)
        {
            if (!string.IsNullOrEmpty(startPath) && Directory.Exists(startPath))
            {
                Task<string[]> res = Task<string[]>.Factory.StartNew(() => ReadFiles(startPath));
                res.Wait();
                if (res.IsCompleted)
                {
                    done(res.Result);
                }
            }
            else
            {
                Console.WriteLine("{0} unable to locate path ",startPath);
            }
        }

        private string[] ReadFiles(string startPath)
        {
            string[] files;
            files = Directory.GetFiles(startPath, "*.*", SearchOption.AllDirectories)
                    .Where(f => f.EndsWith(".txt") || f.EndsWith(".doc")).ToArray();
            return files;
        }
    }
}
