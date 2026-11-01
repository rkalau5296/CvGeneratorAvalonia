using CvGeneratorAvalonia.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CvGeneratorAvalonia.Templates
{
    public class ExecutiveTemplate : ICvTemplate
    {
        public string TemplateName => "Executive";

        public void Compose(IDocumentContainer container, CvData data)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(0);

                page.Content().Row(row =>
                {
                    row.ConstantItem(180).Background("#2C3E50").Padding(20).Column(col =>
                    {
                        col.Item().Text(data.FullName).FontColor("#FFFFFF").FontSize(16).Bold();
                        col.Item().PaddingTop(5).Text(data.Title).FontColor("#BDC3C7").FontSize(10);

                        col.Item().PaddingVertical(15).LineHorizontal(1).LineColor("#34495E");

                        col.Item().Text("CONTACT").FontColor("#FFFFFF").FontSize(11).Bold();
                        col.Item().PaddingTop(8).Text(data.Email).FontColor("#ECF0F1").FontSize(8.5f);
                        col.Item().Text(data.Phone).FontColor("#ECF0F1").FontSize(8.5f);
                        col.Item().Text(data.Location).FontColor("#ECF0F1").FontSize(8.5f);

                        if (data.Skills != null && data.Skills.Count > 0)
                        {
                            col.Item().PaddingVertical(15).LineHorizontal(1).LineColor("#34495E");
                            col.Item().Text("SKILLS").FontColor("#FFFFFF").FontSize(11).Bold();
                            foreach (var skill in data.Skills)
                            {
                                col.Item().PaddingTop(4).Text($"- {skill}").FontColor("#ECF0F1").FontSize(8.5f);
                            }
                        }

                        if (data.Languages != null && data.Languages.Count > 0)
                        {
                            col.Item().PaddingVertical(15).LineHorizontal(1).LineColor("#34495E");
                            col.Item().Text("LANGUAGES").FontColor("#FFFFFF").FontSize(11).Bold();
                            foreach (var lang in data.Languages)
                            {
                                col.Item().PaddingTop(4).Text($"- {lang}").FontColor("#ECF0F1").FontSize(8.5f);
                            }
                        }

                        if (data.Hobbies != null && data.Hobbies.Count > 0)
                        {
                            col.Item().PaddingVertical(15).LineHorizontal(1).LineColor("#34495E");
                            col.Item().Text("HOBBIES").FontColor("#FFFFFF").FontSize(11).Bold();
                            foreach (var hobby in data.Hobbies)
                            {
                                col.Item().PaddingTop(4).Text($"- {hobby}").FontColor("#ECF0F1").FontSize(8.5f);
                            }
                        }
                    });

                    row.RelativeItem().Background("#FFFFFF").Padding(25).Column(col =>
                    {
                        if (!string.IsNullOrEmpty(data.Summary))
                        {
                            col.Item().Text("ABOUT ME").FontSize(12).Bold().FontColor("#2C3E50");
                            col.Item().PaddingTop(4).Text(data.Summary).FontSize(9.5f).FontColor("#333333");
                            col.Item().PaddingVertical(10).LineHorizontal(0.5f).LineColor("#BDC3C7");
                        }

                        if (data.Experiences != null && data.Experiences.Count > 0)
                        {
                            col.Item().Text("WORK EXPERIENCE").FontSize(12).Bold().FontColor("#2C3E50");
                            col.Item().PaddingTop(6);

                            foreach (var exp in data.Experiences)
                            {
                                col.Item().Row(r =>
                                {
                                    r.RelativeItem().Text($"{exp.Position} | {exp.Company}").Bold().FontSize(9.5f).FontColor("#2C3E50");
                                    r.ConstantItem(95).AlignRight().Text(exp.Period).FontSize(8.5f).FontColor("#7F8C8D");
                                });

                                if (!string.IsNullOrEmpty(exp.ProjectScope))
                                {
                                    col.Item().PaddingTop(2).Text($"Scope: {exp.ProjectScope}").FontSize(8.5f).Italic().FontColor("#666666");
                                }

                                if (exp.Description != null && exp.Description.Count > 0)
                                {
                                    foreach (var desc in exp.Description)
                                    {
                                        col.Item().PaddingLeft(8).PaddingTop(2).Text($"• {desc}").FontSize(9f).FontColor("#444444");
                                    }
                                }

                                col.Item().PaddingBottom(8);
                            }

                            col.Item().PaddingVertical(5).LineHorizontal(0.5f).LineColor("#BDC3C7");
                        }

                        if (data.Education != null && data.Education.Count > 0)
                        {
                            col.Item().PaddingTop(5).Text("EDUCATION").FontSize(12).Bold().FontColor("#2C3E50");
                            col.Item().PaddingTop(6);

                            foreach (var edu in data.Education)
                            {
                                col.Item().Row(r =>
                                {
                                    r.RelativeItem().Text($"{edu.Degree} | {edu.Institution}").Bold().FontSize(9.5f).FontColor("#2C3E50");
                                    r.ConstantItem(95).AlignRight().Text(edu.Period).FontSize(8.5f).FontColor("#7F8C8D");
                                });
                                col.Item().PaddingBottom(6);
                            }
                        }
                    });
                });
            });
        }
    }
}