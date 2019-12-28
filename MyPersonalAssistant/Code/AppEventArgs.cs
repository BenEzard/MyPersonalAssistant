using System;

namespace MyPersonalAssistant.Code
{
    public partial class AppEventArgs : EventArgs
    {
        public AppEventType EventType { get; set; }

        public AppEventArgs(AppEventType type)
        {
            EventType = type;
        }
    }
}
