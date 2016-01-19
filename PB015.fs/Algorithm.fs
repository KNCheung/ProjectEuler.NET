namespace ProjectEuler

type public Algorithm() = class
    let c n k= 
        let rec reducer (ns:List<uint64>) = 
            match ns with
            | [] -> [1UL]
            | [x] -> [x]
            | x::xs -> (x + xs.Head) :: (reducer xs)
        let nextLine lst = 1UL::(reducer lst)
        let rec iter n ans =
            if n = 0
            then ans
            else nextLine ans |> iter (n - 1)
        iter n [1UL] |> List.item k

    interface IAlgorithm with
        member this.Compute(): string = c 40 20 |> string
        member this.Prepare(): bool = true
    end
end
