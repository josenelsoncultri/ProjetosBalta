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