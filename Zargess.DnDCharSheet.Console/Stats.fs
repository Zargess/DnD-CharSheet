module Stats

open Util
open System.Xml.Linq

type Stat = { name:string; score:int; modifier:int }

let calcModifier score = -5 + score / 2

let loadStat path name =
    let element = 
        readFile path "Stat"
        |> List.map (fun (x:XElement) -> x.Attributes() |> ienumToList) 
        
    let q = List.find (fun (x:XAttribute list) -> x.[0].Value = name) element
    let modifier = calcModifier (int q.[1].Value)
    { name=name; score= int q.[1].Value; modifier=modifier; }

let stats =
    let attributes = getAttributes sheetpath "Stat"
    let names = findAttributeNames attributes "name"
    names

let findStat name = ()