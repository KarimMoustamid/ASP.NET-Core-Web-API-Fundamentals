using Microsoft.AspNetCore.StaticFiles;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

 // Add this line to include controller support
builder.Services.AddControllers(
    // This option causes the controller to return a 406 Not Acceptable response when the request's Accept header does not match any of the controller's usable media types.
    option => option.ReturnHttpNotAcceptable = true
)
// Adds the XML Data Contract Serializer formatters to MVC so it can deserialize the XML received in requests and serialize XML in the responses.
.AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add FileExtensionContentTypeProvider as a singleton service to the DI container
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

// Uncomment the following lines to add ProblemDetails middleware.
// This middleware intercepts exceptions and generates a ProblemDetails object.
// It customizes ProblemDetails by adding "Server" field which contains the name of the server where the code is run.

// builder.Services.AddProblemDetails(option =>
// {
//     option.CustomizeProblemDetails = ctx =>
//     {
//         // Adding a custom property "Server" to the ProblemDetails response
//         ctx.ProblemDetails.Extensions.Add("Server", Environment.MachineName);
//     };
// });

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