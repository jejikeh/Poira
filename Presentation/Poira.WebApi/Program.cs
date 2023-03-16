using Poira.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServiceMiddlewares();   

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.InitializeServiceContextProvider();

app.Run();