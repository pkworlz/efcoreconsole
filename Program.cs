using System;


namespace efcoreconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                // db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                // var count = db.SaveChanges();
                // Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                listAllBlogs();
                // foreach (var blog in db.Blogs)
                // {
                //     Console.WriteLine(" - {0}", blog.Url);
                // }
                Console.WriteLine("Do you want to add new blog..?(yes/no)");
                if (Console.ReadLine() == "yes")
                {
                    Console.WriteLine("Enter Text Here : ");
                    Blog newBlog = new Blog();
                    newBlog.Url = Console.ReadLine();
                    db.Blogs.Add(newBlog);
                    db.SaveChanges();
                    Console.WriteLine("Your blog sucessfully saved..");
                    listAllBlogs();
                }
                else
                {
                    Console.WriteLine("press anything to continue...");
                    Console.ReadLine();
                }

            }

            void listAllBlogs()
            {
                using (var db = new BloggingContext())
                {
                    foreach (var blog in db.Blogs)
                    {
                        Console.WriteLine(" - {0}", blog.Url);
                    }
                }
            }
        }

    }
}
