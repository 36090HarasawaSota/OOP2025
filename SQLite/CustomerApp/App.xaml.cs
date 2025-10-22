using System;
using System.IO;
using System.Windows;

namespace CustomerApp {
    public partial class App : Application {
        public static string databasePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "customer.db");
    }
}