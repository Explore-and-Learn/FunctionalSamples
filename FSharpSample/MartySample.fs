module MartySample

    let v = 2


    let Area radius =
        if radius < 0. then
            0.
        else
            System.Math.PI * radius ** 2.5

    let IsEvenNumber value : bool =
        if value > 0 then value%2 = 0 else false

