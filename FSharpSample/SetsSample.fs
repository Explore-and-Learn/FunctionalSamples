module SetsSample

    open System.IO

    let re = System.Text.RegularExpressions.Regex("\w+")
    let ToWords str =
        seq { for m in re.Matches(str) -> m.Value}

    let FileWords fileName =
        fileName
        |> File.ReadLines
        |> Seq.collect ToWords
        |> Seq.map (fun w -> w.ToLowerInvariant())

    let DirUniqueWords dirName =
        dirName
        |> Directory.EnumerateFiles
        |> Seq.collect FileWords
        |> Set.ofSeq

    let PrintUniqueWords (words: Set<string>) =
        words
        |> Seq.iter (fun w -> printf "%s\r" w)

    


