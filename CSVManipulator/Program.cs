using CSVReader;



CSVProperties csvProperties = new CSVProperties
{
    Filename = "C:\\Users\\KulbirSingh\\Downloads\\EVCDATA.csv",
    Separator = ",",
    RowsToIgnore = 5,
    HasHeader = true,
    FilenameToWrite = "C:\\Users\\KulbirSingh\\Downloads\\EVCCSHARPEDDATA.csv",
};

CSVManipulator csv = new CSVManipulator(csvProperties);

csv.RowShuffleCSV(1000);
csv.WriteCSV(csvProperties);