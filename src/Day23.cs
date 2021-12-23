/*
--- Day 23: Amphipod ---
A group of amphipods notice your fancy submarine and flag you down. "With such an impressive shell," one amphipod says, "surely you can help us with a question that has stumped our best scientists."

They go on to explain that a group of timid, stubborn amphipods live in a nearby burrow. Four types of amphipods live there: Amber (A), Bronze (B), Copper (C), and Desert (D). They live in a burrow that consists of a hallway and four side rooms. The side rooms are initially full of amphipods, and the hallway is initially empty.

They give you a diagram of the situation (your puzzle input), including locations of each amphipod (A, B, C, or D, each of which is occupying an otherwise open space), walls (#), and open space (.).

For example:

#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########
The amphipods would like a method to organize every amphipod into side rooms so that each side room contains one type of amphipod and the types are sorted A-D going left to right, like this:

#############
#...........#
###A#B#C#D###
  #A#B#C#D#
  #########
Amphipods can move up, down, left, or right so long as they are moving into an unoccupied open space. Each type of amphipod requires a different amount of energy to move one step: Amber amphipods require 1 energy per step, Bronze amphipods require 10 energy, Copper amphipods require 100, and Desert ones require 1000. The amphipods would like you to find a way to organize the amphipods that requires the least total energy.

However, because they are timid and stubborn, the amphipods have some extra rules:

Amphipods will never stop on the space immediately outside any room. They can move into that space so long as they immediately continue moving. (Specifically, this refers to the four open spaces in the hallway that are directly above an amphipod starting position.)
Amphipods will never move from the hallway into a room unless that room is their destination room and that room contains no amphipods which do not also have that room as their own destination. If an amphipod's starting room is not its destination room, it can stay in that room until it leaves the room. (For example, an Amber amphipod will not move from the hallway into the right three rooms, and will only move into the leftmost room if that room is empty or if it only contains other Amber amphipods.)
Once an amphipod stops moving in the hallway, it will stay in that spot until it can move into a room. (That is, once any amphipod starts moving, any other amphipods currently in the hallway are locked in place and will not move again until they can move fully into a room.)
In the above example, the amphipods can be organized using a minimum of 12521 energy. One way to do this is shown below.

Starting configuration:

#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########
One Bronze amphipod moves into the hallway, taking 4 steps and using 40 energy:

#############
#...B.......#
###B#C#.#D###
  #A#D#C#A#
  #########
The only Copper amphipod not in its side room moves there, taking 4 steps and using 400 energy:

#############
#...B.......#
###B#.#C#D###
  #A#D#C#A#
  #########
A Desert amphipod moves out of the way, taking 3 steps and using 3000 energy, and then the Bronze amphipod takes its place, taking 3 steps and using 30 energy:

#############
#.....D.....#
###B#.#C#D###
  #A#B#C#A#
  #########
The leftmost Bronze amphipod moves to its room using 40 energy:

#############
#.....D.....#
###.#B#C#D###
  #A#B#C#A#
  #########
Both amphipods in the rightmost room move into the hallway, using 2003 energy in total:

#############
#.....D.D.A.#
###.#B#C#.###
  #A#B#C#.#
  #########
Both Desert amphipods move into the rightmost room using 7000 energy:

#############
#.........A.#
###.#B#C#D###
  #A#B#C#D#
  #########
Finally, the last Amber amphipod moves into its room, using 8 energy:

#############
#...........#
###A#B#C#D###
  #A#B#C#D#
  #########
What is the least energy required to organize the amphipods?

Your puzzle answer was 13455.

--- Part Two ---
As you prepare to give the amphipods your solution, you notice that the diagram they handed you was actually folded up. As you unfold it, you discover an extra part of the diagram.

Between the first and second lines of text that contain amphipod starting positions, insert the following lines:

  #D#C#B#A#
  #D#B#A#C#
So, the above example now becomes:

#############
#...........#
###B#C#B#D###
  #D#C#B#A#
  #D#B#A#C#
  #A#D#C#A#
  #########
The amphipods still want to be organized into rooms similar to before:

#############
#...........#
###A#B#C#D###
  #A#B#C#D#
  #A#B#C#D#
  #A#B#C#D#
  #########
In this updated example, the least energy required to organize these amphipods is 44169:

#############
#...........#
###B#C#B#D###
  #D#C#B#A#
  #D#B#A#C#
  #A#D#C#A#
  #########

#############
#..........D#
###B#C#B#.###
  #D#C#B#A#
  #D#B#A#C#
  #A#D#C#A#
  #########

#############
#A.........D#
###B#C#B#.###
  #D#C#B#.#
  #D#B#A#C#
  #A#D#C#A#
  #########

#############
#A........BD#
###B#C#.#.###
  #D#C#B#.#
  #D#B#A#C#
  #A#D#C#A#
  #########

#############
#A......B.BD#
###B#C#.#.###
  #D#C#.#.#
  #D#B#A#C#
  #A#D#C#A#
  #########

#############
#AA.....B.BD#
###B#C#.#.###
  #D#C#.#.#
  #D#B#.#C#
  #A#D#C#A#
  #########

#############
#AA.....B.BD#
###B#.#.#.###
  #D#C#.#.#
  #D#B#C#C#
  #A#D#C#A#
  #########

#############
#AA.....B.BD#
###B#.#.#.###
  #D#.#C#.#
  #D#B#C#C#
  #A#D#C#A#
  #########

#############
#AA...B.B.BD#
###B#.#.#.###
  #D#.#C#.#
  #D#.#C#C#
  #A#D#C#A#
  #########

#############
#AA.D.B.B.BD#
###B#.#.#.###
  #D#.#C#.#
  #D#.#C#C#
  #A#.#C#A#
  #########

#############
#AA.D...B.BD#
###B#.#.#.###
  #D#.#C#.#
  #D#.#C#C#
  #A#B#C#A#
  #########

#############
#AA.D.....BD#
###B#.#.#.###
  #D#.#C#.#
  #D#B#C#C#
  #A#B#C#A#
  #########

#############
#AA.D......D#
###B#.#.#.###
  #D#B#C#.#
  #D#B#C#C#
  #A#B#C#A#
  #########

#############
#AA.D......D#
###B#.#C#.###
  #D#B#C#.#
  #D#B#C#.#
  #A#B#C#A#
  #########

#############
#AA.D.....AD#
###B#.#C#.###
  #D#B#C#.#
  #D#B#C#.#
  #A#B#C#.#
  #########

#############
#AA.......AD#
###B#.#C#.###
  #D#B#C#.#
  #D#B#C#.#
  #A#B#C#D#
  #########

#############
#AA.......AD#
###.#B#C#.###
  #D#B#C#.#
  #D#B#C#.#
  #A#B#C#D#
  #########

#############
#AA.......AD#
###.#B#C#.###
  #.#B#C#.#
  #D#B#C#D#
  #A#B#C#D#
  #########

#############
#AA.D.....AD#
###.#B#C#.###
  #.#B#C#.#
  #.#B#C#D#
  #A#B#C#D#
  #########

#############
#A..D.....AD#
###.#B#C#.###
  #.#B#C#.#
  #A#B#C#D#
  #A#B#C#D#
  #########

#############
#...D.....AD#
###.#B#C#.###
  #A#B#C#.#
  #A#B#C#D#
  #A#B#C#D#
  #########

#############
#.........AD#
###.#B#C#.###
  #A#B#C#D#
  #A#B#C#D#
  #A#B#C#D#
  #########

#############
#..........D#
###A#B#C#.###
  #A#B#C#D#
  #A#B#C#D#
  #A#B#C#D#
  #########

#############
#...........#
###A#B#C#D###
  #A#B#C#D#
  #A#B#C#D#
  #A#B#C#D#
  #########
Using the initial configuration from the full diagram, what is the least energy required to organize the amphipods?

Your puzzle answer was 43567.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021 {
    class Day23 {
        string[] lines = Common.ReadLines("input23.txt");
        Dictionary<string, long> answers;
        Dictionary<char, long> costs = new Dictionary<char, long> { { 'A', 1 }, { 'B', 10 }, { 'C', 100 }, { 'D', 1000 } };
        Dictionary<char, int> roomCols = new Dictionary<char, int> { { 'A', 2 }, { 'B', 4 }, { 'C', 6 }, { 'D', 8 } };
        char empty = '.';
               
        string GetKey((Dictionary<char, char[]> rooms, char[] top) state) {
            string str = "";
            foreach (var room in state.rooms)
                str += new string(room.Value);
            str += new string(state.top);
            return str;
        }

        (Dictionary<char, char[]> rooms, char[] top) CopyState((Dictionary<char, char[]> rooms, char[] top) state) {
            var newRooms = new Dictionary<char, char[]>();
            foreach (var room in state.rooms) {
                newRooms.Add(room.Key, (char[])room.Value.Clone());
            }
            var newTops = (char[])state.top.Clone();
            return (newRooms, newTops);            
        }

        bool IsRoomDone(KeyValuePair<char, char[]> room) {
            foreach (var space in room.Value) {
                if (space != room.Key)
                    return false;
            }
            return true;
        }

        bool IsDone((Dictionary<char, char[]> rooms, char[] top) state) {
            foreach (var room in state.rooms) {
                if (!IsRoomDone(room))
                    return false;
            }
            return true;
        }

        bool IsEmpty(char c) {
            return c == empty;
        }

        int GetLevelInRoom(char[] room, char amphipod) {
            int level = -1;
            for (int i = 0; i < room.Length; i++) {
                if (IsEmpty(room[i])) {
                    level = i;
                }
                else if (room[i] != amphipod) {
                    return -1;
                }
            }
            return level;
        }

        bool IsClearPath(int colFrom, int colTo, char[] top, bool checkFrom) {
            if (colFrom > colTo) {
                for (int col = checkFrom ? colFrom : colFrom - 1; col >= colTo; col--)
                    if (!IsEmpty(top[col]))
                        return false;
            }
            else {
                for (int col = checkFrom ? colFrom : colFrom + 1; col <= colTo; col++)
                    if (!IsEmpty(top[col]))
                        return false;
            }
            return true;
        }

        int Distance(int rowFrom, int colFrom, int rowTo, int colTo) {
            return Math.Abs(rowFrom - rowTo) + Math.Abs(colFrom - colTo);
        }

        long Cost(int rowFrom, int colFrom, int rowTo, int colTo, char amphipod) {
            return Distance(rowFrom, colFrom, rowTo, colTo) * costs[amphipod];
        }

        bool CanMoveFrom(KeyValuePair<char, char[]> room) {
            foreach (var c in room.Value)
                if (!IsEmpty(c) && c != room.Key)
                    return true;
            return false;
        }

        void ShowState((Dictionary<char, char[]> rooms, char[] top) state) {
            Console.WriteLine("#############");
            Console.Write("#");
            foreach (var c in state.top) {
                Console.Write(c);
            }
            Console.WriteLine("#");
           
            for (int level = 0; level < state.rooms['A'].Length; level++) {
                Console.Write(level == 0 ? "###" : "  #");
                foreach (var room in state.rooms) {
                    Console.Write(room.Value[level]);
                    Console.Write("#");
                }
                Console.WriteLine(level == 0 ? "##" : "  ");
            }
            Console.WriteLine("  #########");            
        }

        long SumCost(long cost1, long cost2) {
            if (cost1 == long.MaxValue || cost2 == long.MaxValue)
                return long.MaxValue;
            else
                return cost1 + cost2;
        }

        long GetMinCost((Dictionary<char, char[]> rooms, char[] top) state) {
          // ShowState(state);

            var key = GetKey(state);
            if (answers.ContainsKey(key))
                return answers[key];

            if (IsDone(state)) {
                answers[key] = 0;
                return 0;
            }

            (var rooms, var top) = state;

            long minCost = long.MaxValue;

            // Pohyb příšerky domů
            for (int col = 0; col < top.Length; col++) {
                if (!IsEmpty(top[col])) {
                    var amphipod = top[col];
                    var roomCol = roomCols[amphipod];
                    if (IsClearPath(col, roomCol, top, false)) {
                        var room = rooms[amphipod];
                        var level = GetLevelInRoom(room, amphipod);
                        if (level > -1) {
                            long cost = Cost(0, col, level + 1, roomCol, amphipod);
                            var newState = CopyState(state);
                            newState.rooms[amphipod][level] = amphipod;                            
                            newState.top[col] = empty;
                            minCost = Math.Min(minCost, SumCost(cost, GetMinCost(newState)));
                        }
                    }
                }                
            }

            // Pohyb příšerky ven
            foreach (var room in rooms) {
                var fields = room.Value;
                for (int level = 0; level < fields.Length; level++) {
                    if (!IsEmpty(fields[level])) {
                        var amphipod = fields[level];
                        if (CanMoveFrom(room)) {
                            var roomCol = roomCols[room.Key];
                            for (int col = 0; col < top.Length; col++) {
                                if (!roomCols.ContainsValue(col)) {
                                    if (IsClearPath(roomCol, col, top, true)) {
                                        long cost = Cost(0, col, level + 1, roomCol, amphipod);
                                        var newState = CopyState(state);
                                        newState.rooms[room.Key][level] = empty;
                                        newState.top[col] = amphipod;
                                        minCost = Math.Min(minCost, SumCost(cost, GetMinCost(newState)));
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
                        
            answers[key] = minCost;
            return minCost;
        }

        (Dictionary<char, char[]> rooms, char[] top) begin = (
                new Dictionary<char, char[]>(),
                new char[11]
                );

        public void PartOne() {            
            begin.rooms['A'] = new char[] { lines[2][3], lines[3][3] };
            begin.rooms['B'] = new char[] { lines[2][5], lines[3][5] };
            begin.rooms['C'] = new char[] { lines[2][7], lines[3][7] };
            begin.rooms['D'] = new char[] { lines[2][9], lines[3][9] };

            for (int i = 0; i < begin.top.Length; i++) {
                begin.top[i] = '.';
            }

            answers = new Dictionary<string, long>();
                                               
            long minCost = GetMinCost(begin);
            Console.WriteLine(minCost);
        }

        public void PartTwo() {
            begin.rooms['A'] = new char[] { lines[2][3], 'D', 'D', lines[3][3] };
            begin.rooms['B'] = new char[] { lines[2][5], 'C', 'B', lines[3][5] };
            begin.rooms['C'] = new char[] { lines[2][7], 'B', 'A', lines[3][7] };
            begin.rooms['D'] = new char[] { lines[2][9], 'A', 'C', lines[3][9] };

            for (int i = 0; i < begin.top.Length; i++) {
                begin.top[i] = '.';
            }

            answers = new Dictionary<string, long>();

            long minCost = GetMinCost(begin);
            Console.WriteLine(minCost);
        }
    }
}
