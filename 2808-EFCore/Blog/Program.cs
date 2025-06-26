using Blog.Data;
using Blog.Models;

using var context = new BlogDataContext();

//CREATE
//var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
//context.Tags.Add(tag);

//O mais correto, ler primeiro do banco e depois fazer as alterações!!!!!
//UPDATE
var tag = context.Tags.FirstOrDefault(x => x.Id == 5);
tag!.Name = ".NET";
tag.Slug = "dotnet";
context.Update(tag);

await context.SaveChangesAsync();
