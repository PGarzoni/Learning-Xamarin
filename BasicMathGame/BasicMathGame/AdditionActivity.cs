using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BasicMathGame
{
    [Activity(Label = "Addition Activity", WindowSoftInputMode = SoftInput.StateAlwaysVisible)]
    public class AdditionActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AdditionGame);

            //initialize game
            MathGame mathGame = new MathGame(MathType.Add);
            int score = 0;

            //setup buttons and text options
            TextView MathQuestion = FindViewById<TextView>(Resource.Id.mathQuestion);
            TextView ScoreCounter = FindViewById<TextView>(Resource.Id.scoreCounter);
            EditText MathAnswer = FindViewById<EditText>(Resource.Id.mathAnswer);
            Button AnswerBtn = FindViewById<Button>(Resource.Id.answerBtn);

            MathAnswer.RequestFocus(); // focus field
            MathQuestion.Text = String.Format(@"{0} + {1} = ?", mathGame.X, mathGame.Y); // set question

            AnswerBtn.Click += delegate
            {
                if (!string.IsNullOrEmpty(MathAnswer.Text))
                {
                    if (int.Parse(MathAnswer.Text).Equals(mathGame.Answer))
                    {
                        score++;
                        mathGame.GenerateMathProblem();
                        MathQuestion.Text = String.Format(@"{0} + {1} = ?", mathGame.X, mathGame.Y);
                    }
                    else
                    {
                        score--;
                    }
                    ScoreCounter.Text = String.Format(@"Score: {0}", score);
                    MathAnswer.Text = string.Empty;
                }
            };
        }
    }
}