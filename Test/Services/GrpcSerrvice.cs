using Grpc.Net.Client;

namespace Test.Services;

public class GrpcSerrvice
{
    
    public void InitializeGrpcConnection(string serverAddress)
    {
        using var channel = GrpcChannel.ForAddress(serverAddress);
        
    }
}
