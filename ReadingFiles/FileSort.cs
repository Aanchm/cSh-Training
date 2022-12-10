using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadingFiles
{
    public class FileSort
    {
        /// <summary>
        /// Initialises pointing at the current directory/
        /// </summary>
        public FileSort() : this(directoryToSort: Directory.GetCurrentDirectory())
        {
        }

        /// <summary>
        /// Initialises with the specified directory.
        /// </summary>
        /// <param name="directoryToSort">The directory operations will operate on.</param>
        public FileSort(string directoryToSort)
        {
            this.directoryToSort = directoryToSort;
        }

        private static DateTime thresholdDateTime = DateTime.Now.AddMonths(-1);
        private string directoryToSort;

        public DateTime ThresholdDateTime
        {
            get { return thresholdDateTime; }
            set { thresholdDateTime = value; }
        }

        public void SortFiles() 
        {
            LoopThroughDirectory();
        }

        private void LoopThroughDirectory()
        {
            string[] fileEntries = Directory.GetFiles(directoryToSort);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName, ThresholdDateTime);
            }
        }

        private static void ProcessFile(string path, DateTime thresholdDateTime)
        {
            DateTime dateModified = System.IO.File.GetCreationTime(path);
            var dir = Path.GetDirectoryName(path);

            if (dateModified < thresholdDateTime)
            {
                string directoryPath = $"{dir}\\{dateModified.ToString("yyyy_MM")}";

                {
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                }

                string newPath = $"{directoryPath}\\{Path.GetFileName(path)}";
                File.Move(path, newPath);
            }

        }
    }
}
