using System;

namespace MyPersonalAssistant.Code.Data.Models
{
    public class WorkItem
    {
        public int? WorkItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public DateTime DeletionDateTime { get; set; }

        //public WorkItemStatusHistory CurrentStatus { get;set; }
    }
}
