open ConsoleApp2
open ConsoleApp2.GameType


let renderConsol (gameObject: GameObject) =
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

let createMap =
    let map = Array2D.init 18 18 (fun _ _ -> (Direction.None,GameType.Ground))
    map[8,8] <- (None, Snake)
    map[10,8] <- (None, Snake)
    map
    
let g:GameObject =  {
      Map = createMap
      Direction = Direction.Up
}

[<EntryPoint>]
let main args =
    
    renderConsol g
    0
    