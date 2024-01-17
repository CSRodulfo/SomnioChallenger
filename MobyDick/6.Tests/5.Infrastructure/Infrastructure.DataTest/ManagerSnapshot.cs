using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Infrastructure.DataTest.SnapshotDB
{
    public class ManagerSnapshot
    {
        private static string snapshotPath = @"..\..\SnapshotDB\SnapshotDatabaseTest.ss";
        private string snapshotName = System.IO.Path.GetFileNameWithoutExtension(snapshotPath);

        public void CreateDatabaseSnapshot(string databaseName)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        snapshotPath = Path.Combine((new DirectoryInfo(Environment.CurrentDirectory)).Root.ToString(), "SnapshotDatabaseTest.ss");
                        //snapshotPath = CombinePaths(Environment.CurrentDirectory, "Snapshot\\SnapshotDatabaseTest.ss");
                        cmd.Connection = cnn;
                        cmd.CommandTimeout = 1000;
                        cmd.CommandText = "CREATE DATABASE " + snapshotName + " ON ( NAME = " + databaseName + ", FILENAME = '" + snapshotPath + "' ) AS SNAPSHOT OF " + databaseName + ";";

                        cnn.Open();
                        cmd.ExecuteNonQuery().ToString();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                cnn.Close();
            }
        }

        public void RevertDatabaseFromSnapshot(string databaseName)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = cnn;
                        cmd.CommandTimeout = 1000;
                        cmd.CommandText = "RESTORE DATABASE " + databaseName + " FROM DATABASE_SNAPSHOT = '" + snapshotName + "'; DROP DATABASE " + snapshotName + ";";

                        cnn.Open();
                        Console.WriteLine("REVERT SNAPSHOT: " + cmd.ExecuteNonQuery().ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private string CombinePaths(string rootPath, string relativePath)
        {
            DirectoryInfo dir = new DirectoryInfo(rootPath);
            // Retorno de 3 Niveles de directorios
            for (int i = 0; i < 3; i++)
            {
                dir = dir.Parent;
            }

            return Path.Combine(dir.FullName, relativePath);
        }

    }
}
