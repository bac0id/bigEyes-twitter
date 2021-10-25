using System;
using System.IO;

namespace BigEyes {
	/// <summary>
	/// 写日志
	/// </summary>
	class LogWriter {
		//输出的格式是：时间:[标记]内容
		private static readonly string DefaultLogFormat = "{0}:[{1}]{2}";
		private readonly StreamWriter sw;

		public LogWriter(string outputFileName) {
			this.sw = new StreamWriter(outputFileName, true);
		}

		~LogWriter() {
			this.Close();
		}

		/// <summary>
		/// 写入日志
		/// </summary>
		/// <param name="flag">标识</param>
		/// <param name="content">内容</param>
		public void WriteLine(string flag, string content) {
			this.sw.WriteLine(DefaultLogFormat,
				DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
				flag,
				content);
		}

		/// <summary>
		/// 关闭 StreamWriter
		/// </summary>
		public void Close() {
			this.sw.Close();
		}
	}
}
