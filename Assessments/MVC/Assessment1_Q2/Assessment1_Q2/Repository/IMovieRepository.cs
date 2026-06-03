using System.Collections.Generic;
using Assessment1_Q2.Models;

namespace Assessment1_Q2.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Insert(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        IEnumerable<Movie> GetByYear(int year);
        IEnumerable<Movie> GetByDirector(string director);
        void Save();
    }
}
