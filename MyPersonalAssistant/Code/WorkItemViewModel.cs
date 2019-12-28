using MyPersonalAssistant.Code.Data.Models;
using MyPersonalAssistant.Code.Data.Services;
using MyPersonalAssistant.Code.UI.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyPersonalAssistant.Code
{
    public class WorkItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The Repository handles all of the data collection; editing and deleting methods.
        /// </summary>
        private WorkItemRepository workItemRepository = new WorkItemRepository();

        /// <summary>
        /// An ObservableCollection of all 'active' WorkItems.
        /// (Potentially this will change to be all work items, if I can work out how to filter the data well).
        /// </summary>
        public ObservableCollection<WorkItem> ActiveWorkItems { get; set;} = new ObservableCollection<WorkItem>();

//        public List<WorkItemStatus> WorkItemStatuses = null;
        public List<WorkItemStatus> WorkItemStatuses { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public delegate void AppEventHandler(object obj, AppEventArgs e);
        public event AppEventHandler ApplicationEvents;

        private WorkItem _selectedWorkItem = null;
        /// <summary>
        /// The currently selected WorkItem.
        /// </summary>
        public WorkItem SelectedWorkItem
        {
            get { return _selectedWorkItem; }
            set { 
                _selectedWorkItem = value; 
                OnPropertyChanged(""); 
            }
        }
        
        public WorkItemViewModel()
        {
            LoadWorkItems();
            LoadWorkItemStatuses();
            Console.WriteLine($"number of list items = {ActiveWorkItems.Count}");
            OnPropertyChanged("");
        }

        /// <summary>
        /// Loads all of the WorkItems from the repository into the ActiveWorkItems collection.
        /// </summary>
        private void LoadWorkItems()
        {
            var list = workItemRepository.GetWorkItems();
            foreach (WorkItem wi in list)
            {
                ActiveWorkItems.Add(wi);
            }
        }

        /* Question: A better approach? But can't get it to work; it hangs.
         * public void LoadWorkItemsAsync()
        {
            var list = new WorkItemRepository().GetWorkItemsAsync();
            foreach (WorkItem wi in list.Result)
            {
                ActiveWorkItems.Add(wi);
            }
        }*/

        public void LoadWorkItemStatuses()
        {
            WorkItemStatuses = workItemRepository.GetWorkItemStatuses();
        }

        #region ApplicationMode
        private ApplicationMode _appMode = ApplicationMode.NOT_SET;
        public ApplicationMode AppMode
        {
            get { return _appMode; }
            set
            {
                _appMode = value;
                OnPropertyChanged("");   // Notify the UI
            }
        }

        /// <summary>
        /// Check to see if the application is in ADD_MODE
        /// </summary>
        public bool IsApplicationInAddMode
        {
            get
            {
                bool rValue = false;

                if (_appMode == ApplicationMode.ADD_MODE)
                    rValue = true;
                
                return rValue;
            }
        }

        public bool IsApplicationNotInAddMode
        {
            get
            {
                bool rValue = true;

                if (_appMode == ApplicationMode.ADD_MODE)
                    rValue = false;

                return rValue;
            }
        }
        #endregion

        public async void AddWorkItem(WorkItem workItem)
        {
            await workItemRepository.AddWorkItem(workItem);
            ActiveWorkItems.Add(workItem);
        }

        public async void SaveWorkItem()
        {
            if (SelectedWorkItem.WorkItemId == null)
                AddWorkItem(SelectedWorkItem);
            else 
                await workItemRepository.UpdateWorkItemAsync(SelectedWorkItem);
        }

        public event EventHandler<WorkItemEventArgs> WorkItemCreatingEvent;

        #region WorkItemCreatingCommand
        RelayCommand _workItemCreatingCommand;
        public ICommand WorkitemCreatingCommand
        {
            get
            {
                if (_workItemCreatingCommand == null)
                {
                    _workItemCreatingCommand = new RelayCommand(BeginWorkItemCreation, CanAddNewWorkItem);
                }
                return _workItemCreatingCommand;
            }
        }

        public void BeginWorkItemCreation()
        {
            Console.WriteLine("inside BeginWorkItemCreation (1)");
            AppMode = ApplicationMode.ADD_MODE;

            var wi = new WorkItem();
            SelectedWorkItem = wi;
            Console.WriteLine("inside BeginWorkItemCreation (2)");
            WorkItemCreatingEvent?.Invoke(this, new WorkItemEventArgs(WorkItemType.WORK_ITEM_CREATING, wi));
            Console.WriteLine("inside BeginWorkItemCreation (3)");
        }

        public bool CanAddNewWorkItem()
        {
            return true;
        }
        #endregion

        #region CancelWorkItemCreatingCommand
        RelayCommand _workItemCamcelCreatingCommand;
        public ICommand CancelWorkitemCreatingCommand
        {
            get
            {
                if (_workItemCamcelCreatingCommand == null)
                {
                    _workItemCamcelCreatingCommand = new RelayCommand(CancelWorkItemCreation, CanCancelNewWorkItem);
                }
                return _workItemCamcelCreatingCommand;
            }
        }

        public void CancelWorkItemCreation()
        {
            AppMode = ApplicationMode.EDIT_MODE;
        }

        public bool CanCancelNewWorkItem()
        {
            if (AppMode == ApplicationMode.ADD_MODE)
                return true;
            else
                return false;
        }
        #endregion
    }

}
