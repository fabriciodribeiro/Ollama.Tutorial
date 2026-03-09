using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OllamaSharp;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddChatClient(new OllamaApiClient(new Uri("http://localhost:11434"), "gemma3:latest"));

var app = builder.Build();
var chatClient = app.Services.GetRequiredService<IChatClient>();


//Sample simple chat
var messageChat = new ChatMessage(ChatRole.User, "Qual é a capital de Angola?");
var responseChat = await chatClient.GetResponseAsync([messageChat]);
Console.WriteLine("Simple chat response: "+ responseChat.Text);

//Sample with image - Analyse the receipt
// var messageReceiptAnalysis = new ChatMessage(ChatRole.User, "What's in the image?");
// messageReceiptAnalysis.Contents.Add(new DataContent( File.ReadAllBytes("Receipt/reciept1.png"), "image/png"));
// var receiptAnalysisResponse = await chatClient.GetResponseAsync([messageReceiptAnalysis]);

// Console.WriteLine("Analyse the receipt: "+ receiptAnalysisResponse.Text);

//Console.ReadLine();