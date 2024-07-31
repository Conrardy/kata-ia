# Game of Life

This is a simple implementation of Conway's Game of Life in Elixir.

## Table of Contents

- [Introduction](#introduction)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [Running the Tests](#running-the-tests)
- [Project Structure](#project-structure)

## Introduction

Conway's Game of Life is a cellular automaton devised by the mathematician John Horton Conway. This implementation initializes a grid and provides a framework to add the rules of the game.

## Installation

To get started with this project, you'll need to have Elixir installed on your system. If you don't have Elixir installed, follow the instructions on the [official Elixir website](https://elixir-lang.org/install.html).

1. Clone the repository:

    ```sh
    git clone <repository-url>
    cd game_of_life
    ```

2. Install the dependencies:

    ```sh
    mix deps.get
    ```

## Running the Application

To start the Game of Life with a 5x5 grid, run the following command in your terminal:

```sh
mix run --no-halt
```

## Running the Tests

```sh
mix test
```

## Project Structure

The project is organized as follows:

game_of_life/
├── lib/
│   ├── game_of_life.ex # Module for the game logic
│   ├── grid.ex # Module for the game grid logic
│   └── main.ex # Main entry point for the application
├── test/
│   ├── game_of_life_test.exs # Tests for the board module
│   │── grid_test.exs # Tests for the cell module
├── mix.exs # Project configuration file
└── README.md # Project documentation
