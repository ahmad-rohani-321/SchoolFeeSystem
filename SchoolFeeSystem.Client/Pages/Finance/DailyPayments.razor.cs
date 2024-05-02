using System.Globalization;

namespace SchoolFeeSystem.Client.Pages.Finance
{
    public partial class DailyPayments
    {
        public DateTime? Date { 
            get 
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ps-AF");
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ps-AF");
                return DateTime.Today;
            }
            set { }
        }
    }
}
