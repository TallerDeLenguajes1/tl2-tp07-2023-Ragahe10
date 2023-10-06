namespace EspacioTarea;
using System.Text.Json;

public class AccesoADatos{
    public List<Tarea> Obtener(){
        var Tareas = new List<Tarea>();
        if (File.Exists("Tareas.json")){
            string json = File.ReadAllText("Tareas.json");
            Tareas = JsonSerializer.Deserialize<List<Tarea>>(json);
        } else {
            Console.WriteLine("No existe el json");
        }
        return Tareas;
    }
    public void Guardar(List<Tarea> Tareas){
        var json = JsonSerializer.Serialize(Tareas);
        File.WriteAllText("Tareas.json",json);
    }
}