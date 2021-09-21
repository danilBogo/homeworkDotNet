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
    .maxstack 2
    .locals init (
      [0] float64 result,
      [1] float64 V_1,
      [2] float64 V_2
    )

    // [6 9 - 6 10]
    IL_0000: nop

    // [7 13 - 13 15]
    IL_0001: ldc.i4.1
    IL_0002: brtrue.s     IL_0005

    // [7 36 - 13 14]
    IL_0004: nop

    IL_0005: ldarg.1      // operation
    IL_0006: switch       (IL_001d, IL_0023, IL_0029, IL_002f)
    IL_001b: br.s         IL_0035

    // [9 45 - 9 60]
    IL_001d: ldarg.0      // value1
    IL_001e: ldarg.2      // value2
    IL_001f: add
    IL_0020: stloc.1      // V_1
    IL_0021: br.s         IL_0045

    // [10 46 - 10 61]
    IL_0023: ldarg.0      // value1
    IL_0024: ldarg.2      // value2
    IL_0025: sub
    IL_0026: stloc.1      // V_1
    IL_0027: br.s         IL_0045

    // [11 49 - 11 64]
    IL_0029: ldarg.0      // value1
    IL_002a: ldarg.2      // value2
    IL_002b: mul
    IL_002c: stloc.1      // V_1
    IL_002d: br.s         IL_0045

    // [12 47 - 12 62]
    IL_002f: ldarg.0      // value1
    IL_0030: ldarg.2      // value2
    IL_0031: div
    IL_0032: stloc.1      // V_1
    IL_0033: br.s         IL_0045
    IL_0035: ldc.i4.1
    IL_0036: brtrue.s     IL_0039

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

