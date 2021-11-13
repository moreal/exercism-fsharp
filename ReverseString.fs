module ReverseString

let reverse: (string -> string) = Seq.rev >> Seq.toArray >> System.String
