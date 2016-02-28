module TreeSample

    type FoodStuff(name: string, isAllergenic: bool, FoodStuffs: FoodStuff list) =
        member this.Name = name
        member this.FoodStuffs = FoodStuffs
        member this.IsAllergenic = isAllergenic

    let cake = 
        FoodStuff("cake", false,
            [
                FoodStuff("flour", false, [])
                FoodStuff("eggs", false, [])
                FoodStuff("mixed fruit", false,
                    [
                        FoodStuff("raisins", false, [])
                        FoodStuff("saltanas", false, [])
                    ])
                FoodStuff("mixed nuts", false,
                    [
                        FoodStuff("walnuts", false, [])
                        FoodStuff("almonds", false, [])
                        FoodStuff("peanuts", false, [])
                    ])
             ])

     //let rec IsAllergenic (foodStuff: FoodStuff) : bool =
       // foodStuff.IsAllergenic
        //|| foodStuff.FoodStuffs |> List.exists IsAllergenic
                 
