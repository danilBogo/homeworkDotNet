module Tests.Tests

open Xunit
open Homework4

[<Theory>]
[<InlineData(10, 5, 15)>]
let ``TestCalculatorAddition`` (value1, value2, expectedResult) =
    let result = Calculator.calculate value1 CalculatorOperation.Plus value2
    Assert.Equal(expectedResult, result)
    
[<Theory>]
[<InlineData(10, 5, 5)>]    
let ``TestCalculatorSubstraction`` (value1, value2, expectedResult) =
    let result = Calculator.calculate value1 CalculatorOperation.Minus value2
    Assert.Equal(expectedResult, result)
    
[<Theory>]
[<InlineData(10, 5, 50)>]    
let ``TestCalculatorMultiplication`` (value1, value2, expectedResult) =
    let result = Calculator.calculate value1 CalculatorOperation.Multiply value2
    Assert.Equal(expectedResult, result)
    
[<Theory>]
[<InlineData(10, 5, 2)>]    
let ``TestCalculatorDivision`` (value1, value2, expectedResult) =
    let result = Calculator.calculate value1 CalculatorOperation.Divide value2
    Assert.Equal(expectedResult, result)

    
[<Theory>]
[<InlineData("f", "+", "3")>]
[<InlineData("3", "+", "f")>]
[<InlineData("a", "+", "f")>]
let ``TestParserWrongValue`` (value1, operation, value2) =
    let args = [|value1;operation;value2|]
    let mutable value1 = 0
    let mutable value2 = 0
    let mutable operation= CalculatorOperation.UndefinedOperation
    let result = Parser.parseCalcArguments args &value1 &operation &value2
    Assert.Equal(Message.WrongArgFormat, result)
    

[<Fact>]
let ``TestParserWrongOperation`` () =
    let args = [|"3";".";"4"|]
    let mutable value1 = 0
    let mutable value2 = 0
    let mutable operation= CalculatorOperation.UndefinedOperation
    let result = Parser.parseCalcArguments args &value1 &operation &value2
    Assert.Equal(Message.WrongArgFormatOperation, result)

[<Fact>]
let ``TestParserWrongLength`` () =
    let args = [|"3";"+";"4";"5"|]
    let mutable value1 = 0
    let mutable value2 = 0
    let mutable operation= CalculatorOperation.UndefinedOperation
    let result = Parser.parseCalcArguments args &value1 &operation &value2
    Assert.Equal(Message.WrongArgLength, result)

[<Theory>]
[<InlineData("f", ".", "3")>]
[<InlineData("3", ".", "f")>]
[<InlineData("a", ".", "f")>]
let ``TestParserWrongOperationAndWrongValue`` (value1, operation, value2) =
    let args = [|value1;operation;value2|]
    let mutable value1 = 0
    let mutable value2 = 0
    let mutable operation= CalculatorOperation.UndefinedOperation
    let result = Parser.parseCalcArguments args &value1 &operation &value2
    Assert.Equal(Message.WrongArgFormatOperation, result)
    
[<Theory>]
[<InlineData("4", "+", "3")>]
[<InlineData("4", "-", "3")>]
[<InlineData("4", "*", "3")>]
[<InlineData("4", "/", "3")>]
let ``TestParserCorrectOperationAndCorrectValues`` (value1, operation, value2) =
    let args = [|value1;operation;value2|]
    let mutable value1 = 0
    let mutable value2 = 0
    let mutable operation= CalculatorOperation.UndefinedOperation
    let result = Parser.parseCalcArguments args &value1 &operation &value2
    Assert.Equal(Message.SuccessfulExecution, result)
    
[<Fact>]
let ``TestParserDividingByZero`` () =
    let args = [|"3";"/";"0"|]
    let mutable value1 = 0
    let mutable value2 = 0
    let mutable operation= CalculatorOperation.UndefinedOperation
    let result = Parser.parseCalcArguments args &value1 &operation &value2
    Assert.Equal(Message.DivideByZero, result)
    
[<Theory>]
[<InlineData("4", "+", "3")>]
[<InlineData("4", "-", "3")>]
[<InlineData("4", "*", "3")>]
[<InlineData("4", "/", "3")>]
let ``TestMainCorrectOperationAndCorrectValues`` (value1, operation, value2) =
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
    Assert.Equal(int Message.WrongArgFormatOperation, result)
    
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