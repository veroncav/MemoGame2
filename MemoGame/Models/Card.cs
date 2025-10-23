using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MemoGame.Models;

public class Card : INotifyPropertyChanged
{
    public int Id { get; set; }
    public string Symbol { get; set; } = string.Empty; // не допускаем null

    private bool _isFlipped;
    public bool IsFlipped
    {
        get => _isFlipped;
        set { _isFlipped = value; OnPropertyChanged(); }
    }

    private bool _isMatched;
    public bool IsMatched
    {
        get => _isMatched;
        set { _isMatched = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
