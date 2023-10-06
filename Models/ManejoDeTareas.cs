namespace EspacioTarea;
public class ManejoDeTareas{
    private AccesoADatos accesoADatos;
    public ManejoDeTareas(AccesoADatos accesoADatos){
        this.accesoADatos = accesoADatos;
    }
    public Tarea AddTarea(Tarea tarea){
        var tareas = accesoADatos.Obtener();
        tarea.Id = tareas.Count()+1;
        tareas.Add(tarea);
        accesoADatos.Guardar(tareas);
        return tarea;
    }
    public Tarea GetTarea(int idTarea){
        var tarea = accesoADatos.Obtener().FirstOrDefault(tarea => tarea.Id == idTarea);
        return tarea;
    }
    public Tarea ActualizarTarea(int idTarea, EstadoTarea estadoTarea){
        var tareas = accesoADatos.Obtener();
        var tarea = tareas.FirstOrDefault(tarea => tarea.Id == idTarea);
        if(tarea!=null){
            tarea.EstadoTarea = estadoTarea;
            accesoADatos.Guardar(tareas);
        }
        return tarea;
    }
    public bool EliminarTarea(int idTarea){
        var tareas = accesoADatos.Obtener();
        var tarea = tareas.FirstOrDefault(tarea => tarea.Id == idTarea);
        if(tarea!=null){
            tareas.Remove(tarea);
            accesoADatos.Guardar(tareas);
            return true;
        }
        return false;
    }
    public List<Tarea> GetTareas(){
        return accesoADatos.Obtener();
    }
    public List<Tarea> GetTareasCompletadas(){
        return accesoADatos.Obtener().FindAll(tarea => tarea.EstadoTarea == EstadoTarea.Completada);
    }
}