using System;
using System.Diagnostics;
using System.IO;
using Xunit;

namespace DemoApp.Tests
{
    public class CodeConventionTests
    {
        [Fact]
        public void Code_Should_Follow_Convention_Rules()
        {
            //var solutionPath = Path.Combine(
            //        Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
            //        "DemoApp.sln"
            //    );

            var solutionPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "DemoApp.sln"));

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = $"build \"{solutionPath}\" --no-restore -warnaserror",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            Assert.True(process.ExitCode == 0,
                $"Code style violations found:\n{output}\n{error}");
        }
    }
}
