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
        Assert.IsTrue(records.First().``Station Number`` = 2)

    [<Test>]
    member x.TestSortedStationNumberDescending() =
        let records = PDXRainGauge.getSortedStationNumberDescending(x.GetPrecipitationTestRecords)
        Assert.IsTrue(records.First().``Station Number`` = 999)

    [<Test>]
    member x.TestPrecipitationRecordsRetrieval() =
        let records = 
            PDXRainGauge.getPDXPrecipitationRecords PDXRainGauge.rainfallData
        Assert.IsTrue(records.Count() > 0)

    [<Test>]
    member x.TestPrecipitationRecordsExistence() =
        let records = 
            PDXRainGauge.getPDXPrecipitationRecords PDXRainGauge.rainfallData
        Assert.IsTrue(records.Any(fun(r) -> r.``Station Number`` = 1))

    member x.GetPrecipitationTestRecords : PDXRainGauge.PrecipitationData[] =

        seq<PDXRainGauge.PrecipitationData>[|
             {
                ``Station Name`` = "Test Station 999"
                ``Station Number`` = 999
                ``1 Day Accumulation`` = 0.01
                ``3 Day Accumulation`` = 0.05
                ``5 Day Accumulation`` = 0.40
                ``Current Month Accumulation`` = 2.50
                ``Water Year Accumulation`` =  10.50
                ``Time Of Reading (UTC)`` = DateTime.UtcNow
            };
             {
                ``Station Name`` = "Test Station 501"
                ``Station Number`` = 501
                ``1 Day Accumulation`` = 0.15
                ``3 Day Accumulation`` = 0.30
                ``5 Day Accumulation`` = 1.40
                ``Current Month Accumulation`` = 4.50
                ``Water Year Accumulation`` =  21.50
                ``Time Of Reading (UTC)`` = DateTime.UtcNow
            };
            {
                ``Station Name`` = "Test Station 002"
                ``Station Number`` = 002
                ``1 Day Accumulation`` = 0.51
                ``3 Day Accumulation`` = 1.00
                ``5 Day Accumulation`` = 1.91
                ``Current Month Accumulation`` = 6.47
                ``Water Year Accumulation`` =  18.50
                ``Time Of Reading (UTC)`` = DateTime.UtcNow
            };
            {
                ``Station Name`` = "Test Station 465"
                ``Station Number`` = 465
                ``1 Day Accumulation`` = 0.34
                ``3 Day Accumulation`` = 0.76
                ``5 Day Accumulation`` = 1.75
                ``Current Month Accumulation`` = 3.50
                ``Water Year Accumulation`` =  13.75
                ``Time Of Reading (UTC)`` = DateTime.UtcNow
            }
        |]
        |> Array.ofSeq
