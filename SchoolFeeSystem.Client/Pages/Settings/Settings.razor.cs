namespace SchoolFeeSystem.Client.Pages.Settings
{
    public partial class Settings
    {
        private bool Enabled = false;
        private string SwicthValue()
        {
            return Enabled ? "تغیر ایله کړی" : "تغیر بند کړی";
        }
    }
}