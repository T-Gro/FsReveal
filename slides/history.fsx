(**
- title : Strongly typed FP
- description : Strongly typed functional programming in .NET
- author : Tomas Grosup
- theme : moon
- transition : default
 
***
 
### Early history of functional programming for .NET
 
- 1970-2024
- Tomas Grosup @ .NET @ DevDiv @ Microsoft



![fp_productivity](images/FP_productivity.jpeg)


---

### Who cares about FP anyway?

![evolution](images/net_evolution_selection.png)


---


### This is not a full history lesson

- Backwards journey seen trough **selected** milestones:
    - Asynchronous programming
    - Generics
    - Early .NET days
    - Birth of F#

> **Peer reviewed history**: https://fsharp.org/history/hopl-final/hopl-fsharp.pdf

- (and do approach me after the talk for more!)

***

### Asynchrony - what is it good for?

- Continue with computation after "stuff" happens
- Let the thread do other useful work

![callback_hell](images/callback_hell.jpg)

---

### Async/await  (C# 5, 2012)


    [lang=cs]
    static async Task<string> FetchUrlAsync(HttpClient client, string url)
    {
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

- Ease of transition sync<->async!
- 1st big feature of Mads Torgersen
- Today an industry standard

---

### How it came to be?

- Inspired by F# computation expression async{}

![async_history](images/async_history.png)


---

### Computation expressions (F# 1.0, 2007)

 
    [lang=fsharp]
    let fetchUrlAsync (url:string) (client:HttpClient) =
        task {
            let! response = client.GetAsync(url)
            response.EnsureSuccessStatusCode()
            return! response.Content.ReadAsStringAsync()
        }

- Author provides a *Builder type (task,async,seq,optional,..)
- Compiler desugars bangs (let!,match!,while!,...) into calls
- builder.Bind(expression, fun result -> rest of the code)
- Nesting & Composition
 

***


### Generics (.NET 2.0, 2005)

- Programming with data types "to be specified later"
- Key enabler for Collections, LINQ, TPL, Span

#### Before

    [lang=cs]
    ArrayList list = new ArrayList();
    list.Add(42);
    int value = (int)list[0];

#### After

    [lang=cs]
    List<int> list = new List<int> { 42 };
    int value = list[0];

---

### What is so FP about generics?

- Pioneered in ML in 70s
    - ML = Ancestor of F#,OCaml,Elm,Haskell,SML
- Strongly typed FP with type inference needs it
- Called 'Parametric polymorphism' in FP
   - Complements 'this' polymorphism


    [lang=cs]
    // public virtual List<T> GenericMethod(T)
    var result = this.GenericMethod(x);

---


### Generics and type inference

- Every symbol starts as a generic type parameter
- Example: Generic caching decorator

*)

let cachedVersionOf originalFunction =
    let mutable cache = Map.empty
    fun key ->
        match cache |> Map.tryFind key  with
        | Some value -> value
        | None ->
            let value = originalFunction(key)
            cache <- cache |> Map.add key value 
            value

let expandEnvVars = cachedVersionOf System.Environment.ExpandEnvironmentVariables

(**

---


### How landed in .NET?

- Don Syme from Microsoft Research
- Specifically designed (1998) to support FP languages on .NET
   - Not an accident!
   - Needed by Project 7 (wait for it.. :-))
- Unlike GJ in JVM, using JIT!

***

### Early .NET

- MSFT: C,ASM,BASIC
- Loss of Java license (J++), OO wave 
- COM+ 2.0 -> Lightning -> .NET
    - Regular Bill Gates reviews
    - Key decision: **Multi-language** runtime
    - +new COOL

---

### Project 7

- Approach industry and academia for 7+7 ports
    - MSR as link to academia
- COBOL, Perl, Python, Ada
- Eiffel, Mercury, **SML**, **Haskell**, **OCaml**, Scheme, **Alice**
- ( OOP ,  Logic ,  ----------  ML    ------------   , LISP, Concurrency)

---

### Interop is good, but hard

- Academical languages needed libraries, frameworks, tools
- BUT: 2 runtimes, 2 GCs ?
- Type systems compatibility
- Haskell.NET: 'Dirtyness' of .NET a problem

***

### Birth of F#


- Started as OCaml.NET by Don Syme
   - 2002
- Do a fresh .NET language with its own identity
- Main ancestor line:
   - OCaml (1996, Object features)
    - Caml (1985)
        - ML (early 70s, Generics, Strongly typed)
            - LISP (1958, GC, Recursion)


---
#### F#
    [lang=fsharp]
    let rec factorial = function
        | 0 -> 1
        | n -> n * factorial (n - 1)    

#### ML
    [lang=sml]
    fun factorial 0 = 1
      | factorial n = n * factorial (n - 1);

#### LISP
    [lang=lisp]
    (defun factorial (n)
        (if (= n 0) 1 (* n (factorial (- n 1))))

Are the parens right?!

 

 
***

 
### Next big thing?
 
- Type unions in C#?


    [lang=fsharp]
    type Size = Pixels of int | Percentage of float | Auto

    type Option<'T> = 
        | Some of 'T 
        | None

    type Result<'T,'TErr> = 
        | Ok of 'T 
        | Error of 'TErr


 
***
 
### The end

- FP found its way into mainstream
- Not the case 25y ago!
- Want to enjoy it even more?
    - https://fsharp.org/
    - Reach me at tomasgrosup @ Twitter/X/bluesky
    - T-Gro @ Github
 
 
*)