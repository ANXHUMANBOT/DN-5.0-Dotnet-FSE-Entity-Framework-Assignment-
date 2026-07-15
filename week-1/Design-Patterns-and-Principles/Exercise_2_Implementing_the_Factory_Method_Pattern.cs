using System;

namespace DesignPatternsAssignment
{
    // Real-world scenario: Document Management System creating Word, PDF documents
    public interface IDocument
    {
        void Open();
        void Close();
    }

    public class WordDocument : IDocument
    {
        public void Open() => Console.WriteLine("Word Document: Opening and parsing formatting blocks...");
        public void Close() => Console.WriteLine("Word Document: Saving structure and flushing data streams.");
    }

    public class PdfDocument : IDocument
    {
        public void Open() => Console.WriteLine("PDF Document: Reading layout metadata and displaying rasterized canvas...");
        public void Close() => Console.WriteLine("PDF Document: Releasing native file system handles.");
    }

    // Abstract Creator
    public abstract class DocumentCreator
    {
        public abstract IDocument CreateDocument();

        // Operation executing the factory mechanism
        public void ProcessDocument()
        {
            IDocument doc = CreateDocument();
            doc.Open();
            doc.Close();
        }
    }

    // Concrete Creators
    public class WordCreator : DocumentCreator
    {
        public override IDocument CreateDocument() => new WordDocument();
    }

    public class PdfCreator : DocumentCreator
    {
        public override IDocument CreateDocument() => new PdfDocument();
    }

    class FactoryProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Requesting Word Document Creation ---");
            DocumentCreator wordEngine = new WordCreator();
            wordEngine.ProcessDocument();

            Console.WriteLine("\n--- Requesting PDF Document Creation ---");
            DocumentCreator pdfEngine = new PdfCreator();
            pdfEngine.ProcessDocument();
        }
    }
}