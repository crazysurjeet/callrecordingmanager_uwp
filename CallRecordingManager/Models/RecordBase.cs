using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRecordingManager.Models
{
    public abstract class RecordBase : BindableBase
    {
		private int id;
		public int Id
		{
			get { return id; }
			set { SetProperty(ref id, value); }
		}

		private DateTime createdDateTime;
		public DateTime CreatedDateTime
		{
			get { return createdDateTime; }
			set { SetProperty(ref createdDateTime, value); }
		}

		private double fileSize;
		public double FileSize
		{
			get { return fileSize; }
			set { SetProperty(ref fileSize, value); }
		}

		private string duration;
		public string Duration
		{
			get { return duration; }
			set { SetProperty(ref duration, value); }
		}

		private string fileName;
		public string FileName
		{
			get { return fileName; }
			set { SetProperty(ref fileName, value); }
		}

		private string extension;
		public string Extension
		{
			get { return extension; }
			set { SetProperty(ref extension, value); }
		}

		public abstract void Play();
		public abstract void Pause();
		public abstract void Stop();

	}
}
