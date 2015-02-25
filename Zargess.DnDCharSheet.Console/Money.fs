module Money

open Util

type Coin       =       { name:string; key:char; value:int }
let copper      =       { name="Copper"; key='c'; value=1 }
let silver      =       { name="Silver"; key='s'; value=10 }
let electrum    =       { name="Electrum"; key='e'; value=50 }
let gold        =       { name="Gold"; key='g'; value=100 }
let platin      =       { name="Platinum"; key='p'; value=1000 }
let coinTypes   =       [ copper; silver; electrum; gold; platin ]

let rec generatecoins key count ls =
    match count with
        | x when x <= 0 -> ls
        | _ ->
            let coin = List.filter (fun x -> x.key = key) coinTypes |> List.head
            let list = coin::ls
            let counter = count - 1
            generatecoins key counter list

let getCoins ls = 
    let last = lastElement ls |> List.head
    let amount =
        List.filter (fun x -> x <> last) ls
        |> List.map (fun x -> string(x)) 
        |> String.concat ""
        |> int
    generatecoins last amount []

let stringToCoins (s:string) =
    match s with
    | "" -> []
    | _ ->
        s.Split(' ')
        |> Array.toList
        |> List.map (fun x -> x.ToCharArray() |> Array.toList)
        |> List.map getCoins
        |> List.concat

let countCoins ls key =
    List.filter (fun x -> x.key = key) ls |> List.length

let coinsToString ls =
    let count = countCoins ls
    let copper = count 'c'
    let silver = count 's'
    let electrum = count 'e'
    let gold = count 'g'
    let platin = count 'p'
    string(platin) + "p " + string(gold) + "g " + string(electrum) + "e " + string(silver) + "s " + string(copper) + "c"

let rec totalValue ls sofar =
    match ls with
    | [] -> sofar
    | car::cdr ->
        let v = sofar + car.value
        totalValue cdr v

// TODO : See if this can be done in a better way
let coparecoinlists owned other =
    let ownedamount = totalValue owned 0
    let otheramount = totalValue other 0
    ownedamount - otheramount