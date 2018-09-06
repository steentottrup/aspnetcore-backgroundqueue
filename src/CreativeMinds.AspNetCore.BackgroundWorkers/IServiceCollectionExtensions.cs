using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CreativeMinds.AspNetCore.BackgroundWorkers {

	public static class IServiceCollectionExtensions {

		public static IServiceCollection AddBackgroundTaskQueue<THostedService, TBackgroundTaskQueue>(this IServiceCollection services) where THostedService : BackgroundService where TBackgroundTaskQueue : class, IBackgroundTaskQueue {
			services
				.AddHostedService<THostedService>();
			services
				.AddSingleton<IBackgroundTaskQueue, TBackgroundTaskQueue>();

			return services;
		}
	}
}
