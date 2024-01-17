using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace Infrastructure.Data.Core
{
    public class SoftDelete : DefaultExpressionVisitor
    {
        public override DbExpression Visit(DbScanExpression expression)
        {
            if (!expression.Target.ElementType.Members.Any(m => m.Name.Equals("deleted")))
            {
                return base.Visit(expression);
            }

            var binding = expression.Bind();

            return binding
                .Filter(binding.VariableType.Variable(binding.VariableName)
                .Property("deleted")
                .Equal(false));
        }
    }

    public class SoftDeleteCommandInterceptor : IDbCommandTreeInterceptor
    {
        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.OriginalResult.DataSpace == DataSpace.SSpace)
            {
                var queryCommand = interceptionContext.Result as DbQueryCommandTree;
                if (queryCommand != null)
                {
                    var newQuery = queryCommand.Query.Accept(new SoftDelete());
                    interceptionContext.Result = new DbQueryCommandTree(queryCommand.MetadataWorkspace, queryCommand.DataSpace, newQuery);
                }
            }
        }
    }
}
