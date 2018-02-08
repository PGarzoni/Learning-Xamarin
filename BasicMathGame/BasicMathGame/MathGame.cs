using System;
using System.Collections.Generic;

namespace BasicMathGame
{
    public enum MathType { Add, Sub, Mul, Div };
    public class MathGame
    {
        private MathType mathMode;
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Answer { get; private set; }

        public MathGame(MathType mathMode)
        {
            this.mathMode = mathMode;
            GenerateMathProblem();
        }

        public void GenerateMathProblem()
        {
            Random rand = new Random();
            X = rand.Next() % 10;
            Y = rand.Next() % 10;

            switch (mathMode)
            {
                case MathType.Add:
                    Answer = X + Y;
                    break;
                case MathType.Sub:
                    Answer = X - Y;
                    break;
                case MathType.Mul:
                    Answer = X* Y;
                    break;
                case MathType.Div:
                    while (Y < 0)
                        Y = rand.Next() % 10;
                    Answer = X;
                    X = X * Y;
                    break;
            }
        }
    }
}