using DocumentFormat.OpenXml.Drawing.Diagrams;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.AIAgentBuilderSample.Structures;

[OSStructure(Description = "Individual Tag of a partition")]
public struct Tag
{
    public Tag(string key, List<string?> values)
    {
        Key = key;
        Values = values;
    }
    
    [OSStructureField(Description = "Key")]
    public string Key;

    [OSStructureField(Description = "Value List")]
    public List<string?> Values;
}