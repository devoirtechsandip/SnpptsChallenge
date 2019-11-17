using System;
using System.IO;
using SQLite;
using learn.iOS;
using Xamarin.Forms;
using learn.Services;

namespace learn.iOS
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