module DiscriminatedUnionsSample

    type Shape =
        | Square of float
        | Rectangle of float * float
        | Circle of float

    let s = Square 4.0
    let r = Rectangle (4.0, 5.0)
    let c = Circle 3.0

    let drawing = [s; r; c] //list of shapes

    let Area (shape: Shape) =
        match shape with
        | Square x -> x * x
        | Rectangle(h, w) -> h * w
        | Circle r -> System.Math.PI * r * r

    let PrintAreas (drawing : List<Shape>) =
        drawing
        |> List.iter (fun shape -> printf "%f \r" (Area shape))

    let TotalDrawingArea (drawing : List<Shape>) =
        drawing
        |> List.sumBy (fun shape -> Area shape)

        //PrintAreas (drawing |> List.toArray);; //if print areas took an array, you must first convert list to array




