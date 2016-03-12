namespace OData.Sample

module ODataSample =
    open Microsoft.FSharp.Data.TypeProviders

    type northwind = ODataService<"http://services.odata.org/V3/Northwind/Northwind.svc">

    let svc = northwind.GetDataContext()


    let getMostRecentInvoices number = 
        
        query {
            for i in svc.Invoices do
            sortByNullableDescending i.ShippedDate
            take number
            select (i.OrderDate, i.CustomerName, i.ProductName)
        }
        |> Seq.iter (printfn "%A")





