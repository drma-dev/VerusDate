using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Mediator.Command.Profile;
using VerusDate.Api.Mediator.Queries.Profile;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Function
{
    public class PrincipalFunction
    {
        private readonly IMediator _mediator;

        public PrincipalFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("PrincipalGet")]
        public async Task<IActionResult> Get(
           [HttpTrigger(AuthorizationLevel.Anonymous, FunctionMethod.GET, Route = "Principal/Get")] HttpRequest req,
           ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = req.BuildRequestQuery<PrincipalGetCommand, ClientePrincipal>();

                var result = await _mediator.Send(request, source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, req.Query.BuildMessage(), req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }

        [FunctionName("PrincipalAdd")]
        public async Task<IActionResult> Add(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.POST, Route = "Principal/Add")] HttpRequest req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = await req.BuildRequestCommand<PrincipalAddCommand>(source.Token);

                var result = await _mediator.Send(request, source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, req.Query.BuildMessage(), req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }
    }
}