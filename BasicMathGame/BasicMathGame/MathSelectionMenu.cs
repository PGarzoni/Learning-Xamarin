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
    [Activity(Label = "Math Select")]
    public class MathSelectionMenu : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MathSelectionMenu);

            Button Addition = FindViewById<Button>(Resource.Id.additionBtn);
            Button Subtraction = FindViewById<Button>(Resource.Id.subtractionBtn);
            Button Multiplication = FindViewById<Button>(Resource.Id.multiplicationBtn);
            Button Division = FindViewById<Button>(Resource.Id.divisionBtn);

            //button clicks
            Addition.Click += delegate
            {
                StartActivity(new Intent(this, typeof(MathSelectionMenu)));
                OverridePendingTransition(Resource.Animation.design_snackbar_in, Resource.Animation.design_snackbar_out);
                this.Finish(); // <-- kills MainActivity activity
            };
        }
    }
}