using BlazorApp.Components;
using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

// https://github.com/CommunityToolkit/Aspire/blob/95b840a788e37ea95d2754bb9568b6418ddbd9ab/src/CommunityToolkit.Aspire.OllamaSharp/AspireOllamaSharpExtensions.cs#L111
var ollama = new System.Data.Common.DbConnectionStringBuilder { ConnectionString = builder.Configuration.GetConnectionString("ollama-qwen") };
#pragma warning disable SKEXP0070
builder.Services.AddOllamaChatCompletion(
    modelId: (string)ollama["Model"],
    endpoint: new((string)ollama["Endpoint"])
);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
