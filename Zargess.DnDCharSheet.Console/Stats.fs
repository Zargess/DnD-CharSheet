﻿module Stats

open Util
open System.Xml.Linq

type Stat = { name:string; score:int; modifier:int }

let calcModifier score = -5 + score / 2

let rec createStats list ls =
    match list with
    | [] -> ls
    | head::tail ->
        let name, value, modifier = head
        let stat = { name = name; score = value; modifier = modifier }
        createStats tail (stat::ls)

let stats =
    let attributes = getAttributes sheetpath "Stat"
    let search = findAttributeValues attributes
    let names = search "name"
    let values = List.map (fun x -> int x) (search "score")
    let modifiers = List.map calcModifier values
    let statlist = List.zip3 names values modifiers
    List.rev (createStats statlist [])


let findStat name = ()