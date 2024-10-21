
using Autofac;
using Autofac.Extensions.DependencyInjection;
using WebAplication.Abstraction;
using WebAplication.Data;
using WebAplication.Mapper;
using WebAplication.Repo;

namespace WebAplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(MapperProfile));
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(container =>
        {
            container.RegisterType<ProductRepo>().As<IProductRepo>();
            container.RegisterType<ProductGroupRepo>().As<IProductGroupRepo>();
            container.Register(_ => new ProductContext(builder.Configuration.GetConnectionString("db"))).InstancePerDependency();
        });
        builder.Services.AddMemoryCache(x=> x.TrackStatistics = true);

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
    }
}

