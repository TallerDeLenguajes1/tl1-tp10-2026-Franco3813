using System.Text.Json;
HttpClient cliente = new HttpClient();
HttpResponseMessage response = await cliente.GetAsync("https://api.isevenapi.xyz/api/iseven/12/");

string responseBody = await response.Content.ReadAsStringAsync();
Datos datos = JsonSerializer.Deserialize<Datos>(responseBody);

string json = JsonSerializer.Serialize(datos,new JsonSerializerOptions{WriteIndented = true});
File.WriteAllText("Datos.json",json);
