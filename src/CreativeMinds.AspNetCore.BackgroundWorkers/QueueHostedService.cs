using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CreativeMinds.AspNetCore.BackgroundWorkers {

	public class QueueHostedService : BackgroundService {
		protected readonly ILogger logger;

		public QueueHostedService(IBackgroundTaskQueue taskQueue, ILogger<QueueHostedService> logger) {
			this.logger = logger;
			this.TaskQueue = taskQueue;
		}

		public IBackgroundTaskQueue TaskQueue { get; }

		protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
			this.logger.LogInformation("Queued Hosting Service is starting.");
			while (!stoppingToken.IsCancellationRequested) {
				var workItem = await this.TaskQueue.DequeueAsync(stoppingToken);

				try {
					await workItem(stoppingToken);
				}
				catch (Exception ex) {
					this.logger.LogError(ex, $"Error occurred executing {nameof(workItem)}.");
				}
			}
			this.logger.LogInformation("Queued Hosting Service is stopping.");
		}
	}
}
