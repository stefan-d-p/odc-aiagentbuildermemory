using AutoMapper;
using Microsoft.KernelMemory;
using Without.Systems.AIAgentBuilderSample.Structures;
using Without.Systems.AIAgentBuilderSample.Util;

namespace Without.Systems.AIAgentBuilderSample;

/// <summary>
/// Sample OutSystems Developer Cloud External Logic.
/// For Demo purposes only. Do not use in production environments!
/// </summary>
public class AIAgentBuilderSample : IAIAgentBuilderSample
{

    private readonly IMapper _automapper;
    
    public AIAgentBuilderSample()
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AllowNullCollections = true;
            cfg.AllowNullDestinationValues = true;

            cfg.CreateMap<Microsoft.KernelMemory.Citation.Partition, Structures.Partition>()
                .ForMember(dest => dest.LastUpdate, opt => opt.MapFrom(src => src.LastUpdate.UtcDateTime));
            cfg.CreateMap<Microsoft.KernelMemory.Citation, Structures.Citation>();
            cfg.CreateMap<Microsoft.KernelMemory.SearchResult, Structures.SearchResult>();

            cfg.CreateMap<Microsoft.KernelMemory.TagCollection, Structures.TagCollection>()
                .ConstructUsing((src, dest) =>
                {
                    var tagCollection = new Structures.TagCollection();
                    if (src is { Count: > 0 })
                    {
                        foreach (var tag in src)
                        {
                            tagCollection.Tags.Add(new Tag(tag.Key, tag.Value));
                        }
                    }

                    return tagCollection;
                });

        });
        
        _automapper = mapperConfiguration.CreateMapper();
    }
    public string IndexWebpage(string url, string title, string openaiKey, string qdrantEndpoint, string qdrantKey, string qdrantCollection)
    {
        var memory = new KernelMemoryBuilder()
            .WithOpenAIDefaults(apiKey: openaiKey)
            .WithQdrantMemoryDb(endpoint: qdrantEndpoint, apiKey: qdrantKey)
            .Build<MemoryServerless>();

        var documentId = AsyncUtil.RunSync(() => memory.ImportWebPageAsync(url: url, index: qdrantCollection, tags: new () {{ "title", title }}));

        return documentId;
    }

    public void DeleteDocument(string documentId,string openaiKey, string qdrantEndpoint, string qdrantKey,
        string qdrantCollection)
    {
        var memory = new KernelMemoryBuilder()
            .WithOpenAIDefaults(apiKey: openaiKey)
            .WithQdrantMemoryDb(endpoint: qdrantEndpoint, apiKey: qdrantKey)
            .Build<MemoryServerless>();

        AsyncUtil.RunSync(() => memory.DeleteDocumentAsync(documentId: documentId, index: qdrantCollection));
    }

    public Structures.SearchResult Search(string text, Structures.SearchOptions searchOptions, string openaiKey, string qdrantEndpoint, string qdrantKey,
        string qdrantCollection)
    {
        var memory = new KernelMemoryBuilder()
            .WithOpenAIDefaults(apiKey: openaiKey)
            .WithQdrantMemoryDb(endpoint: qdrantEndpoint, apiKey: qdrantKey)
            .Build<MemoryServerless>();

        var results = AsyncUtil.RunSync(() => memory.SearchAsync(query: text, limit: searchOptions.limit,
            minRelevance: searchOptions.relevance, index: qdrantCollection));

        return _automapper.Map<Structures.SearchResult>(results);

    }
}