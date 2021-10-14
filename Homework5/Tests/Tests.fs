module Tests.Tests

open Xunit
open Homework5

[<Theory>]
[<InlineData(10, 5, 15)>]
[<InlineData(1.9, 5, 6.9)>]
[<InlineData(1.9, 5.9, 7.8)>]
[<InlineData(1.009, 5.9, 6.909)>]
[<InlineData(-1.9, 5.9, 4)>]
let ``TestCalculatorAddition`` (value1 : decimal, value2 : decimal, expectedResult : decimal) =
    let result = Calculator.calculate (value1, CalculatorOperation.Plus, value2)
    Assert.Equal(expectedResult, result)
    
[<Theory>]
[<InlineData(10, 5, 5)>]
[<InlineData(1.9, 5, -3.1)>]
[<InlineData(1.9, 5.9, -4)>]
[<InlineData(5.9, 1.9, 4)>]
let ``TestCalculatorSubstraction`` (value1 : decimal, value2 : decimal, expectedResult : decimal) =
    let result = Calculator.calculate (value1, CalculatorOperation.Minus, value2)
    Assert.Equal(expectedResult, result)
    
[<Theory>]
[<InlineData(10, 5, 50)>]
[<InlineData(10, 5.0, 50)>]
[<InlineData(10, 5.1, 51)>]
[<InlineData(10.1, 5.1, 51.51)>]
[<InlineData(-10, -5, 50)>]
[<InlineData(-10, 5, -50)>]    
let ``TestCalculatorMultiplication`` (value1 : decimal, value2 : decimal, expectedResult : decimal) =
    let result = Calculator.calculate (value1, CalculatorOperation.Multiply, value2)
    Assert.Equal(expectedResult, result)
    
[<Theory>]
[<InlineData(10, 5, 2)>]
[<InlineData(10.5, 5, 2.1)>]
[<InlineData(10.2, 5.1, 2)>]
[<InlineData(-10.2, 5.1, -2)>]
[<InlineData(10.2, -5.1, -2)>]
[<InlineData(-10.2, -5.1, 2)>]
[<InlineData(26.52, 5.1, 5.2)>]
let ``TestCalculatorDivision`` (value1 : decimal, value2 : decimal, expectedResult : decimal) =
    let result = Calculator.calculate (value1, CalculatorOperation.Divide, value2)
    Assert.Equal(expectedResult, result)

    
[<Theory>]
[<InlineData("f", "+", "3")>]
[<InlineData("3", "+", "f")>]
[<InlineData("a", "+", "f")>]
let ``TestParserWrongValue`` (value1, operation, value2) =
    let args = [|value1;operation;value2|]
    let result = Parser.parseCalcArguments args
    match result with
    | Error resultError -> Assert.Equal(resultError, Message.WrongArgFormat)
    

[<Fact>]
let ``TestParserWrongOperation`` () =
    let args = [|"3";".";"4"|]
    let result = Parser.parseCalcArguments args
    match result with
    | Error resultError -> Assert.Equal(resultError, Message.WrongArgFormatOperation)

[<Fact>]
let ``TestParserWrongLength`` () =
    let args = [|"3";"+";"4";"5"|]
    let result = Parser.parseCalcArguments args
    match result with
    | Error resultError -> Assert.Equal(resultError, Message.WrongArgLength)

[<Theory>]
[<InlineData("f", ".", "3")>]
[<InlineData("3", ".", "f")>]
[<InlineData("a", ".", "f")>]
let ``TestParserWrongOperationAndWrongValue`` (value1, operation, value2) =
    let args = [|value1;operation;value2|]
    let result = Parser.parseCalcArguments args
    match result with
    | Error resultError -> Assert.Equal(resultError, Message.WrongArgFormat)
    
[<Theory>]
[<InlineData("4", "+", "3", 4, CalculatorOperation.Plus, 3)>]
[<InlineData("4", "-", "3", 4, CalculatorOperation.Minus, 3)>]
[<InlineData("4", "*", "3", 4, CalculatorOperation.Multiply, 3)>]
[<InlineData("4", "/", "3", 4, CalculatorOperation.Divide, 3)>]
[<InlineData("4.2", "+", "3", 4.2, CalculatorOperation.Plus, 3)>]
[<InlineData("4.2", "-", "3", 4.2, CalculatorOperation.Minus, 3)>]
[<InlineData("4.2", "*", "3", 4.2, CalculatorOperation.Multiply, 3)>]
[<InlineData("4.2", "/", "3", 4.2, CalculatorOperation.Divide, 3)>]
let ``TestParserCorrectOperationAndCorrectValues`` (value1, operation, value2, arg1, calcOperation, arg2) =
    let values = [|value1;operation;value2|]
    let result = Parser.parseCalcArguments values
    match result with
    | Ok resultOk -> Assert.Equal(arg1, resultOk.Item1)
    
[<Fact>]
let ``TestParserDividingByZero`` () =
    let args = [|"3";"/";"0"|]
    let result = Parser.parseCalcArguments args
    match result with
    | Error resultError -> Assert.Equal(resultError, Message.DivideByZero)
    
[<Theory>]
[<InlineData("4", "+", "3", 4, CalculatorOperation.Plus, 3)>]
[<InlineData("4", "-", "3", 4, CalculatorOperation.Minus, 3)>]
[<InlineData("4", "*", "3", 4, CalculatorOperation.Multiply, 3)>]
[<InlineData("4", "/", "3", 4, CalculatorOperation.Divide, 3)>]
[<InlineData("4.2", "+", "3", 4.2, CalculatorOperation.Plus, 3)>]
[<InlineData("4.2", "-", "3", 4.2, CalculatorOperation.Minus, 3)>]
[<InlineData("4.2", "*", "3", 4.2, CalculatorOperation.Multiply, 3)>]
[<InlineData("4.2", "/", "3", 4.2, CalculatorOperation.Divide, 3)>]
let ``TestMainCorrectOperationAndCorrectValues`` (value1, operation, value2, arg1, calcOperation, arg2) =
    let args = [|value1;operation;value2|]
    let result = Program.main args
    Assert.Equal(int Message.SuccessfulExecution, result)
    
[<Theory>]
[<InlineData("f", ".", "3")>]
[<InlineData("3", ".", "f")>]
[<InlineData("a", ".", "f")>]
let ``TestMainWrongOperationAndWrongValue`` (value1, operation, value2) =
    let args = [|value1;operation;value2|]
    let result = Program.main args
    Assert.Equal(int Message.WrongArgFormat, result)
    
[<Theory>]
[<InlineData("f", "+", "3")>]
[<InlineData("3", "+", "f")>]
[<InlineData("a", "+", "f")>]
let ``TestMainWrongValue`` (value1, operation, value2) =
    let args = [|value1;operation;value2|]
    let result = Program.main args
    Assert.Equal(int Message.WrongArgFormat, result)
    
[<Fact>]
let ``TestMainWrongLength`` () =
    let args = [|"3";"+";"4";"5"|]
    let result = Program.main args
    Assert.Equal(int Message.WrongArgLength, result)
    
[<Fact>]
let ``TestMainDividingByZero`` () =
    let args = [|"3";"/";"0";|]
    let result = Program.main args
    Assert.Equal(int Message.DivideByZero, result)