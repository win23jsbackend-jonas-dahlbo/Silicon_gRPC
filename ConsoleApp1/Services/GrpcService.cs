using Grpc.Net.Client;

namespace ConsoleApp1.Services;

public class GrpcService
{
    private readonly GrpcChannel _channel;
    private readonly SubscriptionService.SubscriptionServiceClient _client;

    public GrpcService(string serverAddress)
    {
        _channel = GrpcChannel.ForAddress(serverAddress);
        _client = new SubscriptionService.SubscriptionServiceClient(_channel);
    }

    public async Task<SubscribeResponse> SubscribeAsync(SubscribeRequest request)
    {
        var response = await _client.SubscribeAsync(request);
        return response;
    }
    public async Task<UnSubscribeResponse> UnSubscribeAsync(UnSubscribeRequest request)
    {
        var response = await _client.UnsubscribeAsync(request);
        return response;
    }

}

