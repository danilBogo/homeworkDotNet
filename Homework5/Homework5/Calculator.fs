module Homework5.Calculator

let calculate (arg1: decimal, operation: CalculatorOperation, arg2: decimal) =
    match operation with
    | CalculatorOperation.Plus -> arg1 + arg2
    | CalculatorOperation.Minus -> arg1 - arg2
    | CalculatorOperation.Divide -> arg1 / arg2
    | _ -> arg1  * arg2