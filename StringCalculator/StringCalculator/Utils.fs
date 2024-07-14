module Utils
open System

type AppErrors = 
    | InvalidInputFormat
    | NegativeNumbers of int array

let Bind f inp =
    match inp with
    | Ok x -> f x
    | Error e -> Error e


let Map f inp =
    match inp with
    | Ok x -> Ok (f x)
    | Error e -> Error e

let ToStringArray (array: int array) =
    "[" + String.Join (", ", array) + "]"


let Tokenize (input: string) (delimiters: Result<string list, AppErrors>): Result<string[], AppErrors> =
    match delimiters with
    | Error e -> Error e
    | Ok delimiters ->
        let uniqueDelimiter = '\u0001'
        let replacedString = delimiters |> List.fold (fun (acc: string) delimiter -> acc.Replace(delimiter, uniqueDelimiter.ToString())) input
        Ok (replacedString.Split(uniqueDelimiter))