module Homework5.Parser

open System
open MaybeBuilder
let isArgLengthSupported (args:string[]) =
    match args.Length with
    | 3 -> Ok args
    | _ -> Error Message.WrongArgLength
let isOperationSupported (arg1: decimal, operation: string, arg2: decimal) =
    match operation with
        | "+" -> Ok (arg1, CalculatorOperation.Plus, arg2)
        | "-" -> Ok (arg1, CalculatorOperation.Minus, arg2)
        | "*" -> Ok (arg1, CalculatorOperation.Multiply, arg2)
        | "/" -> Ok (arg1, CalculatorOperation.Divide, arg2)
        | _ -> Error Message.WrongArgFormatOperation

let parseArgs (args: string[]) =
    try Ok (args.[0] |> decimal, args.[1], args.[2] |> decimal)
    with | _ -> Error Message.WrongArgFormat
    
let isDividingByZero (arg1: decimal, operation: CalculatorOperation, arg2: decimal) = 
    match operation with
    | CalculatorOperation.Divide when arg2 = Decimal.Zero -> Error Message.DivideByZero
    | _ -> Ok (arg1, operation, arg2)
let parseCalcArguments (args: string[]) =
    maybe {
        let! checkArgLength = isArgLengthSupported args
        let! tryParseArgs = parseArgs checkArgLength
        let! checkOperation = isOperationSupported tryParseArgs
        let! checkDividingByZero = isDividingByZero checkOperation
        return checkDividingByZero
    }