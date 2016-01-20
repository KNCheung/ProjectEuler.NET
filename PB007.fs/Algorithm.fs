namespace ProjectEuler

type public Algorithm() = class
    let isPrime n = TroyMath.isPrime(n)

    let nthPrime n = 
        Seq.initInfinite id
        |> Seq.filter isPrime
        |> Seq.item (n - 1)

    interface IAlgorithm with
        member this.Compute(): string = nthPrime 10001 |> string
        member this.Prepare(): bool = true
    end
end
