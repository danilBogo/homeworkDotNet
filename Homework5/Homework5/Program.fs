module Homework5.Program

[<EntryPoint>]
let main args =
    let check = Parser.parseCalcArguments args
    match check with
    | Ok resultOk -> printf $"Result is: {Calculator.calculate resultOk}"
                     int Message.SuccessfulExecution
    | Error resultError -> printf $"Error is: {resultError}"
                           int resultError
