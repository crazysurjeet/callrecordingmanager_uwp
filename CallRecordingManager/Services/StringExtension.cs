using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRecordingManager.Services
{
    public static class StringExtension
    {
        public static int Subint(this string str, int start, int end)
        {
            return int.Parse(str.Substring(start, end));
        }
    }
}
