;To Use
;(load-file "C:/Users/Thomas/Documents/GitHub/practice/utilities/nonvisualstudio/clojure/Implementation/Sequences.clj")
;(use 'utilities.sequences)

(ns utilities.sequences)

(defn sum [seqToSum]
  (reduce + seqToSum))

(defn firstInts [x]
  (range 1 (+ 1 x)))

