using System.Text;
using Data.FoodMod;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.FoodMod.ActivityRepository;
using Repository.FoodMod.DietsRepository;
using Repository.FoodMod.IngredientsRepository;
using Repository.FoodMod.InRecRepository;
using Repository.FoodMod.MealRepository;
using Repository.FoodMod.MenuRepository;
using Repository.FoodMod.ParametersRepository;
using Repository.FoodMod.ParMenRepository;
using Repository.FoodMod.RecipesRepository;
using Repository.FoodMod.TypeOfDietRepository;
using Service.FoodMod.ActivityService;
using Service.FoodMod.DietsService;
using Service.FoodMod.IngredientsService;
using Service.FoodMod.InRecService;
using Service.FoodMod.MealService;
using Service.FoodMod.MenuService;
using Service.FoodMod.ParametersService;
using Service.FoodMod.ParMenService;
using Service.FoodMod.RecipesService;
using Service.FoodMod.TypeOfDietService;
using Service.TokenServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); //  Постройка связи моделей с базой данных DefaultConnection
});

builder.Services.AddCors(c => c.AddPolicy("cors", opt =>
{
    opt.AllowAnyHeader();
    opt.AllowCredentials();
    opt.AllowAnyMethod();
    opt.WithOrigins(builder.Configuration.GetSection("Cors:Urls").Get<string[]>()!);
}));



// FoodMod
builder.Services.AddScoped(typeof(IActivityRepository), typeof(ActivityRepository));
builder.Services.AddTransient<IActivityService, ActivityService>();
builder.Services.AddScoped(typeof(IDietsRepository), typeof(DietsRepository));
builder.Services.AddTransient<IDietsService, DietsService>();
builder.Services.AddScoped(typeof(IIngredientsRepository), typeof(IngredientsRepository));
builder.Services.AddTransient<IIngredientsService, IngredientsService>();
builder.Services.AddScoped(typeof(IInRecRepository), typeof(InRecRepository));
builder.Services.AddTransient<IInRecService, InRecService>();
builder.Services.AddScoped(typeof(IMealRepository), typeof(MealRepository));
builder.Services.AddTransient<IMealService, MealService>();
builder.Services.AddScoped(typeof(IMenuRepository), typeof(MenuRepository));
builder.Services.AddTransient<IMenuService, MenuService>();
builder.Services.AddScoped(typeof(IParametersRepository), typeof(ParametersRepository));
builder.Services.AddTransient<IParametersService, ParametersService>();
builder.Services.AddScoped(typeof(IParMenRepository), typeof(ParMenRepository));
builder.Services.AddTransient<IParMenService, ParMenService>();
builder.Services.AddScoped(typeof(IRecipesRepository), typeof(RecipesRepository));
builder.Services.AddTransient<IRecipesService, RecipesService>();
builder.Services.AddScoped(typeof(ITypeOfDietRepository), typeof(TypeOfDietRepository));
builder.Services.AddTransient<ITypeOfDietService, TypeOfDietService>();






//Token
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddAuthentication(opt => {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"]!,
            ValidAudience = builder.Configuration["Jwt:Audience"]!,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
        };
    });
builder.Services.AddAuthorization(options => options.DefaultPolicy =
    new AuthorizationPolicyBuilder
            (JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build());
builder.Services.AddIdentity<User, IdentityRole<long>>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddUserManager<UserManager<User>>()
    .AddRoleManager<RoleManager<IdentityRole<long>>>()
    .AddRoles<IdentityRole<long>>()
    .AddSignInManager<SignInManager<User>>();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Liskalisovsky", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
//app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("cors");
app.MapControllers();




app.UseRouting();
app.UseEndpoints(e=>{});
/*
app.UseEndpoints(e =>
    {
        e.MapGet("/1", () => "#1");
        e.MapGet("/2", () => "#2");
        e.MapGet("/3", () => "#3");
    });
    */






app.Run();

