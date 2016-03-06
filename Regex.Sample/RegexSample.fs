namespace Regex.Sample

module RegexSample =
    open FSharpx.TypeProviders.Regex

    [<Literal>]
    //extracts RGB values from Hex String using named captures
    let colorPattern =
        @"^#?(?<red>[\dA-F]{2})(?<green>[\dA-F]{2})(?<blue>[\dA-F]{2})$"

    
    //creates type using defined regex pattern
    type colorParser = FSharpx.Regex<colorPattern>

    type color =
        {
            red: string
            blue: string
            green: string
        }

    //instance of type

    let getColorValues color =
        let regex = colorParser()
        let getTestColor = 
            match regex.Match color with
            | m when m.Success -> 
                {
                    red = m.red.Value
                    green = m.green.Value
                    blue = m.blue.Value
                }
            | _ -> color |> failwith "Color not recognized"
        getTestColor
    
     

