This test project produces the following output.

```
C:/Users/Bouke/Developer/SandboxStacktrace/Parent/bin/Debug/Parent.exe

Application domain 'Parent.exe': IsFullyTrusted = True
   IsFullyTrusted = True for the current assembly Child, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
   IsFullyTrusted = True for mscorlib
Stack trace contains line numbers for Child assembly:
   System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. ---> System.Exception: Some exception
   at Child.Child.Play() in C:\Users\Bouke\Developer\SandboxStacktrace\Child\Child.cs:line 20
   --- End of inner exception stack trace ---
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor)
   at System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(Object obj, Object[] parameters, Object[] arguments)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
   at Parent.Worker.TestInner() in C:\Users\Bouke\Developer\SandboxStacktrace\Parent\Worker.cs:line 43

Application domain 'Sandbox': IsFullyTrusted = False
   IsFullyTrusted = False for the current assembly Child, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
   IsFullyTrusted = True for mscorlib

=====================================
FirstChanceException: System.Exception Some exception
=====================================


=====================================
FirstChanceException: System.Reflection.TargetInvocationException Exception has been thrown by the target of an invocation.
=====================================

Stack trace contains no line numbers for Child assembly:
   System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. ---> System.Exception: Some exception
   at Child.Child.Play()
   --- End of inner exception stack trace ---
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor)
   at System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(Object obj, Object[] parameters, Object[] arguments)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
   at Parent.Worker.TestInner() in C:\Users\Bouke\Developer\SandboxStacktrace\Parent\Worker.cs:line 43

```
