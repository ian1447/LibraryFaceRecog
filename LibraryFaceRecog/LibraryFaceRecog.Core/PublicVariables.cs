using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryFaceRecog.Core
{
    public class PublicVariables
    {
        public static string ProjectName = "Library Management System";
        public static string ProjectVersion = "v1.0.0";

        public static string ConnectionString = "SERVER = localhost; DATABASE = librarymanagement; Uid = system_admin; Pwd = system_admin; PORT = 3306; AllowZeroDateTime = True;";

        #region Directory Settings
        public static string DefaultDirectory = Environment.CurrentDirectory;

        /// <summary>
        /// Here add Directory forlders that are necessary for the program
        /// Add more if needed
        /// </summary>
        #endregion

        #region User's Credentials/Privilege

        /// <summary>
        /// Here add user privilege that are necessary for the program
        /// Add more if needed
        /// </summary>
        public static string User;
        #endregion
    }
}
