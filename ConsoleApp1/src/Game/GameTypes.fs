module ConsoleApp1.Game.GameTypes

type GameObject = Ground | Snake | Food

type Direction = Up | Down | Right | Left | None

type GameContext = {
    Map: (GameObject * Direction)
    Direction: Direction
    Position: int * int
    Score: int
    StepsLeft: int
    Dead: bool
}