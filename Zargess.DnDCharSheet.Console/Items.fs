module Items 

open Money
open Util
open Stats
open System
open System.Xml.Linq

type Dice = { name:string; quantity:int }
 
type Item = 
    | Armor of name:string * description:string * ac:int * weight:int * value:Coin list
    | Weapon of name:string * description:string * dmg:Dice * magic:int * stat:Stat * weight:int * value:Coin list
    | Ammonition of name:string * weight:int * value:Coin list
    | Other of name:string * description:string * weight:int * value:Coin list   

let stringToDice (s:string) =
    let quan = int(s.[0])
    let name = s.Remove(1)
    { name=name; quantity=quan }

module ItemCreator =

    let saveItem i =
        // Somehow save the item in the "knownItems.xml" file
        i

    let knownItem i =
        // Some how check if the given item is in the "knownItems.xml" file
        true

    let constructArmor (attrs:string list) = 
        let name = attrs.[1]
        let desc = attrs.[2]
        let ac = int attrs.[3]
        let weight = int attrs.[4]
        let value = stringToCoins attrs.[5]
        Armor(name,desc,ac,weight,value)
          
    let constructWeapon path (attrs:string list) = 
        let name = attrs.[1]
        let desc = attrs.[2]
        let dmg = stringToDice attrs.[3]
        let magic = int attrs.[4]
        let stat = loadStat path attrs.[5]
        let weight = int attrs.[6]
        let value = stringToCoins attrs.[7]
        Weapon(name,desc,dmg,magic,stat,weight,value)  
          
    let constructAmmonition (attrs:string list) = 
        let name = attrs.[1]
        let weight = int attrs.[2]
        let value = stringToCoins attrs.[3]
        Ammonition(name,weight,value)
          
    let constructOther (attrs:string list) = 
        let name = attrs.[1]
        let desc = attrs.[2]
        let weight = int attrs.[3]
        let value = stringToCoins attrs.[4]
        Other(name, desc, weight, value)            

    let rec constructItems (attr:XAttribute list list) ls =
        match attr with
        | [] -> ls
        | first::rest ->
            let a = getAttrVal first
            let t = a.[0]
            let item = match t with
                       | "Armor" -> constructArmor a
                       | "Weapon" -> constructWeapon @"C:\Users\MFH\Dropbox\Programmering\Character.xml" a
                       | "Ammonition" -> constructAmmonition a
                       | "Other" -> constructOther a
                       | _ -> failwith "Not an item"
            let list = item::ls
            constructItems rest list

    let readItems path =
        let elements = readFile path "Item"
        let items = List.map (fun (x:XElement) -> x.Attributes() |> ienumToList) elements |> ienumToList
        constructItems items []