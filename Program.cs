using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json.Serialization;
/*

TOP TIPS: 
----Choose an API that has a simple, less nested API. Perhaps one that just returns
    an array of one-level-deep objects. This will make your task significantly easier.
----Choose one of the APIs from this list that does not request "AUTH" (Authorization) 
    since an API that requires authorization is a little more difficult to use when first learning.

Explorer Mode: 

-After choosing your API read the documentation.

-Create a new application for accessing the API.

-Create a class to store information that comes back from your API.

-Write code to query the API and show results.

-If your API has more than one endpoint (), add support for a few options, 
 perhaps by creating a menu system in your application.

Epic Mode:

-Use the site Mockaroo to create a mock API. 
 You may need an account and then learn how their "Mock API" feature works.

-Once you have created your Mock API for whatever schema you wish, create a client 
 application to work with it.

*/

namespace ApiClient
{
    class Joke
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("setup")]
        public string SetUp { get; set; }
        [JsonPropertyName("punchline")]
        public string PunchLine { get; set; }

        class Program
        {
            static async void GetARandomJoke()
            //static async Task<Joke> GetARandomJoke()
            {
                // Console.Clear();
                // var client = new HttpClient();
                // var url = "https://official-joke-api.appspot.com/jokes/random";
                // var responseAsStream = await client.GetStreamAsync(url);
                // var joke = await JsonSerializer.DeserializeAsync<Joke>(responseAsStream);
                // return joke;
                var client = new HttpClient();
                var url = "https://official-joke-api.appspot.com/jokes/random";
                var responseAsStream = await client.GetStreamAsync(url);
                var joke = await JsonSerializer.DeserializeAsync<Joke>(responseAsStream);
                Console.WriteLine();
                Console.WriteLine($"{joke.SetUp}...");
                Console.WriteLine();
                Console.WriteLine($"...{joke.PunchLine}");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                var userInput = Console.ReadLine();
                Console.Clear();
            }
            static async void GetTenRandomJokes()
            {
                var client = new HttpClient();
                var url = "https://official-joke-api.appspot.com/jokes/ten";
                var responseAsStream = await client.GetStreamAsync(url);
                var jokes = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);
                foreach (var joke in jokes)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"{joke.SetUp}...");
                    Console.WriteLine();
                    Console.WriteLine($"...{joke.PunchLine}");
                }
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                var userInput = Console.ReadLine();
                Console.Clear();
            }
            // static async void GetARandomKnockKnockJoke() // This link might be busted
            // {
            //     var client = new HttpClient();
            //     var url = "https://official-joke-api.appspot.com/jokes/knock-knock/random";
            //     var responseAsStream = await client.GetStreamAsync(url);
            //     var joke = await JsonSerializer.DeserializeAsync<Joke>(responseAsStream);
            //     Console.WriteLine();
            //     Console.WriteLine($"{joke.SetUp}...");
            //     Console.WriteLine();
            //     Console.WriteLine($"...{joke.PunchLine}");
            //     Console.WriteLine();
            //     Console.WriteLine("Press Enter to continue...");
            //     var userInput = Console.ReadLine();
            //     Console.Clear();
            // }
            // static async void GetARandomProgrammingJoke() //This link might be busted
            // {
            //     var client = new HttpClient();
            //     var url = "https://official-joke-api.appspot.com/jokes/programming/random";
            //     var responseAsStream = await client.GetStreamAsync(url);
            //     var joke = await JsonSerializer.DeserializeAsync<Joke>(responseAsStream);
            //     Console.WriteLine();
            //     Console.WriteLine($"{joke.SetUp}...");
            //     Console.WriteLine();
            //     Console.WriteLine($"...{joke.PunchLine}");
            //     Console.WriteLine();
            //     Console.WriteLine("Press Enter to continue...");
            //     var userInput = Console.ReadLine();
            //     Console.Clear();
            // }
            static string Menu()
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(1) See a random joke");
                Console.WriteLine("(2) See ten random jokes");
                // Console.WriteLine("(3) See a knock-knock joke");
                // Console.WriteLine("(4) See a programming joke");
                Console.WriteLine("(3) Close the application");
                Console.WriteLine();
                Console.WriteLine("Select an option and press Enter");
                var choice = Console.ReadLine();
                return choice;
            }
            static void Main(string[] args)
            {
                var keepTheJokesComing = true;
                while (keepTheJokesComing)
                {
                    var menuSelection = Menu();
                    switch (menuSelection)
                    {
                        case "1":
                            GetARandomJoke();
                            // var obj1 = await GetARandomJoke();
                            // Console.WriteLine($"{obj1.SetUp}...{obj1.PunchLine}");
                            // Console.WriteLine();
                            // Console.WriteLine("Press Enter to continue...");
                            // var userInput = Console.ReadLine();
                            // Console.Clear();
                            break;
                        case "2":
                            GetTenRandomJokes();
                            break;
                        // case "3":
                        //     GetARandomKnockKnockJoke();
                        //     break;
                        // case "4":
                        //     GetARandomProgrammingJoke();
                        //     break;
                        case "3":
                            Console.WriteLine();
                            Console.Write("Closing application");
                            Console.WriteLine("");
                            keepTheJokesComing = false;
                            break;
                    }
                }
            }
        }
    }
}
