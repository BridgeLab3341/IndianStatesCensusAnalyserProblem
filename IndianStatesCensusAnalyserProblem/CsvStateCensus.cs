using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class CsvStateCensus
    {
        public int ReadStateCensusData(string filepath)
        {
            using(var reader=new StreamReader(filepath))
            using(var csvReader=new CsvReader(reader,CultureInfo.InvariantCulture))
            {
                var records=csvReader.GetRecords<CensusData>().ToList();
                foreach(var data in records)
                {
                    Console.WriteLine(data);
                }
                return records.Count() -1; 
            }
        }
    }
}
