using System;
using System.Collections.Generic;
using System.Text;

namespace learn.Models
{
	public class tbl_UserMaster
	{
		public string pk { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Mobile { get; set; }
		public string Password { get; set; }
		public string RegDateTime { get; set; }
        public string GoogleVerified { get; set; }
        public string ProfilePhotoUrl { get; set; }
    }
}
