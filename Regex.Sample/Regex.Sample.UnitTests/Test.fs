namespace Regex.Sample.UnitTests
open System
open NUnit.Framework

[<TestFixture>]
type RegexSampleTests() = 

    [<Test>]
    member x.TestRed() =
        let testColor = Regex.Sample.RegexSample.getColorValues "#FF0000"
        Assert.IsTrue(testColor.red = "FF")

    [<Test>]
    member x.TestGreen() =
        let testColor = Regex.Sample.RegexSample.getColorValues "#FF0A00"
        Assert.IsTrue(testColor.green = "0A")

    [<Test>]
    member x.TestBlue() =
        let testColor = Regex.Sample.RegexSample.getColorValues "#00004D"
        Assert.IsTrue(testColor.blue = "4D")

    [<Test>]
    [<ExpectedException>]
    member x.TestException() =
        let testColor = Regex.Sample.RegexSample.getColorValues "#GG0000"
        Assert.IsTrue(false)

