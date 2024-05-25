using System.Drawing;

namespace BigEyes.Component {
	public interface IImageSaver {

		string SavingPath { get; }

		void Save(Image image, string pathAndFileName);

	}
}
