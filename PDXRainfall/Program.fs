open PDXRainfall.WebClient
open FSharp.Core
open System
open System.Linq
open FSharp.Data

[<EntryPoint>]
let main argv = 
    PDXRainGauge.getSortedStationNumberAscending(PDXRainGauge.getPDXPrecipitationRecords PDXRainGauge.rainfallData)
    |> Seq.iter (fun r -> System.Console.WriteLine( "Station: {0} rained {1} inches over the last 24 hours. Reading at {2}."
                , r.``Station Number``, r.``1 Day Accumulation``, r.``Time Of Reading (UTC)``))
    0













