using MudBlazor;
using SchoolFeeSystem.Client.Pages.Students;

namespace SchoolFeeSystem.Client.Pages.Finance
{
    public partial class TakeFees
    {
        private bool _searchProcess = false;

        async Task SearchProcessSomething()
        {
            _searchProcess = true;
            await Task.Delay(2000);
            _searchProcess = false;
        }
        private bool _saveProcess = false;

        async Task SaveProcessSomething()
        {
            _saveProcess = true;
            await Task.Delay(2000);
            _saveProcess = false;
        }

        private void ShowDiaog()
        {
            DialogService.Show<StudentDialog>("غیر فعال");
        }
    }
}
