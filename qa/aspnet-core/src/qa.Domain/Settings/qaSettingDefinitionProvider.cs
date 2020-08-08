using Volo.Abp.Settings;

namespace qa.Settings
{
    public class qaSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(qaSettings.MySetting1));
        }
    }
}
