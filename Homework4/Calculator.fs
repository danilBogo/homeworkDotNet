module Homework4.Calculator
let calculate val1 operation val2 =
    let val1d = val1 |> double
    let val2d = val2 |> double
    
    match operation with
    | CalculatorOperation.Plus -> val1d + val2d
    | CalculatorOperation.Minus -> val1d - val2d
    | CalculatorOperation.Divide -> val1d / val2d
    | _ -> val1d  * val2d