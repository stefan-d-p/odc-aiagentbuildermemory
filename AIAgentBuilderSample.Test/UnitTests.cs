using Microsoft.Extensions.Configuration;
using Microsoft.KernelMemory;
using Without.Systems.AIAgentBuilderSample.Structures;

namespace Without.Systems.AIAgentBuilderSample.Test;

public class Tests
{
    private static readonly IAIAgentBuilderSample _actions = new AIAgentBuilderSample();

    private string _openaiKey = String.Empty;
    private string _qdrantEndpoint = String.Empty;
    private string _qdrantKey = String.Empty;
    private string _qdrantCollection = "agentbuildercollection";
    
    
   
    [SetUp]
    public void Setup()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<Tests>()
            .AddEnvironmentVariables()
            .Build();
        
        _openaiKey = configuration["OpenAIKey"] ?? throw new InvalidOperationException();
        _qdrantEndpoint = configuration["QdrantEndpoint"] ?? throw new InvalidOperationException();
        _qdrantKey = configuration["QdrantKey"] ?? throw new InvalidOperationException();
    }

    [Test]
    public void Index_Page()
    {
        string url = "https://medium.com/itnext/application-level-encryption-in-outsystems-7b2db15f1c21";
        string title = "Application Level Encryption with OutSystems Developer Cloud";
        var result = _actions.IndexWebpage(url, title, _openaiKey, _qdrantEndpoint, _qdrantKey, _qdrantCollection);
        Assert.That(result, Is.Not.Empty);
    }

    [Test]
    public void Search_Index()
    {
        string query = "What are end-user roles?";
        SearchOptions options = new SearchOptions()
        {
            limit = 3,
            relevance = 0.7
        };
        
        var result = _actions.Search(query, options, _openaiKey, _qdrantEndpoint, _qdrantKey, _qdrantCollection);
    }

    [Test]
    public void Delete_Document()
    {
        string documentId = "32e341fb641e46c8b0dfa672ea6f2336202408050138508219611";
        _actions.DeleteDocument(documentId, _openaiKey, _qdrantEndpoint, _qdrantKey, _qdrantCollection);
    }
}