module ConsoleApp1.Game.Game
open ConsoleApp1.Game.GameTypes

let createGameContext: GameContext =
    let map = Array2D.init 18 18 (fun _ _ -> (GameObject.Ground, Direction.None))
    map.[8, 8] <- (GameObject.Snake, Direction.Up)
    let foodX, foodY = 9,9
    map.[foodX, foodY] <- (GameObject.Food, Direction.None)
    { Map = map
      Direction = Direction.Up
      Position = (8, 8)
      Score = 0
      StepsLeft = 400
      Dead = false }

