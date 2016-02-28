#if interactive
#else
    module DictionarySample
#endif
//mutable style
    open System.Collections.Generic
    type LatLong = { Lat : double; Long : float} //record
    let zipLocations = Dictionary<int, LatLong>()

    zipLocations.Add(97202, {Long = 908.00; Lat = -876.98});; // ';;' is required to run in F# interactive?
    zipLocations.Add(97865, {Long = 897.00; Lat = -634.74});;
    zipLocations.Add(13583, {Long = 203.45; Lat = -34.63});;

    zipLocations
    |> Seq.iter (fun kvp ->
        printfn "%i %f %f" kvp.Key kvp.Value.Lat kvp.Value.Long)

    zipLocations.Keys
    |> Seq.iter (fun key ->
        printfn "%i" key)

  //dict is a special F# keyword that converts a kvp to an immutable dictionary

    let capitals = 
      [
          "United States of America", "Washington D.C."
          "United Kingdom", "London"
          "France", "Paris"

      ] |> dict
      |> Seq.iter (fun kvp ->
        printfn "%s: %s" kvp.Key kvp.Value)

    //capitals.["United States of America"] <- "New York" NOT ALLOWED


    