using CvGeneratorAvalonia.Models;
using CvGeneratorAvalonia.Templates;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace CvGeneratorAvalonia
{
    public class CvDocument : IDocument
    {
        private readonly CvData _cvData;
        private readonly ICvTemplate _template;
                
        public CvDocument(CvData cvData, ICvTemplate template)
        {
            _cvData = cvData;
            _template = template;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {            
            _template.Compose(container, _cvData);
        }
    }
}