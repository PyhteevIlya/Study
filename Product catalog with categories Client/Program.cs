using Product_catalog_with_categories_Client.Models.Config;
using Product_catalog_with_categories_Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.Configure<ProductcatalogwithcategoriesWebAPIConfig>(builder.Configuration.GetSection("Product catalog with categories WebAPI"));

builder.Services.AddScoped<ProductCatalogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Electronics}/{action=Index}/{id?}");

app.Run();
