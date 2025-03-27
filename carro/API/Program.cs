//Esse é o imports dos arquivos da pasta Models dentro da pasta API
using API.Models;
//Esse import é para realizar os returns
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

/*Adcionando objetos com suas informações neste caso 2 Objetos Carro com os nomes "Fusca" e "Ferrari" respectivamente para o id "1" e "2"
List<Carro> carros = [
    new Carro() { Id = 1,  Name = "Fusca"},
    new Carro() { Id = 2, Name = "Ferrari"}
];*/

/*Exeplo de requisição
app.MapGet("/", () => "Hello World!");*/

//GET api/carros(resumindo colocar na url api/carros para conseguir a informações)
app.MapGet("/api/carros", ([FromServices] AppDataContext ctx) => {
    
    if(ctx.Carros.Any()){
        return Results.Ok(ctx.Carros.ToList());
    }

    return Results.NotFound();
});

//Post para registrar os carros no banco
app.MapPost("/api/carros", ([FromBody] Carro carro, 
                            [FromServices] AppDataContext ctx) => {
            
                ctx.Carros.Add(carro);
                ctx.SaveChanges();
                return Results.Created("", carro);

});

//get com o objetivo de buscar carro via id.(FromRoute para conseguir buscar o id pela url)
app.MapGet("/api/carros/{id}", ([FromRoute] int id,
                                [FromServices] AppDataContext ctx) => {
                Carro? carro = ctx.Carros.Find(id);

                if(carro != null){
                    return Results.Ok(carro);
                }

                return Results.NotFound();                    
});

app.MapPut("/api/carros/{id}", ([FromRoute] int id,
                                [FromBody] Carro carro,
                                [FromServices] AppDataContext ctx) => {
                
                Carro? entidade = ctx.Carros.Find(id);

                if(entidade != null){
                    entidade.Name = carro.Name;
                    ctx.Carros.Update(entidade);
                    ctx.SaveChanges();
                    return Results.Ok(entidade);
                }

                return Results.NotFound();
});

app.MapDelete("/api/carros/{id}", ([FromRoute] int id,
                                    [FromServices] AppDataContext ctx) => {
                
                Carro? carro = ctx.Carros.Find(id);

                if(carro == null){
                    return Results.NotFound();
                }

                ctx.Carros.Remove(carro);
                ctx.SaveChanges();
                return Results.NoContent();
            
});

app.Run();
