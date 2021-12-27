using System.Threading.Tasks;
using myProject.Configuration.Dto;

namespace myProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
