using ConsoleEntityFramework.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEntityFramework
{
    class Program
    {
        static void Seed()
        {
            Console.WriteLine("Подключаемся");
            //1) Подключение к базе

            var db = new ModelMoviesContainer();

            //2) Проверяем пустая или нет
            if (db.Genres.Any()) // SELECT count(*) FROM dbo.Genres
            {
                Console.WriteLine("База не пустая");
                return;
            }
            Console.WriteLine("База пустая, заполняем...");

            var listGenres = new List<Genre>
            {
                new Genre { Name = "фантастика"},
                new Genre { Name = "боевик" },
                new Genre { Name = "приключение" },
                new Genre { Name = "Комедия" },
                new Genre { Name = "ужас" },
                new Genre { Name = "мелодрама" }
            };

            listGenres.ForEach(g => db.Genres.Add(g));


            var tomCruze = new Person()
            {
                LastName = "Круз",
                FirstName = "Том"
            };

            var emily = new Person()
            {
                LastName = "Блант",
                FirstName = "Эмили"
            };

            var dug = new Person()
            {
                LastName = "Лайман",
                FirstName = "Даг"
            };
            db.PersonSet.Add(tomCruze);
            db.PersonSet.Add(emily);
            db.PersonSet.Add(dug);


            var movie = new Movie
            {
                Title = "Грань будущего",
                Year = 2014,
            };
            movie.Actors.Add(tomCruze);
            movie.Actors.Add(emily);
            movie.Directors.Add(dug);
            db.Movies.Add(movie);

            db.SaveChanges();

            Console.WriteLine("Успешно сохранили");

            //var genreSciFi = new Genre{Name = "фантастика"};
            //var genreAction = new Genre { Name = "боевик" };
            //var genreAdventure = new Genre { Name = "приключение" };
            //var genreComedy = new Genre { Name = "Комедия" };
            //var genreHorror = new Genre { Name = "ужас" };

            //db.Genres.Add(genreSciFi);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Demo entity framework");

            Seed();

            Console.WriteLine("Запросы");
            var db = new ModelMoviesContainer();
            Console.WriteLine("Фамилий всех актеров");
            List<string> lastnames = db.PersonSet.Where(p => p.ActorofMovies.Any()).Select(p => p.LastName).ToList();

            lastnames.ForEach(s =>Console.WriteLine(s));

            Console.ReadLine();
        }
    }
}
