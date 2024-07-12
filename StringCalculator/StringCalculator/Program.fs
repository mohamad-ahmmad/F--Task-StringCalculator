// For more information see https://aka.ms/fsharp-console-apps

open System

let Tokenize (input: string) (delimiters: string list) =
    let uniqueDelimiter = '\u0001'
    
    let replacedString = delimiters 
                         |> List.fold (fun (acc: string) delimiter -> acc.Replace(delimiter, uniqueDelimiter.ToString())) input
    
    replacedString.Split(uniqueDelimiter) 

let ExtractDelimiter (delimiters:string)  =
    let delimiter = delimiters.Substring(2);

    match delimiter.Length with 
    | 1 -> [delimiter]
    | _ -> if delimiter.StartsWith("[") && delimiter.EndsWith("]") then
                let delChar = delimiter.Substring(1, delimiter.Length - 2)
                match delChar.Length with
                | 1 -> [delChar]
                | _ -> failwith "Not supported empty delimiter char"
            else
                failwith "Not supported delimiter"

let Add (numbers:string):int =
    if numbers = "" then
        0
    elif not (numbers.StartsWith("//")) then
        numbers.Split([|","; "\n"|], StringSplitOptions.None) |> Array.map int |> Array.sum
    else
        let parts = numbers.Split("\n")
        parts[0] |> ExtractDelimiter |> Tokenize parts[1]
        |> Array.map int |> Array.sum
        
        
        

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
//Step 3:
printfn "%d" (Add "0\n2,10\n4,4")

//step 4:
printfn "%d" (Add "//*\n1*2*10")
printfn "%d" (Add "//[-]\n1-4-10")
