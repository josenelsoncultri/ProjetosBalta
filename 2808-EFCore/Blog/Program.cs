using System.Collections.Immutable;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

/*
Anotações:
-Para insert ou update, sempre ler do banco pra depois fazer a alteração
-Para leitura, usar o AsNoTracking a fim de não trazer metadados adicionais do EFCore
-Queries são executadas com os métodos da lista, exemplo ToList, First, FirstOrDefault
--SingleOrDefault exige que o retorno tenha apenas um item, caso tenha mais de um vai dar Exception
*/

using var context = new BlogDataContext();

// var tag = context
//     .Tags
//     .AsNoTracking()
//     .FirstOrDefault(t => t.Name.Contains(".NET"));
// Console.WriteLine(tag?.Name);

//CREATE
// var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
// context.Tags.Add(tag);

// var tag2 = new Tag { Name = ".NET", Slug = "dotnet" };
// context.Tags.Add(tag2);

//O mais correto, ler primeiro do banco e depois fazer as alterações!!!!!
//UPDATE
// var tag = context.Tags.AsNoTracking().FirstOrDefault(x => x.Id == 7);
// tag!.Name = ".NET";
// tag.Slug = "dotnet";
// context.Update(tag);

//O mais correto, ler primeiro do banco e depois fazer a exclusão!!!!!
//DELETE
// var tag = context.Tags.FirstOrDefault(x => x.Id == 5);
// context.Remove(tag!);

// await context.SaveChangesAsync();


// var tags = context
//     .Tags
//     .AsNoTracking()
//     .ToList();

// foreach (var tag in tags)
// {
//     Console.WriteLine(tag.Name);
// }