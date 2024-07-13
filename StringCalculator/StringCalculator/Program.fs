// For more information see https://aka.ms/fsharp-console-apps

open System
open Utils


let private ExtractDelimiters (delimiters:string)  =
    let trimmedDelimiters = delimiters.Substring(2)

    if String.IsNullOrEmpty trimmedDelimiters || trimmedDelimiters = "[]" then 
        failwith "Empty delimiter are not allowed"
    elif trimmedDelimiters.StartsWith("[") && trimmedDelimiters.EndsWith("]") then
        trimmedDelimiters.Substring(1, trimmedDelimiters.Length - 2).Split("][") |> Array.toList
    else
        [trimmedDelimiters]


let private ThrowExceptionIfAnyNegatives (array: int array) =
    let negValues = Array.filter (fun (num:int) -> num < 0) array
    match negValues.Length with
    | 0 -> array
    | _ -> failwith ("negatives not allowed " + ToStringArray negValues)

let private ExtractNumbersFromInput (numbers: string) =
    let extractedNumber:string[] =
        if String.IsNullOrWhiteSpace numbers then
            [| "0" |]
        elif not (numbers.StartsWith("//")) then
            numbers.Split([|","; "\n"|], StringSplitOptions.None)
        else
            let parts = numbers.Split("\n")
            parts[0] |> ExtractDelimiters |> Tokenize parts[1]

    extractedNumber |> Array.map int
        
            
let Add (numbers:string):int =
    numbers
    |> ExtractNumbersFromInput
    |> ThrowExceptionIfAnyNegatives
    |> Array.filter (fun num -> num <= 1000) 
    |> Array.sum
  
    

//Step 1:
printfn "%d" (Add "")
printfn "%d" (Add "1")
printfn "%d" (Add "1,2")
//printfn "%d" (Add "-1,4") //throw an exception negatives
//printfn "%d" (Add "1,2,3,4") // thorw an exception in Step 1

//-------

//Step 2:
printfn "%d" (Add "1,2,3,4")
printfn "%d" (Add "0,2,10,4,4")

//-------
//Step 3:
printfn "%d" (Add "0\n2,10\n4,4")

//-------

//Step 4:
printfn "%d" (Add "//*\n1*2*10")
printfn "%d" (Add "//[-]\n1-4-10")

//-------

//Step 5:
//printfn "%d" (Add "//^\n11^2^-10^-3") //throw an exception negatives not allowed

//-------
//Step 6:
printfn "%d" (Add "1001,10,2")

//Step 7:
printfn "%d" (Add "//***\n2***10***3")
printfn "%d" (Add "//[*&*]\n2*&*10*&*3")

//Step 8&9:
printfn "%d" (Add "//[&*][%]\n10&*2&*8")
