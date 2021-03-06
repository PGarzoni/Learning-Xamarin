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

namespace HelloWorld
{
    [Activity(Label = "FirstPage")]
    public class FirstPage : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.FirstPage);

            Button Home = FindViewById<Button>(Resource.Id.HomeBtn);
            Home.Click += delegate
            {
                StartActivity(new Intent(this, typeof(MainActivity)));
                OverridePendingTransition(Resource.Animation.design_snackbar_in, Resource.Animation.design_snackbar_out);
                this.Finish(); // <-- kills FirstPage activity
            };
        }
    }
}