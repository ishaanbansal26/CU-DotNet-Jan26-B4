

namespace Day31
{
    class User { public int Id; public string Name; public string Country; }
    class Post { public int UserId; public int Likes; }

    internal class Q9
    {
        static void Main(string[] args)
        {
            var users = new List<User>
                {
                    new User{Id=1, Name="A", Country="India"},
                    new User{Id=2, Name="B", Country="USA"}
                };

            var posts = new List<Post>
            {
                new Post{UserId=1, Likes=100},
                new Post{UserId=1, Likes=50}
            };

            var topUserByLikes = users.Join(posts, u => u.Id, p => p.UserId, (u, p) => new { u.Name, p.Likes })
                .GroupBy(g => g.Name).Select(s => new { User = s.Key, TotalLikes = s.Sum(x => x.Likes) }).OrderByDescending(o => o.TotalLikes);
            foreach(var v in topUserByLikes)
            {
                Console.WriteLine(v.User +" - "+v.TotalLikes);
            }
            Console.WriteLine();

            var groupByCountry = users.GroupBy(g => g.Country).Select(s=> new {Country = s.Key, Name = s.Select(x=>x.Name)});
            foreach(var v in groupByCountry)
            {
                Console.WriteLine(v.Country +" - "+ string.Join(",",v.Name));
            }
            Console.WriteLine();

            var inactiveUsers = users.GroupJoin(posts, u => u.Id, p => p.UserId, (u, p) => new
            {
                Name = u.Name,
                Posts = p
            }).Where(x => x.Posts.Sum(s => s.Likes) == 0).Select(s => new { Name = s.Name });

            foreach(var v in inactiveUsers)
            {
                Console.WriteLine("The Inactive user is "+v.Name);
            }
            Console.WriteLine();

            var avgLikesPerPost = users.GroupJoin(posts,u => u.Id,p => p.UserId,(u, p) => new
            {
                 UserID = u.Id,
                 AvgLikes = p.Select(x => x.Likes).DefaultIfEmpty().Average()});
            foreach (var v in avgLikesPerPost)
            {
                Console.WriteLine(v.UserID +" - "+v.AvgLikes);
            }
        }
    }
}
