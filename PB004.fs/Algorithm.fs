namespace ProjectEuler

type public Algorithm() = class
    let isPalindrome (str:string) = 
        let n = str.Length
        match str with 
        | "" -> true
        | _ -> seq {0..(n >>> 1)}
            |> Seq.exists (fun i -> str.[i] <> str.[n - i - 1])
            |> not

    let run =
        seq {for i in 100..999 do
                for j in i..999 -> i * j}
        |> Seq.sortDescending
        |> Seq.map string
        |> Seq.filter isPalindrome
        |> Seq.head

    interface IAlgorithm with
        member this.Compute(): string = run |> string
        member this.Prepare(): bool = true
    end
end
