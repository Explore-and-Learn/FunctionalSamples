module TreeSampleDiscriminatedUnions

    type Tree =
        | Leaf of int
        | Node of Tree * Tree

    type Tree<'T> =
        | Leaf of 'T
        | Node of Tree<'T> * Tree<'T>

    //Car tree sample

    type Description = 
        { Name : string;
            PartNumber : string;
            Cost : decimal option }
    
    type Part =
        | Item of Description
        | Repeat of Part * int
        | Compound of Description * Part list

    let pad = Item{ Name = "brake pad"; PartNumber = "B12345"; Cost = Some 15.90M }
    let calliperBody = Item{Name = "calliper body"; PartNumber = "C456780"; Cost = Some 19.99M}
    let brakePiston = Item{Name = "brake calliper piston"; PartNumber = "P99669"; Cost = Some 9.80M}
    let disc = Item{Name="disc"; PartNumber="D56789";Cost=Some 45.48M}
    let clip = Item{Name="clip"; PartNumber ="P89792"; Cost=Some 10.00M}
    let pin = Item{Name="pin";PartNumber="N13452";Cost=Some 2.20M}

    let calliper =
        Compound(
            {Name="Calliper"; PartNumber = "R124C41"; Cost= None},
            [calliperBody; Repeat(brakePiston, 2)] )

    let brake = 
        Compound(
            {Name = "Brake"; PartNumber="THX1138"; Cost=None},
            [disc; calliper; Repeat(pin,2); Repeat(pad, 2); clip])

     let Flatten (part: Part) = 
         let rec flatten p =
             seq {
                 match p with
                 | Item d -> 
                    yield d
                 | Repeat(rp, count) ->
                     for _ in 0..count-1 do
                         yield! flatten rp
                 | Compound(d, children) ->
                     yield d
                     for child in children do
                         yield! flatten child
             }
         flatten part

     let TotalCost part =
         part
         |> Flatten
         |> Seq.sumBy (fun d ->
             match d.Cost with
             | Some c -> c
             | None -> 0.0m )

     let Indent (part : Part) =
         let rec indent level count p=
             seq{
                 match p with
                 | Item d -> yield level, count, d
                 | Repeat(pr, count) ->
                     yield! indent (level+1) count pr
                 | Compound(d, children) ->
                     yield level, count, d
                     for child in children do
                         yield! indent (level+1) 1 child
             }
         indent 0 1 part
     open System

     let Print(part: Part) =
         let printItem(indent: int, count : int, desc : Description) =
             let costStr = match desc.Cost with | Some c -> sprintf "%0.2f" c | None -> "N/A"
             printfn "%s %s %s %s x %i" (String(' ', indent*3)) desc.Name desc.PartNumber costStr count

         part
          |> Indent
          |> Seq.iter printItem
      
     brake
     |> Flatten
     |> Seq.iter (fun desc -> printfn "%A" desc)
     

      




