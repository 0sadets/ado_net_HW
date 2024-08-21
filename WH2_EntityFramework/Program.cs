namespace WH2_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicDbContext db = new MusicDbContext();
            //db.Playlists.Add(new Playlist()
            //{
            //    Title = "title",
            //    Category = "category",
            //});
            //db.SaveChanges();
            //foreach (var item in db.Playlists)
            //{
            //    Console.WriteLine($"{item.Id} {item.Category} {item.Title}");
            //}
            foreach (var item in db.Artists)
            {
                Console.WriteLine($"Artist: {item.Name} {item.Lastname}");
            }
        }
    }
}
