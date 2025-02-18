// For more information see https://aka.ms/fsharp-console-apps
open System

open ConsoleApp1.Game
open bfile


type GameObject = Ground | Snake | Food

type Direction = Up | Down | Left | Right | None



let rec asd (gameContext:(GameObject * Direction)) =
    let a = gameContext.ToValueTuple()
    let x d = gameContext.Deconstruct()
    a.ToTuple()
    let c = fst gameContext
    printfn "xxxx"
    0
[<EntryPoint>]
let main argv =
    //let aaa = (GameObject.Snake, Direction.Down)
    //let b = [aaa,aaa]
    Renderer.renderMap()

    //let b = asd aaa
    0
