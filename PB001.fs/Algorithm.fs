namespace ProjectEuler

type public Algorithm() = class
    let run = 
        seq {1..1000}
        |> Seq.filter (fun (x) -> ((x % 3 = 0) || (x % 5 = 0)))
        |> Seq.sum

    interface IAlgorithm with
        member this.Compute(): string = run |> string
        member this.Prepare(): bool = true
    end
end
