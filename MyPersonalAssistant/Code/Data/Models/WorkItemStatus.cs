namespace MyPersonalAssistant.Code.Data.Models
{
    public class WorkItemStatus
    {
        public int WorkItemStatusId { get; set; }
        public string StatusLabel { get; set; }
        public char IsConsideredActive { get; set; }
        public char IsDefault { get; set; }
    }
}
