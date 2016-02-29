namespace FSharpSample.UnitTests
open System
open NUnit.Framework

[<TestFixture>]
type TestTreeDiscriminatedUnions() = 

    [<Test>]
    member x.Test() =
        TreeSampleDiscriminatedUnions.Print TreeSampleDiscriminatedUnions.brake

