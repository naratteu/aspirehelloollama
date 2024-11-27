var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BlazorApp>(nameof(Projects.BlazorApp));

builder.Build().Run();
