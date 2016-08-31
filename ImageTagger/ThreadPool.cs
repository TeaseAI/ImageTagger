using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ImageTagger
{
	public class ThreadPool
	{
		private Thread[] threads;

		public ThreadPool(int max)
		{
			threads = new Thread[max];
		}

		public void RunOrWait(ThreadStart start)
		{
			int i;
			Thread t;
			while (true)
			{
				for (i = 0; i < threads.Length; i++)
				{
					t = threads[i];
					if (t == null || !t.IsAlive)
					{
						t = threads[i] = new Thread(start);
						t.Start();
						return;
					}
				}
			}
		}

		public void WaitForAll()
		{
			foreach (Thread t in threads)
				while (t != null && t.IsAlive)
					Thread.Sleep(50);
		}
	}
}
