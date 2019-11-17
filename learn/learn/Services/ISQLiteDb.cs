using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.Services
{
	public interface ISQLiteDb
	{
		SQLiteAsyncConnection GetConnection();
	}
}
