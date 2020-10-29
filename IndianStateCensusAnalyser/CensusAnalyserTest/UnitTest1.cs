using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;
namespace CensusAnalyserTest
{
    public class Tests
    {
        //CensusAnalyser.CensusAnalyser censusAnalyser;
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\Puja\Desktop\StateCensusAnalyser\StateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CSV\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\Puja\Desktop\StateCensusAnalyser\StateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CSV\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\Puja\Desktop\StateCensusAnalyser\StateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CSV\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Puja\Desktop\StateCensusAnalyser\StateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CSV\WrongIndiaStateCensus.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Puja\Desktop\StateCensusAnalyser\StateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CSV\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"C:\Users\Puja\Desktop\StateCensusAnalyser\StateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CSV\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\Puja\Desktop\StateCensusAnalyser\StateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CSV\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\Puja\Desktop\StateCensusAnalyser\StateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CSV\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\Puja\Desktop\StateCensusAnalyser\StateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CSV\WrongIndiaStateCode.csv";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        [Test]
        public void GivenCorrectFilePathButIncorrectFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFileType, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        [Test]
        public void GivenIncorrectDelimiterCsvFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        [Test]
        public void GivenIncorrectHeaderCsvFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}
