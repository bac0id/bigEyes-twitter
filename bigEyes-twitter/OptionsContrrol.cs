﻿using System.IO;

namespace BigEyes {
	class OptionsContrrol {
		private readonly StreamReader sr;
		private readonly StreamWriter sw;

		public OptionsContrrol(string pathName) {
			this.sr = new StreamReader(pathName);
			this.sw = new StreamWriter(pathName, true);
		}
	}
}
