using PingSite.Core.Repositories;
using PingSite.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Tools
{
    public class AutoPingTool
    {
        private readonly IHostRepository _hostRepository;
        private readonly IHostHistoryService _hostHistoryService;

        public AutoPingTool(IHostRepository hostRepository, IHostHistoryService hostHistoryService)
        {
            _hostRepository = hostRepository;
            _hostHistoryService = hostHistoryService;
        }

        public async Task PingHost()
        {
            var hosts = await _hostRepository.GetAllAsync();

            foreach(var host in hosts)
            {
                var status = PingTool.CheckPingStatus(host.Address);
                if(host.LastStatus == false && status == true)
                {
                    await _hostHistoryService.AddAsync(DateTime.Now, (int)host.Id);
                }
                host.SetLastStatus(status);

                await _hostRepository.UpdateAsync(host);
            }
        }
    }
}
