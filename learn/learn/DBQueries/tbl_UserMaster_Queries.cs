using learn.Models;
using learn.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace learn.DBQueries
{
	public class tbl_UserMaster_Queries
	{
		private SQLiteAsyncConnection _connection;

		public tbl_UserMaster_Queries()
		{
			try
			{
				_connection = DependencyService.Get<ISQLiteDb>().GetConnection();
				_connection.CreateTableAsync<tbl_UserMaster>().Wait();
			}
			catch (Exception ex)
			{
			}

		}

		public Task<List<tbl_UserMaster>> GetAllItems()
		{
			return _connection.Table<tbl_UserMaster>().ToListAsync();
		}



		public async Task<int> DeleteItem(tbl_UserMaster item)
		{
			return await _connection.DeleteAsync(item);
		}

		public async Task<int> AddItem(tbl_UserMaster item)
		{
			return await _connection.InsertAsync(item);
			//return result;

		}

		public Task<int> UpdateItem(tbl_UserMaster item)
		{
			return _connection.UpdateAsync(item);
		}




		public async Task<int> DropTable()
		{
			return await _connection.DropTableAsync<tbl_UserMaster>();
		}

		//custom queries

		//public async Task<int> DeleteAll()
		//{
		//	return await _connection.ExecuteAsync("DELETE FROM tbl_Plaza_Master");
		//}


		//public async Task<int> DeleteItemByChecklistpk(string checklistpk, string userpk, string currdate)
		//{
		//	var str = "DELETE FROM checklistdata where parameterpk = '" + checklistpk + "' and date = '" + currdate + "' and user_name = '" + userpk + "'";
		//	return await _connection.ExecuteAsync(str);
		//}

		//public async Task<List<checklistdata>> GetNonUploadedItems()
		//{
		//	return await _connection.Table<checklistdata>().Where(t => t.uploadStatus != "1" || t.uploadStatus == null).ToListAsync();
		//}

		//public async Task<int> UpdateItemWithUploadStatus(checklistdata item)
		//{
		//	var str = "Update checklistdata set uploadStatus = '1' where parameterpk = '" + item.parameterpk + "' and timestamp = '" + item.timestamp + "' and user_name = '" + item.user_name + "'";

		//	return await _connection.ExecuteAsync(str);
		//}


		//public Task<checklistdata> GetDoneItem(string pk, string currdate)
		//{
		//	return _connection.Table<checklistdata>().Where(t => t.parameterpk == pk && t.date == currdate).FirstOrDefaultAsync();

		//}

		//public async Task<int> DeleteItem(checklistdata item)
		//{
		//	//return await _connection.ExecuteAsync("DELETE FROM checklistdata");
		//	return await _connection.DeleteAsync<checklistdata>(item.pk); // Id is the primary key
		//}

		//public Task<checklistdata> GetItemByName(string Name)
		//{
		//	return _connection.Table<checklistdata>().Where(t => t.activity == Name).FirstOrDefaultAsync();

		//}

		//public Task<List<checklistdata>> GetAllItemByfk(string fk)
		//{
		//	return _connection.Table<checklistdata>().Where(t => t.taskname == fk).ToListAsync();

		//}


		public async Task<int> DeleteAll()
		{
			return await _connection.DeleteAllAsync<tbl_UserMaster>();
		}

		public async Task<List<tbl_UserMaster>> GetItems(tbl_UserMaster item)
		{
			return await _connection.Table<tbl_UserMaster>().Where(t => t.Email == item.Email && t.Password == item.Password).ToListAsync();

		}
	}
}
