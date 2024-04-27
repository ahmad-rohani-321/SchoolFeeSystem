using MudBlazor;

namespace SchoolFeeSystem.Client.Pages.Reports
{
    public partial class UserActivites
    {
        bool _isInProcess = false;
        private async Task ProcessDuration()
        {
            _isInProcess = true;
            await Task.Delay(1000);
            _isInProcess = false;
        }
    }
}
