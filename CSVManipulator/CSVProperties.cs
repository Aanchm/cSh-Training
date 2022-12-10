using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    public class CSVProperties
    {
        public int RowsToIgnore { get; init; }
        public string Separator { get; init; }
        public bool HasHeader { get; init; }

        public string Filename { get; init; }

        public string FilenameToWrite { get; set; }

    }
}