﻿using Balta.ContentContext;
using Balta.ContentContext.Enums;
using Balta.SubscriptionContext;

var articles = new List<Article>();
articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
articles.Add(new Article("Artigo sobre C#", "csharp"));
articles.Add(new Article("Artigo sobre .NET", "dotnet"));

foreach (var article in articles)
{
    Console.WriteLine(article.Id);
    Console.WriteLine(article.Title);
    Console.WriteLine(article.Url);
}

var courses = new List<Course>();
var courseOOP = new Course("Fundamentos OOP", "fundamentos-oop");
var courseCsharp = new Course("Fundamentos C#", "fundamentos-csharp");
var courseAspnet = new Course("Fundamentos ASP.NET", "fundamentos-aspnet");
courses.Add(courseOOP);
courses.Add(courseCsharp);
courses.Add(courseAspnet);

var careers = new List<Career>();
var careerDotnet = new Career("Especialista .NET", "especialista-dotnet");
var careerItem3 = new CareerItem(2, "OOP", "", courseOOP);
var careerItem2 = new CareerItem(3, "Aprenda .NET", "", courseAspnet);
var careerItem = new CareerItem(1, "Comece por aqui", "", courseCsharp);
careerDotnet.Items.Add(careerItem2);
careerDotnet.Items.Add(careerItem3);
careerDotnet.Items.Add(careerItem);
careers.Add(careerDotnet);

foreach (var career in careers)
{
    Console.WriteLine(career.Title);

    foreach (var item in career.Items.OrderBy(x => x.Order))
    {
        Console.WriteLine($"{item.Order} - {item.Title}");
        Console.WriteLine(item.Course?.Title);
        Console.WriteLine(item.Course?.Level);

        foreach (var notification in item.Notifications)
        {
            Console.WriteLine($"{notification.Property} - {notification.Message}");
        }
    }

    var payPalSubscription = new PayPalSubscription();
    var student = new Student();
    student.CreateSubscription(payPalSubscription);
}

