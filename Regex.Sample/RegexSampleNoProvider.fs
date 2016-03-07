namespace Regex.Sample

module RegexSampleNoProvider =

    open System.Text.RegularExpressions

    [<Literal>]
    //extracts RGB values from Hex String using named captures
    let pattern =
        @"^#?(?<red>[\dA-F]{2})(?<green>[\dA-F]{2})(?<blue>[\dA-F]{2})$"

    type colorTest =
        {
            red: string
            blue: string
            green: string
        }

    let getColorTestValues color =
        let regex = Regex(pattern)
        let getTestColor = 
            match regex.Match color with
            | m when m.Success -> 
                {
                    red = m.Groups.["red"].Value
                    green = m.Groups.["green"].Value
                    blue = m.Groups.["blue"].Value
                }
            | _ -> color |> failwith "Color not recognized"
        getTestColor
    
     




