
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using MyReactCore.Abstract;
using MyReactCore.Service;

namespace MyReactCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<ICream, CreameService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                         .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                    );
            });

            //builder.Services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/build";
            //});


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
            app.UseCors("AllowAll");
            app.UseStaticFiles();

            app.UseAuthorization();

            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";

            //    if (app.Environment.IsDevelopment())
            //    {
            //        spa.UseReactDevelopmentServer(npmScript: "start");
            //    }
            //});
            app.MapControllers();

            app.Run();
        }
    }
}

/*
 const fetchData = () => {
    // setLoading(true);
    console.log('123333')
    const requestOptions = {
      method: "GET",
      headers: { "Content-Type": "application/json" }
    };
    fetch(`http://localhost:5423/IceCream/GetIceCream`, requestOptions)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        console.log(data)
        // setLoading(false);
        // setData(data);
        // setQty("Найдено: " + data.length);
      });
  };
 */