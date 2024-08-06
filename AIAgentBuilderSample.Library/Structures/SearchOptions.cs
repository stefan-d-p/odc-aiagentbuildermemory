using DocumentFormat.OpenXml.Drawing.Diagrams;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.AIAgentBuilderSample.Structures;


[OSStructure(Description = "Search options")]
public struct SearchOptions
{
    [OSStructureField(Description = "Result limit. -1 is all",
        DataType = OSDataType.Integer,
        IsMandatory = false,
        DefaultValue = "-1")]
    public int limit;

    [OSStructureField(Description = "Relevance Score Threshold",
        DataType = OSDataType.Decimal,
        IsMandatory = false,
        DefaultValue = "0.0")]
    public double relevance;
}