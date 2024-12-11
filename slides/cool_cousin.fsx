(**
- title : CSharps cool cousin FSharp
- description : CSharps cool cousin FSharp
- author : Tomas Grosup
- theme : Sky
- transition : slide
- slide-number: c/t

***
# F#
### C#'s Cool Cousin

#### Why Settle for Okay When You Can Be Functional?


##### Tomas Grosup @ F# Team @ DevDiv


***

### F# Team @ DevDiv Prague

- Compiler
- Tooling (VS directly, others indirectly via Nuget)
- Language design and suggestions
- OSS interactions
- FSharp.Core standard library


***

### Why F# ?

- Succint language for .NET and JS (Fable project) runtimes
- Write it anywhere - VS, VsCode, that other IDE competitor
- Run it anywhere - cloud, desktop, mobile, scripts
   - Why not at your job?
   - Even this slide deck is in F#!


---


### F# for fun ...

![yoko](images/yoko.png)


---

### ... and so much profit
![profit](images/fsharpprofit.png)


***

### What is F#?

- Pragmatic, functional-first language
- Smooth .NET interop in both directions
- Good defaults, type inference!
    - 'static vs dynamic' is so over


---

### Do you like these in C#?
#### You will love F#!

- async/await
- Expression-bodied members
- Pattern matching
- Records
- Collection literals

---

### Quiz: What makes the features strong in .NET?
#### (compare to e.g. JVM)
- Span,ReadOnlySpan
- Task
- Collections

***

### Pieces of F#
#### Let's start with |> pipe
- Just like unix pipes!
*)
let (|>) x f = f x // This is defined in FSharp.Core already :-)

let square x = x * x
let withoutPipes n = List.sum(List.map (square) [1..n] )
let sumOfSquares n =
   [1..n]
   |> List.map square
   |> List.sum

(** 
`sumOfSquares 5`:
*)
(*** include-value: sumOfSquares 5 ***)


(**

---

### Union Types

*)
type Expression =
    | Number of int
    | Add of Expression * Expression
    | Multiply of Expression * Expression
    | Variable of string

(**

---

### Matching and evaluation

*)
let rec Evaluate env exp =
    match exp with
    | Number n -> n
    | Add(x, y) -> Evaluate env x + Evaluate env y
    | Multiply(x, y) -> Evaluate env x * Evaluate env y
    | Variable id -> env |> Map.find id

(**

---

### Scripting

*)


// the expression: a + 2 * b.
let expressionTree1 = Add(Variable "a", Multiply(Number 2, Variable "b"))
let environment = Map [ "a", 1; "b", 2 ]
let result = Evaluate environment expressionTree1
(** 
`result` is evaluated for us here:
*)
(*** include-value: result ***)

(**

***

### Excellent for DSLs

- Type inference and collection expressions
- Active patterns
- Computation expressions

---

### Succint and composable

![webapi](images/webapi.jpg)



***



### And you can write F# without this, yes!
#### This is the end.

![monads](images/monadssmaller.png)

---




*)