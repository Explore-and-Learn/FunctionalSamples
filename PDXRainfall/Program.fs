open PDXRainfall.WebClient
open FSharp.Core
open System
open System.Linq
open FSharp.Data

[<EntryPoint>]
let main argv = 
    PDXRainGauge.getSortedStationNumberAscending(PDXRainGauge.getPDXPrecipitationRecords PDXRainGauge.rainfallData)
    |> Seq.iter (fun r -> System.Console.WriteLine( "Station: {0} - {1} rained {2} inches over the last 24 hours. Reading at {3}."
                , r.StationNumber, r.StationName, r._1DayAccumulation, r.TimeOfReading))
    0













