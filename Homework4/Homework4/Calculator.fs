module Homework4.Calculator
let calculate value1 operation value2 =
    let value1d = value1 |> double
    let value2d = value2 |> double
    
    match operation with
    | CalculatorOperation.Plus -> value1d + value2d
    | CalculatorOperation.Minus -> value1d - value2d
    | CalculatorOperation.Divide -> value1d / value2d
    | _ -> value1d  * value2d