using MudBlazor;
using System.Diagnostics.Contracts;

namespace SchoolFeeSystem.Client.Pages.Class
{
    public partial class Classes
    {
        private Entities.Class model = new Entities.Class();
        private List<Entities.Class> classes = new List<Entities.Class>();
        private List<Entities.Branch> branches = new List<Entities.Branch>();
        private MudForm form;
        private bool _processing = false;
        private bool _loading = false;
        protected override async Task OnInitializedAsync()
        {
            branches = await Branch.GetAllBranches();
            await ReloadClasses();
        }
        private async void OnSubmit()
        {
            await form.Validate();
            if (form.IsValid && model.Id == 0)
            {
                _processing = true;
                var added = await Class.AddClass(model);
                Snackbar.Add(
                    added.IsSuccess ? added.Message : "ټولګۍ اضافه نه سو",
                    added.IsSuccess ? Severity.Success : Severity.Error);
                await form.ResetAsync();
                await ReloadClasses();
                _processing = false;
            }
            else if (form.IsValid && model.Id != 0)
            {
                _processing = true;
                var added = await Class.UpdateClass(model);
                Snackbar.Add(
                    added.IsSuccess ? added.Message : "ټولګۍ نه سو تغیر",
                    added.IsSuccess ? Severity.Success : Severity.Error);
                await form.ResetAsync();
                await ReloadClasses();
                _processing = false;
            }
        }

        private async Task ReloadClasses()
        {
            _loading = true;
            classes = await Class.GetClasses();
            _loading = false;
        }

        private async void OnEdit(int id)
        {
            var c = await Class.GetSingleClass(id);
            model.Id = c.Id;
            model.Name = c.Name;
            model.Description = c.Description;
            model.BranchId = c.BranchId;
            StateHasChanged();
        }
        private void OnCheckStudents(int id)
        {
            Navigation.NavigateTo($"studentslist/{id}");
        }
    }
}