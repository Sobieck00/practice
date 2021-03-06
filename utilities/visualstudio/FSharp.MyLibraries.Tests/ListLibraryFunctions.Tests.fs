﻿namespace FSharp.MyLibraries.Tests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FSharp.MyLibraries.ListLibraryFunctions
open System.Numerics

module ListLibraryFunctions = 
  
    let testSpaceRow0 = [0;0;0;0;1]
    let testSpaceRow1 = [1;1;2;2;3]
    let testSpaceRow2 = [1;1;4;4;5]
    let testSpaceRow3 = [2;5;6;7;9]
    let testSpaceRow4 = [3;9;9;9;8]

    [<TestClass>]
    type ListLibraryFunctionsTests() = 

        [<TestMethod>]
        member x.``ListLibraryFunctions productOf [1;2;3;4] should equal 24.``() =
            Assert.AreEqual(24, productOf [1;2;3;4])

        [<TestMethod>]
        member x.``ListLibraryFunctions productOf [1;2;3;4;9] should equal 216.``() =
            Assert.AreEqual(216, productOf [1;2;3;4;9])

        [<TestMethod>]
        member x.``ListLibraryFunctions zip4 should return correct tuple.``() =
            Assert.AreEqual(
                [
                    (0,1,1,2);
                    (0,1,1,5);
                    (0,2,4,6);
                    (0,2,4,7);
                    (1,3,5,9)
                ],
                zip4 (testSpaceRow0, testSpaceRow1, testSpaceRow2, testSpaceRow3)
            )

        [<TestMethod>]
        member x.``ListLibraryFunctions zip4 should return correct tuple with only 3 items.``() =
            Assert.AreEqual(
                [
                    (0,1,1,2);
                    (0,1,1,5);
                    (0,2,4,6)
                ],
                zip4 (testSpaceRow0, testSpaceRow1, testSpaceRow2, [2;5;6])
            )

        [<TestMethod>]
        member x.``ListLibraryFunctions zip4 should return correct tuple with only 1 items.``() =
            Assert.AreEqual(
                [
                    (0,1,1,2)
                ],
                zip4 (testSpaceRow0, testSpaceRow1, testSpaceRow2, [2])
            )


        [<TestMethod>]
        member x.``ListLibraryFunctions dropLastItem should drop last item.``() =
            Assert.AreEqual([1..80], dropLastItem [1..81])

        [<TestMethod>]
        member x.``ListLibraryFunctions dropLast2Items should drop last item.``() =
            Assert.AreEqual([1..79], dropLast2Items [1..81])

        [<TestMethod>]
        member x.``ListLibraryFunctions unionOfSortedRemoveDuplicates should add two lists that are the same together in order without duplicates.``() =
            Assert.AreEqual([1..10], unionOfSortedRemoveDuplicates [1..10] [1..10])

        [<TestMethod>]
        member x.``ListLibraryFunctions unionOfSortedRemoveDuplicates should add two lists that have some overlap together in order without duplicates.``() =
            Assert.AreEqual([1..81], unionOfSortedRemoveDuplicates [1..13] [11..81])

        [<TestMethod>]
        member x.``ListLibraryFunctions unionOfSortedRemoveDuplicates should add two lists together in order without duplicates.``() =
            Assert.AreEqual([1..81], unionOfSortedRemoveDuplicates [1..10] [11..81])

        [<TestMethod>]
        member x.``ListLibraryFunctions removeItemsFromList1ThatAreInList2Sorted should remove items that are in the second list.``() =
            Assert.AreEqual(List.append [1..10][92..100], removeItemsFromListThatAreInList2Sorted [1..100] [11..91])

        [<TestMethod>]
        member x.``ListLibraryFunctions removeItemsFromList1ThatAreInList2Sorted should remove items that are in the second list. Nothing in second list overlaps``() =
            Assert.AreEqual([1..100], removeItemsFromListThatAreInList2Sorted [1..100] [111..911])

        [<TestMethod>]
        member x.``ListLibraryFunctions removeItemsFromList1ThatAreInList2Sorted should remove items that are in the second list. All at the beginning.``() =
            Assert.AreEqual([11..100], removeItemsFromListThatAreInList2Sorted [1..100] [1..10])


        [<TestMethod>]
        member x.``ListLibraryFunctions initInfiniteL should return 0L.``() =
            Assert.AreEqual(0L, Seq.head initInfiniteL)

        [<TestMethod>]
        member x.``ListLibraryFunctions initInfiniteL 10001th item should be 10001L.``() =
            Assert.AreEqual(10001L, Seq.nth 10001 initInfiniteL)

        [<TestMethod>]
        member x.``ListLibraryFunctions initInfiniteBigInt should return BigInteger(0).``() =
            Assert.AreEqual(BigInteger(0), Seq.head initInfiniteBigInt)

        [<TestMethod>]
        member x.``ListLibraryFunctions initInfiniteBigInt 10001th item should be BigInteger(10001).``() =
            Assert.AreEqual(BigInteger(10001), Seq.nth 10001 initInfiniteBigInt)

        [<TestMethod>]
        member x.``ListLibraryFunctions convertListToBigIntegers [1;2;3] should return BigInts.``() =
            let expected = [BigInteger(1);BigInteger(2);BigInteger(3)]
            let actual = convertListToBigIntegers [1..3]

            Assert.AreEqual(expected, actual)

