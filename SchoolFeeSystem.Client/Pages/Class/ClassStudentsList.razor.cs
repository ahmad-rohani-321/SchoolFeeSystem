using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace SchoolFeeSystem.Client.Pages.Class
{
    public partial class ClassStudentsList
    {
        private readonly List<Entities.ClassStudents> classStudents = new List<Entities.ClassStudents>();
        private List<Entities.Class> classesList = new List<Entities.Class>();
        private MudTable<Entities.ClassStudents> _table;
        private bool _loading = false;
        private bool _selectOnRowClick = false;
        private bool _allowEdit = false;
        private bool _allowMove = false;
        [Parameter]
        public int? ClassId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            classesList = await Class.GetClasses();
            await ReloadStudents();
        }
        void NavigateTo()
        {
            Navigation.NavigateTo($"classes/studentslist/add/{ClassId}");
        }
        private async Task ReloadStudents()
        {
            _loading = true;
            classStudents.Clear();
            classStudents.AddRange(await ClassStudents.GetClassStduents(ClassId));
            _loading = false;
        }
        private async void OnEditRow(MouseEventArgs e)
        {
            if (_allowEdit)
            {
                var row = _table.SelectedItem;
                var update = await ClassStudents.UpdateStudentFees(row.Id, row.StudentFee);
                if (update.IsSuccess)
                {
                    StateHasChanged();
                }
            }
        }
        private void OnClickMenu()
        {
            _allowMove = !_allowMove;
        }
        private async void DeleteStudent()
        {
            var row = _table.SelectedItem;
            if (row != null)
            {
                var delete = await ClassStudents.DeleteStudents([.. _table.SelectedItems]);
                if (delete.IsSuccess)
                {
                    StateHasChanged();
                }
            }
        }
    }
}
