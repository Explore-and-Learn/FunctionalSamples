namespace PDXRainfall.UnitTests
open System
open System.Collections.Generic
open System.Linq
open NUnit.Framework
open PDXRainfall.WebClient
open FSharp.Data

[<TestFixture>]
type Test() = 

    [<Test>]
    member x.TestGetPDXPreciptationRecords() =
        let records = PDXRainGauge.getSortedStationNumberAscending(x.GetPrecipitationTestRecords)
        Assert.IsTrue(records.Count() > 0)

    [<Test>]
    member x.TestSortedStationNumberAscending() =
        let records = PDXRainGauge.getSortedStationNumberAscending(x.GetPrecipitationTestRecords)
        Assert.IsTrue(records.First().StationNumber = 5)

    [<Test>]
    member x.TestSortedStationNumberDescending() =
        let records = PDXRainGauge.getSortedStationNumberDescending(x.GetPrecipitationTestRecords)
        Assert.IsTrue(records.First().StationNumber = 999)

    [<Test>]
    member x.TestPrecipitationRecordsRetrieval() =
        let records = 
            PDXRainGauge.getPDXPrecipitationRecords PDXRainGauge.rainfallData
        Assert.IsTrue(records.Count() > 0)

    [<Test>]
    member x.TestPrecipitationRecordsExistence() =
        let records = 
            PDXRainGauge.getPDXPrecipitationRecords PDXRainGauge.rainfallData
        Assert.IsTrue(records.Any(fun(r) -> r.StationNumber = 1))

    member x.GetPrecipitationTestRecords : PDXRainGauge.PrecipitationData[] =

        seq<PDXRainGauge.PrecipitationData>[|
             {
                StationName = "Test Station 999"
                StationNumber = 999
                _1DayAccumulation = 0.01
                _3DayAccumulation = 0.05
                _5DayAccumulation = 0.40
                CurrentMonthAccumulation = 2.50
                WaterYearAccumulation =  10.50
                TimeOfReading = DateTime.UtcNow
            };
             {
                StationName = "Test Station 5"
                StationNumber = 5
                _1DayAccumulation = 0.11
                _3DayAccumulation = 0.15
                _5DayAccumulation = 0.40
                CurrentMonthAccumulation = 4.50
                WaterYearAccumulation =  19.50
                TimeOfReading = DateTime.UtcNow
            };
            {
                StationName = "Test Station 500"
                StationNumber = 500
                _1DayAccumulation = 0.03
                _3DayAccumulation = 0.80
                _5DayAccumulation = 1.20
                CurrentMonthAccumulation = 3.78
                WaterYearAccumulation =  13.75
                TimeOfReading = DateTime.UtcNow
            };
            {
                StationName = "Test Station 100"
                StationNumber = 100
                _1DayAccumulation = 0.40
                _3DayAccumulation = 1.20
                _5DayAccumulation = 2.00
                CurrentMonthAccumulation = 5.00
                WaterYearAccumulation =  20.50
                TimeOfReading = DateTime.UtcNow
            }
        |]
        |> Array.ofSeq
