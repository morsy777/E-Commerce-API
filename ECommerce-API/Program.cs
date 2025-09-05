var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencies(builder.Configuration);

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:5173") // your frontend (Vite, React, etc.)
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

// Enable CORS before Authorization
app.UseCors("AllowFrontend");

app.UseAuthorization();

//await DbSeeder.SeedAsync(app.Services);

app.MapControllers();

app.Run();