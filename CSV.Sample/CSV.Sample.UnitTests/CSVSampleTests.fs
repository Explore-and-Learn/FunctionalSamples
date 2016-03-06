namespace CSV.Sample.UnitTests
open System
open NUnit.Framework
open System.Linq

[<TestFixture>]
type CSVSampleTests() = 

    [<Test>]
    member x.TestCSVHeaders() =
        use sample = new CSV.Sample.CSVSample.sampleCsv()
        Assert.IsTrue(sample.Headers.IsSome)

  
    [<Test>]
    member x.TestCsvSort() =
        let sortedRows : CSV.Sample.CSVSample.bookData[] = CSV.Sample.CSVSample.parseCsv
        Assert.IsTrue(sortedRows.[0].author.Contains("Timothy"))

