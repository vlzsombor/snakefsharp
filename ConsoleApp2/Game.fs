module ConsoleApp2.Game

open ConsoleApp2.GameType

let borderX, borderY = 16, 16
let rec createFood (xBorder, yBorder, map:(Direction * MapType)[,])=
    let r = System.Random()
    let x:int = r.Next(xBorder)
    let y:int = r.Next(yBorder)
    let _, t = map[x,y]
    if t = Snake || t = Food then
        createFood(xBorder,yBorder, map)
    else
        (x,y)
let createMap =
    let map = Array2D.init borderX borderY (fun _ _ -> (Direction.None,GameType.Ground))
    map[borderX/2,borderY/2] <- (Up, Snake)
    let fX, fY = createFood(borderX, borderY, map)
    map[fX,fY] <- (None, Food)
    map
let rec findTail(map : (Direction * MapType)[,],(x, y) : int * int) =
    let dir, _ = map.[x,y]
    
    let newX, newY =
        match dir with
            | Up -> (x+1, y)
            | Down -> (x-1, y)
            | Right -> (x, y-1)
            | Left -> (x, y+1)
            | _ -> (x,y)

    let _, obj = map[newX, newY]
    
    if obj = Snake then
        findTail (map, (newX, newY))
    else
        (x, y)
    
let modifyHitFood (gameObj: GameObject, x, y, direction: Direction) = 
    gameObj.Map[x,y] <- (direction, Snake)
    let foodX, foodY = createFood(borderX, borderY, gameObj.Map)
    gameObj.Map[foodX, foodY] <- (None, Food)
    gameObj.Map

let modifyHitGround (gameObj: GameObject, x, y, direction: Direction) =
    gameObj.Map[x, y] <- (direction, Snake)
    let tailX, tailY = findTail(gameObj.Map, (x, y))
    gameObj.Map[tailX, tailY] <- (None, Ground)
    gameObj.Map
    
let gameLoop (gameObject:GameObject) =
    if gameObject.StepsLeft <= 0 then
        {gameObject with Dead = true}
    else
        let x, y = gameObject.Position
        let newX, newY =
            match gameObject.Direction with
            | Direction.Up -> (x - 1, y)
            | Direction.Down -> (x + 1, y)
            | Direction.Right -> (x, y + 1)
            | Direction.Left -> (x, y - 1)
            | _ -> (x,y)
        try
            let _,obj = gameObject.Map[newX, newY]
            
            match obj with
            | Snake -> { gameObject with Dead = true }
            | Food -> { gameObject with
                            Score = gameObject.Score + 1
                            Position = (newX, newY)
                            StepsLeft = gameObject.StepsLeft + 1000
                            Map = modifyHitFood(gameObject, newX, newY, gameObject.Direction)
                         }
            | Ground -> { gameObject with
                            StepsLeft = gameObject.StepsLeft - 1
                            Position = (newX, newY)
                            Map = modifyHitGround(gameObject, newX, newY, gameObject.Direction)
                         }
            | _ -> gameObject
        with
        | :? System.IndexOutOfRangeException -> { gameObject with Dead = true }
    
    
let init =  {
        Map = createMap
        Direction = Up
        StepsLeft = 25
        Dead = false
        Position = (borderX/2, borderY/2)
        Score = 0
    }