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

namespace TicTacToe
{
    [Activity(Label = "Tic Tac Toe", MainLauncher = true, Icon = "@mipmap/icon")]
    public class Game : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GameBoard);

            //initialize gridlayout
            GridLayout gridLayout = FindViewById<GridLayout>(Resource.Id.gridLayout1);
            gridLayout.LayoutParameters.Width = GetDeviceWidth;
            gridLayout.LayoutParameters.Height = GetDeviceWidth;

            //initialize board variables
            List<TextView> board = new List<TextView>() {
                FindViewById<TextView>(Resource.Id.r1c1),
                FindViewById<TextView>(Resource.Id.r1c2),
                FindViewById<TextView>(Resource.Id.r1c3),
                FindViewById<TextView>(Resource.Id.r2c1),
                FindViewById<TextView>(Resource.Id.r2c2),
                FindViewById<TextView>(Resource.Id.r2c3),
                FindViewById<TextView>(Resource.Id.r3c1),
                FindViewById<TextView>(Resource.Id.r3c2),
                FindViewById<TextView>(Resource.Id.r3c3)
            };
            InitializeBoard(board);

            //initialize current player
            CurrentPlayer = "X";
            SetCurrentPlayerText();
            var playerText = FindViewById<TextView>(Resource.Id.CurrentPlayer);
            playerText.SetTextSize(Android.Util.ComplexUnitType.Dip, GetDeviceWidth / 32);
        }

        private void InitializeBoard(List<TextView> list)
        {
            for(var i = 0; i < list.Count; i++)
            {
                var CellSize = (GetDeviceWidth / 3) - 20;
                list.ElementAt(i).LayoutParameters.Width = CellSize;
                list.ElementAt(i).LayoutParameters.Height = CellSize;

                list.ElementAt(i).Gravity = GravityFlags.Center;
                list.ElementAt(i).SetIncludeFontPadding(false);

                list.ElementAt(i).SetTextSize(Android.Util.ComplexUnitType.FractionParent, 100);


                var j = i;
                list.ElementAt(i).Click += delegate
                {
                    if (list.ElementAt(j).Text == "")
                    {
                        list.ElementAt(j).Text = CurrentPlayer;
                        if (IsWinCondition(list))
                        {
                            ResetBoard(list);
                            Toast.MakeText(this, String.Format("Player {0} wins!", CurrentPlayer), ToastLength.Long).Show();
                        }
                        else if (IsCatsGame(list))
                        {
                            ResetBoard(list);
                            Toast.MakeText(this, "Cats Game!", ToastLength.Long).Show();
                        }
                        ChangePlayer();
                    }
                };
            }
        }

        private string CurrentPlayer { get; set; }
        private void ChangePlayer()
        {
            if (CurrentPlayer.Equals("X"))
            {
                CurrentPlayer = "O";
            }
            else
            {
                CurrentPlayer = "X";
            }
            SetCurrentPlayerText();
        }

        private void SetCurrentPlayerText()
        {
            FindViewById<TextView>(Resource.Id.CurrentPlayer).Text = String.Format(@"Current player: {0}", CurrentPlayer);
        }

        private void ResetBoard(List<TextView> list)
        {
            foreach (TextView tv in list)
            {
                tv.Text = "";
            }
        }

        private bool IsWinCondition(List<TextView> list)
        {
            //0 1 2
            //3 4 5
            //6 7 8
            
            if(
                (!String.IsNullOrWhiteSpace(list.ElementAt(0).Text) && list.ElementAt(0).Text.Equals(list.ElementAt(1).Text) && list.ElementAt(1).Text.Equals(list.ElementAt(2).Text)) || //Row 1
                (!String.IsNullOrWhiteSpace(list.ElementAt(3).Text) && list.ElementAt(3).Text.Equals(list.ElementAt(4).Text) && list.ElementAt(4).Text.Equals(list.ElementAt(5).Text)) || //Row 2
                (!String.IsNullOrWhiteSpace(list.ElementAt(7).Text) && list.ElementAt(6).Text.Equals(list.ElementAt(7).Text) && list.ElementAt(7).Text.Equals(list.ElementAt(8).Text)) || //Row 3
                (!String.IsNullOrWhiteSpace(list.ElementAt(0).Text) && list.ElementAt(0).Text.Equals(list.ElementAt(3).Text) && list.ElementAt(3).Text.Equals(list.ElementAt(6).Text)) || //Column 1
                (!String.IsNullOrWhiteSpace(list.ElementAt(1).Text) && list.ElementAt(1).Text.Equals(list.ElementAt(4).Text) && list.ElementAt(4).Text.Equals(list.ElementAt(7).Text)) || //Column 2
                (!String.IsNullOrWhiteSpace(list.ElementAt(2).Text) && list.ElementAt(2).Text.Equals(list.ElementAt(5).Text) && list.ElementAt(5).Text.Equals(list.ElementAt(8).Text)) || //Column 3
                (!String.IsNullOrWhiteSpace(list.ElementAt(0).Text) && list.ElementAt(0).Text.Equals(list.ElementAt(4).Text) && list.ElementAt(4).Text.Equals(list.ElementAt(8).Text)) || //Diagonal 1
                (!String.IsNullOrWhiteSpace(list.ElementAt(2).Text) && list.ElementAt(2).Text.Equals(list.ElementAt(4).Text) && list.ElementAt(4).Text.Equals(list.ElementAt(6).Text)) ////Diagonal 2
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsCatsGame(List<TextView> list)
        {
            foreach(TextView tv in list)
            {
                if (String.IsNullOrEmpty(tv.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private int GetDeviceWidth
        {
            get { return Resources.DisplayMetrics.WidthPixels; }            
        }

        private int GetDeviceHeight
        {
            get { return Resources.DisplayMetrics.HeightPixels; }
        }
    }
}
