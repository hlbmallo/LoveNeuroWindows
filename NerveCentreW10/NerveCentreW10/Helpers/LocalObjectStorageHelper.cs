using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace NerveCentreW10.Helpers
{
    public class LocalObjectStorageHelper : Microsoft.Toolkit.Uwp.Helpers.BaseObjectStorageHelper
    {
        public StorageFolder Folder { get; set; }
    }
}
