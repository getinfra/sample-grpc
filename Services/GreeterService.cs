using Grpc.Core;
using getinfra.samples.grpc;
using System.Collections.Generic;
using getinfra.samples.grpc.Abstractions;
using System.Reflection.PortableExecutable;

namespace getinfra.samples.grpc.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        var list = new List<HeaderItem>();
        //context.
        foreach (var header in context.RequestHeaders)
        {
            list.Add(new HeaderItem() { Key = header.Key, Value = header.Value });
        }

        var response = new HelloReply
        {
            Message = "Hello " + request.Name
        };

        foreach (var header in context.RequestHeaders)
        {
            response.Headers.Add(new HeaderItem() { Key = header.Key, Value = header.Value });
        }

        response.Headers.Add(new HeaderItem() { Key = "status", Value = context.Status.StatusCode.ToString() });
        response.Headers.Add(new HeaderItem() { Key = "host", Value = context.Host });
        response.Headers.Add(new HeaderItem() { Key = "method", Value = context.Method });

        return Task.FromResult(response);
    }
}
