module TestAbstract where

    import Test.HUnit

    easyAssertEqual functionName function input expected = assertEqual nameOfTest expected (function input)
        where
            nameOfTest = functionName ++ " " ++ (show input) ++ " should return " ++ (show expected) ++ "."

    easyAssertEqualTwoInputs functionName function input1 input2 expected = assertEqual nameOfTest expected (function input1 input2)
      where nameOfTest = functionName ++ " " ++ (show input1) ++ " " ++ (show input2) ++ " should return " ++ (show expected) ++ "."
