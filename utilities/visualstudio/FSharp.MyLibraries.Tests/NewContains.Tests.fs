﻿namespace FSharp.MyLibraries.Tests

open Microsoft.VisualStudio.TestTools.UnitTesting

open FSharp.MyLibraries.NewContains

open FsCheck
open FsUnit

module NewContains = 

    let zs = "zZ"
    let os = "oO"
    let es = "eE"

    let nextLetter (list : string) = 
        Gen.elements list    

    type NewContainsProperties = 
        static member ``randomString should most likely not contain the offending word.`` (string : string) = contains string [zs;os;es] = false

    [<TestClass>]
    type NewContainsTests() =        

        [<TestMethod>]
        member x.``NewContains anything with no zoe should return false.``() =
            contains "herbert" ["z"] |> should equal false

        [<TestMethod>]
        member x.``NewContains should return true when it is passed zoe.``() =
            contains "zoe" ["z";"o";"e"] |> should equal true
   
        [<TestMethod>]
        member x.``NewContains quickCheck properties.``() =
            Check.QuickThrowOnFailureAll<NewContainsProperties>()

        [<TestMethod>]
        member x.``Fake stuff``() = 
            usingGenerateOddlySpelledWord |> should equal "zoe"

