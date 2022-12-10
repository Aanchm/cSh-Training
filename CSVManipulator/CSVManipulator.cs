using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    public class CSVManipulator
    {
        public string[] headers;   
        public List<double[]> Data { get; set; } //Experiment with dynamics and Expando

        public void ReadCSV(CSVProperties csvProperties)
        {
            string[] CSVLines = File.ReadAllLines(csvProperties.Filename);

            /*foreach (string dataRow in CSVLines)
            {
                if (string.IsNullOrEmpty(dataRow))
                {
                    CSVLines.Remove(dataRow);
                } 
            }
            */

            for (int i=csvProperties.RowsToIgnore+1; i<CSVLines.Length; i++)
            {
                string[] columnData = CSVLines[i].Split(csvProperties.Separator);
                double[] rowToAppend = new double[columnData.Length];

                for (int j = 0; j<columnData.Length; j++)
                {
                    double doubledData;
                    if (double.TryParse(columnData[j], out doubledData))
                        rowToAppend[j] = doubledData;
                    else
                        rowToAppend[j] = 0;
                }
                Data.Add(rowToAppend);
            }

            if (csvProperties.HasHeader)
                headers = CSVLines[csvProperties.RowsToIgnore].Split(csvProperties.Separator);
        }


 
        public void RowShuffleCSV(int NumberToShuffle)
        {
            Random random = new Random();
            for (int q = 0; q < NumberToShuffle; q++)
            {
                int i = random.Next(0, Data.Count - 1);
                var TempStore = Data[i];
                int v = random.Next(0, Data.Count - 1);
                Data[i] = Data[v];
                Data[v] = TempStore;
            }
        }

        public void WriteCSV(CSVProperties csvProperties)
        {
            List<string> toWrite = new List<string>();
            string headersToAdd = String.Join(csvProperties.Separator, headers);
            toWrite.Add(headersToAdd);

            for (int i = 0; i<Data.Count; i++)
            {
                string dataToAdd = String.Join(csvProperties.Separator, Data[i]);
                toWrite.Add(dataToAdd);

            }
            File.WriteAllLines(csvProperties.FilenameToWrite, toWrite.ToArray());
        }
        
        //TODO make csv properties objects
        public CSVManipulator(CSVProperties csvProperties)
        {
            Data = new List<double[]>();
            ReadCSV(csvProperties);
        }

    }
   
}

