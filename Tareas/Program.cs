using System.Text.Json;
using System.Text.Json.Nodes;

HttpClient cliente = new HttpClient();
HttpResponseMessage response = await cliente.GetAsync("https://jsonplaceholder.typicode.com/todos/");

string responseBody = await response.Content.ReadAsStringAsync();
List<Tareas> datos = JsonSerializer.Deserialize<List<Tareas>>(responseBody);

Console.WriteLine("-----Tareas Incompletas-----");
filtrar("incompleta",datos);

Console.WriteLine("-----Tareas Completas-----");
filtrar("completa",datos);
string json = JsonSerializer.Serialize(datos, new JsonSerializerOptions
{
    WriteIndented = true
});

File.WriteAllText("tarea.json", json);


void filtrar(string datos,List<Tareas> lista){
    foreach (var item in lista){
        if (datos == "incompleta"){
            if (item.completed==false){
                Console.WriteLine("Titulo: "+item.title+" Estado: Incompletado");
            }
        }else{
            if (item.completed ==true){
                Console.WriteLine("Titulo: "+item.title+" Estado: Completado");
            }
        }
    }
}
