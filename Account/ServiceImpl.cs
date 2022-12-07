using BTLNhom3.Models;
namespace BTLNhom3.Account{
    public class ServiceImpl :Service
    {
        private List<Login> logins;
        public ServiceImpl()
        {
            logins = new List<Login>
            {
                new Login
                {
                    Username = "Admin",
                    Password = "123456",
                    FullName = "Nguyen Van A"
                },
                 new Login
                {
                    Username = "NV1",
                    Password = "123456",
                    FullName = "Trần Văn B"
                },
                 new Login
                {
                    Username = "NV2",
                    Password = "123456",
                    FullName = "Nguyen Thi C"
                }

            };

        } 
        public Login Login (string Username, string Password)
    {
        // trả về giá trị mặc định của kiểu dữ liệu trong bộ sưu tập
        return logins.SingleOrDefault(a =>a.Username == Username && a.Password == Password);

    }
        
    }
}