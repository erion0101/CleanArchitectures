using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MinimalAPi.DTOs.DTO;
using Newtonsoft.Json.Linq;
using q.Authorization;
using q.Authorization.CustomPermission;
using q.Commands;
using q.DTOs.DTO;
using q.PipelineBehaviors;
using q.Queries;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthorization(options =>
 {

    options.AddPolicy("Ceo", policy =>
    {
        policy.Requirements.Add(new CEORequirement("ceo"));
    });
    options.AddPolicy("Admin", policy =>
    {
        policy.Requirements.Add(new AdminRequirement("admin"));
    });
      options.AddPolicy("PermissionPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Permission", "MemberAdmin"); 
    });
});

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IPaymentsService, PaymentsService>();
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.AddScoped<IReservationsService, ReservationsService>();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped<ReservationsService>();
builder.Services.AddScoped<CustomersService>();
builder.Services.AddSingleton<CustomersDTO>();
builder.Services.AddScoped<IAuthorizationHandler, AdminHandler>();
builder.Services.AddScoped<IAuthorizationHandler, CEOHandler>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionForAdminHandler>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

//Get cars by Id
app.MapGet("api/cars/{id}", async (int id, CancellationToken token, IMediator mediator) =>
{
    var query = new GetCarsByIdQuery(id);
    var result = await mediator.Send(query, token);
    return result != null ? Results.Ok(result) : Results.NotFound(result);
}).RequireAuthorization("PermissionPolicy");
//Get all cars
app.MapGet("api/cars/all", async  (CancellationToken token, IMediator mediator) =>
{
    var query = new GetALLCarsQuery();
    var result = await mediator.Send(query, token);
    return result != null ? Results.Ok(result) : Results.NotFound(result);

}).RequireAuthorization("Ceo");
//Get all Customers 
app.MapGet("api/customers/getall", async  (CancellationToken token,IMediator mediator) =>
{
    var query = new GetAllCustomersQuery();
    var result = await mediator.Send(query,token);
    return result != null ? Results.Ok(result) : Results.NotFound(result);

}).RequireAuthorization("Admin");
// get all reservations on Rent a Care
app.MapGet("api/reservations/all", async (IMediator mediator, CancellationToken token) =>
{
    var query = new GetAllReservationsQuery();
    var result = await mediator.Send(query, token);
    return Results.Ok(result);
});
//Login 
app.MapPost("auth/login", async ([FromBody]AuthRequestCommand request,
    IMediator mediator, CancellationToken cancellationToken, IConfiguration _configuration) =>
{
    return await mediator.Send(request, cancellationToken);

});
//Create new Customers in Rent
app.MapPost("api/customers/register", async ([FromBody]CreateCustomersCommand cmd,CancellationToken token, IMediator mediator) =>
{
    return await mediator.Send(cmd,token);
});
app.MapPost("api/create/reservations", async ([FromBody]CreateReserrvationCommand create, CancellationToken token, IMediator mediator ) =>
{
    return await mediator.Send(create,token);
});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.Run();


