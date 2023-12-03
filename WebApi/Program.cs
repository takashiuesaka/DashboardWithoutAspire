using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// AddOpenTelemetry method is implemeted in OpenTelemetry.Extensions.Hosting Package
builder.Logging.AddOpenTelemetry(logging =>
{
    logging.AddOtlpExporter();
    logging.IncludeFormattedMessage = true;
    logging.IncludeScopes = true;
});

// AddOpenTelemetry method is implemeted in OpenTelemetry.Extensions.Hosting Package
builder.Services.AddOpenTelemetry()
    .WithMetrics(metrics =>
    {
        metrics.AddMeter(
            "Microsoft.AspNetCore.Hosting",
            "Microsoft.AspNetCore.Server.Kestrel",
            "System.Net.Http");
        metrics.AddOtlpExporter();
    });

// !! Tracing is not working !!
//builder.Services.AddOpenTelemetry()
//    .WithTracing(tracing =>
//    {
//        if (builder.Environment.IsDevelopment())
//        {
//            // We want to view all traces in development
//            tracing.SetSampler(new AlwaysOnSampler());
//        }

//        tracing.AddAspNetCoreInstrumentation()  // AddAspNetCoreInstrumentation method is implemeted in OpenTelemetry.Instrumentation.AspNetCore Package
////               .AddGrpcClientInstrumentation()
//               .AddHttpClientInstrumentation();
//    });


//Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
