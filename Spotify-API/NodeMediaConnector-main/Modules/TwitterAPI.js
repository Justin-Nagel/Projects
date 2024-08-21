const axios = require('axios');
require('dotenv').config();

const tweetIDs = '44196397'; //ID of spsific tweet
const params = 'tweet.fields=lang,author_id&user.fields=created_at'; //Request parameters
const endpointURL = `https://api.twitter.com/2/tweets?ids=${tweetIDs}&${params}`; //API endpoint.
const bearerToken = process.env.TWITTER_BEARER_TOKEN;

//Function to get bearer token that will be used for oauth 1.0
async function getRequest() {
  try {
    console.log('Requesting data from Twitter API...');
    const response = await axios.get(endpointURL, {
      headers: {
        Authorization: `Bearer ${bearerToken}`,
        'User-Agent': "v2TweetLookupJS"
      }
    });

    console.log('Data fetched successfully:', response.data);
    return response.data;
  } catch (error) {
    console.error('Error fetching data from Twitter API:', error.response ? error.response.status : error.message);
    throw new Error('Unsuccessful request');
  }
}

module.exports = {
  getRequest
};
