using System.Drawing;

namespace BigEyes.Component {
	class ImageSaver : IImageSaver {
		public string SavingPath { get; private set; }

		public ImageSaver(string savingPth) {
			SavingPath = savingPth;
			if (SavingPath.EndsWith("/") == false) {
				SavingPath += "/";
			}
		}

		public void Save(Image image, string fileName) {
			image.Save($"{SavingPath}{fileName}");
		}
	}
}
