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
    public class DisplayByNameViewModel : BindableBase
    {
        public ICallRecordService callRecordService;
        private ObservableCollection<CallRecord> callRecords;
        private ObservableCollection<CallRecord> currentCallRecords;
        public ObservableCollection<CallRecord> CurrentCallRecords
        {
            get { return currentCallRecords; }
            set { SetProperty(ref currentCallRecords, value); }
        }
        private string EntryName;
        public DisplayByNameViewModel(string entryName, RecordViewModel recordViewModel)
        {
            this.EntryName = entryName;
            callRecords = recordViewModel.callRecords;
            FilterCallRecordings();
        }
        public void FilterCallRecordings()
        {
            CurrentCallRecords = new ObservableCollection<CallRecord>(callRecords.Where(x => x.Name.ToLower().Contains(EntryName.ToLower())));
        }
    }
}
