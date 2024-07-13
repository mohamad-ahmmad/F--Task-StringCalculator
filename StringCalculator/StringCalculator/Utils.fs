module Utils
open System

let ToStringArray (array: int array) =
    "[" + String.Join (", ", array) + "]"


let Tokenize (input: string) (delimiters: string list) =
    let uniqueDelimiter = '\u0001'
    
    let replacedString = delimiters 
                         |> List.fold (fun (acc: string) delimiter -> acc.Replace(delimiter, uniqueDelimiter.ToString())) input
    
    replacedString.Split(uniqueDelimiter)