﻿var builder = WebApplication.CreateBuilder(args);

builder.DisableIpPortBinding();

builder.Configuration
    .AddScrapeConfiguration();

builder.Host
    .SetupSerilog(builder.Configuration);

builder.Services
    .RegisterMassTransit()
    .AddDataStorage()
    .AddCrawlers()
    .AddDmmSupport()
    .AddQuartz(builder.Configuration);

var app = builder.Build();
app.Run();