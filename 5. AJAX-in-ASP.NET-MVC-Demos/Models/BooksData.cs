namespace AjaxMVCDemos.Models
{
    using System.Collections.Generic;

    public static class BooksData
    {
        public static List<Book> GetAll()
        {
            return new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "Pro ASP.NET MVC 4",
                    Author = "Adam Freeman",
                    Content = "The ASP.NET MVC 4 Framework is the latest evolution of Microsoft’s ASP.NET web platform. It provides a high-productivity programming model that promotes cleaner code architecture, test-driven development, and powerful extensibility, combined with all the benefits of ASP.NET."
                },
                new Book
                {
                    Id = 2,
                    Title = "Professional ASP.NET MVC 4",
                    Author = "Jon Galloway, Phil Haack, Brad Wilson, K. Scott Allen",
                    Content = "Microsoft insiders join giants of the software development community to offer this in-depth guide to ASP.NET MVC, an essential web development technology."
                },
                new Book
                {
                    Id = 3,
                    Title = "Programming ASP.NET MVC 5",
                    Author = "Nimit Joshi",
                    Content = "This book is a basic introduction to Programming ASP.NET MVC 5, basically for beginners who want to learn complete basic with example of ASP.NET MVC 5."
                },
                new Book
                {
                    Id = 4,
                    Title = "AJAX For Dummies",
                    Author = "Steve Holzner",
                    Content = "AJAX is short for “Asynchronous JavaScript + CSS + DOM + XMLHttpRequest.” Even if you weren’t intimidated before, that tidbit is probably enough to make you reach for the Excedrin. Just reach for Ajax For Dummies instead. With screen shots, actual code and explanations, and live Web sites where you can see Ajax applications doing their thing, it will have you using Ajax to create Web applications that look an act like desktop applications in no time. With Ajax, you can speed up and clean up your Web applications."
                }
            };
        }
    }
}