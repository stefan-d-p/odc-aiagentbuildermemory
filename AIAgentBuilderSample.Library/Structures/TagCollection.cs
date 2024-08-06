using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.AIAgentBuilderSample.Structures;

[OSStructure(Description = "Tag Collection")]
public struct TagCollection()
{
    [OSStructureField(Description = "Tags")]
    public List<Tag> Tags = new();
}