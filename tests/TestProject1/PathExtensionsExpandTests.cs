using Xunit;

namespace System.IO.Abstractions.Extensions.Tests
{
    public sealed class PathExtensionsTests: IDisposable
    {
        private const string TestVariableName = "Var1";
        private const string TestVariableValue = @"test\path";

        public PathExtensionsTests()
        {
            Environment.SetEnvironmentVariable(TestVariableName, TestVariableValue);
        }

        public void Dispose()
        {
            Environment.SetEnvironmentVariable(TestVariableName, null);
        }

        [Theory]
        [InlineData(@"c:\%var1%", @"c:\test\path")]
        [InlineData(@"c:\%VAR1%", @"c:\test\path")]
        public void Variables_should_be_replaced_in_path(string pathToExpand, string expectedPath)
        {
            var iPath = new FileSystem().Path;

            var expandedPath = iPath.Expand(pathToExpand);

            Assert.Equal(expectedPath, expandedPath);
        }

        [Fact]
        public void Path_without_variables_should_not_be_modified()
        {
            var iPath = new FileSystem().Path;
            const string pathWithoutVariables = @"c:\some\test\path";

            var expandedPath = iPath.Expand(pathWithoutVariables);
            
            Assert.Equal(pathWithoutVariables, expandedPath);
        }
    }
}
