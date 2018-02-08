using System;
using System.Collections.Generic;

namespace BasicMathGame
{
    public enum MathMode { Add, Sub, Mul, Div };
    public class MathGame
    {
        private MathMode mathMode;

        public MathGame(MathMode mathMode)
        {
            this.mathMode = mathMode;
        }

        public List<int> GenerateMathProblem()
        {
            List<int> list = new List<int>();
            Random rand = new Random();
            int x = rand.Next() % 10;
            int y = rand.Next() % 10;

            if (mathMode.Equals(MathMode.Div))
            {
                while (y < 0)
                    y = rand.Next() % 10;
                x = x * y; // this ensures the answer is a whole number
            }

            list.Add(x);
            list.Add(y);

            switch (mathMode)
            {
                case MathMode.Add:
                    list.Add(x + y);
                    break;
                case MathMode.Sub:
                    list.Add(x - y);
                    break;
                case MathMode.Mul:
                    list.Add(x * y);
                    break;
                case MathMode.Div:
                    list.Add(x / y);
                    break;
            }
            return list;
        }
    }
}