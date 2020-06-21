using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRecordingManager.Models
{
    public class CallRecord : RecordBase
    {
		private string countryCode;
		public string CountryCode
		{
			get { return countryCode; }
			set { SetProperty(ref countryCode, value); }
		}

		private string contactNumber;
		public string ContactNumber
		{
			get { return contactNumber; }
			set { SetProperty(ref contactNumber, value); }
		}

		private string name;
		public string Name
		{
			get { return name; }
			set { SetProperty(ref name, value); }
		}

		private DateTime parsedDateTime;
		public DateTime ParsedDateTime
		{
			get { return parsedDateTime; }
			set { SetProperty(ref parsedDateTime, value); }
		}

		public override void Play()
		{
			throw new NotImplementedException();
		}

		public override void Pause()
		{
			throw new NotImplementedException();
		}

		public override void Stop()
		{
			throw new NotImplementedException();
		}
	}

	public class CallRecordComparer : IEqualityComparer<CallRecord>
	{
		public bool Equals(CallRecord x, CallRecord y)
		{
			if (x.Name == y.Name) return true;
			else return false;
		}

		public int GetHashCode(CallRecord obj)
		{
			return obj.Name.GetHashCode();
		}
	}
}
