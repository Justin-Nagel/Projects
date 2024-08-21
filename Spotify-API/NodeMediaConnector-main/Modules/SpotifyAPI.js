// Function to get Spotify Bearer Token that is used for authorization.
async function getSpotifyToken() {
  const response = await fetch('https://accounts.spotify.com/api/token', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded',
      'Authorization': 'Basic ' + Buffer.from(`${process.env.SPOTIFY_CLIENT_ID}:${process.env.SPOTIFY_CLIENT_SECRET}`).toString('base64'),
    },
    body: 'grant_type=client_credentials',
  });

  const data = await response.json();
  return data.access_token;
}

// Function to get song details from Spotify
async function getSongDetails(songName) {
  const token = await getSpotifyToken();
  const response = await fetch(`https://api.spotify.com/v1/search?q=${encodeURIComponent(songName)}&type=track&limit=1`, {
    headers: {
      'Authorization': `Bearer ${token}`,
    },
  });

  const data = await response.json();
  if (data.tracks.items.length > 0) {
    const track = data.tracks.items[0];
    return {
      artists: track.artists.map(artist => artist.name).join(', '),
      song: track.name,
      preview_url: track.preview_url,
      album: track.album.name,
    };
  } else {
    return null;
  }
}

// Export the functions
module.exports = {
  getSongDetails,
};
