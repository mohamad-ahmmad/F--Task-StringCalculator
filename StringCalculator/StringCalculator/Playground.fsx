

open System



let input = "Hello world\nhello,"

let minDel = List.map (fun (delimiter: string) -> (delimiter.Length, input.IndexOf (delimiter))) ["\n"; ","] 
                                        |> List.minBy (fun (i, j) -> j)

let subStringTup (length:int, index:int) = input.Substring(0, index)
let tailSubString (length:int, index: int) = input.Substring(index+length)

subStringTup minDel
tailSubString minDel


[1;2;3;4] |> List.fold (fun acc num -> acc+num ) 0

"1\n2,3".Split([|"\n"; ","|], System.StringSplitOptions.None)

let tokenize (input: string) (delimiters: string list) =
    let uniqueDelimiter = '\u0001'
    
    let replacedString = delimiters 
                         |> List.fold (fun (acc: string) delimiter -> acc.Replace(delimiter, uniqueDelimiter.ToString())) input
    
    replacedString.Split(uniqueDelimiter)

(tokenize "123%%23;;54\n54" ["%%";";;";"\n"])
