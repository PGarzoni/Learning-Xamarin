using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace HelloWorld
{
    [Activity(Label = "HelloWorld", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button FirstPageBtn = FindViewById<Button>(Resource.Id.FirstPageBtn);
            FirstPageBtn.Click += delegate
            {
                StartActivity(new Intent(this, typeof(FirstPage)));
                OverridePendingTransition(Resource.Animation.abc_popup_enter, Resource.Animation.abc_popup_exit);
                this.Finish(); // <-- kills MainActivity activity
            };
        }
    }
}

    