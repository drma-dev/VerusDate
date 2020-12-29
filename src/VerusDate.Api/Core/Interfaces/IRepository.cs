﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Shared.Core;

namespace VerusDate.Api.Core.Interfaces
{
    public interface IRepository
    {
        Task<T> Get<T>(string id, string partitionKeyValue, CancellationToken cancellationToken) where T : CosmosBase;

        Task<List<T>> Query<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken) where T : CosmosBase;

        Task<List<T>> Query<T>(Expression<Func<T, bool>> predicate, string partitionKeyValue, CancellationToken cancellationToken) where T : CosmosBase;

        /// <summary>
        /// Adiciona um novo objeto ao container
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="partitionKeyValue">tabela pai = Id / tabela filho = IdPai</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> Add<T>(T item, string partitionKeyValue, CancellationToken cancellationToken) where T : CosmosBase;

        Task<T> Update<T>(T item, string id, string partitionKeyValue, CancellationToken cancellationToken) where T : CosmosBase;

        Task<T> Delete<T>(string id, string partitionKeyValue, CancellationToken cancellationToken) where T : CosmosBase;
    }
}