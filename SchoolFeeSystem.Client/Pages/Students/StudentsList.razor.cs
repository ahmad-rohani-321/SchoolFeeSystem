namespace SchoolFeeSystem.Client.Pages.Students
{
    public partial class StudentsList
    {
        private bool _processing = false;

        void ProcessSomething()
        {
            _processing = true;
            Task.Delay(2000);
            _processing = false;
        }

        private void ShowDiaog()
        {
            DialogService.Show<StudentDialog>("غیر فعال");
        }
    }
}
