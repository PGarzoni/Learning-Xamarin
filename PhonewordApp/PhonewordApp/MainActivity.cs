using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Content;

namespace PhonewordApp
{
    [Activity(Label = "Phoneword App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        static readonly List<string> phoneNumbers = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EditText PhoneNumberText = FindViewById<EditText>(Resource.Id.PhoneWordText);
            TextView TranslatedPhoneText = FindViewById<TextView>(Resource.Id.TranslatedResults);
            Button TranslationBtn = FindViewById<Button>(Resource.Id.TranslationBtn);
            Button TranslationHistoryBtn = FindViewById<Button>(Resource.Id.TranslatedHistoryBtn);

            TranslationBtn.Click += delegate
            {
                string translated = Translate.ToNumber(PhoneNumberText.Text);
                if (translated.Length < 0)
                    TranslatedPhoneText.Text = "";
                else
                {
                    TranslatedPhoneText.Text = translated;
                    phoneNumbers.Add(translated);
                    TranslationHistoryBtn.Enabled = true;
                }
            };

            TranslationHistoryBtn.Click += delegate
            {
                var intent = new Intent(this, typeof(TranslatedHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };
        }
    }
}

