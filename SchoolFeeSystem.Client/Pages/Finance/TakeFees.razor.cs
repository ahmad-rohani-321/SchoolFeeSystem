using SchoolFeeSystem.Client.Generals;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace SchoolFeeSystem.Client.Pages.Finance
{
    public partial class TakeFees
    {
        private readonly List<Entities.FeesCollection> fees = new();
        private readonly List<Entities.Class> classes = new();
        private MudLocalizedSelect classSelect;
        private int classValue = 0;
        private bool _isLoading = false;
        private bool _processing = false;
        protected override async Task OnInitializedAsync()
        {
            classes.AddRange(await Class.GetClasses());
        }
        async Task ClassChanged()
        {
            classValue = classSelect.Value;
            await LoadClassStudents();
        }
        async Task LoadClassStudents()
        {
            _isLoading = true;
            fees.Clear();
            var collection = await Collection.GetByClassForMonthlyFees(classValue);
            fees.AddRange(collection);
            _isLoading = false;
            StateHasChanged();
        }

        async Task Save()
        {
            _processing = true;
            var response = await Collection.UpdateMonthlyFees(fees);
            if (response.IsSuccess)
            {
                Snackbar.Add("عملیه تکمیل سوه" , MudBlazor.Severity.Success);
                fees.Clear();
                fees.AddRange(response.Data);
            }
            else
            {
                Snackbar.Add("عملیه تکمیل نه سوه", MudBlazor.Severity.Error);
            }
            _processing = false;
            StateHasChanged();
        }
    }
}
