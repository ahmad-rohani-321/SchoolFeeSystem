using MudBlazor;
namespace SchoolFeeSystem.Client.Generals
{
    public class MudLocalizedTextField : MudTextField<string>
    {
        protected override void OnInitialized()
        {
            Class = "bahij-nassim-regular";
            Variant = Variant.Outlined;
            Margin = Margin.Dense;
            base.OnInitialized();
        }
    }
    public class MudLocalizedNumericField : MudNumericField<int>
    {
        protected override void OnInitialized()
        {
            Class = "bahij-nassim-regular";
            Variant = Variant.Outlined;
            Margin = Margin.Dense;
            base.OnInitialized();
        }
    }
    public class MudLocalizedSelect : MudSelect<int>
    {
        protected override void OnInitialized()
        {
            Class = "bahij-nassim-regular";
            Variant = Variant.Outlined;
            Margin = Margin.Dense;
            Dense = true;
            base.OnInitialized();
        }
    }
}
