using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace DemoApp.Tests
{
    public class CodeConventionTests
    {
        [Fact]
        public void Code_Should_Follow_Convention_Rules()
        {
            var solutionPath = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "DemoApp.sln"));

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

            // Only fail on your defined convention errors
            //var conventionErrors = new[] { "CS8981", "IDE0042", "xUnit2020" };
            //bool hasConventionViolation = conventionErrors.Any(w => output.Contains(w) || error.Contains(w));

            //if (process.ExitCode != 0 || hasConventionViolation)
            //{
            //    // xUnit way to fail a test
            //    Assert.True(false, $"Code convention violations found:\n{output}\n{error}");
            //}
            var conventionErrors = new[] { "CS8981", "IDE0042", "xUnit2020" };

            if (process.ExitCode != 0 || conventionErrors.Any(w => output.Contains(w) || error.Contains(w)))
            {
                throw new Xunit.Sdk.XunitException($"Code convention violations found:\n{output}\n{error}");
            }
        }
    }
}
