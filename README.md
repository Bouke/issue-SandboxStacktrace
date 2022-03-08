This test project produces the following output.

```
C:/Users/Bouke/Developer/SandboxStacktrace/Parent/bin/Debug/Parent.exe
Application domain 'Parent.exe': IsFullyTrusted = True
IsFullyTrusted = True for the current assembly Child, Version=1.0.0.0, Cultur
e=neutral, PublicKeyToken=null
IsFullyTrusted = True for mscorlib
Stack trace contains line numbers for Child assembly:
System.Reflection.TargetInvocationException: Exception has been thrown by the
target of an invocation. ---> System.Exception: Some exception
at Child.Child.Play() in C:\Users\Bouke\Developer\SandboxStacktrace\Child\Chi
ld.cs:line 20
--- End of inner exception stack trace ---
at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments,
Signature sig, Boolean constructor)
at System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(Object obj, Objec
t[] parameters, Object[] arguments)
at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invoke
Attr, Binder binder, Object[] parameters, CultureInfo culture)
at System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
at Parent.Worker.TestInner() in C:\Users\Bouke\Developer\SandboxStacktrace\Pa
rent\Worker.cs:line 43
Application domain 'Sandbox': IsFullyTrusted = False
IsFullyTrusted = False for the current assembly Child, Version=1.0.0.0, Cultu
re=neutral, PublicKeyToken=null
IsFullyTrusted = True for mscorlib

=====================================
FirstChanceException: System.Exception Some exception
=====================================


=====================================
FirstChanceException: System.Reflection.TargetInvocationException Exception has
been thrown by the target of an invocation.
=====================================


=====================================
FirstChanceException: System.Security.SecurityException Stack walk modifier must
be reverted before another modification of the same type can be performed.
=====================================


=====================================
FirstChanceException: System.Security.SecurityException Stack walk modifier must
be reverted before another modification of the same type can be performed.
=====================================

Stack trace contains no line numbers for Child assembly:
System.Reflection.TargetInvocationException: Exception has been thrown by the
target of an invocation. ---> System.Exception: Some exception
at Child.Child.Play()
--- End of inner exception stack trace ---
at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments,
Signature sig, Boolean constructor)
at System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(Object obj, Objec
t[] parameters, Object[] arguments)
at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invoke
Attr, Binder binder, Object[] parameters, CultureInfo culture)
at System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
at Parent.Worker.TestInner() in C:\Users\Bouke\Developer\SandboxStacktrace\Pa
rent\Worker.cs:line 43

Process finished with exit code 0.
```
