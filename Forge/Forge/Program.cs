//using Microsoft.Extensions.Configuration;
//using OpenAI.Chat;

//var builder = new ConfigurationBuilder()
//    .AddUserSecrets<Program>()
//    .Build();

//var key = builder["OpenAi:SecretKey"];

//ChatClient client = new("gpt-4.1-mini", key);

//ChatCompletion completion = client.CompleteChat("Say 'this is a test.'");

//Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");


while (true)
{
    // Get the input text. e.g. forge spec --filename myfile.md
    string? input = Console.ReadLine();
}