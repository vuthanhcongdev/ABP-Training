using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using myProject.Configuration.Dto;

namespace myProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : myProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
