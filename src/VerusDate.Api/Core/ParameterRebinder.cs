﻿using System.Collections.Generic;
using System.Linq.Expressions;

namespace VerusDate.Api.Core
{
    internal class ParameterRebinder : ExpressionVisitor
    {
        private readonly IDictionary<ParameterExpression, ParameterExpression> _map;

        internal ParameterRebinder(IDictionary<ParameterExpression, ParameterExpression> map) =>
            _map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();

        internal static Expression ReplaceParameters(
            IDictionary<ParameterExpression, ParameterExpression> map, Expression exp) =>
            new ParameterRebinder(map).Visit(exp);

        /// <inheritdoc />
        protected override Expression VisitParameter(ParameterExpression parameter)
        {
            if (_map.TryGetValue(parameter, out ParameterExpression replacement))
            {
                parameter = replacement;
            }

            return base.VisitParameter(parameter);
        }
    }
}