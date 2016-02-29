namespace FSharpSample.UnitTests
open System
open System.Linq
open NUnit.Framework

[<TestFixture>]
type TestTreeDiscriminatedUnions() = 

    [<Test>]
    member x.TestFlattenBrake() =
        let brake = TreeDiscriminatedUnions.Flatten TreeDiscriminatedUnions.brake
        Assert.IsTrue(brake.Any())
        Assert.IsTrue(brake.First().PartNumber = "THX1138")

    [<Test>]
    member x.TestCostCalculation() =
        let cost = TreeDiscriminatedUnions.TotalCost TreeDiscriminatedUnions.brake
        Assert.IsTrue(cost > 0m)

