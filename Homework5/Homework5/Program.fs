module Homework5.Program

[<EntryPoint>]
let main args =
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operation = CalculatorOperation.Plus
    
    let check = Parser.parseCalcArguments args &val1 &operation &val2
    if check <> Message.SuccessfulExecution then int check
    else
        printf $"Result is: {Calculator.calculate val1 operation val2}"
        0