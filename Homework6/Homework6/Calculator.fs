module Homework6.Calculator

open Homework6.InputExpression

let calculate expression =
    match expression.operation with
    | CalculatorOperation.Plus -> expression.value1 + expression.value2
    | CalculatorOperation.Minus -> expression.value1 - expression.value2
    | CalculatorOperation.Divide -> expression.value1 / expression.value2
    | _ -> expression.value1  * expression.value2
