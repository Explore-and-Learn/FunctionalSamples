namespace CSV.Sample

module CSVSample =
    open System
    open FSharp.Data

    type bookData  = {
        author: string
        reviewDate : DateTime
        isbn : int
        discountedPrice: decimal

    }

    type sampleCsv = CsvProvider<"Sample.csv">
    //type sampleCsv = CsvProvider<"SampleTest.csv">

    let sortCsv =
        use sample = new sampleCsv()

        query {
                for s in sample.Rows do
                sortByDescending s.AUTHOR
                select { 
                        author = s.AUTHOR
                        reviewDate = s.REVIEW_DATE
                        isbn = s.ISBN
                        discountedPrice = s.DISCOUNTED_PRICE
                    }
            }
            |> Seq.toArray


