🎮 MemoGame – A Memory Challenge

MemoGame is a fun and simple memory-improvement game built with .NET MAUI. Your goal is to match all pairs of cards on the board using as few moves as possible.

🚀 Key Features

Classic Gameplay: Flip two cards at a time and try to find a matching pair.

Score System: Earn +10 points for every match and lose 2 points for every miss.

Cross-Platform Experience: Runs natively on Windows, Android, iOS, and macOS thanks to .NET MAUI.

Light & Dark Themes: Seamless theme switching for comfortable play at any time of day.

Smooth Animations: Subtle transitions enhance the overall user experience.

Clean Architecture: Game logic is completely separated from the user interface following modern software design principles.

🛠️ Technology Stack

Framework: .NET MAUI

Language: C#

UI Markup: XAML

💡 How It Works

Models:
This layer contains the core logic of the game.
The Game class manages the entire game flow — creating cards, checking matches, and tracking scores.
It’s fully independent of UI components like buttons or colors.

View (MainPage.xaml):
Defines the visual layout — the card grid, buttons, and score display — using declarative XAML markup.

Code-Behind (MainPage.xaml.cs):
Acts as the bridge between the View and the Model.
It handles user actions (like tapping a card) and communicates with the game engine (Game.cs).
After the engine updates the state, it refreshes the UI (for example, updating the score or flipping cards).

Converters:
Helper classes that adapt data for UI display.
For instance, InverseBoolConverter disables a button when its bound property is true.
