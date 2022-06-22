using RequestProject.Policies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// configure ImmediateRetry policy  with client factory. 
builder.Services.AddHttpClient("ImmediateRetry").AddPolicyHandler(
    request => request.Method == HttpMethod.Get ? new ClientPolicy().ImmediteHttpRetryPolicy : new ClientPolicy().ImmediteHttpRetryPolicy );

builder.Services.AddSingleton<ClientPolicy>(new ClientPolicy());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
