﻿using System;
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

            EditText mathAnswer = FindViewById<EditText>(Resource.Id.mathAnswer);
            mathAnswer.RequestFocus();
            
        }
    }
}