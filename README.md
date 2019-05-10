
# TinyExe - Tiny Expression Evaluator

By Herre Kuijpers

http://www.codeproject.com/Articles/241830/a-Tiny-Expression-Evaluator


# Changes from original

- Code was adapted to run on .netcf 3.5 profile.
- UI code was separated from parser
- Contexts are recursively scoped. This allows
  to declare derived contexts.
- Syntax update to have logical `and`, `or` operations.
- Bit functions: rshift, lshift, bitand, bitor, bitxor

# Grammar details

The functionality of the tool is based on the implementation as used in Excel. Currently the expression evaluator supports the following features:

It can parse mathematical expressions, including support for the most commonly used functions,e.g.:

    4*(24/2-5)+14
    cos(Pi/4)*sin(Pi/6)^2
    1-1/E^(0.5^2)
    min(5;2;9;10;42;35)

The following functions are supported:

~~About~~ Abs Acos And Asin Atan Atan2 Avg Ceiling Clear Cos Cosh Exp Fact Floor Format ~~Help~~ Hex If Floor Left Len Ln Log Lower Max Min Mid Min Not Or Pow Rand Right Round Sign Sin Sinh Sqr Sqrt StDev Trunc Upper Val Var

Bit related functions:

rshift, lshift, bitand, bitor, bitxor

Basic string functions:

    "Hello " & "world"
    "Pi = " & Pi
    Len("hello world")
    Boolean operators:
    true != false
    5 > 6 ? "hello" : "world"
    If(5 > 6;"hello";"world")

Function and variable declaration

    x := 42
    f(x) := x^2
    f(x) := sin(x) / cos(x) // declare new     dynamic functions using built-in functions
    Pi
    E

Recursion and scope

    fac(n) := (n = 0) ? 1 : fac(n-1)*n
    // fac calls itself with different parameters

    f(x) = x*Y
    // x is in function scope, Y is global scope

Currently 5 datatypes are supported: double, hexidecimal, int, string and boolean. Note that integers (and hexadecimals also) are always converted to doubles when used in a calculation by default. Use the int() function to convert to integer explicitly.

The tool uses the following precedence rules for its operators:

1. ( ), f(x) Grouping, functions
2. ! ~ - + (most) unary operations
3. ^ Power to (Excel rule: that is a^b^c -> (a^b)^c
4. * / % Multiplication, division, modulo
5. + - Addition and subtraction
6. & concatenation of strings
7. < <= > >= Comparisons: less-than, ...
8. = != <> Comparisons: equal and not equal
9. `&&` `and` - Logical AND
10. `||` `or` - Logical OR
11. ?: Conditional expression
12. := Assignment


Checkout [Grammar](https://github.com/hobdrive/tinyexe/blob/master/TinyExe/TinyExe.tpg) for details.