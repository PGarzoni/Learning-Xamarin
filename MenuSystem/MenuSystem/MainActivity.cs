using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace MenuSystem
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
            Button NewGame = FindViewById<Button>(Resource.Id.newgameBtn);
            Button LoadGame = FindViewById<Button>(Resource.Id.loadgameBtn);
            Button ScoreBoard = FindViewById<Button>(Resource.Id.scoreboardBtn);

            //button clicks
            NewGame.Click += delegate
            {
                StartActivity(new Intent(this, typeof(DifficultySelection)));
                OverridePendingTransition(Resource.Animation.abc_popup_enter, Resource.Animation.abc_popup_exit);
                this.Finish(); // <-- kills MainActivity activity
            };
        }
    }
}

