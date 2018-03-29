using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

namespace TicTacToe
{
    [Activity(Label = "TicTacToe", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            base.OnCreate(savedInstanceState);

            StartActivity(new Intent(this, typeof(Game)));
            this.Finish();
        }
    }
}

