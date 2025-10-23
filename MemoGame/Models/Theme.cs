using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MemoGame.Models;

public class Theme
{
    public Color PageColor { get; set; } = Colors.White;
    public Color FontColor { get; set; } = Colors.Black;
    public Color ButtonBackgroundColor { get; set; } = Colors.White;
    public Color ButtonTextColor { get; set; } = Colors.Black;
    public Color CardBackColor { get; set; } = Colors.LightGray;
    public Color CardBorderColor { get; set; } = Colors.Gray;
    public Color CardMatchedColor { get; set; } = Colors.LightGreen;

    public static Theme LightMode => new Theme
    {
        PageColor = Color.FromRgb(245, 245, 245),
        FontColor = Colors.Black,
        ButtonBackgroundColor = Colors.White,
        ButtonTextColor = Colors.Black,
        CardBackColor = Colors.LightGray,
        CardBorderColor = Colors.Gray,
        CardMatchedColor = Colors.LightGreen
    };

    public static Theme DarkMode => new Theme
    {
        PageColor = Color.FromRgb(25, 25, 25),
        FontColor = Colors.White,
        ButtonBackgroundColor = Color.FromRgb(50, 50, 50),
        ButtonTextColor = Colors.White,
        CardBackColor = Color.FromRgb(60, 60, 60),
        CardBorderColor = Colors.Gray,
        CardMatchedColor = Colors.Green
    };

    public static Theme OceanMode => new Theme
    {
        PageColor = Color.FromRgb(0, 105, 148),
        FontColor = Colors.White,
        ButtonBackgroundColor = Color.FromRgb(0, 150, 199),
        ButtonTextColor = Colors.White,
        CardBackColor = Color.FromRgb(0, 168, 232),
        CardBorderColor = Colors.White,
        CardMatchedColor = Color.FromRgb(0, 255, 255)
    };
    public static Theme PinkMode => new Theme
    {
        PageColor = Color.FromRgb(255, 192, 203), // розовый фон
        FontColor = Colors.Black,
        ButtonBackgroundColor = Color.FromRgb(255, 182, 193),
        ButtonTextColor = Colors.Black,
        CardBackColor = Color.FromRgb(255, 182, 193),
        CardBorderColor = Colors.White,
        CardMatchedColor = Color.FromRgb(255, 105, 180)
    };

    public void Activate()
    {
        var resources = Application.Current.Resources;
        if (resources != null)
        {
            resources["PageBackgroundColor"] = PageColor;
            resources["PrimaryTextColor"] = FontColor;
            resources["ButtonBackgroundColor"] = ButtonBackgroundColor;
            resources["ButtonTextColor"] = ButtonTextColor;
            resources["CardBackColor"] = CardBackColor;
            resources["CardBorderColor"] = CardBorderColor;
            resources["CardMatchedColor"] = CardMatchedColor;
        }
    }
}
