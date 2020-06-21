using CallRecordingManager.Models;
using CallRecordingManager.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRecordingManager.ViewModels
{
    public class RecordViewModel:BindableBase
    {
        public ICallRecordService callRecordService;
        public ObservableCollection<CallRecord> callRecords;
        //public ObservableCollection<RecordBase> CallRecords
        //{
        //    get { return callRecords; }
        //    set { SetProperty(ref callRecords, value); }
        //}

        private ObservableCollection<CallRecord> currentCallRecords;
        public ObservableCollection<CallRecord> CurrentCallRecords
        {
            get { return currentCallRecords; }
            set { SetProperty(ref currentCallRecords, value); }
        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set { 
                SetProperty(ref searchText, value);
                FilterCallRecordings();
            }
        }


        public RecordViewModel(ICallRecordService callRecordService)
        {
            this.callRecordService = callRecordService;
            if (App.GlobalRecordCollection.Count > 0)
            {
                callRecords = App.GlobalRecordCollection;
                GetDistinctCallRecordings();
            }
            else
            {
                callRecords = new ObservableCollection<CallRecord>();
                LoadCallRecordings();
            }
        }
        public async void LoadCallRecordings()
        {
            callRecords = new ObservableCollection<CallRecord>((await callRecordService.GetRecordings()));
            App.GlobalRecordCollection = callRecords;
            GetDistinctCallRecordings();
        }
        public void GetDistinctCallRecordings()
        {
            CurrentCallRecords = new ObservableCollection<CallRecord>(callRecords.Distinct(new CallRecordComparer()));
        }
        public void FilterCallRecordings()
        {
            CurrentCallRecords= new ObservableCollection<CallRecord>(callRecords.Distinct(new CallRecordComparer()).Where(x => x.Name.ToLower().Contains(SearchText.ToLower())));
        }
    }
}
