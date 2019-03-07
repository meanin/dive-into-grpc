using System.Threading.Tasks;
using Grpc.Core;

namespace DiveIntoGrpc.Server
{
    public class ValueServiceImpl : ValueService.ValueServiceBase
    {
        public override Task<ValueResponse> GetValues(ValueRequest request, ServerCallContext context)
        {
            var valueResponse = new ValueResponse();
            for (var i = 0; i < request.Count; i++)
            {
                valueResponse.Values.Add(i);
            }
            return Task.FromResult(valueResponse);
        }
    }
}
