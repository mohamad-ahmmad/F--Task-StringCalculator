// For more information see https://aka.ms/fsharp-console-apps

open System

    

let Add (numbers:string):int =
    match numbers with
    | "" -> 0
    | _ -> numbers.Split(",")
           |> Array.map int
           |> Array.sum

//Step 1:
printfn "%d" (Add "")
printfn "%d" (Add "1")
printfn "%d" (Add "1,2")
printfn "%d" (Add "-1,4")
//printfn "%d" (Add "1,2,3,4") // thorw an exception

//-------

//Step 2:
printfn "%d" (Add "1,2,3,4")
printfn "%d" (Add "0,2,10,4,4")

//-------
