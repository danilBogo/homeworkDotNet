.assembly ClassLibrary1
{
  .ver 1:0:0:0
}

.class public abstract auto ansi sealed beforefieldinit ClassLibrary1.Class
  extends [CORE_ASSEMBLY]System.Object
{
  .method public hidebysig static int32 Square(int32 a) cil managed
  {
    .maxstack 2
    ldarg.0
    dup
    mul
    ret
  }
}