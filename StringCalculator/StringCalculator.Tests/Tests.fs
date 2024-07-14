module Tests

open System
open Xunit


// Assuming the Add function is defined in the StringCalculator module
open StringCalculator
open Utils

// Step 2
[<Fact>]
let ``Add with comma separated numbers`` () =
    Assert.Equal(Ok 10, Add "1,2,3,4")
    Assert.Equal(Ok 20, Add "0,2,10,4,4")

// Step 3
[<Fact>]
let ``Add with new lines as separators`` () =
    Assert.Equal(Ok 20, Add "0\n2,10\n4,4")

// Step 4
[<Fact>]
let ``Add with custom single character delimiter`` () =
    Assert.Equal(Ok 13, Add "//*\n1*2*10")
    Assert.Equal(Ok 15, Add "//[-]\n1-4-10")

// Step 5
[<Fact>]
let ``Add with negative numbers should throw exception`` () =
    Assert.Equal(Error(NegativeNumbers [|-10;-3|]), Add "//^\n11^2^-10^-3" )

// Step 6
[<Fact>]
let ``Add ignoring numbers greater than 1000`` () =
    Assert.Equal(Ok 12, Add "1001,10,2")

// Step 7
[<Fact>]
let ``Add with custom multi-character delimiter`` () =
    Assert.Equal(Ok 15, Add "//***\n2***10***3")
    Assert.Equal(Ok 15, Add "//[*&*]\n2*&*10*&*3")

// Step 8 & 9
[<Fact>]
let ``Add with multiple custom delimiters`` () =
    Assert.Equal(Ok 20, Add "//[&*][%]\n10&*2&*8")
    Assert.Equal(Ok 25, Add "//[&*&]\n10&*&7&*&8")
