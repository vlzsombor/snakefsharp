open ConsoleApp2
open ConsoleApp2.GameType
open System
open Game

let renderMap (map : (Direction * MapType)[,], score : int, steps : int) =
    for x = 0 to Array2D.length2 map - 1 do
        for y = 0 to Array2D.length1 map - 1 do
            let _,obj = map.[x, y]
            match obj with
            | Snake -> printf "S"
            | Food -> printf "F"
            | Ground -> printf "."
        printf "\n"
    printfn $"Score: %d{score}"
    printfn $"Steps left: %d{steps}"
        
let rec main (gameContext:GameObject) =
    if gameContext.Dead then Environment.Exit 55

    Console.Clear()
    renderMap(gameContext.Map, gameContext.Score, gameContext.StepsLeft)

    
    Threading.Thread.Sleep(200)
    if Console.KeyAvailable then
        match Console.ReadKey().Key with
        | ConsoleKey.Q -> Environment.Exit 55
        | ConsoleKey.W ->
            main (Game.gameLoop({ gameContext with Direction = Direction.Up }))
        | ConsoleKey.S ->
            main (Game.gameLoop({ gameContext with Direction = Direction.Down }))
        | ConsoleKey.A ->
            main (Game.gameLoop({ gameContext with Direction = Direction.Left }))
        | ConsoleKey.D ->
            main (Game.gameLoop({ gameContext with Direction = Direction.Right }))
        | _ -> main (Game.gameLoop(gameContext))
    else
        main gameContext
    
[<EntryPoint>]
main Game.init
    
    