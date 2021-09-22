.class public abstract sealed auto ansi beforefieldinit
  IlClasses.Calculator
    extends System.Object
{

  .method public hidebysig static int32
    Calculate(
      int32 value1,
      valuetype IlClasses.CalculatorOperation operation,
      int32 value2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 result,
      [1] int32 V_1,
      [2] int32 V_2
    )
    
    ldc.i4.1
    brtrue.s     goToSwitch

    goToSwitch: 
    ldarg.1      // operation
    switch       (firstValue, secondValue, thirdValue, fourthValue)
    br.s         IL_0035

    // [9 45 - 9 60]
    firstValue: 
    ldarg.0      // value1
    ldarg.2      // value2
    add
    stloc.1      // V_1
     br.s         IL_0045

    // [10 46 - 10 61]
    secondValue: 
    ldarg.0      // value1
    ldarg.2      // value2
    sub
    stloc.1      // V_1
    br.s         IL_0045

    // [11 49 - 11 64]
    thirdValue: 
    ldarg.0      // value1
    ldarg.2      // value2
    mul
    stloc.1      // V_1
    br.s         IL_0045

    // [12 47 - 12 62]
    fourthValue: 
    ldarg.0      // value1
    ldarg.2      // value2
    div
    stloc.1      // V_1
    br.s         IL_0045
    IL_0035: ldc.i4.1
    brtrue.s     IL_0039

    // [7 36 - 13 14]
    IL_0038: nop

    IL_0039: ldarg.1      // operation
    IL_003a: box          IlClasses.CalculatorOperation
    IL_003f: newobj       instance void [System.Runtime]System.Runtime.CompilerServices.SwitchExpressionException::.ctor(object)
    IL_0044: throw

    IL_0045: ldc.i4.1
    IL_0046: brtrue.s     IL_0049

    // [7 13 - 13 15]
    IL_0048: nop

    IL_0049: ldloc.1      // V_1
    IL_004a: stloc.0      // result

    // [14 13 - 14 27]
    IL_004b: ldloc.0      // result
    IL_004c: stloc.2      // V_2
    IL_004d: br.s         IL_004f

    // [15 9 - 15 10]
    IL_004f: ldloc.2      // V_2
    IL_0050: ret

  }
}

