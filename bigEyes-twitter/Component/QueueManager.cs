using System;
using System.Collections.Generic;
using System.IO;

namespace BigEyes.Component {
	class QueueManager {

		public event Action<int> OnTaskCountChanged;

		private string filename;

		public HashSet<string> Tasks { get; private set; }

		public bool Add(string task) {
			bool ok = Tasks.Add(task);
			if(OnTaskCountChanged != null) {
				OnTaskCountChanged.Invoke(Tasks.Count);
			}
			return ok;
		}

		public bool Remove(string task) {
			bool ok = Tasks.Remove(task);
			OnTaskCountChanged.Invoke(Tasks.Count);
			return ok;
		}

		public QueueManager(string bindFilename) {
			Tasks = new HashSet<string>();
			filename = bindFilename;
			LoadFromFile();
		}

		private void LoadFromFile() {
			StreamReader sr = new StreamReader(filename);
			for (; ; )
			{
				string line = sr.ReadLine();
				if (line == null) break;
				Add(line);
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
