namespace AdventureWorks_FSharp


module AdventureWorks =
    
    open System
    open FSharp.Data
    open System.Configuration

    type Product = {
        productName : string
        productNumber : string
        productId : int
        listPrice: decimal
    }

    [<Literal>]
    let productsQuery = "Select * from [Production].[Product]"

    [<Literal>]
    let connectionString = "Server=.;Database=AdventureWorks2014;Trusted_Connection=True;"
    
    let getProducts =
        let query = new SqlCommandProvider<productsQuery, connectionString>()
        query.Execute() 
            |> Seq.map (fun product -> {
                                        productName = product.Name
                                        productNumber = product.ProductNumber
                                        productId = product.ProductID
                                        listPrice = product.ListPrice
                                })

       