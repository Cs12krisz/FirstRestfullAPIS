using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Test.Controllers
{
    [Route("books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        Connect database = new Connect();
        [HttpGet]
        public List<Book> GetAllBooks()
        {

            database.Connection.Open();
            List<Book> books = new List<Book>();

            string sql = "SELECT * FROM books";
            MySqlCommand cmd = new MySqlCommand(sql, database.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var book = new Book
                {
                    Id = dr.GetInt32(0),
                    Title = dr.GetString(1),
                    Author = dr.GetString(2),
                    releaseDate = dr.GetDateTime(3),
                };

                books.Add(book);

            }

            database.Connection.Close();
            return books;
        }

        [HttpGet("getById")]
        public Book getById(int id)
        {
            database.Connection.Open();

            string sql = "SELECT * FROM books WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, database.Connection);
            cmd.Parameters.Add("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();


           dr.Read();
          var book = new Book
          { 
              Id = dr.GetInt32(0),
              Title = dr.GetString(1),
              Author = dr.GetString(2),
              releaseDate = dr.GetDateTime(3),
          };

               

            database.Connection.Close();
            return book;

        }
    }
}
