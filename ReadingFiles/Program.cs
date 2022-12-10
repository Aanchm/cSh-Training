using System;
using System.IO;
using System.Collections;

namespace ReadingFiles
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string targetDirectory = "C:\\repos\\75x_Data_Processing";

            var fileSorter = new FileSort(directoryToSort: targetDirectory); 


            try
            {
                fileSorter.SortFiles();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            
                   
        }
        
    }
}

