using PlateformService.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PlateformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient<ICommandDataCleint,CommandDataCleint>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// regesiter service 
builder.Services.AddScoped<IPlateformRepo,PlateformRepo>();

// register db context 
builder.Services.AddDbContext<AppDataContext>(optionsAction =>{
    optionsAction.UseInMemoryDatabase("InMem");
});
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

PrepData.PrepDataPopulation(app);
app.Run();


