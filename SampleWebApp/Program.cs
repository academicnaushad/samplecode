using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


//builder.Services.Configure<IConfigurationBuilder>((IConfiguration)builder.Configuration.AddEnvironmentVariables());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapGet("/locations", () =>
{
    var Locations = new List<string>();
    //to get the connection string 
    var _config = app.Services.GetRequiredService<IConfiguration>();
    var connectionstring = _config["ConnectionStrings:SQLConnection"];
    //build the sqlconnection and execute the sql command
    using (SqlConnection conn = new SqlConnection(connectionstring))
    {
        conn.Open();
        string commandtext = "select LocationName from OptiQMaster";

        SqlCommand cmd = new SqlCommand(commandtext, conn);

        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string locationname = reader["LocationName"].ToString();
            Locations.Add(locationname);
        }
    }
    return Locations;
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
