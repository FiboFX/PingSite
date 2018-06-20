using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingSite.Core.DTO;
using PingSite.Core.Models;
using PingSite.Core.Repositories;

namespace PingSite.Core.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<Settings> GetAsync()
        {
            var settingsModel = await _settingRepository.GetAllAsync();
            Settings settings = new Settings
            {
                AutoPing = GetSettingValue(settingsModel, "AutoPing") == "1",
                AutoPingDelay = GetSettingValue(settingsModel, "AutoPingDelay")
            };

            return settings;
        }

        public Task UpdateAsync(Settings settings)
        {
            throw new NotImplementedException();
        }

        private string GetSettingValue(IEnumerable<Setting> settingsModel, string settingName)
        {
            var setting = settingsModel.Select(x => x).Where(y => y.Name == settingName).ToList();

            return setting[0].Value;
        }
    }
}
