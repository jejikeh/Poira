using Poira.WebApp.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServiceMiddlewares();   

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
    app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();
app.MapFallbackToFile("index.html");
app.UseCors("AllowAll");

app.InitializeServiceContextProvider();

app.Run();