open System
open Util
open Money
open Items

type Dice = { name:string; quantity:int }
type Stat = { name:string; score:int; modifier:int }
 
type Item = 
    | Armor of name:string * description:string * ac:int * amount:int * weight:int * value:Coin list
    | Weapon of name:string * description:string * dmg:Dice * magic:int * stat:Stat * amount:int * weight:int * value:Coin list
    | Ammonition of name:string * amount:int *  weight:int * value:Coin list
    | Other of name:string * description:string * amount:int * weight:int * value:Coin list

type Container = 
    | Inventory of Item list

[<EntryPoint>]
let main argv = 
    let a = stringToCoins "19p 19g 13s"
//    printfn "%A" a
    //coinsToString a |> stringToCoins |> printfn "%A"
    let foo = ItemCreator.readItems @"C:\Users\MFH\Dropbox\Programmering\knownItems.xml"
    foo |> printfn "%A"
    Console.ReadLine() |> ignore
    0 // return an integer exit code
