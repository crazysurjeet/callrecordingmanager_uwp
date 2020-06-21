using CallRecordingManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace CallRecordingManager.Services
{
    public interface ICallRecordService
    {
        Task<List<CallRecord>> GetRecordings();
    }
    public class CallRecordService : ICallRecordService
    {
        string FolderPath = @"C:\Surjeet\Documents\Recordings\Call Recordings";
        string Extension = ".amr";
        string fname = @"Assets\Audio\Mommy-1904031437.amr";
        
        public async Task<List<CallRecord>> GetRecordings()
        {

            //var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            //folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            //folderPicker.FileTypeFilter.Add("*");

            //Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();

            //if (folder != null)
            //{
            //    // Application now has read/write access to all contents in the picked folder
            //    // (including other sub-folder contents)
            //    Windows.Storage.AccessCache.StorageApplicationPermissions.
            //    FutureAccessList.AddOrReplace("PickedFolderToken", folder);

            //}
            //else
            //{
            //    throw new Exception("Exception occured");
            //}

            StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFolder assets = await appInstalledFolder.GetFolderAsync(@"Assets\Audio");
            var files = await assets.GetFilesAsync();
            List<CallRecord> result = new List<CallRecord>();
            foreach (var storageFile in files)
            {
                //StorageFile storageFile = await InstallationFolder.GetFileAsync(fname);
                if (File.Exists(storageFile.Path))
                {
                    FileInfo file = new FileInfo(storageFile.Path);
                    //var contents = File.ReadAllBytes(file.Path);

                    //var directoryInfo = new DirectoryInfo(FolderPath);
                    //var fileInfo = directoryInfo.GetFiles($"*{Extension}");
                    //foreach (var file in fileInfo)
                    //{
                    string countryCode, contactNo, name;
                    DateTime parsedDateTime;
                    ExtractFileInfo(file.Name.Replace($"{file.Extension}",""), out countryCode, out contactNo, out name, out parsedDateTime);
                    CallRecord recording = new CallRecord() {
                        Name = name,
                        ContactNumber = contactNo,
                        CountryCode = countryCode,
                        ParsedDateTime = parsedDateTime,
                        FileName = file.Name,
                        FileSize = file.Length,
                        Extension = file.Extension,
                        CreatedDateTime = file.CreationTime,
                    };
                    result.Add(recording);
                }
            }
            return result;
        }
        public void ExtractFileInfo(string fileName, out string countryCode, out string contactNo, out string name, out DateTime parsedDateTime)
        {
            var arr = fileName.Split('-');
            name = arr[0];
            countryCode = null;
            contactNo = null;
            parsedDateTime = new DateTime();

            if (name[0].Equals('+'))
            {
                if (name[1] == '1')
                {
                    countryCode = "+1";
                    contactNo = name.Substring(2);
                }

                if (name[1] == '9' && name[2] == '1')
                {
                    countryCode = "+91";
                    contactNo = name.Substring(3);
                }
            }
            else if (Char.IsDigit(name[0])) contactNo = name;

            var tempDate = arr[1];
            try
            {
                parsedDateTime = new DateTime(int.Parse("20" + tempDate.Subint(0, 2)), tempDate.Subint(2, 2), tempDate.Subint(4, 2), tempDate.Subint(6, 2), tempDate.Subint(8, 2), 0);
            }
            catch { }
        }
    }
}
