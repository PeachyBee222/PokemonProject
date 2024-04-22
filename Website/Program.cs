using TheFlyingSaucer.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=PokemonProject;Integrated Security=SSPI;";

var pokemon_connection = new SqlPokemonRepository(connectionString);

builder.Services.AddSingleton<IPokemonRepository>(pokemon_connection);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
