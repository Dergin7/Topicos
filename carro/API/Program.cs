//Esse é o imports dos arquivos da pasta Models dentro da pasta API
using API.Models;
//Esse import é para realizar os returns
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Adcionando objetos com suas informações neste caso 2 Objetos Carro com os nomes "Fusca" e "Ferrari" respectivamente para o id "1" e "2"
List<Carro> carros = [
    new Carro() { Id = 1,  Name = "Fusca"},
    new Carro() { Id = 2, Name = "Ferrari"}
];

//Exeplo de requisição
app.MapGet("/", () => "Hello World!");

//GET api/carros(resumindo colocar na url api/carros para conseguir a informações)
app.MapGet("/api/carros", () => {
    return Results.Ok(carros);
});

app.Run();
