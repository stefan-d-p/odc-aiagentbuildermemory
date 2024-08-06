using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.AIAgentBuilderSample.Structures;

[OSStructure(Description = "Citation Structure")]
public struct Citation
{
    [OSStructureField(Description = "Link to the source, if available",
        DataType = OSDataType.Text)]
    public string Link;

    [OSStructureField(Description = "Index",
        DataType = OSDataType.Text)]
    public string Index;
    
    [OSStructureField(Description = "Document Identifier",
        DataType = OSDataType.Text)]
    public string DocumentId;
    
    [OSStructureField(Description = "File Identifier",
        DataType = OSDataType.Text)]
    public string FileId;
    
    [OSStructureField(Description = "Type of source, e.g. PDF, Word, Chat, etc",
        DataType = OSDataType.Text)]
    public string SourceContentType;
    
    [OSStructureField(Description = "Name of the source, e.g. file name",
        DataType = OSDataType.Text)]
    public string SourceName;
    
    [OSStructureField(Description = "URL of the source, used for web pages and external data",
        DataType = OSDataType.Text)]
    public string SourceUrl;

    [OSStructureField(Description = "List of chunks/blocks of text used",
        DataType = OSDataType.InferredFromDotNetType)]
    public List<Partition> Partitions;
}