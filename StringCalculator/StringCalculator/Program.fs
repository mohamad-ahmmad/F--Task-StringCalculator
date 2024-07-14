// For more information see https://aka.ms/fsharp-console-apps
module StringCalculator

open System
open Utils



let private ExtractDelimiters (delimiters:string):Result<string list, AppErrors>   =
    let trimmedDelimiters = delimiters.Substring(2)

    if String.IsNullOrEmpty trimmedDelimiters || trimmedDelimiters = "[]" then 
        Error InvalidInputFormat
    elif trimmedDelimiters.StartsWith("[") && trimmedDelimiters.EndsWith("]") then
        Ok (trimmedDelimiters.Substring(1, trimmedDelimiters.Length - 2).Split("][") |> Array.toList)
    else
        Ok [trimmedDelimiters]


let private ValidateNoNegatives (array: int array):Result<int array, AppErrors> =
    let negValues = Array.filter (fun (num:int) -> num < 0) array
    match negValues.Length with
    | 0 -> Ok array
    | _ -> Error (NegativeNumbers negValues)

let private ExtractNumbersFromInput (numbers: string): Result<int array, AppErrors> =
    if String.IsNullOrWhiteSpace numbers then
        Ok [| 0 |]
    elif not (numbers.StartsWith("//")) then
        try
            Ok (numbers.Split([|","; "\n"|], StringSplitOptions.None) |> Array.map int)
        with
        | :? System.FormatException -> Error InvalidInputFormat
    else
        let parts = numbers.Split("\n")
        if parts.Length < 2 then
            Error InvalidInputFormat
        else
            parts.[0]
            |> ExtractDelimiters
            |> Tokenize parts[1]
            |> Map (Array.map int)
        
            
let Add (numbers:string): Result<int, AppErrors> =
    numbers
    |> ExtractNumbersFromInput
    |> Bind ValidateNoNegatives
    |> Map (Array.filter (fun num -> num <= 1000))
    |> Map Array.sum
  
    

//Step 1:
printfn "%A" (Add "")
printfn "%A" (Add "1")
printfn "%A" (Add "1,2")
printfn "%A" (Add "-1,4") //throw an exception negatives
printfn "%A" (Add "1,2,3,4") // thorw an exception in Step 1

//-------

//Step 2:
printfn "%A" (Add "1,2,3,4")
printfn "%A" (Add "0,2,10,4,4")

//-------
//Step 3:
printfn "%A" (Add "0\n2,10\n4,4")

//-------

//Step 4:
printfn "%A" (Add "//*\n1*2*10")
printfn "%A" (Add "//[-]\n1-4-10")

//-------

//Step 5:
printfn "%A" (Add "//^\n11^2^-10^-3") //throw an exception negatives not allowed

//-------
//Step 6:
printfn "%A" (Add "1001,10,2")

//Step 7:
printfn "%A" (Add "//***\n2***10***3")
printfn "%A" (Add "//[*&*]\n2*&*10*&*3")

//Step 8&9:
printfn "%A" (Add "//[&*][%]\n10&*2&*8")
