using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DogAPI_Console_App.API
{
    public class Dog_API
    {
        private const string DATA = @"{}";

        public void Get_Dogs(string url)
        {
            Parse_Json_And_Display(url);
        }

        public void Check_If_Breed_Exists(string breedType, string allDogs_URL)
        {
            string allDogs = API_Request(allDogs_URL);

            Regex breedCheck = new Regex("retriever");
            bool breedExists = breedCheck.IsMatch(breedType);
            
            if (breedExists)
            {
                Console.WriteLine(breedType + " EXISTS");
            }
            else
            {
                Console.WriteLine("NO SUCH BREED exists!!!");
            }
        }

        public string Get_Random_SubBreedImage_URL(string randomGoldenRetrieverPicture_URL)
        {
            string imgUrl = API_Request(randomGoldenRetrieverPicture_URL);

            var charsToRemove = new string[] { "\\" };
            foreach (var c in charsToRemove)
            {
                imgUrl = imgUrl.Replace(c, string.Empty);
            }
            return imgUrl;
        }

        private string API_Request(string apiUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(DATA);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    return response;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Something went Wrong OOPs");
                Console.Out.WriteLine(e.Message);
            }

            return null;
        }

        private void Parse_Json_And_Display(string url)
        {
            var results = JObject.Parse(API_Request(url));

            foreach (var result in results)
            {
                System.Console.WriteLine(result.Key);
                System.Console.WriteLine(result.Value);
            }
        }
    }
}
