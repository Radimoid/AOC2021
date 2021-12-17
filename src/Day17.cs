using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AOC2021 {
    class Day17 {
        string line = Common.ReadAllText("input17.txt");
        int x1, x2, y1, y2;

        public Day17() {
            var pattern = @"target area: x=(\-?[0-9]+)\.\.(\-?[0-9]+), y=(\-?[0-9]+)\.\.(\-?[0-9]+)";
            var match = Regex.Match(line, pattern);
            x1 = int.Parse(match.Groups[1].Value);
            x2 = int.Parse(match.Groups[2].Value);
            y1 = int.Parse(match.Groups[3].Value);
            y2 = int.Parse(match.Groups[4].Value);
        }

        List<int> GetStepsToTarget(int vx0) {
            int n = 0;
            int x = 0;
            var ret = new List<int>();
            while (x < x2) {
                n++;
                x += vx0;
                if (x > x2)
                    return ret;

                if (x >= x1)
                    ret.Add(n);
                if (vx0 > 0)
                    vx0--;
            }

            return ret;
        }

        int GetYtop(int vy) {
            int y = 0;
            while (vy > 0) {
                vy--;
                y += vy;
               
            }
            return y;
        }

        public void PartOne() {
            int y1abs = Math.Abs(y1);
            int y2abs = Math.Abs(y2);
            int ymax = y1abs > y2abs ? y1abs : y2abs;
            int ytop = GetYtop(ymax);
            Console.WriteLine(ytop);
        }

        public void PartTwo() {

        }
    }
}
