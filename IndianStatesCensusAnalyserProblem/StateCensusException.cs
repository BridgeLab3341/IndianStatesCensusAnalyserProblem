using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class StateCensusException : Exception
    {
        public enum ExceptionType
        {
            FILE_INCORRECT, FILE_NOT_FOUND, FILE_TYPE_INCORRECT,DELIMETER_NOT_FOUND,HEADER_INCORRECT
        }
        public ExceptionType type;
        public StateCensusException(ExceptionType type, string message):base(message)
        {
            this.type = type;
        }
    }
}
