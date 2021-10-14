module Homework5.MaybeBuilder

type MaybeBuilder() =
    member builder.Bind(a, f) =
        match a with
        | Ok resultOk -> f resultOk
        | Error resultError  -> Error resultError
    member builder.Return x = Ok x
let maybe = MaybeBuilder()