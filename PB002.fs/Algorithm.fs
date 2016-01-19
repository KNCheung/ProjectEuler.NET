namespace ProjectEuler

type public Algorithm() = class
    let fibonacci = 
        let rec iter a b =
            seq {
                yield a
                yield! iter b (a + b)
            }
        iter 1 2

    let run = 
        fibonacci 
        |> Seq.takeWhile (fun (x) -> (x <= 4000000))
        |> Seq.filter (fun (x) -> ((x &&& 1) = 0))
        |> Seq.sum
 
    interface IAlgorithm with
        member this.Compute(): string = run.ToString()
        member this.Prepare(): bool = true
    end
end
