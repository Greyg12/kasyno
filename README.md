# Project: Casino

This project is a simple console application that simulates a casino with various games of chance. The user can deposit and withdraw coins from their account and play games such as crash, lotto, roulette, and coin flip.

## Table of Contents

1. [Project Description](#project-description)
2. [How to Run](#how-to-run)
3. [Features](#features)
   - [Deposit and Withdrawal](#deposit-and-withdrawal)
   - [Games](#games)
     - [Crash](#crash)
     - [Lotto](#lotto)
     - [Roulette](#roulette)
     - [Coin Flip](#coin-flip)
4. [File Structure](#file-structure)
5. [Requirements](#requirements)
6. [License](#license)

## Project Description

The casino application allows the user to interact with various games of chance. The program stores the user's account balance in a text file and allows playing games with coin betting. Depending on the game results, the account balance is updated and saved.

### Main features:
- **Deposit and withdrawal of coins**: The user can deposit or withdraw coins from their account.
- **Games of chance**: The user can choose games such as crash, lotto, roulette, and coin flip.
- **Account balance management**: The balance is saved to and loaded from a file.

## How to Run

To run the project:
1. Download or clone the repository.
2. Open the project in a C#-compatible IDE (e.g., Visual Studio).
3. Build and run the application.
4. The application will start in the terminal/console. Follow the on-screen instructions.

## Features

### Deposit and Withdrawal
- **Deposit coins**: The user can add coins to their account.
- **Withdraw coins**: The user can withdraw coins from their account, provided they have enough balance.

### Games

#### Crash
In this game, the user bets coins and tries to "cash out" before the multiplier crashes. The user can press Enter to cash out during the game; if they do so before the crash, they win their bet multiplied by the current multiplier.

#### Lotto
In the lotto game, the user picks 6 numbers. If they match 3 or more numbers, they win. The prize depends on the number of matches:
- 3 matches: 3x bet
- 4 matches: 40x bet
- 5 matches: 1500x bet
- 6 matches: 1,000,000x bet

#### Roulette
In roulette, the user can bet in various ways:
- **Numbers (0-36)**: Win if the drawn number matches the bet.
- **Colors**: Bet on red or black.
- **Number ranges**: Bet on ranges: 1-12, 13-24, 25-36, 1-18, 19-36.

#### Coin Flip
In this game, the user bets on heads or tails. If their prediction is correct, they double their bet.

## File Structure

The project contains the following structures and files:
- `balance.txt` - file where the user's account balance is stored.

## Requirements

To run the project, you need:
- A C#-compatible development environment (e.g., Visual Studio).
- .NET SDK version 5.0 or higher.

## License

This project is licensed under the MIT License.

