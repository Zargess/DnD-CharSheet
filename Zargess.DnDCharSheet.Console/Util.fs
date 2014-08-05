module Util

open System.Xml
open System.Collections.Generic
open System.Xml.Linq

let rec lastElement ls =
    match ls with
    | [] -> []
    | x::[] -> [x]
    | x::xs -> lastElement xs

let ienumToList (ienum:IEnumerable<_>) =
    List.ofSeq ienum

let xName s = XName.Get(s)
let readFile (path:string) searchedType =
        let xd = XDocument.Load path
        xd.Descendants <| xName searchedType |> ienumToList

let getAttrVal (ls:XAttribute list) = List.map (fun (x:XAttribute) -> x.Value) ls