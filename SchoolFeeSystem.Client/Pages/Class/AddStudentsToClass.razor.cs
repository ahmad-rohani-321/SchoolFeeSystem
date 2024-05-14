using Microsoft.AspNetCore.Components;
using MudBlazor;
using SchoolFeeSystem.Client.Entities;
using System.Diagnostics.Contracts;
namespace SchoolFeeSystem.Client.Pages.Class
{
    public partial class AddStudentsToClass
    {
        [Parameter]
        public int ClassId { get; set; }

        private int searchType = 0;
        private string keywords;
        private bool _loading = false;
        private bool _processing = false;
        private readonly List<ClassStudents> students = new List<ClassStudents>();
        private readonly HashSet<ClassStudents> classStudentsToAdd = new HashSet<ClassStudents>();
        protected override async Task OnInitializedAsync()
        {
            _loading = true;
            students.Clear();
            students.AddRange(await ClassStudents.GetStudentsForAdd(ClassId));
            _loading = false;
            StateHasChanged();
        }
        private string GetGender(bool gender)
        {
            return gender ? "نارینه" : "ښځینه";
        }
        bool _saving = false;
        private async void OnSubmit()
        {
            _saving = true;
            var result = await ClassStudents.AddStudent(classStudentsToAdd);
            if (result.IsSuccess)
            {
                Navigation.NavigateTo($"classes/studentslist/add/{ClassId}");
                _saving = false;
                StateHasChanged();
            }
        }
    }
}
