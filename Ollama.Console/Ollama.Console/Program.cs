using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OllamaSharp;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddChatClient(new OllamaApiClient(new Uri("http://localhost:11434"), "llama3.2:1b"));

var app = builder.Build();

var chatClient = app.Services.GetRequiredService<IChatClient>();
var message = new ChatMessage(ChatRole.User, "Qual é a capital da França?");
var response = await chatClient.GetResponseAsync([message]);

Console.Write(response);
Console.ReadLine();