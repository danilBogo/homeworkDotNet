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
    
    ldarg.0      // args
    ldc.i4.0
    ldelem.ref
    ldarg.1      // value1
    call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    stloc.0      // isInt1

    ldarg.0      // args
    ldc.i4.2
    ldelem.ref
    ldarg.3      // value2
    call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    stloc.1      // isInt2

    ldarg.0      // args
    ldc.i4.1
    ldelem.ref
    ldarg.2      // operation
    call         bool IlClasses.Parser::IsOperationSupported(string, valuetype IlClasses.CalculatorOperation&)
    ldc.i4.0
    ceq
    stloc.2      // V_2

    ldloc.2      // V_2
    brfalse.s    Method_IsArgLengthSupported

    ldc.i4.3
    stloc.3      // V_3
    br.s         MethodEnd

    Method_IsArgLengthSupported: 
    ldarg.0      // args
    ldlen
    conv.i4
    call         bool IlClasses.Parser::IsArgLengthSupported(int32)
    ldc.i4.0
    ceq
    stloc.s      V_4
    ldloc.s      V_4
    brfalse.s    Method_IsValueInt
    ldc.i4.1
    stloc.3      // V_3
    br.s         MethodEnd

    Method_IsValueInt: 
    ldarg.0      // args
    ldc.i4.0
    ldelem.ref
    ldloc.0      // isInt1
    call         bool IlClasses.Parser::IsValueInt(string, bool)
    brfalse.s    Value1IsInt
    ldarg.0      // args
    ldc.i4.2
    ldelem.ref
    ldloc.1      // isInt2
    call         bool IlClasses.Parser::IsValueInt(string, bool)
    ldc.i4.0
    ceq
    br.s         ComposingOutputValue
    
    Value1IsInt: 
    ldc.i4.1
    
    ComposingOutputValue: 
    stloc.s      V_5
    ldloc.s      V_5
    brfalse.s    Goto1
    ldc.i4.2
    stloc.3      // V_3
    br.s         MethodEnd

    Goto1: 
    ldarg.2      // operation
    ldind.i4
    ldc.i4.3
    bne.un.s     Goto2
    ldarg.3      // value2
    ldind.i4
    ldc.i4.0
    ceq
    br.s         Goto3
    
    Goto2: 
    ldc.i4.0
    
    Goto3: 
    stloc.s      V_6
    ldloc.s      V_6
    brfalse.s    Goto4
    ldc.i4.4
    stloc.3      // V_3
    br.s         MethodEnd

    Goto4: 
    ldc.i4.0
    stloc.3      // V_3
    br.s         MethodEnd

    MethodEnd: 
    ldloc.3
    ret
  }

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
    
    ldarg.0      // length
    ldc.i4.3
    ceq
    stloc.0      // V_0
    
    ldloc.0      // V_0
    brfalse.s    Goto1

    ldc.i4.1
    stloc.1      // V_1
    br.s         MethodEnd

    Goto1: 
    ldc.i4.0
    stloc.1      // V_1
    br.s         MethodEnd

    MethodEnd: 
    ldloc.1      // V_1
    ret

  }

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
    
    ldarg.0      // arg
    ldstr        "+"
    call         bool System.String::op_Equality(string, string)
    brtrue.s     Goto1
    ldarg.0      // arg
    ldstr        "-"
    call         bool System.String::op_Equality(string, string)
    brtrue.s     Goto2
    ldarg.0      // arg
    ldstr        "*"
    call         bool System.String::op_Equality(string, string)
    brtrue.s     Goto3
    ldarg.0      // arg
    ldstr        "/"
    call         bool System.String::op_Equality(string, string)
    brtrue.s     Goto4
    br.s         Goto5

    Goto1: 
    ldc.i4.0
    stloc.0      // V_0
    br.s         Goto6

    Goto2: 
    ldc.i4.1
    stloc.0      // V_0
    br.s         Goto6

    Goto3: 
    ldc.i4.2
    stloc.0      // V_0
    br.s         Goto6

    Goto4: 
    ldc.i4.3
    stloc.0      // V_0
    br.s         Goto6

    Goto5: ldc.i4.4
    stloc.0      // V_0
    br.s         Goto6

    Goto6: 
    ldc.i4.1
    brtrue.s     Goto7

    Goto7: 
    ldarg.1      // operation
    ldloc.0      // V_0
    stind.i4
    ldarg.1      // operation
    ldind.i4
    ldc.i4.4
    ceq
    ldc.i4.0
    ceq
    stloc.1      // V_1
    ldloc.1      // V_1
    ret
    
  }

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
    
    ldarg.1      // isInt
    stloc.0      // V_0

    ldloc.0      // V_0
    brfalse.s    Goto1

    ldc.i4.1
    stloc.1      // V_1
    br.s         MethodEnd

    Goto1: 
    ldc.i4.0
    stloc.1      // V_1
    br.s         MethodEnd

    MethodEnd: 
    ldloc.1      // V_1
    ret

  }

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    ldarg.0      // this
    call         instance void System.Object::.ctor()
    ret
    
  }
}
