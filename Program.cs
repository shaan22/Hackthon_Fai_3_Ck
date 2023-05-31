using hotelApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace hotelApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string policyName = "myPolicy";
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<Ihotelcharge, hoteldata>();
            builder.Services.AddCors((options) =>
            {
                options.AddPolicy(policyName, options =>
                {
                    options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();

                });
            });
            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGet("/hotelcomponents", ([FromServices] Ihotelcharge com) =>
            {
                return com.Getitems();
            });

            app.MapGet("/hotelcomponents/{id}", (int id, Ihotelcharge com) =>
            {
                return com.Getitem(id);
            });
            app.MapPost("/hotelcomponents", (hotelcomponents item, Ihotelcharge com) =>
            {
                com.Additem(item);
            });
            app.MapDelete("/hotelcomponents/{id}", (int id, Ihotelcharge com) =>
            {
                com.RemoveItem(id);
            });
            app.MapPut("/hotelcomponents/{id}", (hotelcomponents item, Ihotelcharge com) =>
            {
                com.Updateitem(item);
            });
            app.UseAuthorization();
            app.UseCors(policyName);
            app.MapControllers();

            app.Run();
        }
    }
}