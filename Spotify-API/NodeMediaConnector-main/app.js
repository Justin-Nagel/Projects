// app.js

const SpotifyAPI = require('./Modules/SpotifyAPI');
const { getRequest } = require('./Modules/TwitterAPI');
const readline = require('readline');
require('dotenv').config();  // Load environment variables

// Setup readline interface
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

async function fetchTweets() {
  try {
    // Make the request
    const response = await getRequest();
    return response;
  } catch (e) {
    console.error('Error fetching data from Twitter API:', e.message);
    return null;
  }
}

async function displayTweets() {
  try {
    const tweets = await fetchTweets();
    if (tweets && tweets.data && tweets.data.length > 0) {
      console.log('Latest Tweets:');
      tweets.data.forEach(tweet => {
        console.log(`- ${tweet.text}`);
      });
    } else {
      console.log('No tweets found or error fetching tweets.');
    }
  } catch (error) {
    console.error('Error:', error);
  }
}

async function getSongDetails(songName) {
  try {
    const songDetails = await SpotifyAPI.getSongDetails(songName);
    return songDetails;
  } catch (error) {
    console.error('Error fetching song details:', error);
    return null;
  }
}

// Prompt user to enter song name then display info about song.
function promptUser() {
  console.log("--------------------------------------");
  console.log('Please make a choice:');
  console.log('1. Twitter');
  console.log('2. Spotify');
  console.log('3. Exit');
  
  // Menu function
  rl.question('Enter your choice: ', async (choice) => {
    if (choice === '1') {
      rl.question('Enter Twitter username: ', async (username) => {
        await displayTweets(username);
        promptUser(); // Loop back to the main menu
      });
    } else if (choice === '2') {
      rl.question('Enter song name to search on Spotify: ', async (songName) => {
        const songDetails = await getSongDetails(songName);
        if (songDetails) {
          console.log(`\nSong Details:`);
          console.log(`- Artist(s): ${songDetails.artists}`);
          console.log(`- Song: ${songDetails.song}`);
          console.log(`- Preview URL: ${songDetails.preview_url}`);
          console.log(`- Album: ${songDetails.album}`);
        } else {
          console.log('Song not found.'); // Error handling for Spotify
        }
        promptUser();
      });
    } else if (choice === '3') {
      console.log('Exiting the application. Goodbye!');
      rl.close();
    } else {
      console.log('Invalid choice. Please choose either 1, 2, or 3.');
      promptUser(); 
    }
  });
}

promptUser();
