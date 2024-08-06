using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.AIAgentBuilderSample.Structures;


[OSStructure(Description = "Partition Structure")]
public struct Partition
{
    [OSStructureField(Description = "Content of the document partition, aka chunk/block of text",
        DataType = OSDataType.Text)]
    public string Text;

    [OSStructureField(
        Description =
            "Relevance of this partition against the given query. Value usually is between 0 and 1, when using cosine similarity.",
        DataType = OSDataType.Decimal)]
    public float Relevance;
    
    [OSStructureField(Description = "Partition number, zero based",
        DataType = OSDataType.Integer)]
    public int PartitionNumber;

    [OSStructureField(Description = "Text page number / Audio segment number / Video scene number",
        DataType = OSDataType.Integer)]
    public int SectionNumber;

    [OSStructureField(Description = "Timestamp about the file/text partition",
        DataType = OSDataType.DateTime)]
    public DateTime LastUpdate;
    
    [OSStructureField(Description = "Tag Collection",
        DataType = OSDataType.InferredFromDotNetType)]
    public TagCollection Tags;
}