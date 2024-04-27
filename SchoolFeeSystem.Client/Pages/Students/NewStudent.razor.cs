using System;
using System.Collections.Generic;

namespace SchoolFeeSystem.Client.Pages.Students
{
    public partial class NewStudent
    {
        IList<IBrowserFile> files = new List<IBrowserFile>();

        private void UploadFiles2(IBrowserFile file)
        {
            files.Add(file);
        }
    }
}
