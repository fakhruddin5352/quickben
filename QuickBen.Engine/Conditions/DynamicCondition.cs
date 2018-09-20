using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using QuickBen.Engine.Interfaces;

namespace QuickBen.Engine.Conditions
{
    public class DynamicCondition : ICondition
    {
        private readonly IList<DynamicConditionParameter> parameters; 
        private readonly Type[] typeMap;
         
        private readonly System.Delegate function;

        public DynamicCondition(Expression expression,IEnumerable<DynamicConditionParameter> parameters )
        {
            this.parameters = new List<DynamicConditionParameter>(parameters);

            typeMap = this.parameters?.Select(x=>x.Type).Select(Type.GetType).ToArray();


            var ps = this.parameters?.Select((x,i) => Expression.Parameter(typeMap[i], x.Name))
                .ToArray();

            var lambda = Expression.Lambda(expression, ps);
            function = lambda.Compile();


        }
        public Task<bool> CanFire(WorkflowContext context)
        {
            var values = parameters.Select((x,i) => context.GlobalParameters.GetContextProperty(x.ContextPath, typeMap[i]))
                .ToArray();
            
           
            var result = (bool) function.DynamicInvoke(values);
            return Task.FromResult(result);
        }
    }
}
