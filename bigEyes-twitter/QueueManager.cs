using System;
using System.Collections.Generic;
using System.IO;

namespace BigEyes {
	class QueueManager {

		public event Action<int> OnTaskCountChanged = null;
		public HashSet<string> Tasks { get; private set; }
		private string filename;

		public bool Add(string task) {
			bool ok = Tasks.Add(task);
			OnTaskCountChanged.Invoke(Tasks.Count);
			return ok;
		}

		public bool Remove(string task) {
			bool ok = Tasks.Remove(task);
			OnTaskCountChanged.Invoke(Tasks.Count);
			return ok;
		}

		public int Count => this.Tasks.Count;

		public QueueManager(string bindFilename) {
			this.Tasks = new HashSet<string>();
			this.filename = bindFilename;
			SaveToFile();
			LoadFromFile();
		}

		private void LoadFromFile() {
			StreamReader sr = new StreamReader(filename);
			for (; ; ) {
				string line = sr.ReadLine();
				if (line == null) break;
				Tasks.Add(line);
			}
			sr.Close();
		}

		public void SaveToFile() {
			StreamWriter sw = new StreamWriter(filename);
			foreach (var task in Tasks) {
				sw.WriteLine(task);
			}
			sw.Close();
		}
	}
}
