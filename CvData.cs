using System.Collections.Generic;

namespace CvGeneratorAvalonia;

public class CvData
{
    public string FullName { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public List<string> Skills { get; set; } = new();
    public List<string> Languages { get; set; } = new();
    public List<string> Hobbies { get; set; } = new();
    public List<ExperienceDto> Experiences { get; set; } = new();
    public List<EducationDto> Education { get; set; } = new();
}
