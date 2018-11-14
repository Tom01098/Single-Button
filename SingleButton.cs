using System;
using Xamarin.Forms;

/// <summary>
/// A button which has a timeout between taps
/// </summary>
public class SingleButton : Button
{
    public new event EventHandler Clicked;
    private long lastTicks = 0;

    private const long secondsBetween = 2;
    private const long ticksBetween = secondsBetween * TimeSpan.TicksPerSecond;

    public SingleButton() : base() =>
        base.Clicked += OnClick;

    private void OnClick(object sender, EventArgs e)
    {
        var ticks = DateTime.Now.Ticks;

        if (lastTicks + ticksBetween < ticks)
        {
            lastTicks = ticks + ticksBetween;
            Clicked(sender, e);
        }
    }
}
