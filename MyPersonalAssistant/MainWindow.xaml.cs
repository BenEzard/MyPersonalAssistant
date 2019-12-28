using MyPersonalAssistant.Code;
using MyPersonalAssistant.Code.Data.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyPersonalAssistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WorkItemViewModel model = new WorkItemViewModel();

        public MainWindow()
        {
            InitializeComponent();
            model.ApplicationEvents += AppEventListener;
            model.WorkItemCreatingEvent += WorkItemCreatingEventListener;
        }

        public void AppEventListener(Object o, AppEventArgs e)
        {
            switch (e.EventType)
            {
                case AppEventType.APPLICATION_MODE_CHANGED:
                    if (model.IsApplicationInAddMode)
                        SelectedTaskTitleField.Focus();
                    break;
            }

        }

        /// <summary>
        /// Listen for WorkItem Creating events.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public void WorkItemCreatingEventListener(Object o, WorkItemEventArgs e)
        {
            Console.WriteLine("Caught");
            SelectedTaskTitleField.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Obsolete("SaveButton_Click is temporary; to be deleted.")]
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (model.SelectedWorkItem == null)
            {
                // temporary, build obj
                var wi = new WorkItem();
                wi.Title = SelectedTaskTitleField.Text;
                wi.Description = TaskDescriptionField.Text;
                model.SelectedWorkItem = wi;
                model.AddWorkItem(wi);
            }
            else
                model.SaveWorkItem();
        }

        /// <summary>
        /// This is here (as opposed to in the model) because it's only related to the UI, not the application.
        /// </summary>
        Border _originalBorder = new Border();

        /// <summary>
        /// To highlight the selected control, add a left border.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlGainsFocus(object sender, RoutedEventArgs e)
        {
            Control c = e.Source as Control;
            _originalBorder.BorderThickness = c.BorderThickness;
            _originalBorder.BorderBrush = c.BorderBrush;

            c.BorderBrush = Brushes.DodgerBlue;
            c.BorderThickness = new Thickness(4, 0, 0, 0);
        }

        /// <summary>
        /// Reset the formerly-highlighted control by restoring it's borders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlLosesFocus(object sender, RoutedEventArgs e)
        {
            Control c = e.Source as Control;
            c.BorderBrush = _originalBorder.BorderBrush;
            c.BorderThickness = _originalBorder.BorderThickness;
        }

    }
}
