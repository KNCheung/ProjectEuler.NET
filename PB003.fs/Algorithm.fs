namespace ProjectEuler

type public Algorithm() = class
    let isPrime (n:int) = 
        let rec iter (n:int) (x:int) = 
            if x > (n |> double |> sqrt |> int)
            then true
            elif n % x = 0
            then false
            else iter n (x + 2)
        if n = 2
        then true
        elif (n &&& 1= 0) || (n < 2)
        then false
        else iter n 3


    let getMaxPrimeFactor (n:uint64) =
        seq {2..(n |> double |> sqrt |> int |> (+) 1)}
        |> Seq.filter (fun (x:int) -> n % (x |> uint64) = 0UL) 
        |> Seq.filter isPrime
        |> Seq.max

    interface IAlgorithm with
        member this.Compute(): string = getMaxPrimeFactor 600851475143UL |> string
        member this.Prepare(): bool = true
    end
end
