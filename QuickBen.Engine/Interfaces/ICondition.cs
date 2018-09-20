using System.Threading.Tasks;

namespace QuickBen.Engine.Interfaces
{
    public interface ICondition
    {

        Task<bool> CanFire(WorkflowContext context);
    }
}