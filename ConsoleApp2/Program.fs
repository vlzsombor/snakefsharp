open ConsoleApp2
open ConsoleApp2.GameType


let renderConsole (gameObject: GameObject) =
    ()
    for i = 0 to Array2D.length1 gameObject.Map - 1 do
        for j = 0 to Array2D.length2 gameObject.Map - 1 do
            let _, obj = gameObject.Map[i,j]
            
            match obj with
            | Food -> printf "f"
            | MapType.Ground -> printf "."
            | MapType.Snake -> printf "s"
            
            //printf "%a" gameObject.Map[i,j]
        printf "\n"
let rec createFood (xBorder, yBorder, map:(Direction * MapType)[,])=
    let r = System.Random()
    let x:int = r.Next(xBorder)
    let y:int = r.Next(yBorder)
    let _, t = map[x,y]
    if t = Snake || t = Food then
        createFood(xBorder,yBorder, map)
    else
        (x,y)

let borderX, borderY = 10, 14
let createMap =
    let map = Array2D.init borderX borderY (fun _ _ -> (Direction.None,GameType.Ground))
    map[borderX/2,borderY/2] <- (None, Snake)
    let fX, fY = createFood(borderX, borderY, map)
    map[fX,fY] <- (None, Food)
    map
    
let g:GameObject =  {
      Map = createMap
      Direction = Direction.Up
}

[<EntryPoint>]
let main args =
    renderConsole g
    
    
    0
    