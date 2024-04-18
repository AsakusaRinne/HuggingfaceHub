namespace Huggingface
{
    public static class Utils
    {
        public static string GetRelativePath(string referencePath, string filePath)
        {
#if NETSTANDARD2_0
            if (!referencePath.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                referencePath += Path.DirectorySeparatorChar;
            }

            Uri fileUri = new Uri(filePath);
            Uri referenceUri = new Uri(referencePath);

            Uri relativeUri = referenceUri.MakeRelativeUri(fileUri);
            
            string relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            relativePath = relativePath.Replace('/', Path.DirectorySeparatorChar);

            return relativePath;
#else
            return Path.GetRelativePath(referencePath, filePath);
#endif
        }

        public static string GetLongestCommonPath(string path1, string path2)
        {
            string[] parts1 = path1.Split(Path.DirectorySeparatorChar);
            string[] parts2 = path2.Split(Path.DirectorySeparatorChar);

            List<string> commonParts = new List<string>();

            int minLength = Math.Min(parts1.Length, parts2.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (parts1[i].Equals(parts2[i], StringComparison.OrdinalIgnoreCase))
                {
                    commonParts.Add(parts1[i]);
                }
                else
                {
                    break;
                }
            }

            string commonPath = String.Join(Path.DirectorySeparatorChar.ToString(), commonParts);

            return commonPath;
        }
    }
}