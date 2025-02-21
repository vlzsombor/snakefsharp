// For more information see https://aka.ms/fsharp-console-apps
open System
open ConsoleApp1.Game
open ConsoleApp1.Game.GameTypes
open ConsoleApp1.Game.Renderer


let rec fbn x =
    if x < 2 then
        1
    else
        fbn(x - 1) + fbn(x - 2) 

let rec main (gameContext:GameContext) =
    let a = fbn(5);
    printfn "%d" a
        // Console.Clear()
    // if false then Environment.Exit 55
    // let map:(GameObject * Direction)[,] = Array2D.init 18 18 (fun _ _ -> (GameObject.Ground, Direction.None))
    // renderMap(map, 3,3)
    // Threading.Thread.Sleep(200)
    // if Console.KeyAvailable then
    //     match Console.ReadKey().Key with
    //     | ConsoleKey.Q -> Environment.Exit 55
    //     | _ -> ()
    0

[<EntryPoint>]
main Game.createGameContext |> ignore