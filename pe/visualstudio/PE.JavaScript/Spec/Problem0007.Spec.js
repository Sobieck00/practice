﻿var javascriptPE;
(function (javascriptPE) {
    (function (spec) {

        (function (problem0007) {

            describe('problem0007', function () {
                var problem0007;
                var mathHelpers;

                beforeEach(function () {
                    mathHelpers = new libraries.helpers.mathHelpers();

                    problem0007 = new javascriptPE.implementation.problem0007(mathHelpers);
                });

                describe('nthPrime', function() {

                    it('should return 2 when input is 1.', function() {
                        nthPrimeAssert(2, 1);
                    });

                    it('should return 13 when input is 6.', function () {
                        nthPrimeAssert(13, 6);
                    });

                    it('should return 7 when input is 4.', function () {
                        nthPrimeAssert(7, 4);
                    });

                    //4 seconds.
                    //it('should return 104743 when input is 10001.', function() {
                    //    nthPrimeAssert(104743, 10001);
                    //});

                    function nthPrimeAssert(expected, input) {
                        expect(problem0007.nthPrime(input)).toBe(expected);
                    }
                });
            });

        })(spec.problem0007 || (spec.problem0007 = {}));
    })(javascriptPE.spec || (javascriptPE.spec = {}));
})(javascriptPE || (javascriptPE = {}));