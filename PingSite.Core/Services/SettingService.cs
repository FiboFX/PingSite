using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using PingSite.Core.DTO;
using PingSite.Core.Models;
using PingSite.Core.Repositories;
using PingSite.Core.Tools;

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
                AutoPing = SettingsTool.GetSettingValue(settingsModel, "AutoPing") == "1",
                AutoPingDelay = SettingsTool.GetSettingValue(settingsModel, "AutoPingDelay")
            };

            return settings;
        }

        public async Task UpdateAsync(Settings settings)
        {
            var settingsList = settings.GetType().GetProperties();

            foreach(var setting in settingsList)
            {
                var settingModel = await _settingRepository.GetAsync(setting.Name);
                
                if(setting.Name == "AutoPing")
                {
                    if(settings.AutoPing)
                    {
                        var delay = settings.AutoPingDelay;
                        settingModel.Value = "1";
                        RecurringJob.AddOrUpdate<AutoPingTool>("AutoPing", x => x.PingHost(), $"*/{delay} * * * *");
                    }
                    else
                    {
                        settingModel.Value = "0";
                        RecurringJob.RemoveIfExists("AutoPing");
                    }
                }
                else
                {
                    var settingValue = settingsList.FirstOrDefault(x => x.Name == setting.Name);
                    settingModel.Value = (string)settingValue.GetValue(settings, null);
                }

                await _settingRepository.UpdateAsync(settingModel);
            }
        }
    }
}
