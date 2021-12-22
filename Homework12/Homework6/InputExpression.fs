namespace Homework6.InputExpression

open Homework6

[<CLIMutable>]
type InputExpression = {
    value1: decimal
    operation: CalculatorOperation 
    value2:decimal
}