
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Extentions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services, IConfiguration configuration)
        {
           Services.AddEndpointsApiExplorer();
Services.AddSwaggerGen();
Services.AddDbContext<StoreContext>(opt=>{

//opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")); for SQL Lite skinet DB
opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

});

Services.AddScoped<IProductRepository,Productsrepository>();
Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

Services.Configure<ApiBehaviorOptions>(option=> {
    option.InvalidModelStateResponseFactory=ActionContext=>
    {
        var erros=ActionContext.ModelState.Where(e=>e.Value.Errors.Count>0)
        .SelectMany(e=>e.Value.Errors)
        .Select(e=>e.ErrorMessage).ToArray();

        var errorresponse=new ApiValidationErrorresponse{
            Errors=erros,
        };    
        return new BadRequestObjectResult(errorresponse);
    };
});

        Services.AddCors(options=>
       {
        options.AddPolicy("AllowLocalhostOrigins",
            builder =>
            {
                builder.WithOrigins("https://localhost:4200")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
    });

    

           return Services;
        }
    }
}