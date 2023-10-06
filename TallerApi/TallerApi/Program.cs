using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerApi;
using TallerApi.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<HotelParaisoContext>();

builder.Services.AddSwaggerGen(
    c =>
    {
        c.EnableAnnotations();
        c.SwaggerDoc("v1",
            new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Taller aplicada Swagger",
                Version = "V1",
                Description = "Hotel Paraíso Endpoints"
            });
        c.OperationFilter<Documentation>();
    }
    );

builder.Services.AddDbContext<HotelParaisoContext>(options =>
options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//[SwaggerOperation(Summary = "Get all customers")]
 
app.MapGet("/Customer", async (HotelParaisoContext context) =>
{
    return Results.Ok(await context.Customers.ToListAsync());
});

app.MapGet("/Customer{id}", async (Guid id, HotelParaisoContext context) =>
{
    if (await context.Customers.AnyAsync<Customer>(x => x.CustomerId == id))
    {
        return Results.Ok(await context.Customers.FirstAsync<Customer>(x => x.CustomerId == id));
    }
    return Results.NotFound();
});

app.MapPost("/Customer", async ([FromBody] Customer customer, HotelParaisoContext context) =>
{
    customer.CustomerId = Guid.NewGuid();
    await context.Customers.AddAsync(customer);
    await context.SaveChangesAsync();
    return Results.Created($"/Customer/{customer.CustomerId}", customer);

});

app.MapPut("/Customer{id}", async (Guid id, [FromBody] Customer customer, HotelParaisoContext context) =>
{
    if (await context.Customers.AnyAsync<Customer>(x => x.CustomerId == id))
    {
        context.Entry(customer).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});

app.MapDelete("/Customer{id}", async (Guid id, HotelParaisoContext context) =>
{
    if (await context.Customers.FindAsync(id) is Customer customer)
    {
        context.Customers.Remove(customer);
        await context.SaveChangesAsync();
        return Results.NoContent();

    }
    return Results.NotFound();

});

app.Run();