var builder = DistributedApplication.CreateBuilder(args);

// https://learn.microsoft.com/dotnet/aspire/community-toolkit/ollama
var ollama = builder.AddOllama("ollama").WithEndpoint(11434, 11434);
builder.AddProject<Projects.BlazorApp>(nameof(Projects.BlazorApp))
    .WithReference(ollama.AddModel("ollama-qwen", "qwen2.5:0.5b"));
builder.Build().Run();