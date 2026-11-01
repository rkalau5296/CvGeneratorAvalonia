using CvGeneratorAvalonia.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CvGeneratorAvalonia.Templates
{
    public class ModernCreamTemplate : ICvTemplate
    {        
        public string TemplateName => "Modern Cream";

        public void Compose(IDocumentContainer container, CvData data)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(16);
                page.DefaultTextStyle(x => x.FontSize(9.5f).FontFamily("Arial").FontColor(Colors.Black));

                string darkCreamColor = "#EFECE6";

                page.Content().Column(mainCol =>
                {
                    mainCol.Spacing(14);
                                        
                    mainCol.Item()
                        .Background(darkCreamColor)
                        .Padding(16)
                        .Column(headerBox =>
                        {
                            headerBox.Spacing(8);
                            headerBox.Item().Row(row =>
                            {
                                row.ConstantItem(220).AlignLeft().Column(colContact =>
                                {
                                    colContact.Spacing(4);
                                    colContact.Item().Text($"📞  {data.Phone}").FontSize(9f).FontColor(Colors.Grey.Darken3);
                                    colContact.Item().Text($"✉  {data.Email}").FontSize(9f).FontColor(Colors.Grey.Darken3);
                                    colContact.Item().Text($"📍  {data.Location}").FontSize(9f).FontColor(Colors.Grey.Darken3);
                                });

                                row.RelativeItem().Column(colTitle =>
                                {
                                    colTitle.Item().Text(data.FullName).FontSize(44).Bold().FontColor(Colors.Grey.Darken4);
                                    colTitle.Item().PaddingTop(4).Text(data.Title).FontSize(12.5f).Bold().FontColor(Colors.Blue.Darken3);
                                });
                            });
                        });

                    mainCol.Item().LineHorizontal(1.5f).LineColor(Colors.Grey.Lighten2);
                                        
                    mainCol.Item().Row(mainRow =>
                    {                    
                        mainRow.ConstantItem(185).Column(leftCol =>
                        {
                            leftCol.Spacing(14);

                            if (data.Skills != null && data.Skills.Count > 0)
                            {
                                leftCol.Item().Background(darkCreamColor).Padding(12).Column(sec =>
                                {
                                    sec.Item().Text("SKILLS").FontSize(11).Bold().FontColor(Colors.Blue.Darken3);
                                    sec.Item().PaddingBottom(4).LineHorizontal(1f).LineColor(Colors.Blue.Darken3);
                                    sec.Spacing(4);
                                    foreach (var skill in data.Skills)
                                        sec.Item().Text($"• {skill}").FontSize(9f);
                                });
                            }

                            if (data.Languages != null && data.Languages.Count > 0)
                            {
                                leftCol.Item().Background(darkCreamColor).Padding(12).Column(sec =>
                                {
                                    sec.Item().Text("LANGUAGES").FontSize(11).Bold().FontColor(Colors.Blue.Darken3);
                                    sec.Item().PaddingBottom(4).LineHorizontal(1f).LineColor(Colors.Blue.Darken3);
                                    sec.Spacing(4);
                                    foreach (var lang in data.Languages)
                                        sec.Item().Text($"• {lang}").FontSize(9f);
                                });
                            }

                            if (data.Hobbies != null && data.Hobbies.Count > 0)
                            {
                                leftCol.Item().Background(darkCreamColor).Padding(12).Column(sec =>
                                {
                                    sec.Item().Text("HOBBIES").FontSize(11).Bold().FontColor(Colors.Blue.Darken3);
                                    sec.Item().PaddingBottom(4).LineHorizontal(1f).LineColor(Colors.Blue.Darken3);
                                    sec.Spacing(4);
                                    foreach (var hobby in data.Hobbies)
                                        sec.Item().Text($"• {hobby}").FontSize(9f);
                                });
                            }

                            if (data.Education != null && data.Education.Count > 0)
                            {
                                leftCol.Item().Background(darkCreamColor).Padding(12).Column(sec =>
                                {
                                    sec.Item().Text("EDUCATION").FontSize(11).Bold().FontColor(Colors.Blue.Darken3);
                                    sec.Item().PaddingBottom(4).LineHorizontal(1f).LineColor(Colors.Blue.Darken3);
                                    sec.Spacing(4);

                                    foreach (var edu in data.Education)
                                    {
                                        sec.Item().Column(eduCol =>
                                        {
                                            eduCol.Spacing(6);
                                            eduCol.Item().PaddingTop(1).Text($"{edu.Institution}  |  {edu.Period}").FontSize(9f).Bold().FontColor(Colors.Grey.Darken3);
                                            eduCol.Item().Text(edu.Degree).Italic().FontSize(8f);
                                        });
                                    }
                                });
                            }
                        });

                        mainRow.ConstantItem(18);
                                                
                        mainRow.RelativeItem().Column(rightCol =>
                        {
                            rightCol.Spacing(14);

                            if (!string.IsNullOrEmpty(data.Summary))
                            {
                                rightCol.Item().Column(sec =>
                                {
                                    sec.Item().Text("ABOUT ME").FontSize(11).Bold().FontColor(Colors.Blue.Darken3);
                                    sec.Item().PaddingBottom(4).LineHorizontal(1f).LineColor(Colors.Blue.Darken3);
                                    sec.Item().PaddingTop(3).Text(data.Summary).FontSize(9.5f);
                                });
                            }

                            if (data.Experiences != null && data.Experiences.Count > 0)
                            {
                                rightCol.Item().Column(sec =>
                                {
                                    sec.Item().Text("WORK EXPERIENCE").FontSize(11).Bold().FontColor(Colors.Blue.Darken3);
                                    sec.Item().PaddingBottom(4).LineHorizontal(1f).LineColor(Colors.Blue.Darken3);
                                    sec.Item().PaddingTop(6);

                                    sec.Item().Column(expListCol =>
                                    {
                                        expListCol.Spacing(16);

                                        foreach (var exp in data.Experiences)
                                        {
                                            expListCol.Item().Column(expCol =>
                                            {
                                                expCol.Spacing(2);
                                                expCol.Item().Row(row =>
                                                {
                                                    row.RelativeItem().AlignLeft().Text(exp.Company).Bold().FontSize(9.5f).FontColor(Colors.Grey.Darken3);
                                                    row.AutoItem().AlignRight().Text(exp.Period).Bold().FontSize(9.5f).FontColor(Colors.Grey.Darken3);
                                                });
                                                expCol.Item().Text(exp.Position).FontSize(8.5f).SemiBold().Italic().FontColor(Colors.Grey.Darken4);

                                                if (!string.IsNullOrEmpty(exp.ProjectScope))
                                                {
                                                    expCol.Item().PaddingTop(2).Text($"Scope: {exp.ProjectScope}").FontSize(8.5f).Italic().FontColor(Colors.Grey.Darken4);
                                                }

                                                if (exp.Description != null && exp.Description.Count > 0)
                                                {
                                                    expCol.Item().PaddingTop(3).Column(descCol =>
                                                    {
                                                        descCol.Spacing(2);
                                                        foreach (var descLine in exp.Description)
                                                        {
                                                            descCol.Item().Text($"• {descLine}").FontSize(8.5f).FontColor(Colors.Grey.Darken4);
                                                        }
                                                    });
                                                }
                                            });
                                        }
                                    });
                                });
                            }
                        });
                    });
                });
            });
        }
    }
}