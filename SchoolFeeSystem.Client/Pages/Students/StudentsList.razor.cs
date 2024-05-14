using MudBlazor;
using System.ComponentModel;

namespace SchoolFeeSystem.Client.Pages.Students
{
    public partial class StudentsList
    {
        private string keywords;
        private int searchType = 0;
        private List<Entities.Student> students = new List<Entities.Student>();
        private bool _processing = false;
        private bool _loading = false;
        async void SearchingStudent()
        {
            _processing = true;
            _loading = true;
            students.Clear();
            students.AddRange(await Students.SearchStudent(keywords, searchType));
            _loading = false;
            _processing = false;
            StateHasChanged();
        }

        private void ShowDiaog(int id)
        {
            var parameters = new DialogParameters<StudentDialog>();
            parameters.Add(x => x.Id, id);
            DialogService.Show<StudentDialog>("غیر فعال", parameters);
        }

        private void NavigateTo(int id)
        {
            Navigation.NavigateTo($"editstudent/{id}");
        }
        protected override async Task OnInitializedAsync()
        {
            _loading = true;
            students.AddRange(await Students.GetTenStudents());
            _loading = false;
        }
        private string GetGender(bool value)
        {
            return value ? "نارینه" : "ښځینه";
        }
    }
}