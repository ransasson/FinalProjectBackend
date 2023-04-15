using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectService.API.BackgroundServices
{
    public class FinalProjectBackgroundService : BackgroundService
    {
        private readonly CancellationTokenSource _token;
        public FinalProjectBackgroundService()
        {
            _token = new CancellationTokenSource();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!_token.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(1000);
                    _token.Cancel();
                }
                catch (Exception)
                {

                    await Task.Delay(1000,stoppingToken);
                }
            }
        }

        protected async Task RunAsync(CancellationToken stoppingToken)
        {
            await ExecuteAsync(stoppingToken);
        }
    }
}
