/*
---Day 14: Extended Polymerization ---
The incredible pressures at this depth are starting to put a strain on your submarine. The submarine has polymerization equipment that would produce suitable materials to reinforce the submarine, and the nearby volcanically-active caves should even have the necessary input elements in sufficient quantities.

The submarine manual contains instructions for finding the optimal polymer formula; specifically, it offers a polymer template and a list of pair insertion rules (your puzzle input). You just need to work out what polymer would result after repeating the pair insertion process a few times.

For example:

NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C
The first line is the polymer template - this is the starting point of the process.

The following section defines the pair insertion rules. A rule like AB -> C means that when elements A and B are immediately adjacent, element C should be inserted between them. These insertions all happen simultaneously.

So, starting with the polymer template NNCB, the first step simultaneously considers all three pairs:

The first pair (NN) matches the rule NN -> C, so element C is inserted between the first N and the second N.
The second pair (NC) matches the rule NC -> B, so element B is inserted between the N and the C.
The third pair (CB) matches the rule CB -> H, so element H is inserted between the C and the B.
Note that these pairs overlap: the second element of one pair is the first element of the next pair. Also, because all pairs are considered simultaneously, inserted elements are not considered to be part of a pair until the next step.

After the first step of this process, the polymer becomes NCNBCHB.

Here are the results of a few steps using the above rules:

Template: NNCB
After step 1: NCNBCHB
After step 2: NBCCNBBBCBHCB
After step 3: NBBBCNCCNBBNBNBBCHBHHBCHB
After step 4: NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB
This polymer grows quickly. After step 5, it has length 97; After step 10, it has length 3073. After step 10, B occurs 1749 times, C occurs 298 times, H occurs 161 times, and N occurs 865 times; taking the quantity of the most common element (B, 1749) and subtracting the quantity of the least common element (H, 161) produces 1749 - 161 = 1588.

Apply 10 steps of pair insertion to the polymer template and find the most and least common elements in the result. What do you get if you take the quantity of the most common element and subtract the quantity of the least common element?

Your puzzle answer was 3342.

--- Part Two ---
The resulting polymer isn't nearly strong enough to reinforce the submarine. You'll need to run more steps of the pair insertion process; a total of 40 steps should do it.

In the above example, the most common element is B (occurring 2192039569602 times) and the least common element is H (occurring 3849876073 times); subtracting these produces 2188189693529.

Apply 40 steps of pair insertion to the polymer template and find the most and least common elements in the result. What do you get if you take the quantity of the most common element and subtract the quantity of the least common element?

Your puzzle answer was 3776553567525.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AOC2021 {
    class Day14 {
        string[] _lines = Common.ReadLines("input14.txt");
        Dictionary<string, string> _rules = new Dictionary<string, string>();
        Dictionary<string, long> _pairs = null;
        Dictionary<string, long> _letters = null;

        public Day14() {
            for (int i = 2; i < _lines.Length; i++) {
                string pattern = @"(\w{2}) -> (\w)";
                var match = Regex.Match(_lines[i], pattern);
                if (match.Success) {
                    _rules[match.Groups[1].Value] = match.Groups[2].Value;
                }
                else {
                    throw new Exception();
                }
            }            
        }

        void AddPair(string pair, long cnt) {
            if (_pairs.ContainsKey(pair))
                _pairs[pair] += cnt;
            else
                _pairs.Add(pair, cnt);
        }

        void AddLetter(string letter, long cnt) {
            if (_letters.ContainsKey(letter))
                _letters[letter] += cnt;
            else
                _letters.Add(letter, cnt);
        }

        void Init() {
            _letters = new Dictionary<string, long>();
            for (int i = 0; i < _lines[0].Length; i++) {
                AddLetter(_lines[0].Substring(i, 1), 1);
            }

            _pairs = new Dictionary<string, long>();
            for (int i = 1; i < _lines[0].Length; i++) {
                AddPair(_lines[0].Substring(i - 1, 2), 1);
            }
        }

        void PerformStep() {
            var prevPairs = _pairs;
            _pairs = new Dictionary<string, long>();
            foreach (var pair in prevPairs) {
                var letter = _rules[pair.Key];
                var cnt = pair.Value;
                AddLetter(letter, cnt);
                string pair1 = pair.Key[0].ToString() + letter;
                AddPair(pair1, cnt);
                string pair2 = letter + pair.Key[1].ToString();
                AddPair(pair2, cnt);
            }
        }

        long Result() {
            long max = 0;
            long min = long.MaxValue;
            foreach (var letter in _letters) {
                if (letter.Value > max)
                    max = letter.Value;
                if (letter.Value < min)
                    min = letter.Value;
            }

            return max - min;
        }

        public void PartOne() {
            Init();
            for (int step = 0; step < 10; step++) {
                PerformStep();
            }                        
            long res = Result();
            Console.WriteLine(res);
        }

        public void PartTwo() {
            Init();
            for (int step = 0; step < 40; step++) {
                PerformStep();
            }
            long res = Result();
            Console.WriteLine(res);
        }
    }
}
