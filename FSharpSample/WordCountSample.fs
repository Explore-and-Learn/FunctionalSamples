module WordCount

    open System
    open System.IO
    open System.Collections.Generic
    open System.Collections.Concurrent

    
    let WordCount dirPath wildCard =

        let wordCounts = ConcurrentDictionary<string, int>()

        let ProcessFile fileName =
            let text = System.IO.File.ReadAllText(fileName)

            text.Split([|'.'; ' '; '\r'|], System.StringSplitOptions.RemoveEmptyEntries)
            |> Array.map (fun w -> w.Trim())
            |> Array.filter (fun w -> w.Length > 2)
            |> Array.iter (fun w ->
                wordCounts.AddOrUpdate(w, 1, (fun _ count -> count+1)) |> ignore)

        Directory.EnumerateFiles(dirPath, wildCard)
        |> Array.ofSeq
        |> Array.Parallel.iter ProcessFile

        wordCounts
        |> Seq.sortBy (fun kv -> kv.Value)
        |> Seq.iter (fun kv -> printf "%s %i \r" kv.Key kv.Value)
        //|> Seq.sumBy (fun kv -> kv.Value) -- just a check that validates the use of concurrency

