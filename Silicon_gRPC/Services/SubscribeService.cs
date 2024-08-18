using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Silicon_gRPC.Data.Context;

namespace Silicon_gRPC.Services;

public class SubscribeService(DataContext context) : SubscriptionService.SubscriptionServiceBase
{
    private readonly DataContext _context = context;

     public override async Task<SubscribeResponse> Subscribe(SubscribeRequest request, ServerCallContext context)
     {
        if (!await _context.Subscribers.AnyAsync(x => x.Email == request.Email))
        {
            _context.Subscribers.Add(request);
            await _context.SaveChangesAsync();

            return new SubscribeResponse
            {
                Message = "You have been subscribed"
            };
        }
        else
        {
            return new SubscribeResponse
            {
                Message = "You are already subscribed"
            };
        }
     }

    public override async Task<UnSubscribeResponse> Unsubscribe(UnSubscribeRequest request, ServerCallContext context)
    {
        var unSubscribeRequest = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == request.Email);

        if (unSubscribeRequest != null)
        {
            _context.Subscribers.Remove(unSubscribeRequest);
            await _context.SaveChangesAsync();
            return new UnSubscribeResponse
            {
                Message = "You have been Unsubscribed"
            };
        }
        else
        {
            return new UnSubscribeResponse
            {
                Message = "You are not currently subscribed"
            };
        }
    }
}
