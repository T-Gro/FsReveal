(**
- title : Tomáš Grošup 
- description : Introduction to FsReveal
- author : Tomáš Grošup
- theme : moon
- transition : default

***

### Kdo je Tomáš

- Českolipský rodák
- Táta(kamarádky(dcery(vaší paní učitelky)))
- Student: FSG Pirna, GCL, (MFF UK Praha)^4
- Učení: FIT CVUT pro Erasmus studenty, hostování na Uni Konstanz, + konference

![FsReveal](images/logo.png)

---

### Informatika na MFF UK

- Hodně matematiky, široký základ je povinný. 
   - Mat. analýza, diskrétní matematika, linární algebra, kombinatorika a grafy, výroková a predikátová logika, optimalizační metody, teorie množin, složitost, vyčíslitelnost,..
- Hodně možností průchodu vyšších ročníků skrze obory a volitelné předměty
- Čistá teorie, praktické programování, vývoj her, AI, ...


---

### Život doktoranda

- Často kombinované s prací
- (nebo model komerčních spoluprací)
- Jde o výzkum (Research), ne programování podle zadání
- Granty, články na konference, časopisy
- Spousta možností cestovat po světě!
- Velmi úzké téma, velmi do hloubky, state-of-the-art celosvětově



***

### IT kariéra

- idioma - Computer-aided translation SW (CAT) - Toyota, Komatsu, Nikkon, Canon,..
- Commerzbank AG - regulatorika pro investiční bankovnictví
- Barclays - Risk, Finance and Treasury - stresové simulace pro akciové trhy
- Microsoft - Cloud and AI - programovací jazyk FSharp (evoluce, kompilátor, nástroje)
  
---

### Různé role - JFDI v menší firmě

- Uživatel nebo jejich zástupce
- Programátor
- (konec)

---

### Různé role - waterfall

![Waterfall](images/waterfall.png)

---

### Různé role - agile

![Agile](images/agile.png)

---

### Různé role - agile, but..

![ScrumBut](images/scrum-but.png)



***

### Domény

- Definují oblasti pro uplatnění software
- Taktéž oblasti expertízy a let učení se
- Specifika: Life-critical, hard real-time, automotive, finance aj.
- Regulatorní požadavky, risk pokut
- Kalkulace ROI pro IT (příklady)
   - Ne vždy platí Pareto 80-20



---

### Kvantita

- Kolik IT systémů měla banka?
- Kolik lidí dělalo na CRM systému pro sales?
- Kolik lidí ma MSFT v Praze (Teams,Dynamics,Azure,kompilátory,..)
- Kolik má můj tým na jazyk FSharp?

---

### Digitalizace

- Lidské workflow - příklad
- Prototyping: Nápad - Excel - Python - IT systém
    - časová náročnost může růst i 10x-100x s každým přesunem
- Komplexita "businessu":
    - Produkty investičního bankovnictví
    - Scénáře
    - Zdánlivé "prkotiny" jako settlement date u cenných papírů


***

#### F#

- Pro platformu .NET nebo JavaScript
- Weby, desktop SW, mobile, cloudové aplikace
- Silně typový jazyk
- Co je ten hashtag?

--- 

#### F#

*)
let factorial x = [1..x] |> List.reduce (*)
(** `factorial 5` *)
(*** include-value: factorial 1 ***)

(** `Series: [1..10] |> List.map factorial)` *)
(*** include-value: ([1..10] |> List.map factorial) ***)


(**

--- 

#### F# - rekurze

*)
let rec fibonacci x =
    match x with
    | 0 | 1 -> 1
    | x -> fibonacci(x-2) + fibonacci(x-1)

(** `fibonacci 4` *)
(*** include-value: fibonacci 4 ***)

(** `Series: [1..10] |> List.map fibonacci)` *)
(*** include-value: ([1..10] |> List.map fibonacci) ***)


(**

--- 

#### Jednotky - a kolik je vysledek?

*)


[<Measure>] type czk
[<Measure>] type month

let investment = 1000.<czk/month>
let monthlySavingsRate = 1.01
let yearlySavingsRate = pown monthlySavingsRate 12

let afterYears noOfYears = 
    let mutable balance = 0.<czk>
    let period = 1.<month>
    for i=0 to (noOfYears*12) do
        balance <- balance + (investment*period)
        balance <- balance * monthlySavingsRate
    System.String.Format("Investing for {0} years yields {1:## ### ##0}", noOfYears,balance)



(** `yearlySavingsRate` *)
(*** include-value: yearlySavingsRate ***)
(**

---
#### Výsledky pro různé počty let

*)

(*** include-value: afterYears 2 ***)
(*** include-value: afterYears 10 ***)
(*** include-value: afterYears 25 ***)
(*** include-value: afterYears 50 ***)
(**



---

### Making of - tyto slidy

![SelfScreen](images/these_slides.png)


***

### The Reality of a Developer's Life 

**When I show my boss that I've fixed a bug:**
  
![When I show my boss that I've fixed a bug](http://www.topito.com/wp-content/uploads/2013/01/code-07.gif)
  
**When your regular expression returns what you expect:**
  
![When your regular expression returns what you expect](http://www.topito.com/wp-content/uploads/2013/01/code-03.gif)
  
*from [The Reality of a Developer's Life - in GIFs, Of Course](http://server.dzone.com/articles/reality-developers-life-gifs)*

*)