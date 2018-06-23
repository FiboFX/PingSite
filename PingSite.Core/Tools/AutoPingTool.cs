using PingSite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Tools
{
    public class AutoPingTool
    {
        private readonly IHostRepository _hostRepository;

        public AutoPingTool(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }

        public async Task PingHost()
        {
            var hosts = await _hostRepository.GetAllAsync();

            foreach(var host in hosts)
            {
                host.SetLastStatus(PingTool.CheckPingStatus(host.Address));

                await _hostRepository.UpdateAsync(host);
            }
        }
    }
}
