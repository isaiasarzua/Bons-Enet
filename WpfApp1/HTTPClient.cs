using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bons_Enet
{
    class HTTPClient
    {
        public bool FoundGameInDB(string title, out GameModel newGame)
        {
            newGame = new GameModel(); // should return null if title is not found in igdb

            // search name and grab cover image from igdb api
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Client-ID", "162uion41pmjjjr5jxqo1lhm4y33ok");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer puqodz7swa2c22bez3zrnlpca4qdqa");
            client.DefaultRequestHeaders.Add("X-Version", "1");
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.igdb.com/v4/games"),
                //Content = new StringContent($"fields cover.url, name; where name = \"{title}\";", Encoding.UTF8, "application/json") //choose fields and name of game here
                Content = new StringContent($"search \"{title}\"; fields name, cover.url;", Encoding.UTF8, "application/json") //choose fields and name of game here
            };



            // deserialize json
            var response = client.SendAsync(httpRequestMessage).Result;
            JArray obj = JsonConvert.DeserializeObject<JArray>(response.Content.ReadAsStringAsync().Result);

            string newTitle = "";
            string imgPathResult;
            // replace 'thumb' with '720p' to get higher res cover art
            string pattern;
            string replace;
            string result;
            string imagePath = ""; // add http: since path does not come with it in api

            // if the title is not found, api returns an empty json rather than error, so check to see if json is empty
            if (obj.Count > 0)
            {
                // if we grab more information in future updates it may be worth looking into a more sophisticated solution (something like json2csharp or IGDB .NET SDK the c# wrapper)
                newGame.Title = (string)obj[0]["name"];
                imgPathResult = (string)obj[0]["cover"]["url"];
                // replace 'thumb' with '720p' to get higher res cover art
                pattern = @"thumb";
                replace = "720p";
                result = System.Text.RegularExpressions.Regex.Replace(imgPathResult, pattern, replace);
                newGame.ImagePath = "http:" + result; // add http: since path does not come with it in api            // right now all we need is the name and cover so these references are fine,
                return true;
            }
            else
            {
                return false;
            }
        }


        // Check if access token has expired, if it has, get a new one
        // current access token: {"access_token":"puqodz7swa2c22bez3zrnlpca4qdqa","expires_in":4897551,"token_type":"bearer"}
        public async Task SendPost()
        {
            //if (todays date > expires_in) //check if we have reached token expired date
            //{

            //}

            //using var client = new HttpClient();

            //var response = await client.PostAsync("https://id.twitch.tv/oauth2/token?client_id=162uion41pmjjjr5jxqo1lhm4y33ok&client_secret=o8vc411t6j4a766uela8cfrlx6y17m&grant_type=client_credentials", null);

            //string result = response.Content.ReadAsStringAsync().Result;
            //Debug.WriteLine(result);

            //if (result == good)
            //{
            //    float timer = result.expires_in;
            //}
            //else
            //{
            //    Debug.Write("bad result recieved");
            //}
        }
    }
}