var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Add this line to include controller support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails(option =>
{
    option.CustomizeProblemDetails = ctx =>
    {
        // Adding a custom property "additionalInfo" to the ProblemDetails response
        ctx.ProblemDetails.Extensions.Add("Server", Environment.MachineName);
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers(); // new version , // app.UseEndpoints(endpoints => endpoints.MapControllers()); older version
app.MapControllers();


app.Run();