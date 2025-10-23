MemoGame - A Memory Game
A simple yet engaging memory improvement game built with .NET MAUI. The goal is to find all matching pairs of cards on the board in the fewest moves possible.

🚀 Key Features
Classic Gameplay: Flip two cards at a time to find a matching pair.

Score Tracking: Get +10 points for a match and a -2 point penalty for a miss.

Cross-Platform UI: Thanks to .NET MAUI, the game looks and feels native on Windows, Android, iOS, and macOS.

Theme Switching: Built-in support for light and dark color themes.

Smooth Animations: Enjoy subtle animations for a better user experience.

Clean Code: The game logic is completely separated from the user interface, following modern development best practices.

🛠️ Technology Stack
Framework: .NET MAUI

Language: C#

UI Markup: XAML

🤔 How It Works
Models: This layer contains all the "pure" application logic. The Game class manages the game flow: creating cards, checking for matches, and calculating the score. It knows nothing about buttons or colors.

View (MainPage.xaml): This is the declarative XAML code that describes what the screen looks like: where the card grid is, where the buttons and labels are located.

Code-Behind (MainPage.xaml.cs): This file acts as the link between the view and the model. It listens to user actions (like a card tap) and sends commands to the game engine (Game.cs). After the engine updates the game's state, the code-behind updates the information on the screen (like the score).

Converters: These are small helpers that transform data for convenient display in the UI. For example, InverseBoolConverter allows a button to be disabled when its bound property is true.

⚙️ Setup and Running
To run this project on your machine, follow these steps:

Ensure you have the .NET SDK and the .NET MAUI workload installed.

Official .NET MAUI installation guide

Clone the repository:

Bash

git clone https://github.com/Zhan-Gabriel-Gerke/MemoGame
Open the project in Visual Studio or JetBrains Rider.

Select the target platform (e.g., Windows Machine, Android Emulator, iOS Simulator).

Press 'Run' (F5). The application will compile and launch.