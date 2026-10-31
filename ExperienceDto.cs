using System.Collections.Generic;

namespace CvGeneratorAvalonia;

public class ExperienceDto
{
    public string Position { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Period { get; set; } = string.Empty;
    public string ProjectScope { get; set; } = string.Empty;
    public List<string> Description { get; set; } = new();
}
