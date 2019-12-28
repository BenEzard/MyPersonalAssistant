using System;
using System.ComponentModel;

namespace MyPersonalAssistant.Code
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            Console.Write("In PropertyChanged....");
            if (this.PropertyChanged != null)
            {
                Console.WriteLine("Firing");
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
