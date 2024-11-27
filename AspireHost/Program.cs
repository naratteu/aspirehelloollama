var builder = DistributedApplication.CreateBuilder(args);

// https://learn.microsoft.com/dotnet/aspire/community-toolkit/ollama
var ollama = builder.AddOllama("ollama"); ollama.AddModel("llama3");
builder.AddProject<Projects.BlazorApp>(nameof(Projects.BlazorApp)).WithReference(ollama);

builder.Build().Run();