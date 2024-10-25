var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.Run();

