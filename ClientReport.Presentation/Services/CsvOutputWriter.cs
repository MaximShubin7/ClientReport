using System.Text;

namespace ClientReport.Presentation.Services
{
    internal class CsvOutputWriter : TextWriter
    {
        private StreamWriter streamWriter { get; }

        public CsvOutputWriter(string path)
        {
            streamWriter = new StreamWriter(
                path,
                append: false,
                new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
        }

        public override Encoding Encoding => streamWriter.Encoding;

        public override void Write(string? value) => streamWriter.Write(value);

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                streamWriter.Dispose();
            base.Dispose(disposing);
        }
    }
}