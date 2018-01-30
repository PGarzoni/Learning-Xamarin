using Android.App;
using Android.OS;

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

            Android.Widget.Button FirstPageBtn = FindViewById<Android.Widget.Button>(Resource.Id.helloViewBtn);
            FirstPageBtn.Click += delegate
            {
                SetContentView(Resource.Layout.FirstPage); // <-- Worked... in a way
            };
        }
    }
}

    