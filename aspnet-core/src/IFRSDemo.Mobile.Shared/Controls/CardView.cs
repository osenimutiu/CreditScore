﻿using Xamarin.Forms;

namespace IFRSDemo.Controls
{
    public class CardView : Frame
    {
        public CardView()
        {
            Padding = 0;

            if (Device.RuntimePlatform == Device.iOS)
            {
                HasShadow = false;
                BorderColor = Color.Gray;
            }
        }
    }
}

