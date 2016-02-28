module DictionaryMutableSample
    open System.Collections.Generic

    type LineRec = { Number: int; Key: string; Line : string}

    let DedupeKeepLast (lines: seq<string>) =
        let lineDict = new Dictionary<string, int>()

        let records =
            lines
            |> Seq.mapi (fun i line -> 
                { Number = i; Key = line.Split([|','|]).[0]; Line = line})

        records
        |> Seq.iter (fun record ->
            lineDict.[record.Key] <- record.Number) //this creates a record if it doesn't exist or updates an existing record; last value wins
        
        records
        |> Seq.choose (fun record ->
            if record.Number = lineDict.[record.Key] then
                Some(record.Line)
            else
                None)


    let TestDeDupeKeepLast =
      [
          "49452, 79.4, 80.0"
          "45786, 79.5, 81.0"
          "34568, 34.5, 12.34"
          "49452, 80.0, 81.0"
          "45786, 30.0, 35.0"
      ]
      |> DedupeKeepLast
      |> Seq.iter (fun lineRec -> printfn "%A" lineRec)

