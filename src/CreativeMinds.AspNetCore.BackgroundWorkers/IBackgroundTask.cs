using System;
using System.Threading;
using System.Threading.Tasks;

namespace CreativeMinds.AspNetCore.BackgroundWorkers {

	public interface IBackgroundTask {
		Task ExecuteAsync(CancellationToken cancellationToken);
	}
}
