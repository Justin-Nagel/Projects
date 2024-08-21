// // oauth.js

// const axios = require('axios');
// const qs = require('querystring');
// const readline = require('readline');

// const consumer_key = process.env.TWITTER_API_KEY;
// const consumer_secret = process.env.TWITTER_API_KEY_SECRET;

// const requestTokenURL = 'https://api.twitter.com/oauth2/token';

// async function input(prompt) {
//   const rl = readline.createInterface({
//     input: process.stdin,
//     output: process.stdout
//   });

//   return new Promise((resolve) => {
//     rl.question(prompt, (answer) => {
//       rl.close();
//       resolve(answer);
//     });
//   });
// }

// async function requestToken() {
//   try {
//     const response = await axios.post(requestTokenURL, qs.stringify({
//       grant_type: 'client_credentials'
//     }), {
//       headers: {
//         'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8',
//         Authorization: `Basic ${Buffer.from(`${consumer_key}:${consumer_secret}`).toString('base64')}`
//       }
//     });

//     if (response.data && response.data.access_token) {
//       return response.data.access_token;
//     } else {
//       throw new Error('Cannot get an OAuth access token');
//     }
//   } catch (error) {
//     throw new Error('Error fetching OAuth access token: ' + error.message);
//   }
// }

// module.exports = {
//   requestToken,
//   input
// };
