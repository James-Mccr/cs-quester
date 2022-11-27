using System;
using System.IO;

namespace Common.App
{
    public static class Paths
    {
        public static readonly string DefaultFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Quester");
        public static void CreateDefaultFolder() => Directory.CreateDirectory(DefaultFolder);
    }
}