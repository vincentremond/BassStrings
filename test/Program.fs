// Learn more about F# at http://fsharp.org

open System

type Octave =
  | SubSubContra
  | SubContra
  | Contra
  | Great
  | Small
  | OneLined
  | TwoLined
  | ThreeLined
  | FourLined
  | FiveLined
  | SixLined
  | SevenLined

let octaveFromHeight ht: Octave =
  match ht with
  | -1 -> SubSubContra
  | 0 -> SubContra
  | 1 -> Contra
  | 2 -> Great
  | 3 -> Small
  | 4 -> OneLined
  | 5 -> TwoLined
  | 6 -> ThreeLined
  | 7 -> FourLined
  | 8 -> FiveLined
  | 9 -> SixLined
  | 10 -> SevenLined
  | _ -> failwith "Octave inconnue ?"

type Altération =
  | Bécarre
//  | Bémol
  | Dièse

type NomNote =
  | Do
  | Ré
  | Mi
  | Fa
  | Sol
  | La
  | Si

type NomNoteUs =
  | C
  | D
  | E
  | F
  | G
  | A
  | B

let nameFrFromUs n =
  match n with
  | C -> Do
  | D -> Ré
  | E -> Mi
  | F -> Fa
  | G -> Sol
  | A -> La
  | B -> Si

type Note = NomNote * Altération * Octave

let incrémenteDemiTon (note: Note): Note =
  match note with
  | (Do, Bécarre, x) -> (Do, Dièse, x)
  | (Do, Dièse, x) -> (Ré, Bécarre, x)
  | (Ré, Bécarre, x) -> (Ré, Bécarre, x)

  


let cordes: Note [] =
  [| ((nameFrFromUs B), Bécarre, (octaveFromHeight 0))
     ((nameFrFromUs E), Bécarre, (octaveFromHeight 1))
     ((nameFrFromUs A), Bécarre, (octaveFromHeight 1))
     ((nameFrFromUs D), Bécarre, (octaveFromHeight 2))
     ((nameFrFromUs G), Bécarre, (octaveFromHeight 2)) |]

[<EntryPoint>]
let main argv =
  let test = cordes |> Seq.map incrémenteDemiTon
  printfn "%A" cordes
  0 // return an integer exit code
