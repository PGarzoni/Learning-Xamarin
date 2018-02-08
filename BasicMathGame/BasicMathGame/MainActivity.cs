using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace BasicMathGame
{
    [Activity(Label = "Menu System Demo", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainMenu);

            // buttons
            Button NewGame = FindViewById<Button>(Resource.Id.mathSelectBtn);
            Button ScoreBoard = FindViewById<Button>(Resource.Id.scoreboardBtn);

            //button clicks
            NewGame.Click += delegate
            {
                StartActivity(new Intent(this, typeof(MathSelectionMenu)));
                OverridePendingTransition(Resource.Animation.design_snackbar_in, Resource.Animation.design_snackbar_out);
                this.Finish(); // <-- kills MainActivity activity
            };
        }
    }
}

