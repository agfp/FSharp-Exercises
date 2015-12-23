// The Secret Santa Problem by Yan Cui
//
// As I walked down Oxford Street the other day, it’s hard to miss all the Christmas decorations everywhere. Many of the
// shops are already running Christmas sales, and HR departments up and down the country are busy booking venues for 
// Christmas parties. With the imminent arrival of Christmas, another time honoured office tradition will soon come to 
// pass – Secret Santa. Which means now is the perfect time to solve the Secret Santa problem, in F# of course :)

// The Rules
//
// 1) Each person must give and receive a present
// 2) People can only give present to someone who is not in their family (i.e. same surname)
// 3) The names are: Toby Blair, Ian Smith, Martin Kelly, Kate Kelly, John Smith, Bruno Tavares, Vicky Chen, Sarah Kelly, 
//    Mark Kelly and Ajay Singh.

open System
open System.Collections.Generic
open System.Linq

let names = List.toSeq <| ["Toby Blair"; "Ian Smith"; "Martin Kelly"; "Kate Kelly"; "John Smith"; "Bruno Tavares"; "Vicky Chen"; "Sarah Kelly"; "Mark Kelly"; "Ajay Singh"]
let surname (name:string) = name.Split().Last()

let sortedBySurname names =
    names
    |> Seq.groupBy surname
    |> Seq.sortByDescending (snd >> Seq.length)
    |> Seq.collect snd

let secretSanta names =
    let queue = new Queue<string>()
    for name in (sortedBySurname names) do
        if queue.Count = 0 || (surname <| queue.Peek()) = (surname name) then
            queue.Enqueue name
        else
            let giftee = queue.Dequeue()
            printfn "%s <-> %s" name giftee
    
secretSanta names
Console.ReadKey() |> ignore
