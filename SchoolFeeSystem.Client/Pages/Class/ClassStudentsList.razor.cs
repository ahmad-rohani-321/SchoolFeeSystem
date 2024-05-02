using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace SchoolFeeSystem.Client.Pages.Class
{
    public partial class ClassStudentsList
    {
        [Parameter]
        public int? ClassId { get; set; }

        private void ShowDeleteDialog(int? id)
        {
            var parameters = new DialogParameters<DeleteStudent>
            {
                { x => x.StudentId, id }
            };
            DialogService.Show<DeleteStudent>("غیر فعال", parameters);
        }
        private void ShowEditFeesDialog(int? id)
        {
            var parameters = new DialogParameters<ChangeFeesDialog>
            {
                { x => x.StudentId, id }
            };
            DialogService.Show<ChangeFeesDialog>("حذف", parameters);
        }
        private void ShowMoveStudentDialog(int? id)
        {
            var parameters = new DialogParameters<MoveStudentDialog>
            {
                { x => x.StudentId, id }
            };
            DialogService.Show<MoveStudentDialog>("انتقال", parameters);
        }
        private void ShowNewStudentDialog()
        {
            DialogOptions options = new DialogOptions() { CloseButton = true };
            DialogService.Show<LoadStudentsModal>("د نوي زده کوونکي انتقال", options);
        }
    }
}
