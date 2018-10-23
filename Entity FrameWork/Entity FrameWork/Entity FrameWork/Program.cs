using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_FrameWork
{
    class PlayList
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<Video> Videos { get; set; } // this will contain video id one to many

        public override string ToString()
        {
            string ret = "Title: " + Title;
            foreach (Video vid in Videos)
                ret += ret + ", ";
            return ret;
        }
    }

    class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public List<PlayList> MyPlayLists { get; set; }
    }

    class MeContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayList>().HasMany(p => p.Videos).WithMany();
            //modelBuilder.Entity<Video>().HasMany(p => p).WithMany();
        }
        /*
        public MeContext()
            : base(@"Data Source=.;Initial Catalog=MyTestDB;Integrated Security=True")
        {
        }
         */
    }

    class MainClass
    {
        static void Main(string[] args)
        {
            // #One-to-Many vs. Many-to-Many Relationsships
            MeContext db = new MeContext();
            /*
            db.Videos.Select(v => v.Title).ToList().ForEach(Console.WriteLine);
            PlayList theList = db.PlayLists.Include(list => list.Videos).Single();
            foreach (Video vid in theList.Videos)
            {
                Console.WriteLine(vid.Title);
            }
            return;
            */
            db.Database.Delete();
            Video meAwesomeVideo = new Video
            {
                Title = "The next Viral hit",
                Description = "Share with your friends."
            };

            //db.Videos.Add(meVideo);
            PlayList mePlayList = new PlayList();
            mePlayList.Title = "Entiry framework playlist";
            PlayList meOtherPlaylist = new PlayList();
            meOtherPlaylist.Title = "Epicness";

            mePlayList.Videos = new List<Video>() { meAwesomeVideo };
            meOtherPlaylist.Videos = new List<Video>() { meAwesomeVideo };

            db.PlayLists.Add(mePlayList); // this won't 'cause ref excep
            db.PlayLists.Add(meOtherPlaylist);
            Console.WriteLine(mePlayList);
            Console.WriteLine(meOtherPlaylist);
            db.SaveChanges();
        }
    }
}
