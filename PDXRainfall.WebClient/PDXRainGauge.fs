namespace PDXRainfall.WebClient

module PDXRainGauge =

    open FSharp.Data
    open System.Collections.Generic
    open System.Linq

    open System

    type PrecipitationData = {
        ``Station Name``: string;
        ``Station Number``: int;
        ``1 Day Accumulation``: float;
        ``3 Day Accumulation``: float;
        ``5 Day Accumulation``: float;
        ``Current Month Accumulation``: float;
        ``Water Year Accumulation``: float
        ``Time Of Reading (UTC)`` : DateTime
        }

    type pdxRainfall = HtmlProvider<"http://or.water.usgs.gov/non-usgs/bes/">
    let rainfallData = pdxRainfall.Load("http://or.water.usgs.gov/non-usgs/bes/");

    let getPDXPrecipitationRecords (records : HtmlProvider<"http://or.water.usgs.gov/non-usgs/bes/">)=

        let getPrecipitationRecords = 
            let arr = records.Tables.``City of Portland HYDRA Rainfall Network 2``.Rows
                        |> Array.filter (fun row -> not (row.``City of Portland Rain Gages``.ToLower().Contains("region")))
                        |> Array.filter (fun row -> not (row.``City of Portland Rain Gages``.Contains("Station Name")))
                        |> Array.filter (fun row -> not (row.``City of Portland Rain Gages``.ToLower().Contains("portland area")))
                        |> Array.filter (fun row -> not (row.``City of Portland Rain Gages``.ToLower().Contains("other")))
                        |> Array.filter (fun row -> not (row.``City of Portland Rain Gages 3``.ToLower().Contains("was retired")))
            let precipitationData =
                try
                    Some( seq<PrecipitationData> {
                        for row in arr do
                            yield {
                                ``Station Name`` = row.``City of Portland Rain Gages``;
                                ``Station Number`` = int row.``City of Portland Rain Gages 2``;
                                ``1 Day Accumulation`` = float row.``City of Portland Rain Gages 4``;
                                ``3 Day Accumulation`` = float row.``City of Portland Rain Gages 5``;
                                ``5 Day Accumulation`` = float row.``City of Portland Rain Gages 6``;
                                ``Current Month Accumulation`` = float row.``City of Portland Rain Gages 7``;
                                ``Water Year Accumulation`` =  float row.``City of Portland Rain Gages 8``
                                ``Time Of Reading (UTC)`` = DateTime.UtcNow
                        }
                    })
                with 
                    | :? System.FormatException -> printfn "Cast failed."; None
            precipitationData

        match getPrecipitationRecords with
        | Some n -> n
        | None -> Seq.empty

    let public getSortedStationNumberAscending arr =
        arr
        |> Seq.sortBy(fun x -> x.``Station Number``)

    let public getSortedStationNumberDescending  arr =
        arr
        |> Seq.sortByDescending(fun x -> x.``Station Number``)

 
    