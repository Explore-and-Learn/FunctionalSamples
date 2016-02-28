namespace PDXRainfall.WebClient

module PDXRainGauge =

    open FSharp.Data
    open System.Collections.Generic
    open System.Linq

    open System

    type PrecipitationData = {
        StationName: string;
        StationNumber: int;
        _1DayAccumulation: float;
        _3DayAccumulation: float;
        _5DayAccumulation: float;
        CurrentMonthAccumulation: float;
        WaterYearAccumulation: float
        TimeOfReading : DateTime
        }

    type pdxRainfall = HtmlProvider<"http://or.water.usgs.gov/non-usgs/bes/">
    let rainfallData = pdxRainfall.Load("http://or.water.usgs.gov/non-usgs/bes/");

    let getPDXPrecipitationRecords (records : HtmlProvider<"http://or.water.usgs.gov/non-usgs/bes/">)=

        let getPrecipitationRecords : seq<PrecipitationData> Option = 
            let arr = records.Tables.``City of Portland HYDRA Rainfall Network 2``.Rows
                        |> Array.filter (fun row -> not (row.``City of Portland Rain Gages``.ToLower().Contains("region")))
                        |> Array.filter (fun row -> not (row.``City of Portland Rain Gages``.Contains("Station Name")))
                        |> Array.filter (fun row -> not (row.``City of Portland Rain Gages``.ToLower().Contains("portland area")))
                        |> Array.filter (fun row -> not (row.``City of Portland Rain Gages``.ToLower().Contains("other")))
                        |> Array.filter (fun row -> not (row.``City of Portland Rain Gages 3``.ToLower().Contains("was retired")))
            let precipitationData : seq<PrecipitationData> Option =
                try
                    Some( seq<PrecipitationData> {
                        for row in arr do
                            yield {
                                StationName = row.``City of Portland Rain Gages``;
                                StationNumber = int row.``City of Portland Rain Gages 2``;
                                _1DayAccumulation = float row.``City of Portland Rain Gages 4``;
                                _3DayAccumulation = float row.``City of Portland Rain Gages 5``;
                                _5DayAccumulation = float row.``City of Portland Rain Gages 6``;
                                CurrentMonthAccumulation = float row.``City of Portland Rain Gages 7``;
                                WaterYearAccumulation =  float row.``City of Portland Rain Gages 8``
                                TimeOfReading = DateTime.UtcNow
                        }
                    })
                with 
                    | :? System.FormatException -> printfn "Cast failed."; None
            precipitationData

        match getPrecipitationRecords with
        | Some n -> n
        | None -> Seq.empty

    let public getSortedStationNumberAscending (arr: seq<PrecipitationData>) : IEnumerable<PrecipitationData> =
        arr
        |> Seq.sortBy(fun x -> x.StationNumber)

    let public getSortedStationNumberDescending  arr =
        arr
        |> Seq.sortByDescending(fun x -> x.StationNumber)

 
    