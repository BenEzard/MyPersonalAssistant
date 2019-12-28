using MyPersonalAssistant.Code.Data.Models;
using System;

namespace MyPersonalAssistant.Code
{
    public class WorkItemEventArgs : EventArgs
    {
        public WorkItemType EventType;
        public WorkItem SelectedWorkItem { get; set; }

        public WorkItemEventArgs(WorkItemType eventType, WorkItem selectedWorkItem)
        {
            EventType = eventType;
            SelectedWorkItem = selectedWorkItem;
        }
    }
}
