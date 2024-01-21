using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace EF_Assignment;


public class Program
{

    public static void Main(string[] args)
    {
        string[] Usercsv = File.ReadAllLines("C:\\Users\\Ahmed\\source\\repos\\EF-Assignment\\UserCsv.csv");
        string[] PostCsv = File.ReadAllLines("C:\\Users\\Ahmed\\source\\repos\\EF-Assignment\\Post.csv");
        string[] BlogCsv = File.ReadAllLines("C:\\Users\\Ahmed\\source\\repos\\EF-Assignment\\Blog.csv");

        using var db = new BloggingContext();

        Console.WriteLine($"Database path: {db.DbPath}.");




        {
            List<int> Blogid1 = new List<int>();
            List<int> Blogid2 = new List<int>();

            foreach (string line in BlogCsv)
            {
                string[] bloginfo = line.Split(',');
                int Posts = int.Parse(bloginfo[3]);
                int blogid = int.Parse(bloginfo[0]);
                if (blogid == 1)
                {
                    Blogid1.Add(Posts);
                }
                if (blogid == 2)
                {
                    Blogid2.Add(Posts);


                }

            }


            string trying = string.Empty;
            int count = 0;
            foreach (string line in BlogCsv)
            {
                string[] blogLine = line.Split(',');
                string url = blogLine[1];
                string name = blogLine[2];
                int postid = int.Parse(blogLine[3]);

                if (trying != url)
                {

                    if (count == 0)
                    {

                        db.Blogs.Add(new Blog { Url = url, Name = name, Posts = Blogid1 });
                        count++;
                    }

                    else
                    {
                        db.Blogs.Add(new Blog { Url = url, Name = name, Posts = Blogid2 });
                        break;

                    }

                }
                trying = url;
            }

            List<int> Userid1 = new List<int>();
            List<int> Userid2 = new List<int>();

            foreach (string line in Usercsv)
            {
                string[] userinfo = line.Split(',');
                int Posts = int.Parse(userinfo[3]);
                int userid = int.Parse(userinfo[0]);
                if (userid == 1)
                {
                    Userid1.Add(Posts);
                }
                if (userid == 2)
                {
                    Userid2.Add(Posts);
                }

            }

            string trying2 = string.Empty;
            int count2 = 0;
            foreach (string line in Usercsv)
            {
                string[] userLine = line.Split(',');
                int userId = int.Parse(userLine[0]);
                string username = userLine[1];
                string password = userLine[2];
                int postId = int.Parse(userLine[3]);

                if (trying2 != username)
                {
                    if (count2 == 0)
                    {
                        db.Users.Add(new User { UserId = userId, Username = username, Password = password, Posts = Userid1 });
                        count2++;
                    }
                    else
                    {
                        db.Users.Add(new User { UserId = userId, Username = username, Password = password, Posts = Userid2 });
                        break;
                    }
                }
            }
        }

    }
}














