using Modul2Test.Services;
using Modul2Test.Services.Interfaces;
using Modul2Test2.SqlFacade;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISqlFacade, SqlFacade>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddRazorPages()
    .AddMvcOptions(options =>
    {
        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
            _ => "Ovo polje je obavezno!");
    });

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
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
