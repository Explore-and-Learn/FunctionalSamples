namespace AdventureWorks_FSharp


module AdventureWorks =
    
    open System
    open FSharp.Data

    type Product = {
        productName : string
        productNumber : string
        productId : int
        listPrice: decimal
    }

     type ProductWithCategory = {
        productName : string
        productsubCategory : string Option
        listPrice: decimal
    }

    [<Literal>]
    let productsQuery = "Select * from [Production].[Product] where ListPrice = 0"
//    let productsQuery = "SELECT p.Name, p.ListPrice, pc.Name [Product Subcategory]  FROM [Production].[Product] p 
//	                        LEFT OUTER JOIN [Production].ProductCategory pc on pc.ProductCategoryID = p.ProductSubcategoryID"

    [<Literal>]
    let connectionString = "Server=.;Database=AdventureWorks2014;Trusted_Connection=True;"
    
    let getProducts =
        let query = new SqlCommandProvider<productsQuery, connectionString>()
        query.Execute() 
            |> Seq.map (fun product -> {
                                        productName = product.Name
                                        productId = product.ProductID
                                        productNumber = product.ProductNumber
                                        listPrice = product.ListPrice

                                })

       