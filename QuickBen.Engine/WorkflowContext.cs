using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBen.Engine
{
    [Serializable]
    public class WorkflowContext
    {

         
        public WorkflowContext() { }

        public WorkflowContext(string workflowId, int workflowVersion, string systemId)
        {
            WorkflowId = workflowId;

            WorkflowVersion = workflowVersion;

            SystemId = systemId;
        }

        public string WorkflowInstanceId { get; set; }

        public string WorkflowId { get; set; }

        public string SystemId { get; set; }

        public int WorkflowVersion { get; set; }


 
        public IEnumerable<string> CurrentStepsIds { get; set; }

        // JSON containing the parameters
        public JObject GlobalParameters { get; set; }

        // Key StepId, Value JSON
        public Dictionary<string, JObject> LocalContexts = new Dictionary<string, JObject>();

        public ICollection<string> TransientTokens { get; } = new HashSet<string>();
        public ICollection<string> RequiredParameters { get; } = new HashSet<string>();


        public string ToJson()
        {
            JToken clone = GlobalParameters ?? new JObject();
            if (TransientTokens.Any())
            {
                clone = clone.DeepClone();
                foreach (var token in TransientTokens.Select(clone.SelectToken))
                {
                    token?.Parent.Remove();
                }
            }

            return clone.ToString(Newtonsoft.Json.Formatting.None);
        }

        public Dictionary<string, string> LocalToJson()
        {
            return LocalContexts.ToDictionary(
                kvp => kvp.Key, 
                kvp => kvp.Value?.ToString(Newtonsoft.Json.Formatting.None));
        }

        /// <summary>
        /// Merge the source context into the dest context
        /// </summary>
        /// <param name="context">The other context</param>
        /// <returns>The result of the merge</returns>
        public void MergeGlobalContexts(JObject context)
        {
            if (GlobalParameters == null)
            {
                GlobalParameters = context;
            }
            else if (context != null)
            {
                GlobalParameters.Merge(context,new JsonMergeSettings { MergeArrayHandling=MergeArrayHandling.Replace,MergeNullValueHandling=MergeNullValueHandling.Merge});
            }
        }

    }
}