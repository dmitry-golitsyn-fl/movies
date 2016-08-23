using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace MyMovies.Models
{
    public class RedisContext : IDisposable
    {
        private readonly RedisClient redis = new RedisClient("localhost", 6379);
        private MoviesStore Store { get; set; }
        public RedisContext()
        {
            SetupTestData();
        }

        public Movie GetMovie(long id)
        {
            var redisMovie = redis.As<Movie>();
            return redisMovie.GetAll().Where(o => o.Id == id).FirstOrDefault();
        }

        public List<Movie> GetMovies()
        {
            var redisMovie = redis.As<Movie>();
            return redisMovie.GetAll().ToList();
        }

        private void SetupTestData()
        {
            redis.FlushAll();
            var redisMovie = redis.As<Movie>();
            var redisMoviesStore = redis.As<MoviesStore>();

            Store = new MoviesStore()
            {
                Id = redisMoviesStore.GetNextSequence(),
                Movies = new List<Movie>()
                {
                    new Movie { Id = redisMovie.GetNextSequence(), Title = "Star Wars", Director = "Lucas" },
                    new Movie { Id = redisMovie.GetNextSequence(), Title = "Back to the Future", Director = "Robert Lee Zemeckis" },
                    new Movie { Id = redisMovie.GetNextSequence(), Title = "Jumanji", Director = "Joe Johnston" },
                    new Movie { Id = redisMovie.GetNextSequence(), Title = "A Space Odyssey", Director = "Stanley Kubrick" },
                    new Movie { Id = redisMovie.GetNextSequence(), Title = "Titanic", Director = "James Francis Cameron" },
                    new Movie { Id = redisMovie.GetNextSequence(), Title = "Inception", Director = "Christopher Jonathan James Nolan" },
                    new Movie { Id = redisMovie.GetNextSequence(), Title = "Battleship Potyomkin", Director = "Sergei Eisenstein" }
                }
            };
            redisMovie.StoreAll(Store.Movies);
            redisMoviesStore.Store(Store);
        }

        public void Dispose()
        {
            redis.Dispose();
        }
    }
}
