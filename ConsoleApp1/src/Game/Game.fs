module ConsoleApp1.Game.Game
open ConsoleApp1.Game.GameTypes

let rec createFood (map : (GameObject * Direction)[,]) =
    let rnd = System.Random()
    let x = rnd.Next(0, 18)
    let y = rnd.Next(0, 18)
    let obj, _ = map.[x, y]
    if obj = GameObject.Snake then
        createFood(map)
    else
        (x, y)
        
let createGameContext: GameContext =
    let map = Array2D.init 18 18 (fun _ _ -> (GameObject.Ground, Direction.None))
    map.[8, 8] <- (GameObject.Snake, Direction.Up)
    let foodX, foodY = createFood(map)
    map.[foodX, foodY] <- (GameObject.Food, Direction.None)
    { Map = map
      Direction = Direction.Up
      Position = (8, 8)
      Score = 0
      StepsLeft = 400
      Dead = false }

