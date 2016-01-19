// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open ProjectEuler

type public Algorithm = 
    class
        interface IProblem with
            member this.compute(): string = "Hello World"
            member this.prepare(): bool = true
        end
    end

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
