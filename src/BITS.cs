using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021 {
    class BITS {
        class Code {
            string _s = "";
            int _index;

            public Code(string s) {
                _index = 0;
                foreach (var c in s) {
                    byte b = Convert.ToByte(c.ToString(), 16);
                    var asString = Convert.ToString(b, 2).PadLeft(4, '0');
                    _s += asString;
                }
            }

            public int GetIndex() {
                return _index;
            }

            public int GetInt(int bits) {
                var intAsString = _s.Substring(_index, bits);
                _index += bits;
                return Convert.ToInt32(intAsString, 2);
            }

            public bool GetBool() {
                bool ret = _s[_index] == '1';
                _index++;
                return ret;
            }

            public string GetString(int bits) {
                var ret = _s.Substring(_index, bits);
                _index += bits;
                return ret;
            }
        };
        
        abstract class PacketType {
            public abstract void Read(Code code);
            public abstract int GetVersionSum();
            public abstract long GetValue();

        };

        class Literal : PacketType {
            long value;

            public override void Read(Code code) {
                bool keepReading = true;
                string s = "";
                while (keepReading) {
                    keepReading = code.GetBool();
                    s += code.GetString(4);
                }
                value = Convert.ToInt64(s, 2);
            }

            public override int GetVersionSum() {
                return 0;
            }

            public override long GetValue() {
                return value;
            }
        }

        abstract class Operator : PacketType {
            protected List<Packet> operands = new List<Packet>();

            public override void Read(Code code) {
                var lenTypeId = code.GetBool();
                if (lenTypeId) {
                    int numSubpackets = code.GetInt(11);
                    for (int i = 0; i < numSubpackets; i++) {
                        var operand = new Packet();
                        operand.Read(code);
                        operands.Add(operand);
                    }
                }
                else {
                    int numBits = code.GetInt(15);
                    int stopIndex = code.GetIndex() + numBits;
                    while (code.GetIndex() < stopIndex) {
                        var operand = new Packet();
                        operand.Read(code);
                        operands.Add(operand);
                    }

                }
            }

            public override int GetVersionSum() {
                int sum = 0;
                foreach (var operand in operands)
                    sum += operand.GetVersionSum();
                return sum;
            }
        }

        class Sum : Operator {
            public override long GetValue() {
                long sum = 0;
                foreach (var operand in operands)
                    sum += operand.GetValue();
                return sum;
            }
        }

        class Product : Operator {
            public override long GetValue() {
                long product = 1;
                foreach (var operand in operands)
                    product *= operand.GetValue();
                return product;
            }
        }

        class Minimum : Operator {
            public override long GetValue() {
                long minimum = long.MaxValue;
                foreach (var operand in operands)
                    minimum = Math.Min(minimum, operand.GetValue());                    
                return minimum;
            }
        }

        class Maximum : Operator {
            public override long GetValue() {
                long maximum = long.MinValue;
                foreach (var operand in operands)
                    maximum = Math.Max(maximum, operand.GetValue());
                return maximum;
            }
        }

        class Greater : Operator {
            public override long GetValue() {
                return operands[0].GetValue() > operands[1].GetValue() ? 1 : 0;
            }
        }

        class Less : Operator {
            public override long GetValue() {
                return operands[0].GetValue() < operands[1].GetValue() ? 1 : 0;
            }
        }

        class Equal : Operator {
            public override long GetValue() {
                return operands[0].GetValue() == operands[1].GetValue() ? 1 : 0;
            }
        }

        class Packet {
            int version;
            int type;
            PacketType typeParam;

            public void Read(Code code) {
                version = code.GetInt(3);
                type = code.GetInt(3);

                switch (type) {
                    case 0:
                        typeParam = new Sum();
                        break;
                    case 1:
                        typeParam = new Product();
                        break;
                    case 2:
                        typeParam = new Minimum();
                        break;
                    case 3:
                        typeParam = new Maximum();
                        break;
                    case 4:
                        typeParam = new Literal();
                        break;
                    case 5:
                        typeParam = new Greater();
                        break;
                    case 6:
                        typeParam = new Less();
                        break;
                    case 7:
                        typeParam = new Equal();
                        break;
                }

                typeParam.Read(code);
            }

            public int GetVersionSum() {
                return version + typeParam.GetVersionSum();
            }

            public long GetValue() {
                return typeParam.GetValue();
            }
        }

        Packet _packet = new Packet();

        public void Read(string s) {
            Code code = new Code(s);
            _packet.Read(code);
        }

        public int GetVersionSum() {
            return _packet.GetVersionSum();
        }

        public long GetValue() {
            return _packet.GetValue();
        }
    }
}
