using System;
using SQLite;
using System.IO;
using Xamarin.Forms;
using learn.Droid;
using learn.Services;

[assembly: Dependency(typeof(SQLiteDb))]
namespace learn.Droid
{
	public class SQLiteDb : ISQLiteDb
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "learndb.db3");

			return new SQLiteAsyncConnection(path);
		}
	}
}