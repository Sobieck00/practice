(ns hr.clojure.algorithms.warmup.implementation.library-fine)

(defn date-differences
  [dueDate dateReturned]
  (->>
    (map vector dueDate dateReturned)
    reverse
    (map
      #(reduce - %))
    (map
      #(* -1 %))))

(defn how-overdue
  [dueDate dateReturned]
  (loop
    [result []
     input (date-differences dueDate dateReturned)]
     (if
       (empty? input)
       result
       (cond
         (> 0 (first input))
          [0 0 0]
         (< 0 (first input))
          (recur
           (assoc
             [0 0 0]
             (-
               3
               (count input))
             (first input))
           [])
         :else
          (recur
           (cons 0 result)
           (rest input))))))

(defn fine-amount
  [dueDate dateReturned]
  (let
    [howOverdue (how-overdue dueDate dateReturned)]
      (cond
        (> (first howOverdue) 0) 10000
        (> (second howOverdue) 0) (* (second howOverdue) 500)
        (> (last howOverdue) 0) (* (last howOverdue) 15)
        :else 0)))
