namespace CSV.Sample

module CSVSample =
    open System
    open FSharp.Data

    type bookData  = {
        author: string
        reviewDate : DateTime
        isbn : int
        //discountedprice: decimal

    }

    type sampleCsv = CsvProvider<"Sample.csv">

    let sortCsv =
        use sample = new sampleCsv()

        query {
                for s in sample.Rows do
                sortByDescending s.AUTHOR
                select { 
                        author = s.AUTHOR
                        reviewDate = s.REVIEW_DATE
                        isbn = s.ISBN
                    }
            }
            |> Seq.toArray


