using IndianStatesCensusAnalyserProblem;

namespace IndianStatesCensusMS_Test
{
    [TestClass]
    public class UnitTest1
    {
        public string stateCensusPath = @"D:\ReMapBridgeLabs\IndianStatesCensusAnalyserProblem\IndianStatesCensusMS_Test\NewFolder\IndianStateCode.csv";
        public string incorrectPath = @"D:\ReMapBridgeLabs\IndianStatesCensusAnalyserProblem\IndianStatesCensusMS_Test\IndianStateCode.csv";
        public string incorrectType = @"D:\ReMapBridgeLabs\IndianStatesCensusAnalyserProblem\IndianStatesCensusMS_Test\NewFolder\IncorrectType.txt";
        public string delimeterPath = @"D:\ReMapBridgeLabs\IndianStatesCensusAnalyserProblem\IndianStatesCensusMS_Test\NewFolder\InCorrectDelimeter.csv";
        public string headerPath = @"D:\ReMapBridgeLabs\IndianStatesCensusAnalyserProblem\IndianStatesCensusMS_Test\NewFolder\IncorrectHeader.csv";
        [TestMethod]
        //TC-1.1
        public void GivenStatesCensusCsvFile_CheckToEnsure_NumberofRecordsMatch()
        {
            StatesCensusAnalyser analyser = new StatesCensusAnalyser();
            CsvStateCensus csvCensus = new CsvStateCensus();
            Assert.AreEqual(analyser.ReadStateCensusData(stateCensusPath), csvCensus.ReadStateCensusData(stateCensusPath));
        }
        [TestMethod]
        //TC-1.2
        public void GivenStatesCensusCsvFile_IfIncorrect_ReturnsCustomException()
        {
            StatesCensusAnalyser analyser = new StatesCensusAnalyser();
            try
            {
                int records = analyser.ReadStateCensusData(incorrectPath);
            }
            catch(StateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect File Path");
            }
        }
        [TestMethod]
        //TC-1.3
        public void GivenStatesCensusCsvFile_TypeIncorrect_ReturnsCustomException()
        {
            StatesCensusAnalyser analyser = new StatesCensusAnalyser();
            try
            {
                int records = analyser.ReadStateCensusData(incorrectType);
            }
            catch (StateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect File Type");
            }
        }
        [TestMethod]
        //TC-1.4
        public void GivenStatesCensusCsvFile_DeliMeterIncorrect_ReturnsCustomException()
        {
            StatesCensusAnalyser analyser = new StatesCensusAnalyser();
            try
            {
                int records = analyser.ReadStateCensusData(delimeterPath);
            }
            catch (StateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Delimeter Not Found");
            }
        }
        [TestMethod]
        //TC-1.5
        public void GivenStatesCensusCsvFile_HeaderIncorrect_ReturnsCustomException()
        {
            StatesCensusAnalyser analyser = new StatesCensusAnalyser();
            try
            {
                bool records = analyser.ReadStateCensusData(headerPath, "state,population,areaInSqKm,densityPerSqKm");
            }
            catch (StateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect Header");
            }
        }
    }
}