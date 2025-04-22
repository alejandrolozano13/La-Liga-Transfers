using Applicatiom.Extensions;
using Infraestructure.Extensions;
using LaLigaTransfers.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationInjectDependencies();
builder.Services.AddInfraInjectDependencies();
builder.Services.AddMongoDBConfigs();
builder.Services.AddJwtAuthentication();
builder.Services.AddSwaggerWithAuth();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();