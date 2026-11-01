using CvGeneratorAvalonia.Models;
using QuestPDF.Infrastructure;


namespace CvGeneratorAvalonia.Templates;

public interface ICvTemplate
{
    string TemplateName { get; }
    void Compose(IDocumentContainer container, CvData data);
}
