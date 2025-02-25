module ConsoleApp2.GameType

type Direction = Up | Down | Right | Left | None
type MapType = Snake | Ground | Food

type GameObject = {
    Map: (Direction * MapType)[,]
    Direction: Direction
    StepsLeft: int
    Dead: bool
    Position: int * int
    Score: int
}