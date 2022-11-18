using Quester.Io.TextWriterProviders;

namespace Quester.Io.Outputs
{
    public class StringOutput : IOutput<string>
    {
        public ITextWriterProvider TextWriterProvider { get; }

        public StringOutput(ITextWriterProvider textWriterProvider)
        {
            TextWriterProvider = textWriterProvider;
        }

        public void Set(string value)
        {
            using (var writer = TextWriterProvider.Provide())
            {
                writer.Write(value);
            }
        }
    }
}