using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using QuickBen.Engine.Interfaces;

namespace QuickBen.Engine.Conditions
{
    class UnaryCondition:ICondition
    {
        private readonly string variable;

        public UnaryCondition(string variable)
        {
            this.variable = variable;
        }

        public async Task<bool> CanFire(WorkflowContext context)
        {
            var token = context.GlobalParameters.SelectToken(variable);
            if (token == null)
                return false;

            switch (token.Type)
            {
                case JTokenType.Array:
                    return ((JArray) token).Any();
                case JTokenType.Boolean:
                    return token.Value<bool>();
                case JTokenType.Float:
                    return token.Value<float>() != 0;
                case JTokenType.Integer:
                    return token.Value<int>() != 0;
                case JTokenType.String:
                    return token.Value<string>().Length>0;
                default :
                    return token.Value<object>() != null;
            }
        }
    }
}
