module CryptographySample

    open System.Security.Cryptography
    open System.IO

    type FileExistsChecker(dirPath : string) =
        let FileMD5 filePath =
            use md5 = SHA1.Create()
            use stream = File.OpenRead(filePath)
            md5.ComputeHash(stream)
        let md5Dict =
            dirPath
            |> Directory.EnumerateFiles
            |> Seq.iter (fun fileName -> printfn "%A" fileName)

            dirPath
            |> Directory.EnumerateFiles
            |> Seq.map(fun filePath -> FileMD5 filePath, filePath)
            |> dict
        member this.ExistingFilePath newFilePath =
            let newMD5 = FileMD5 newFilePath
            let ok, value = md5Dict.TryGetValue(newMD5)
            if ok then
                value |> Some
            else
                None