using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.AIAgentBuilderSample
{
    [OSInterface(
        Name = "AIAgentBuilderSourceSample",
        Description = "AI Agent Builder Sample Logic for indexing webpages to Qdrant Vector Database via Microsoft Kernel Memory",
        IconResourceName = "Without.Systems.AIAgentBuilderSample.Resources.AgentBuilderSample.png")]
    public interface IAIAgentBuilderSample
    {
        [OSAction(
            Description = "Indexes a Webpage",
            ReturnName = "id",
            ReturnDescription = "Document Id",
            ReturnType = OSDataType.Text,
            IconResourceName = "Without.Systems.AIAgentBuilderSample.Resources.AgentBuilderSample.png")]
        string IndexWebpage(
            [OSParameter(Description = "Url to scrape content",
                DataType = OSDataType.Text)]
            string url,
            [OSParameter(Description = "Title of the page",
                DataType = OSDataType.Text)]
            string title,
            [OSParameter(Description = "Open AI Project API Key",
                DataType = OSDataType.Text)]
            string openaiKey,
            [OSParameter(Description = "Qdrant Vector Database Endpoint Url",
                DataType = OSDataType.Text)]
            string qdrantEndpoint,
            [OSParameter(Description = "Qdrant Vector Database API Key",
                DataType = OSDataType.Text)]
            string qdrantKey,
            [OSParameter(Description = "Qdrant Vector Database Collection",
                DataType = OSDataType.Text)]
            string qdrantCollection);

        [OSAction(
            Description = "Search Index",
            ReturnName = "result",
            ReturnDescription = "Search result",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.AIAgentBuilderSample.Resources.AgentBuilderSample.png")]
        public Structures.SearchResult Search(
            [OSParameter(Description = "Client search text",
                DataType = OSDataType.Text)]
            string text,
            [OSParameter(Description = "Search refinement options")]
            Structures.SearchOptions searchOptions,
            [OSParameter(Description = "Open AI Project API Key",
                DataType = OSDataType.Text)]
            string openaiKey,
            [OSParameter(Description = "Qdrant Vector Database Endpoint Url",
                DataType = OSDataType.Text)]
            string qdrantEndpoint,
            [OSParameter(Description = "Qdrant Vector Database API Key",
                DataType = OSDataType.Text)]
            string qdrantKey,
            [OSParameter(Description = "Qdrant Vector Database Collection",
                DataType = OSDataType.Text)]
            string qdrantCollection);

        [OSAction(
            Description = "Deletes a document from the vector store",
            IconResourceName = "Without.Systems.AIAgentBuilderSample.Resources.AgentBuilderSample.png")]
        void DeleteDocument(
            [OSParameter(Description = "Document Identifier to delete",
                DataType = OSDataType.Text)]
            string documentId,
            [OSParameter(Description = "Open AI Project API Key",
                DataType = OSDataType.Text)]
            string openaiKey,
            [OSParameter(Description = "Qdrant Vector Database Endpoint Url",
                DataType = OSDataType.Text)]
            string qdrantEndpoint,
            [OSParameter(Description = "Qdrant Vector Database API Key",
                DataType = OSDataType.Text)]
            string qdrantKey,
            [OSParameter(Description = "Qdrant Vector Database Collection",
                DataType = OSDataType.Text)]
            string qdrantCollection);
    }
}