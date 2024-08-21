# Node.js App with Twitter, Spotify

## Overview

This Node.js application interacts with the Twitter, Spotify APIs to retrieve and display specific information based on user input from the terminal. The application reads commands from the terminal and from a text file, processes these commands by making API calls, and outputs the results in a specified format.

## Features

1. **Print Latest Tweets**: Fetch and display the latest tweets from a specified Twitter user.
2. **Spotify Song Lookup**: Retrieve and display information about a song from Spotify.

## Requirements

### Twitter API Integration

- **Command**: `node app.js tweets <username> <count>`
- **Description**: Fetches the latest tweets from the specified username, limited to the number of tweets specified.
- **Output**: A JSON object containing an array of the most recent tweets.

### Spotify API Integration

- **Command**: `node app.js spotify <song name>`
- **Description**: Performs a Spotify lookup for the specified song.
- **Output**: A JSON object containing the artist(s), song title, preview link, and album.

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/Lincalibur/WPR381-Assignment1.git

## How to run Application:
-**Open Terminal.**
- **Run Command**: Node app.js
- **Navigate Through Menu**: By selecting from 1,2 or 3 and answering the requests you will be able to demo the application.

## Installation To install the required dependencies: 
run the following command: ```sh npm install axios@^1.7.2 dotenv@^16.4.5 express@^4.19.2 got@^14.3.0 inquirer@^9.2.22 node-fetch@^3.3.2 oauth@^0.10.0 twitter@^1.1.0 twitter-api-v2@^1.17.0
