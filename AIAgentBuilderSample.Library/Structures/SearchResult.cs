using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.AIAgentBuilderSample.Structures;

[OSStructure(Description = "Search Result Structure")]
public struct SearchResult
{
    [OSStructureField(Description = "Client question",
        DataType = OSDataType.Text)]
    public string Query;

    [OSStructureField(Description = "Whether the search didn't return any result",
        DataType = OSDataType.Boolean)]
    public bool NoResult;

    [OSStructureField(
        Description =
            "List of the relevant sources used to produce the answer. Key = Document ID. Value = List of partitions used from the document",
        DataType = OSDataType.InferredFromDotNetType)]
    public List<Citation> Results;
}