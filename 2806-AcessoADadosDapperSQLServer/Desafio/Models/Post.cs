using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[Post]")]
public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }

    public int AuthorId { get; set; }
    [Write(false)]
    public User Author { get; set; } = null!;

    public int CategoryId { get; set; }
    [Write(false)]
    public Category Category { get; set; } = null!;

    [Write(false)]
    public List<Tag> Tags { get; set; } = [];

    public override string ToString()
    {
        return $"""
        Id: {Id} - Título: {Title} - Slug: {Slug}
        Autor: {Author.Name} - Categoria: {Category.Name}
        Criado em: {CreateDate:dd/MM/yyyy HH:mm:ss}
        Resumo: {Summary}
        Conteúdo:
        {Body}
        Última Atualização: {LastUpdateDate:dd/MM/yyyy HH:mm:ss}
        ------------------------------------------------------------------------------------------------
        """;
    }
}