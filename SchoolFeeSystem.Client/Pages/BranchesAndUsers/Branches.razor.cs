using MudBlazor;
using MudBlazor.Interfaces;
using SchoolFeeSystem.Client.Entities;

namespace SchoolFeeSystem.Client.Pages.BranchesAndUsers
{
    public partial class Branches
    {
        private MudForm branch;
        private Branch model = new Branch();
        private List<Branch> branches = new List<Branch>();
        private bool _processing = false;
        private bool _loading = false;
        private async void OnSubmitForm()
        {
            await branch.Validate();
            if (branch.IsValid && model.Id == 0)
            {
                _processing = true;
                var added = await Branch.AddBranch(model);
                Snackbar.Add(
                    added.IsSuccess ? added.Message : "څانګه اضافه نه سوه",
                    added.IsSuccess ? Severity.Success : Severity.Error);
                await branch.ResetAsync();
                await ReloadBranches();
                _processing = false;
                StateHasChanged();
            }
            else if (branch.IsValid && model.Id != 0)
            {
                _processing = true;
                var added = await Branch.UpdateBranch(model);
                Snackbar.Add(
                    added.IsSuccess ? added.Message : "څانګه تغیر نه سوه",
                    added.IsSuccess ? Severity.Success : Severity.Error);
                await branch.ResetAsync();
                await ReloadBranches();
                _processing = false;
                StateHasChanged();
            }
        }
        private async void GetStudent(int id)
        {
            var br = await Branch.GetSingleBranch(id);
            model.Id = br.Id;
            model.Name = br.Name;
            model.Address = br.Address;
            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()
        {
            await ReloadBranches();
        }
        private async Task ReloadBranches()
        {
            _loading = true;
            branches.Clear();
            branches = await Branch.GetAllBranches();
            _loading = false;
        }
    }
}
