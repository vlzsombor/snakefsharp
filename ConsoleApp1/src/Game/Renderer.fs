module ConsoleApp1.Game.Renderer

open ConsoleApp1.Game.GameTypes

let renderMap (map : (GameObject * Direction)[,], score : int, steps : int)=
    for x = 0 to Array2D.length1 map - 1 do
        for y = 0 to Array2D.length1 map - 1 do
            printf "."
        printf "\n"
    printfn $"Score: %d{score}"
    printfn $"Steps left: %d{steps}"
