using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace ImageTagger
{
	public class ThreadPool
	{
		private Thread[] threads;
		private ConcurrentQueue<Action> Queue;

		public bool Run = true;

		public ThreadPool(int max)
		{
			threads = new Thread[max];
			Queue = new ConcurrentQueue<Action>();

			Run = true;
			for (int i = 0; i < max; ++i)
			{
				threads[i] = new Thread(new ThreadStart(ThreadRunning));
				threads[i].Start();
			}
		}

		public void Encueue(Action action)
		{
			Queue.Enqueue(action);
		}

		private void ThreadRunning()
		{
			Action action;
			while (Run)
			{
				if (Queue.TryDequeue(out action))
					action.Invoke();
				else
					Thread.Sleep(1000);
			}
		}

	}
}
