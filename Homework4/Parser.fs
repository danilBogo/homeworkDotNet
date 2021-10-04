module Homework4.Parser
open System
let isArgLengthSupported (args:string[]) = args.Length = 3
let isOperationSupported (arg:string) (operation: outref<CalculatorOperation>) =
    operation <- match arg with
    | "+" -> CalculatorOperation.Plus
    | "-" -> CalculatorOperation.Minus
    | "*" -> CalculatorOperation.Multiply
    | "/" -> CalculatorOperation.Divide
    | _ -> CalculatorOperation.UndefinedOperation
    operation <> CalculatorOperation.UndefinedOperation
let parseCalcArguments (args: string[])
                       (value1: outref<int>)
                       (operation: outref<CalculatorOperation>)
                       (value2: outref<int>) =
    let isInt1 = Int32.TryParse(args.[0], &value1)
    let isInt2 = Int32.TryParse(args.[2], &value2)
    
    if isOperationSupported args.[1] &operation = false then
        Message.WrongArgFormatOperation
    elif isArgLengthSupported args = false then
        Message.WrongArgLength
    elif isInt1 = false || isInt2 = false then
        Message.WrongArgFormat
    elif operation = CalculatorOperation.Divide && value2 = 0 then
        Message.DivideByZero
    else      
    Message.SuccessfulExecution
