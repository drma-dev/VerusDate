﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetLikesCommand : MediatorQuery<List<InteractionQuery>>
    {
        public InteractionGetLikesCommand() : base(CosmosType.Profile)
        {
        }

        public override void SetParameters(IQueryCollection query)
        {
            //do nothing
        }
    }

    public class InteractionGetLikesHandler : IRequestHandler<InteractionGetLikesCommand, List<InteractionQuery>>
    {
        private readonly IRepository _repo;

        public InteractionGetLikesHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<InteractionQuery>> Handle(InteractionGetLikesCommand request, CancellationToken cancellationToken)
        {
            var sb = new StringBuilder();
            sb.Append("SELECT * ");
            sb.Append("FROM c ");
            sb.Append("WHERE ");
            sb.Append($"	c.type             = {(int)CosmosType.Interaction} ");
            sb.Append($"	AND c.idUserInteraction    = '{request.IdLoggedUser}' ");
            sb.Append("     AND c[\"like\"][\"value\"] = true ");
            sb.Append("	    AND c.blink[\"value\"]     != true ");
            sb.Append("	    AND c.match[\"value\"]     != true ");
            sb.Append("	    AND c.block[\"value\"]     != true ");

            var query = new QueryDefinition(sb.ToString());

            return await _repo.Query<InteractionQuery>(query, cancellationToken);
        }
    }
}