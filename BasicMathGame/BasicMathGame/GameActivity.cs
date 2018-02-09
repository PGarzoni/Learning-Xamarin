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
using Newtonsoft.Json;

namespace BasicMathGame
{
    [Activity(Label = "Game Activity", WindowSoftInputMode = SoftInput.StateAlwaysVisible)]
    public class GameActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GameBoard);

            var mathType = JsonConvert.DeserializeObject<MathType>(Intent.GetStringExtra("MathType"));

            //initialize game
            MathGame mathGame = new MathGame(mathType);
            int score = 0;

            //setup buttons and text options
            TextView Title = FindViewById<TextView>(Resource.Id.title);
            TextView MathQuestion = FindViewById<TextView>(Resource.Id.mathQuestion);
            TextView ScoreCounter = FindViewById<TextView>(Resource.Id.scoreCounter);
            EditText MathAnswer = FindViewById<EditText>(Resource.Id.mathAnswer);
            Button AnswerBtn = FindViewById<Button>(Resource.Id.answerBtn);

            Title.Text = mathGame.MathTitle;
            MathQuestion.Text = String.Format(@"{0} {1} {2} = ?", mathGame.X, mathGame.Symbol, mathGame.Y); // set question
            MathAnswer.RequestFocus(); // focus field

            AnswerBtn.Click += delegate
            {
                if (!string.IsNullOrEmpty(MathAnswer.Text))
                {
                    if (int.Parse(MathAnswer.Text).Equals(mathGame.Answer))
                    {
                        score++;
                        mathGame.GenerateMathProblem();
                        MathQuestion.Text = String.Format(@"{0} {1} {2} = ?", mathGame.X, mathGame.Symbol, mathGame.Y);
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