namespace EspacioTarea;
public enum EstadoTarea{
    pendiente,
    enProgreso,
    Completada
}
public class Tarea{
    private int id;
    private string titulo;
    private string descripcion;
    private EstadoTarea estadoTarea;

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public EstadoTarea EstadoTarea { get => estadoTarea; set => estadoTarea = value; }
}