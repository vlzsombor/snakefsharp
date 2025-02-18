module ConsoleApp1.Game.Renderer

open snake.f.console.GameTypes


let renderMap ()=
    for x = 0 to 16 - 1 do
        for y = 0 to 16 - 1 do
            printf "."
        printf "\n"
