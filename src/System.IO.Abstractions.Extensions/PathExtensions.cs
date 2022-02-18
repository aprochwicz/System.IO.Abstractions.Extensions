namespace System.IO.Abstractions.Extensions
{
    /// <summary>
    /// IPath interface extensions.
    /// </summary>
    public static class PathExtensions
    {
        ///<inheritdoc cref="Environment.ExpandEnvironmentVariables"/>
        ///<param name="iPath">IPath instance to call extension method on.</param>
        ///<param name="path"><inheritdoc cref="Environment.ExpandEnvironmentVariables"/></param>
#pragma warning disable IDE0060 // Remove unused parameter
        public static string Expand(this IPath iPath, string path)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            return Environment.ExpandEnvironmentVariables(path);
        }
    }
}
