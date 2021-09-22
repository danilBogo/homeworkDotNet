.class public auto ansi beforefieldinit
  IlClasses.Parser
    extends System.Object
{
  .method public hidebysig static int32
    ParseCalcArguments(
      string[] args,
      [out] int32& value1,
      [out] valuetype IlClasses.CalculatorOperation& operation,
      [out] int32& value2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool isInt1,
      [1] bool isInt2,
      [2] bool V_2,
      [3] int32 V_3,
      [4] bool V_4,
      [5] bool V_5,
      [6] bool V_6
    )

    // [9 9 - 9 10]
    IL_0000: nop

    // [10 13 - 10 60]
    IL_0001: ldarg.0      // args
    IL_0002: ldc.i4.0
    IL_0003: ldelem.ref
    IL_0004: ldarg.1      // value1
    IL_0005: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_000a: stloc.0      // isInt1

    // [11 13 - 11 60]
    IL_000b: ldarg.0      // args
    IL_000c: ldc.i4.2
    IL_000d: ldelem.ref
    IL_000e: ldarg.3      // value2
    IL_000f: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_0014: stloc.1      // isInt2

    // [13 13 - 13 63]
    IL_0015: ldarg.0      // args
    IL_0016: ldc.i4.1
    IL_0017: ldelem.ref
    IL_0018: ldarg.2      // operation
    IL_0019: call         bool IlClasses.Parser::IsOperationSupported(string, valuetype IlClasses.CalculatorOperation&)
    IL_001e: ldc.i4.0
    IL_001f: ceq
    IL_0021: stloc.2      // V_2

    IL_0022: ldloc.2      // V_2
    IL_0023: brfalse.s    IL_0029

    // [13 64 - 13 109]
    IL_0025: ldc.i4.3
    IL_0026: stloc.3      // V_3
    IL_0027: br.s         IL_007d

    // [14 13 - 14 52]
    IL_0029: ldarg.0      // args
    IL_002a: ldlen
    IL_002b: conv.i4
    IL_002c: call         bool IlClasses.Parser::IsArgLengthSupported(int32)
    IL_0031: ldc.i4.0
    IL_0032: ceq
    IL_0034: stloc.s      V_4

    IL_0036: ldloc.s      V_4
    IL_0038: brfalse.s    IL_003e

    // [14 53 - 14 89]
    IL_003a: ldc.i4.1
    IL_003b: stloc.3      // V_3
    IL_003c: br.s         IL_007d

    // [15 13 - 15 78]
    IL_003e: ldarg.0      // args
    IL_003f: ldc.i4.0
    IL_0040: ldelem.ref
    IL_0041: ldloc.0      // isInt1
    IL_0042: call         bool IlClasses.Parser::IsValueInt(string, bool)
    IL_0047: brfalse.s    IL_0057
    IL_0049: ldarg.0      // args
    IL_004a: ldc.i4.2
    IL_004b: ldelem.ref
    IL_004c: ldloc.1      // isInt2
    IL_004d: call         bool IlClasses.Parser::IsValueInt(string, bool)
    IL_0052: ldc.i4.0
    IL_0053: ceq
    IL_0055: br.s         IL_0058
    IL_0057: ldc.i4.1
    IL_0058: stloc.s      V_5

    IL_005a: ldloc.s      V_5
    IL_005c: brfalse.s    IL_0062

    // [15 79 - 15 118]
    IL_005e: ldc.i4.2
    IL_005f: stloc.3      // V_3
    IL_0060: br.s         IL_007d

    // [16 13 - 16 72]
    IL_0062: ldarg.2      // operation
    IL_0063: ldind.i4
    IL_0064: ldc.i4.3
    IL_0065: bne.un.s     IL_006e
    IL_0067: ldarg.3      // value2
    IL_0068: ldind.i4
    IL_0069: ldc.i4.0
    IL_006a: ceq
    IL_006c: br.s         IL_006f
    IL_006e: ldc.i4.0
    IL_006f: stloc.s      V_6

    IL_0071: ldloc.s      V_6
    IL_0073: brfalse.s    IL_0079

    // [16 73 - 16 109]
    IL_0075: ldc.i4.4
    IL_0076: stloc.3      // V_3
    IL_0077: br.s         IL_007d

    // [18 13 - 18 54]
    IL_0079: ldc.i4.0
    IL_007a: stloc.3      // V_3
    IL_007b: br.s         IL_007d

    // [19 9 - 19 10]
    IL_007d: ldloc.3      // V_3
    IL_007e: ret

  } // end of method Parser::ParseCalcArguments

  .method private hidebysig static bool
    IsArgLengthSupported(
      int32 length
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool V_0,
      [1] bool V_1
    )

    // [28 9 - 28 10]
    IL_0000: nop

    // [29 13 - 29 29]
    IL_0001: ldarg.0      // length
    IL_0002: ldc.i4.3
    IL_0003: ceq
    IL_0005: stloc.0      // V_0

    IL_0006: ldloc.0      // V_0
    IL_0007: brfalse.s    IL_000d

    // [29 30 - 29 42]
    IL_0009: ldc.i4.1
    IL_000a: stloc.1      // V_1
    IL_000b: br.s         IL_0011

    // [30 13 - 30 26]
    IL_000d: ldc.i4.0
    IL_000e: stloc.1      // V_1
    IL_000f: br.s         IL_0011

    // [31 9 - 31 10]
    IL_0011: ldloc.1      // V_1
    IL_0012: ret

  } // end of method Parser::IsArgLengthSupported

  .method private hidebysig static bool
    IsOperationSupported(
      string arg,
      [out] valuetype IlClasses.CalculatorOperation& operation
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] valuetype IlClasses.CalculatorOperation V_0,
      [1] bool V_1
    )

    // [29 9 - 29 10]
    IL_0000: nop

    // [30 13 - 37 15]
    IL_0001: ldc.i4.1
    IL_0002: brtrue.s     IL_0005

    // [30 29 - 37 14]
    IL_0004: nop

    IL_0005: ldarg.0      // arg
    IL_0006: ldstr        "+"
    IL_000b: call         bool System.String::op_Equality(string, string)
    IL_0010: brtrue.s     IL_003b
    IL_0012: ldarg.0      // arg
    IL_0013: ldstr        "-"
    IL_0018: call         bool System.String::op_Equality(string, string)
    IL_001d: brtrue.s     IL_003f
    IL_001f: ldarg.0      // arg
    IL_0020: ldstr        "*"
    IL_0025: call         bool System.String::op_Equality(string, string)
    IL_002a: brtrue.s     IL_0043
    IL_002c: ldarg.0      // arg
    IL_002d: ldstr        "/"
    IL_0032: call         bool System.String::op_Equality(string, string)
    IL_0037: brtrue.s     IL_0047
    IL_0039: br.s         IL_004b

    // [32 24 - 32 48]
    IL_003b: ldc.i4.0
    IL_003c: stloc.0      // V_0
    IL_003d: br.s         IL_004f

    // [33 24 - 33 49]
    IL_003f: ldc.i4.1
    IL_0040: stloc.0      // V_0
    IL_0041: br.s         IL_004f

    // [34 24 - 34 52]
    IL_0043: ldc.i4.2
    IL_0044: stloc.0      // V_0
    IL_0045: br.s         IL_004f

    // [35 24 - 35 50]
    IL_0047: ldc.i4.3
    IL_0048: stloc.0      // V_0
    IL_0049: br.s         IL_004f

    // [36 22 - 36 60]
    IL_004b: ldc.i4.4
    IL_004c: stloc.0      // V_0
    IL_004d: br.s         IL_004f

    IL_004f: ldc.i4.1
    IL_0050: brtrue.s     IL_0053

    // [30 13 - 37 15]
    IL_0052: nop

    IL_0053: ldarg.1      // operation
    IL_0054: ldloc.0      // V_0
    IL_0055: stind.i4

    // [39 13 - 39 72]
    IL_0056: ldarg.1      // operation
    IL_0057: ldind.i4
    IL_0058: ldc.i4.4
    IL_0059: ceq
    IL_005b: ldc.i4.0
    IL_005c: ceq
    IL_005e: stloc.1      // V_1
    IL_005f: br.s         IL_0061

    // [40 9 - 40 10]
    IL_0061: ldloc.1      // V_1
    IL_0062: ret

  } // end of method Parser::IsOperationSupported

  .method private hidebysig static bool
    IsValueInt(
      string arg,
      bool isInt
    ) cil managed
  {
    .maxstack 1
    .locals init (
      [0] bool V_0,
      [1] bool V_1
    )

    // [48 9 - 48 10]
    IL_0000: nop

    // [49 13 - 49 23]
    IL_0001: ldarg.1      // isInt
    IL_0002: stloc.0      // V_0

    IL_0003: ldloc.0      // V_0
    IL_0004: brfalse.s    IL_000a

    // [49 24 - 49 36]
    IL_0006: ldc.i4.1
    IL_0007: stloc.1      // V_1
    IL_0008: br.s         IL_000e

    // [50 13 - 50 26]
    IL_000a: ldc.i4.0
    IL_000b: stloc.1      // V_1
    IL_000c: br.s         IL_000e

    // [51 9 - 51 10]
    IL_000e: ldloc.1      // V_1
    IL_000f: ret

  } // end of method Parser::IsValueInt

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    IL_0000: ldarg.0      // this
    IL_0001: call         instance void System.Object::.ctor()
    IL_0006: nop
    IL_0007: ret

  }
}
