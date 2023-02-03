# TicTacToeGame

(A basic TicTacToe game written in C#. It works fine if user enters input accordingly. I have not added exception handling. Just wanted to make a quick and simple(!) game. There are redundant code snippets and duplicated code blocks but overall i think it doest what it should.)

A console-based Tic Tac Toe game. The game is played between a player and the computer. The player plays as 'X' and the computer as 'O'. The game board is a 3x3 grid, and the first player to get 3 of their marks in a row (horizontally, vertically, or diagonally) wins the game. The game is played in a console window, and the game board is displayed after each turn. If the board is full and no player has won, the game is declared a draw.

Classes:

    Program: The main class which runs the game.
    GameManager: Manages the game logic. It keeps track of the moves made, the state of the game board, and the winner of the game.

Methods:

    addMark: Adds a mark to the specified location on the game board.
    GetMark: Returns the mark at the specified location on the game board.
    excludeCoordinate: Sets a coordinate to false to prevent it from being marked again.
    Main: The entry point of the program which initializes the game and runs the game loop.
    PlayTurn: The method which allows the player to make their move.
    getGameScreen: Displays the current state of the game board.
    ComputerMark: The computer makes its move by randomly selecting a coordinate to mark.
    isGameOverFunc: Determines if the game is over, and if so, who the winner is.

(Please consider that this is my first project that i wrote with C# all my own so i definitely wrote some unnecessary code blocks but in the end this was just an exercise.)
