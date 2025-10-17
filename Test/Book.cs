using MySql.Data.Types;

namespace Test
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public MySqlDateTime releaseDate { get; set; }
    }
}
