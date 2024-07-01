using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("StoreContext") ?? throw new InvalidOperationException("Connection string 'StoreContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


public class Proveedor
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Contacto { get; set; }
    public string CorreoElectronico { get; set; }
    // Otras propiedades...
}


public class AgregarProveedorModel : PageModel
{
    private readonly StoreContext _context;
    private readonly ILogger<AgregarProveedorModel> _logger;

    public AgregarProveedorModel(StoreContext context, ILogger<AgregarProveedorModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    [BindProperty]
    public Proveedor Proveedor { get; set; }

    // Propiedad para almacenar el mensaje
    public string Mensaje { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            _context.Proveedor.Add(Proveedor);
            await _context.SaveChangesAsync();

            // Mensaje de depuración: proveedor agregado correctamente
            _logger.LogInformation("Proveedor agregado correctamente: {ProveedorId}", Proveedor.Id);

            // Asigna el mensaje de éxito
            Mensaje = "Proveedor agregado correctamente";

            return RedirectToPage("./ListaProveedores");
        }
        catch (Exception ex)
        {
            // Mensaje de depuración: error al agregar el proveedor
            _logger.LogError(ex, "Error al agregar el proveedor");

            // Asigna el mensaje de error
            Mensaje = "Hubo un error al agregar el proveedor";

            return Page();
        }
