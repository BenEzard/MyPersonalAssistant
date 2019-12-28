using MyPersonalAssistant.Code.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPersonalAssistant.Code.Data.Services
{
    public interface IWorkItemRepository
    {
        /// <summary>
        /// Get a list of all of the Work Items.
        /// </summary>
        /// <returns></returns>
        List<WorkItem> GetWorkItems();

        /* A better approach? But can't get it to work. It seems to hang.
        Task<List<WorkItem>> GetWorkItemsAsync(); */

        Task<WorkItem> AddWorkItem(WorkItem workItem);

        List<WorkItemStatus> GetWorkItemStatuses();
    }
}
