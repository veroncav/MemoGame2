using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoGame.Models;

// основной класс игры
public class Game
{
    public Player CurrentPlayer { get; } // текущий игрок
    public List<Card> Cards { get; private set; } = new List<Card>(); // список всех карточек
    private Card? _firstSelectedCard; // первая выбранная карта
    private Card? _secondSelectedCard; // вторая выбранная карта
    private bool _isProcessing; // чтобы нельзя было нажимать, пока проверяются карты

    private string _category; // категория (фрукты, овощи и т.д.)

    // создаём игру, по умолчанию с фруктами
    public Game(string playerName, string category = "fruits")
    {
        CurrentPlayer = new Player(playerName);
        _category = category;
        StartNewGame();
    }

    // запуск новой игры
    public void StartNewGame()
    {
        CurrentPlayer.Score = 0;
        _firstSelectedCard = null;
        _secondSelectedCard = null;
        CreateCards(); // создаём карты заново
    }

    // смена категории с перезапуском
    public void ChangeCategory(string category)
    {
        _category = category;
        StartNewGame();
    }

    // создаём список карточек в зависимости от выбранной категории
    private void CreateCards()
    {
        var fruits = new List<string>
        {
            "🍎","🍌","🍉","🍇","🍓","🍒","🍍","🥝"
        };

        var vegetables = new List<string>
        {
            "🥕","🥦","🥔","🌽","🍅","🫛","🧅","🍆"
        };

        var sweets = new List<string>
        {
            "🍩","🍪","🍫","🍬","🍭","🧁","🍰","🥧"
        };

        var animals = new List<string>
        {
            "🐶","🐱","🐭","🐹","🐰","🦊","🐻","🐼"
        };

        var mix = new List<string>
        {
            "🐶","🍩","🍍","🐹","🍬","🦊","🐻","🥕","🍰","🍌","🐶","🍅"
        };

        // выбираем нужный набор
        List<string> symbols = _category switch
        {
            "vegetables" => vegetables,
            "sweets" => sweets,
            "animals" => animals,
            "mix" => mix,
            _ => fruits // если ничего не выбрано — берём фрукты
        };

        int pairsCount = 8; // поле 4x4, значит 8 пар
        var selectedSymbols = symbols.Take(pairsCount).ToList();
        var cardSymbols = selectedSymbols.Concat(selectedSymbols).ToList(); // дублируем символы, чтобы были пары

        // перемешиваем карты
        var random = new Random();
        cardSymbols = cardSymbols.OrderBy(_ => random.Next()).ToList();

        // создаём карточки
        Cards = new List<Card>();
        for (int i = 0; i < cardSymbols.Count; i++)
        {
            Cards.Add(new Card { Id = i, Symbol = cardSymbols[i] });
        }
    }

    // логика выбора карт
    public async Task SelectCardAsync(Card card)
    {
        // если сейчас идёт проверка или карта уже открыта — выходим
        if (_isProcessing || card.IsFlipped || card.IsMatched) return;

        card.IsFlipped = true; // переворачиваем карту

        if (_firstSelectedCard == null)
        {
            // первая карта выбрана
            _firstSelectedCard = card;
        }
        else
        {
            // вторая карта выбрана
            _secondSelectedCard = card;
            _isProcessing = true;

            // проверяем совпадение
            if (_firstSelectedCard.Symbol == _secondSelectedCard.Symbol)
            {
                // если совпало
                _firstSelectedCard.IsMatched = true;
                _secondSelectedCard.IsMatched = true;
                CurrentPlayer.Score += 10; // добавляем очки
            }
            else
            {
                // если не совпало — ждём и переворачиваем обратно
                await Task.Delay(1000);
                _firstSelectedCard.IsFlipped = false;
                _secondSelectedCard.IsFlipped = false;
                CurrentPlayer.Score -= 2; // штраф
            }

            ResetSelection();
            _isProcessing = false;
        }
    }

    // сброс выбора
    private void ResetSelection()
    {
        _firstSelectedCard = null;
        _secondSelectedCard = null;
    }

    // проверка — выиграл ли игрок
    public bool CheckForWin()
    {
        return Cards.All(c => c.IsMatched);
    }
}
