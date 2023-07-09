using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class StatesCensusAnalyser
    {
        //UC-1
        public int ReadStateCensusData(string filepath)
        {

            if (!File.Exists(filepath))
            {
                throw new StateCensusException(StateCensusException.ExceptionType.FILE_INCORRECT, "Incorrect File Path");
            }
            if (!File.Exists(".csv"))
            {
                throw new StateCensusException(StateCensusException.ExceptionType.FILE_TYPE_INCORRECT, "Incorrect File Type");
            }
            var read=File.ReadAllLines(filepath);
            string header = read[0];
            if (header.Contains("/"))
            {
                throw new StateCensusException(StateCensusException.ExceptionType.DELIMETER_NOT_FOUND, "Delimeter Not Found");
            }
            using (var reader = new StreamReader(filepath))
            using (var csvFile = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
               var records = csvFile.GetRecords<CensusData>().ToList();
               foreach (var data in records)
               {
                   Console.WriteLine("\tState = " + data.State + "\tPopulation = " + data.Population + "\tAreaInSqKm = " + data.AreaInSqKm + "\tDensityPerSqKm = " + data.DensityPerSqKm);
               }
              return records.Count() - 1;
            }
        } 
        public bool ReadStateCensusData(string filepath, string actualheader)
        {
            var reader = File.ReadAllLines(filepath);
            string header = reader[0];
            if(header.Equals(header))
            {
                return true;
            }
            else
            {
                throw new StateCensusException(StateCensusException.ExceptionType.HEADER_INCORRECT, "Incorrect Header");
            }
        }
    }
}
