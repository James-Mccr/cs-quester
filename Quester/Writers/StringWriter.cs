using Quester.TextWriterProviders;

namespace Quester.Writers
{
    public class StringWriter : IWriter<string>
    {
        public ITextWriterProvider TextWriterProvider { get; }
        
        public StringWriter(ITextWriterProvider textWriterProvider)
        {
            TextWriterProvider = textWriterProvider;
        }

        public void Write(string value)
        {
            using (var writer = TextWriterProvider.Provide())
            {
                writer.Write(value);
            }
        }
    }
}