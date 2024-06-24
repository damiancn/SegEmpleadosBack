using DataAcccess.Beneficiary;
using DataAcccess.Employee;
using DataAcccess.Interface;
using Dtos.Beneficiary;
using Dtos.Employee;
using Entities.Core;
using Entities.Models.Catalog;
using Facade.Employee.Impl;
using Microsoft.EntityFrameworkCore;
using Services.Beneficiary;
using Services.Employee;
using Services.Interface;
using Facade.Beneficiary;
using Facade.Beneficiary.Impl;
using AutoMapper;
using SeguimientoEmpleadosAPI.Attributes;
using Facade.Catalogs.Employee;
using Facade.Security.User;
using Facade.Security.User.Impl;
using Dtos.Security.User;
using Services.Security.User.Impl;
using Entities.Models.Security;
using DataAcccess.Security.User;
using Services.Security.User;
using DataAcccess.Security.Rol;
using Services.Security.Rol;
using Services.Security.Rol.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();  
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IDataBaseContext, DataBaseContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Autenticacion",
       b =>

           b.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{

    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["ConfiguracionJWT:Issuer"],
        ValidAudience = builder.Configuration["ConfiguracionJWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["ConfiguracionJWT:Key"]))
    };
});

builder.Services.AddScoped<ICatalogDao<EmployeeModel>, EmployeeDao>();
builder.Services.AddScoped<IGenericService<EmployeeDto>, EmployeeService>();
builder.Services.AddScoped<IEmployeeFacade, EmployeeFacade>();

builder.Services.AddScoped<ICatalogDao<BeneficiaryModel>, BeneficiaryDao>();
builder.Services.AddScoped<IGenericService<BeneficiaryDto>, BeneficiaryService>();
builder.Services.AddScoped<IBeneficiaryFacade, BeneficiaryFacade>();

builder.Services.AddScoped<IRoleDao, RoleDao>();
builder.Services.AddScoped<IRolService, RoleService>();

builder.Services.AddScoped<ICatalogDao<UserModel>, UserDao>();
builder.Services.AddScoped<IUserDao, UserDao>();
builder.Services.AddScoped<IGenericService<UserDto>, UserService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserFacade, UserFacade>();


var mvcBuilder = builder.Services.AddMvc();
mvcBuilder.AddMvcOptions(p => p.Filters.Add(new CustomExceptionAttribute()));
builder.Services.AddScoped(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new Services.Mapping.Mapper());
}).CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
context.Database.Migrate();
app.UseCors("Autenticacion");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();



