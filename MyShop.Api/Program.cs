using MyShop.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddConfigureJWT(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddServiceIdentity();


builder.Services.AddCors(opts =>
    opts.AddPolicy("AllowAll",
        b =>
            b.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
    )
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
