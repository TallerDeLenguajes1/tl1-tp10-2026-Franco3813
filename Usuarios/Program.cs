using System.Text.Json;

HttpClient cliente = new HttpClient();
HttpResponseMessage response = await cliente.GetAsync("https://jsonplaceholder.typicode.com/users");

string responseBody = await response.Content.ReadAsStringAsync();
List<Usuario> datos = JsonSerializer.Deserialize<List<Usuario>>(responseBody);

for (int i = 0; i < 5; i++){
    Console.WriteLine("Nombre: "+datos[i].name+" Correo: "+datos[i].email+" Direccion: "+datos[i].address.street+" "+datos[i].address.suite);
}
