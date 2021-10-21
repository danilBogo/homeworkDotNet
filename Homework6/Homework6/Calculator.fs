module Homework6.Calculator

open Homework6.InputExpression

let calculate expression =
    match expression.operation with
    | CalculatorOperation.Plus -> expression.value1 + expression.value2
    | CalculatorOperation.Minus -> expression.value1 - expression.value2
    | CalculatorOperation.Divide -> expression.value1 / expression.value2
    | _ -> expression.value1  * expression.value2

//let calculate InputExpression =
//    let divide numerator denominator =
//        if denominator = decimal 0 then
//            Error "Dividing by zero"
//        else
//            Ok(numerator / denominator)
//            
//        let result = MaybeBuilder()
//        
//        result {
//            match expression.operation with
//            | CalculatorOperation.Plus -> return expression.value1 + expression.value2
//            | CalculatorOperation.Minus -> return expression.value1 - expression.value2
//            | CalculatorOperation.Divide -> return expression.value1 |> divide expression.value2
//            | _ -> return expression.value1  * expression.value2
//        }
            
//let calculate (val1, op, val2) =
//    let divideBy bottom top =
//        if bottom = decimal 0 then
//            Error "Divide by zero"
//        else
//            Ok(top / bottom)
//
//    let result = ResultBuilder()
//
//    result {
//        match op with
//        | Operation.Plus -> return val1 + val2
//        | Operation.Minus -> return val1 - val2
//        | Operation.Multiply -> return val1 * val2
//        | Operation.Divide ->
//            let! r = val1 |> divideBy val2
//            return r
//    }
    
//let calculate expression =
//    match expression.operation with
//    | CalculatorOperation.Plus -> expression.value1 + expression.value2
//    | CalculatorOperation.Minus -> expression.value1 - expression.value2
//    | CalculatorOperation.Divide -> expression.value1 / expression.value2
//    | _ -> expression.value1  * expression.value2