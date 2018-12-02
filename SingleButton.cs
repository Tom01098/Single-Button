using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ThreeGoodThings.Custom_Controls
{
    /// <summary>
    /// A button which has a timeout between taps
    /// </summary>
    public class SingleButton : Button
    {
        // Clicked event, overriding the button clicked event
        public new event EventHandler Clicked;

        // Stopwatch used to measure time between clicks
        private Stopwatch stopwatch = Stopwatch.StartNew();

        // The seconds between each allowed button press
        private const double secondsBetween = .5;

        // Constructor, calls the base constructor and also assigns the OnClick event
        public SingleButton() : base() =>
            base.Clicked += OnClick;

        // Called when the button is pressed
        private void OnClick(object sender, EventArgs e)
        {
            // If the right amount of time has elapsed
            if (stopwatch.Elapsed.TotalSeconds > secondsBetween)
            {
                // Call the Clicked event
                Clicked(sender, e);

                // Restart the stopwatch
                stopwatch.Restart();
            }
        }
    }
}
