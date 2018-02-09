using System;
using System.Collections.Generic;

namespace BasicMathGame
{
    public enum MathType { Add, Sub, Mul, Div };
    public class MathGame
    {
        private MathType mathType;
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Symbol { get; private set; }
        public int Answer { get; private set; }
        public string MathTitle { get; private set; }

        public MathGame(MathType mathType)
        {
            this.mathType = mathType;
            GenerateMathProblem();
        }

        public void GenerateMathProblem()
        {
            Random rand = new Random();
            X = rand.Next() % 10;
            Y = rand.Next() % 10;

            switch (mathType)
            {
                case MathType.Add:
                    Answer = X + Y;
                    Symbol = '+';
                    MathTitle = "Addition";
                    break;
                case MathType.Sub:
                    if(X < Y)
                    {
                        int T = X;
                        X = Y;
                        Y = T;
                    }
                    Answer = X - Y;
                    Symbol = '-';
                    MathTitle = "Subtraction";
                    break;
                case MathType.Mul:
                    Answer = X * Y;
                    Symbol = '*';
                    MathTitle = "Multiplication";
                    break;
                case MathType.Div:
                    while (Y <= 0)
                        Y = rand.Next() % 10;
                    Answer = X;
                    X = X * Y;
                    Symbol = '/';
                    MathTitle = "Division";
                    break;
            }
        }

        
    }
}