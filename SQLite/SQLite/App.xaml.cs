using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SQLite.Entity;

namespace SQLite
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ObjednavkaDatabase _database;

        public static ObjednavkaDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new FileHelper();
                    _database = new ObjednavkaDatabase(fileHelper.GetLocalFilePath("ObjednavkaDatabase.db3"));
                }
                return _database;
            }
        }

    }
}
