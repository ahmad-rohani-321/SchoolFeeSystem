using MudBlazor;

namespace SchoolFeeSystem.Client.Pages.Class
{
    public partial class Classes
    {
        private void OpenDialog()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };

            DialogService.Show<ClassEditor>("Simple Dialog", closeOnEscapeKey);
        }
    }
}