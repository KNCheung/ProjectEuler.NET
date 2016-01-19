// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open ProjectEuler

type public Algorithm = 
    class
        interface IAlgorithm with
            member this.Compute(): string = "Hello World"
            member this.Prepare(): bool = true
        end
    end

[<EntryPoint>]
let main argv = 
    printfn "%s" "Hello World"
    0 // return an integer exit code
