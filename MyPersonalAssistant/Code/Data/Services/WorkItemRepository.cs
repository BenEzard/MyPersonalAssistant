using Microsoft.EntityFrameworkCore;
using MyPersonalAssistant.Code.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonalAssistant.Code.Data.Services
{
    public class WorkItemRepository : BaseRepository, IWorkItemRepository
    {
        /// <summary>
        /// Get a list of WorkItems.
        /// </summary>
        /// <returns></returns>
        public List<WorkItem> GetWorkItems()
        {
            return dbContext.WorkItems.ToList();
        }

        /* Is the below a better approach? but can't get it to work. It seems to hang.
         * public async Task<List<WorkItem>> GetWorkItemsAsync()
        {
            return await dbContext.WorkItems.ToListAsync();
        }*/

        public async Task<WorkItem> AddWorkItem(WorkItem workItem)
        {
            //dbContext.WorkItems.Add(workItem);
            if (!dbContext.WorkItems.Local.Any(c => c.WorkItemId == workItem.WorkItemId))
            {
                dbContext.WorkItems.Attach(workItem);
            }
            workItem.CreationDateTime = DateTime.Now;
            await dbContext.SaveChangesAsync();
            return workItem;
        }

        public async Task<WorkItem> UpdateWorkItemAsync(WorkItem workItem)
        {
            if (!dbContext.WorkItems.Local.Any(c => c.WorkItemId == workItem.WorkItemId))
            {
                dbContext.WorkItems.Attach(workItem);
            }
            dbContext.Entry(workItem).State = EntityState.Modified;
            workItem.ModificationDateTime = DateTime.Now;
            await dbContext.SaveChangesAsync();
            return workItem;

        }

        /// <summary>
        /// Get the list of Statuses that a WorkItem can take.
        /// </summary>
        /// <returns></returns>
        public List<WorkItemStatus> GetWorkItemStatuses()
        {
            return dbContext.WorkItemStatus.ToList();
        }

    }
}
