// For more information see https://aka.ms/fsharp-console-apps

open System

    

let Add (numbers:string):int =
    match numbers with
    | "" -> 0
    | _ -> match numbers.Split(",")  with
           | [| num1 |] -> (int num1)
           | [| num1 ; num2 |] -> (int num1) + (int num2)
           | _ -> failwith "Not Supported"

//Step 1:
printfn "%d" (Add "")
printfn "%d" (Add "1")
printfn "%d" (Add "1,2")
printfn "%d" (Add "-1,4")
printfn "%d" (Add "1,2,3,4") // thorw an exception

//-------
