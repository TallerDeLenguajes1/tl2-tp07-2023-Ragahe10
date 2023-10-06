using EspacioTarea;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp07_2023_Ragahe10.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{
    private readonly ILogger<TareasController> _logger;
    private ManejoDeTareas manejoDeTareas;

    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        AccesoADatos accesoADatos = new AccesoADatos();
        manejoDeTareas = new ManejoDeTareas(accesoADatos);
    }
    
    
}
