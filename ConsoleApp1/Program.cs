using ConsoleApp1;
using ConsoleApp1.Services;

var grpc = new GrpcService("https://localhost:7195");

Console.Clear();
Console.WriteLine("email to subscribe");
var subscribeRequest = new SubscribeRequest { Email = Console.ReadLine() };

var subscribeResponse = await grpc.SubscribeAsync(subscribeRequest);

Console.WriteLine($"{subscribeResponse.Message}");

Console.ReadKey();



Console.WriteLine("email to Unsubscribe");
var unSubscribeRequest = new UnSubscribeRequest { Email = Console.ReadLine() };

var unSubscribeResponse = await grpc.UnSubscribeAsync(unSubscribeRequest);

Console.WriteLine($"{unSubscribeResponse.Message}");

Console.ReadKey();