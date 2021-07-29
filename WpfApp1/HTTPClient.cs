using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace Bons_Enet
{
    class HTTPClient
    {
        public bool FoundGameInDB(string title, out GameModel newGame)
        {
            string titleReplace;
            // will return null if title is not found in igdb
            newGame = new GameModel();
            // parse game title to only use first 6 words (which should be enough in most cases)
            titleReplace = Regex.Replace(title, @"^((?:\S+\s+){5}\S+).*", "${1}");

            Debug.WriteLine(titleReplace);

            // search name and grab cover image from igdb api
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Client-ID", "162uion41pmjjjr5jxqo1lhm4y33ok");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer puqodz7swa2c22bez3zrnlpca4qdqa");
            client.DefaultRequestHeaders.Add("X-Version", "1");
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.igdb.com/v4/games"),
                // filter search to only include games that were released on PC using "where release_dates.platform = 6"
                Content = new StringContent($"search \"{titleReplace}\"; fields name, cover.url; where release_dates.platform = 6;", Encoding.UTF8, "application/json") //choose fields and name of game here
            };

            // deserialize json
            var response = client.SendAsync(httpRequestMessage).Result;
            JArray obj = JsonConvert.DeserializeObject<JArray>(response.Content.ReadAsStringAsync().Result);

            string imgPathResult;


            // if the title is not found, api returns an empty json rather than error, so check to see if json is empty
            if (obj.Count > 0)
            {
                // if we grab more information in future updates it may be worth looking into a more sophisticated solution (something like json2csharp or IGDB .NET SDK c# wrapper)
                newGame.Title = (string)obj[0]["name"];
                imgPathResult = (string)obj[0]["cover"]["url"];

                // replace 'thumb' with '720p' to get higher res cover art, as per igdb api
                // URI needs "https://" to recognize a link, igdb's img path is not returned in this format so add it
                newGame.CoverPath = "https:" + Regex.Replace(imgPathResult, @"thumb", "720p");
                return true;
            }
            else
            {
                return false;
            }
        }


        private DateTime accessTokenReceivedDate;

        // Check if access token has expired, if it has, get a new one
        //6gv5s4oewmw8el63pscow0txrwynl5
        //y361waj378mzpr3t0zz47n1agnsyfk expires in: 5282501
        public void SendPost()
        {
            //if (todays date > expires_in) //check if we have reached token expired date
            //{

            //}

            using var client = new HttpClient();

            var response = client.PostAsync("https://id.twitch.tv/oauth2/token?client_id=6gv5s4oewmw8el63pscow0txrwynl5&client_secret=d8l29qf2em8yety18q6dlbn580movn&grant_type=client_credentials", null).Result;

            string result = response.Content.ReadAsStringAsync().Result;

            Debug.WriteLine(result);


            // deserialize json
            JArray obj = JsonConvert.DeserializeObject<JArray>(response.Content.ReadAsStringAsync().Result);


            // deserialize json
            //var response = client.SendAsync(httpRequestMessage).Result;
            //JArray obj = JsonConvert.DeserializeObject<JArray>(response.Content.ReadAsStringAsync().Result);


            //accessTokenReceivedDate = DateTime.Now.AddSeconds((double)obj[0]["cover"]["url"]);

            //// if the title is not found, api returns an empty json rather than error, so check to see if json is empty
            //if (obj.Count > 0)
            //{
            //    // if we grab more information in future updates it may be worth looking into a more sophisticated solution (something like json2csharp or IGDB .NET SDK the c# wrapper)
            //    newGame.Title = (string)obj[0]["name"];
            //    imgPathResult = (string)obj[0]["cover"]["url"];
            //    // replace 'thumb' with '720p' to get higher res cover art
            //    pattern = @"thumb";
            //    replace = "720p";
            //    result = System.Text.RegularExpressions.Regex.Replace(imgPathResult, pattern, replace);
            //    newGame.CoverPath = "http:" + result; // add http: since path does not come with it in api
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            //accessTokenReceivedDate = DateTime.Now;

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