using System.Drawing;

namespace BigEyes {
	class ImageSaver : IImageSaver {
		public string Path { get; private set; }

		public ImageSaver(string path) {
			this.Path = path;
		}

		public void Save(Image image, string fileName) {
			image.Save($"{Path}{fileName}");
		}
	}
}
