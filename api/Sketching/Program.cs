using System;
using System.Threading.Tasks;

using Octokit;

namespace Sketching
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));
            var user = await client.User.Get("dayton-outar");
            Console.WriteLine("{0} has {1} public repositories - go check out their profile at {2}",
                user.Name,
                user.PublicRepos,
                user.Url);
        }
    }
}
