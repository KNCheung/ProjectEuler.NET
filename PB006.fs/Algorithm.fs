namespace ProjectEuler

type public Algorithm() = class
    let square x = x * x

    let SumOfSquare n = 
        [1..n]
        |> List.map square
        |> List.sum

    let SquareOfSum n = 
        [1..n]
        |> List.sum
        |> square

    let ans n = (SquareOfSum n) - (SumOfSquare n)

    interface IAlgorithm with
        member this.Compute(): string = ans 100 |> string
        member this.Prepare(): bool = true
    end
end
