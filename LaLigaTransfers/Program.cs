using Applicatiom.Extensions;
using Infraestructure.Extensions;
using LaLigaTransfers.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationInjectDependencies();
builder.Services.AddInfraInjectDependencies();
builder.Services.AddSwaggerWithAuth();
builder.Services.AddMongoDBConfigs();
builder.Services.AddControllers();
builder.Services.AddJwtAuthentication();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();
app.Run();