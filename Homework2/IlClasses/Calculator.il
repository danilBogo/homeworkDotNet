.class public abstract sealed auto ansi beforefieldinit
  IlClasses.Calculator
    extends System.Object
{

  .method public hidebysig static float64
    Calculate(
      int32 value1,
      valuetype IlClasses.CalculatorOperation operation,
      int32 value2
    ) cil managed
  {
    .maxstack 3
    
    ldarg.0     //push value1 to stack
    conv.r8     //cast to float64
    
    ldarg.2     //push value2 to stack
    conv.r8     //cast to float64
    
    ldarg.1     //push operation to stack
    
    switch (sum, substraction, multiplication, division)
    
    sum: add ret
    substraction: sub ret
    multiplication: mul ret
    division: div ret
  }
}

