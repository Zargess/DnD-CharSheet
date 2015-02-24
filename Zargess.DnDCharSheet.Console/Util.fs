module Util

open System.Xml
open System.Collections.Generic
open System.Xml.Linq

let sheetpath = @"C:\Users\Marcus\Dropbox\Programmering\Character.xml"
let knownitemspath = @"C:\Users\Marcus\Dropbox\Programmering\knownItems.xml"

let rec lastElement ls =
    match ls with
    | [] -> []
    | x::[] -> [x]
    | x::xs -> lastElement xs

let ienumToList (ienum:IEnumerable<_>) = List.ofSeq ienum

let xName s = XName.Get(s)
let readFile (path:string) searchedType =
        let xd = XDocument.Load path
        xName searchedType
        |> xd.Descendants 
        |> ienumToList

let getAttrVal (ls:XAttribute list) = List.map (fun (x:XAttribute) -> x.Value) ls

let getAttributes path tagname =
    readFile path tagname
    |> List.map (fun x -> x.Attributes() |> ienumToList)
    |> List.concat

// TODO : This does not work
let findAttributeNames attributes name =
    List.filter (fun (x:XAttribute) -> x.Name.LocalName.Equals(name)) attributes
    |> getAttrVal