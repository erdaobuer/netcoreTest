using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace TestAPI.Repository.sugar
{
   public class BaseDBConfig
    {
        public static string ConnectionString = File.ReadAllText(@"D:\myFile\dbPsw.txt");
    }
}
