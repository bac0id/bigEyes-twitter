using System.Drawing;

namespace BigEyes {
	interface IImageSaver {
		string Path { get; }
		void Save(Image image, string pathAndFileName);
	}
}
