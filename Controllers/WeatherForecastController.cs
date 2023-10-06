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
// ● Crear una nueva tarea.
// ● Obtener una tarea por id.
// ● Actualizar una tarea.
// ● Eliminar una tarea.
// ● Listar todas las tareas.
// ● Listar todas las tareas completadas.
    [HttpPost("CrearTarea")]
    public ActionResult<Tarea> AddTarea(Tarea tarea){
        var t = manejoDeTareas.AddTarea(tarea);
        if(t!=null){
            return Ok(t);
        }
        return BadRequest(t);
    }

    [HttpGet]
    [Route ("Tarea/{idTarea}")]
    public ActionResult<Tarea> GetTarea(int idTarea){
        var tarea = manejoDeTareas.GetTarea(idTarea);
        if(tarea != null){
            return Ok(tarea);
        }
        return BadRequest(tarea);
    }

    [HttpPut("Actualizar Tarea")]
    public ActionResult<Tarea> ActualizarTarea(int idTarea, EstadoTarea estadoTarea){
        var tarea = manejoDeTareas.ActualizarTarea(idTarea, estadoTarea);
        if(tarea != null){
            return Ok(tarea);
        }
        return BadRequest(tarea);
    }

    [HttpDelete]
    public ActionResult<Tarea> EliminarTarea(int idTarea){
        var tarea = manejoDeTareas.EliminarTarea(idTarea);
        if(tarea){
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet]
    [Route ("Tareas")]
    public ActionResult<Tarea> GetTareas(){
        var tareas = manejoDeTareas.GetTareas();
        if(tareas != null){
            return Ok(tareas);
        }
        return BadRequest(tareas);
    }

    [HttpGet]
    [Route ("Completadas")]
    public ActionResult<Tarea> GetTareasCompletadas(){
        var tareas = manejoDeTareas.GetTareasCompletadas();
        if(tareas != null){
            return Ok(tareas);
        }
        return BadRequest(tareas);
    }

}
