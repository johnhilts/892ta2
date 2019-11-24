let limit = 10

let rec getChunkSize (c: int list) =
    let filteri i m =
        let sum = c.[0..i] |> List.sum
        if sum < limit then Some m 
        else None 

    c 
    |> List.mapi(filteri) 
    |> List.choose id
    |> List.length

let rec chunker c l =
    let take = getChunkSize l
    let taken = c |> List.take(take) 
    let takenSize = taken |> List.length
    let nextChunk = c |> List.skip(takenSize)
    let nextLengths = l |> List.skip(takenSize)
    taken @ 
        if (nextChunk |> List.length) > 0 then ["-"] @ chunker nextChunk nextLengths
        else []

let original = ["one";"two";"three";"four";"five";"six"]
let lengths = original |> List.map(fun m -> m |> String.length)
chunker original lengths |> printfn "%A"
