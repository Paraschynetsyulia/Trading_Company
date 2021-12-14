using System;
namespace DTO
{
    public class UsersDTO
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public byte[] Password { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public Guid S{get;set ;}
       
    }
}
