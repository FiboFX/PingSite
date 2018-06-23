using PingSite.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingSite.Core.Tools
{
    public static class SettingsTool
    {
        public static string GetSettingValue(IEnumerable<Setting> settingsModel, string settingName)
        {
            var setting = settingsModel.FirstOrDefault(x => x.Name == settingName);

            return setting.Value;
        }
    }
}
