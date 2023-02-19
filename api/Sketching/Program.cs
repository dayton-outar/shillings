using System;
using System.Threading.Tasks;

using Octokit;

namespace Sketching
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // export GITTKN=yay! or /etc/environment
            var token = Environment.GetEnvironmentVariable("GITTKN");

            var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));
            client.Credentials = new Credentials(token);
            // var user = await client.User.Get("dayton-outar");
            // Console.WriteLine("{0} has {1} public repositories - go check out their profile at {2}",
            //     user.Name,
            //     user.PublicRepos,
            //     user.Url);

            // Grant access to user to do pull request so that the user can create issue
            var createIssue = new NewIssue("this is lame");
            var nIssue = await client.Issue.Create("dayton-outar", "shillings", createIssue);

            // var issuesForOctokit = await client.Issue.GetAllForRepository("dayton-outar", "smpl");
            // foreach(var issue in issuesForOctokit) {
            //     Console.WriteLine("#{0} {1} .. {2}", issue.Id, issue.Title, issue.Url); // issue.Body
            // }
        }
    }
}
