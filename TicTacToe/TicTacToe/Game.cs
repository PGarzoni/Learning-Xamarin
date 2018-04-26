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
            FindViewById<TextView>(Resource.Id.CurrentPlayer).SetTextSize(Android.Util.ComplexUnitType.Dip, GetDeviceWidth / 32);
        }

        private void InitializeBoard(List<TextView> list)
        {
            Board board = new Board(3);

            for (var i = 0; i < list.Count; i++)
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
                        board.SetTokenAtLocation(j, CurrentPlayer);
                        if (board.DetectWinCondition())
                        {
                            board.ResetBoard();
                            ClearBoard(list);
                            Toast.MakeText(this, String.Format("Player {0} wins!", CurrentPlayer), ToastLength.Long).Show();
                        }
                        if(board.IsAllElementsFilled())
                        {
                            board.ResetBoard();
                            ClearBoard(list);
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

        private void ClearBoard(List<TextView> list)
        {
            foreach (TextView tv in list)
            {
                tv.Text = "";
            }
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
