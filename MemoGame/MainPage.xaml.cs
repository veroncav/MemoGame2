using Microsoft.Maui.Controls;
using MemoGame.Models;

namespace MemoGame;

public partial class MainPage : ContentPage
{
    private Game? _game;
    private string _currentCategory = "fruits"; // категория по умолчанию

    public MainPage()
    {
        InitializeComponent();
        Theme.LightMode.Activate();
        StartNewGame();
    }

    private void StartNewGame()
    {
        _game = new Game("Player 1", _currentCategory);
        CardsCollectionView.ItemsSource = _game.Cards;
        UpdateScore();
    }

    private void UpdateScore()
    {
        ScoreLabel.Text = $"Score: {_game?.CurrentPlayer.Score ?? 0}";
    }

    private async void OnCardTapped(object sender, TappedEventArgs e)
    {
        if (_game == null) return;
        if (e.Parameter is not Card card) return;

        await _game.SelectCardAsync(card);
        UpdateScore();

        if (_game.CheckForWin())
        {
            await DisplayAlert("Awesome!", $"You completed the game with {_game.CurrentPlayer.Score} points!", "OK");
            StartNewGame();
        }
    }

    private async void OnNewGameClicked(object sender, EventArgs e)
    {
        await CardsCollectionView.FadeTo(0, 250, Easing.SinIn);
        StartNewGame();
        await CardsCollectionView.FadeTo(1, 250, Easing.SinOut);
    }

    // --- Темы ---
    private void OnLightThemeClicked(object sender, EventArgs e) => Theme.LightMode.Activate();
    private void OnDarkThemeClicked(object sender, EventArgs e) => Theme.DarkMode.Activate();
    private void OnOceanThemeClicked(object sender, EventArgs e) => Theme.OceanMode.Activate();
    private void OnPinkThemeClicked(object sender, EventArgs e) => Theme.PinkMode.Activate();

    // --- Категории ---
    private void OnFruitsClicked(object sender, EventArgs e)
    {
        _currentCategory = "fruits";
        StartNewGame();
    }

    private void OnVegetablesClicked(object sender, EventArgs e)
    {
        _currentCategory = "vegetables";
        StartNewGame();
    }

    private void OnSweetsClicked(object sender, EventArgs e)
    {
        _currentCategory = "sweets";
        StartNewGame();
    }

    private void OnAnimalsClicked(object sender, EventArgs e)
    {
        _currentCategory = "animals";
        StartNewGame();
    }
    private void OnMixClicked(object sender, EventArgs e)
    {
        _currentCategory = "mix";
        StartNewGame();
    }
}

