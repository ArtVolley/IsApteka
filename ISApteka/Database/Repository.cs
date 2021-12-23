using ISApteka.Database.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ISApteka.Entities.Enums;

namespace ISApteka.Database
{
    public class Repository
    {
        private SqlConnection Connection;

        private async Task ConnectDataBase()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ISApteka.DataBase"].ConnectionString;
                Connection = new SqlConnection(connectionString);
                await Connection.OpenAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #region Users
        public async Task<User> GetByLoginAndPasswodFromUsers(string login, string password)
        {
            try
            {
                await ConnectDataBase();
                User user = new();
                string query = $"select * from dbo.Users where Login = '{login}' and Password = '{password}'";
                SqlCommand command = new(query, Connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows == false)
                {
                    return null;
                }
                while (await reader.ReadAsync())
                {
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Login = reader["Login"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.Role = (Role)Convert.ToInt32(reader["Role"]);
                    user.Name = reader["Name"].ToString();
                    user.Phone = reader["Phone"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.Birth = reader["Birth"].ToString();
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<User>> GetAllFromUsers()
        {
            try
            {
                await ConnectDataBase();
                List<User> users = new();
                string query = $"select * from dbo.Users";
                SqlCommand command = new(query, Connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows == false)
                {
                    return users;
                }
                while (await reader.ReadAsync())
                {
                    User user = new()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Login = reader["Login"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = (Role)Convert.ToInt32(reader["Role"]),
                        Name = reader["Name"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        Birth = reader["Birth"].ToString()
                    };
                    users.Add(user);
                }
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task UpdateByIdIntoUsers(User user)
        {
            try
            {
                await ConnectDataBase();
                string query = $"UPDATE dbo.Users SET Login='{user.Login}', Password='{user.Password}', Role={(int)user.Role}," +
                    $"Name='{user.Name}', Phone='{user.Phone}', Email='{user.Email}', Birth='{user.Birth}'" +
                    $"WHERE Id={user.Id}";
                SqlCommand command = new(query, Connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<int> CreateIntoUsers(User user)
        {
            try
            {
                await ConnectDataBase();
                string query = $"INSERT INTO dbo.Users(Login,Password,Role,Name,Phone,Email,Birth) output INSERTED.ID " +
                    $"VALUES('{user.Login}','{user.Password}',{(int)user.Role},'{user.Name}','{user.Phone}','{user.Email}','{user.Birth}')";
                SqlCommand command = new(query, Connection);
                var id = await command.ExecuteScalarAsync();
                return (int)id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task DeleteByIdIntoUsers(int id)
        {
            try
            {
                await ConnectDataBase();
                string query = $"delete from dbo.Users where id={id}";
                SqlCommand command = new(query, Connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Medicines
        public async Task<List<Medicine>> GetAllFromMedicines()
        {
            try
            {
                await ConnectDataBase();
                List<Medicine> medicines = new();
                string query = $"select * from dbo.Medicines";
                SqlCommand command = new(query, Connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows == false)
                {
                    return medicines;
                }
                while (await reader.ReadAsync())
                {
                    var b = reader["BrandId"].ToString();
                    Medicine medicine = new()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Form = reader["Form"].ToString(),
                        Description = reader["Description"].ToString(),
                        Composition = reader["Composition"].ToString(),
                        Instruction = reader["Instruction"].ToString(),
                        IsPrescription = Convert.ToBoolean(reader["IsPrescription"]),
                        BrandId = reader["BrandId"].ToString() == "" ? null : Convert.ToInt32(reader["BrandId"]),
                        Amount = reader["Amount"].ToString()
                    };
                    medicines.Add(medicine);
                    
                }
                return medicines;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Medicine> GetByIdFromMedicines(int medicineId)
        {
            try
            {
                await ConnectDataBase();
                Medicine medicine = new();
                string query = $"select * from dbo.Medicines where Id = {medicineId}";
                SqlCommand command = new(query, Connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows == false)
                {
                    return medicine;
                }
                while (await reader.ReadAsync())
                {
                    var b = reader["BrandId"].ToString();

                    medicine.Id = Convert.ToInt32(reader["Id"]);
                    medicine.Name = reader["Name"].ToString();
                    medicine.Form = reader["Form"].ToString();
                    medicine.Description = reader["Description"].ToString();
                    medicine.Composition = reader["Composition"].ToString();
                    medicine.Instruction = reader["Instruction"].ToString();
                    medicine.IsPrescription = Convert.ToBoolean(reader["IsPrescription"]);
                    medicine.BrandId = reader["BrandId"].ToString() == "" ? null : Convert.ToInt32(reader["BrandId"]);
                    medicine.Amount = reader["Amount"].ToString();
                }
                return medicine;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<int> CreateIntoMedicines(Medicine medicine)
        {
            try
            {
                await ConnectDataBase();
                string query = $"INSERT INTO dbo.Medicines(Name,Amount,Description,BrandId,Form,Instruction,Composition,IsPrescription) " +
                    $"output INSERTED.ID VALUES('{medicine.Name}','{medicine.Amount}','{medicine.Description}','{medicine.BrandId}'," +
                    $"'{medicine.Form}','{medicine.Instruction}','{medicine.Composition}',{(medicine.IsPrescription ? 1 : 0)})";
                SqlCommand command = new(query, Connection);
                var id = await command.ExecuteScalarAsync();
                return (int)id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task UpdateByIdIntoMedicines(Medicine medicine)
        {
            try
            {
                await ConnectDataBase();
                string query = $"UPDATE dbo.Medicines SET Name='{medicine.Name}', Amount='{medicine.Amount}'," +
                    $"Description='{medicine.Description}', Form='{medicine.Form}', Instruction='{medicine.Instruction}'," +
                    $"Composition='{medicine.Composition}', IsPrescription={(medicine.IsPrescription ? 1 : 0)}," +
                    $"BrandId={(medicine.BrandId == null ? "null" : medicine.BrandId.ToString())} " +
                    $"WHERE Id={medicine.Id}";
                SqlCommand command = new(query, Connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task DeleteByIdIntoMedicines(int id)
        {
            try
            {
                await ConnectDataBase();
                string query = $"delete from dbo.Medicines where id={id}";
                SqlCommand command = new(query, Connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Brands
        public async Task<Brand> GetByIdFromBrands(int id)
        {
            try
            {
                await ConnectDataBase();
                Brand Brand = new();
                string query = $"select * from dbo.Brands where id = {id}";
                SqlCommand command = new(query, Connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows == false)
                {
                    return null;
                }
                while (await reader.ReadAsync())
                {
                    Brand.Id = Convert.ToInt32(reader["Id"]);
                    Brand.Name = reader["Name"].ToString();
                    Brand.Description = reader["Description"].ToString();
                    Brand.Country = reader["Country"].ToString();
                }
                return Brand;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public async Task<List<Brand>> GetAllFromBrands()
        {
            try
            {
                await ConnectDataBase();
                List<Brand> brands = new();
                string query = $"select * from dbo.Brands";
                SqlCommand command = new(query, Connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows == false)
                {
                    return brands;
                }
                while (await reader.ReadAsync())
                {
                    Brand brand = new()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Country = reader["Country"].ToString()
                    };
                    brands.Add(brand);

                }
                return brands;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Store
        public async Task<Store> GetByMedicineIdFromStore(int medicineId)
        {
            try
            {
                await ConnectDataBase();
                Store Brand = new();
                string query = $"select * from dbo.Store where MedicineId = {medicineId}";
                SqlCommand command = new(query, Connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows == false)
                {
                    return null;
                }
                while (await reader.ReadAsync())
                {
                    Brand.Id = Convert.ToInt32(reader["Id"]);
                    Brand.MedicineId = Convert.ToInt32(reader["MedicineId"]);
                    Brand.Amount = Convert.ToInt32(reader["Amount"]);
                    Brand.Cost = Convert.ToDouble(reader["Cost"]);
                    Brand.Place = reader["Place"].ToString();
                }
                return Brand;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<Store>> GetAllFromStores()
        {
            try
            {
                await ConnectDataBase();
                List<Store> stores = new();
                string query = $"select * from dbo.Store";
                SqlCommand command = new(query, Connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows == false)
                {
                    return stores;
                }
                while (await reader.ReadAsync())
                {
                    Store store = new()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        MedicineId = Convert.ToInt32(reader["MedicineId"]),
                        Amount = Convert.ToInt32(reader["Amount"]),
                        Cost = Convert.ToDouble(reader["Cost"]),
                        Place = reader["Place"].ToString()
                    };
                    stores.Add(store);

                }
                return stores;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<int> CreateIntoStore(Store store)
        {
            try
            {
                await ConnectDataBase();
                string query = $"INSERT INTO dbo.Store(MedicineId,Amount,Cost,Place) " +
                    $"output INSERTED.ID VALUES({store.MedicineId},{store.Amount},{store.Cost.ToString().Replace(",",".")},'{store.Place}')";
                SqlCommand command = new(query, Connection);
                var id = await command.ExecuteScalarAsync();
                return (int)id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task UpdateByMedicineIdIntoStore(Store store)
        {
            try
            {
                await ConnectDataBase();
                string query = $"UPDATE dbo.Store SET Amount={store.Amount}, Cost={store.Cost.ToString().Replace(",", ".")}," +
                    $"Place='{store.Place}'" +
                    $"WHERE MedicineId={store.MedicineId}";
                SqlCommand command = new(query, Connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task UpdateAmountByMedicineIdIntoStore(int medicineId, int amount)
        {
            try
            {
                await ConnectDataBase();
                string query = $"UPDATE dbo.Store SET Amount={amount} WHERE MedicineId={medicineId}";
                SqlCommand command = new(query, Connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task DeleteByIdIntoStore(int id)
        {
            try
            {
                await ConnectDataBase();
                string query = $"delete from dbo.Store where MedicineId={id}";
                SqlCommand command = new(query, Connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Orders
        public async Task<int> CreateIntoOrders(Order order)
        {
            try
            {
                var date = DateTime.Now.ToString("HH:mm:ss dd.MM.yyyy");
                await ConnectDataBase();
                string query = $"INSERT INTO dbo.Orders(Date,TotalCost,IsPassed,UserId) output INSERTED.ID " +
                    $"VALUES('{date}',{order.TotalCost.ToString().Replace(",", ".")},{order.IsPassed},{order.UserId})";
                SqlCommand command = new(query, Connection);
                var id = await command.ExecuteScalarAsync();
                return (int)id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task UpdateIntoOrders(Order order)
        {
            try
            {
                var date = DateTime.Now.ToString("HH:mm:ss dd.MM.yyyy");
                await ConnectDataBase();
                string query = $"UPDATE dbo.Orders SET " +
                    $"Date='{date}', TotalCost={order.TotalCost.ToString().Replace(",", ".")}, " +
                    $"IsPassed={order.IsPassed}, UserId={order.UserId} " +
                    $"WHERE Id={order.Id}";
                SqlCommand command = new(query, Connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region OrderInfo
        public async Task<int> CreateIntoOrderInfo(OrderInfo orderInfo)
        {
            try
            {
                await ConnectDataBase();
                string query = $"INSERT INTO dbo.OrderInfo(OrderId,MedicineId,Amount,Cost) output INSERTED.ID " +
                    $"VALUES({orderInfo.OrderId},{orderInfo.MedicineId},{orderInfo.Amount},{orderInfo.Cost.ToString().Replace(",", ".")})";
                SqlCommand command = new(query, Connection);
                var id = await command.ExecuteScalarAsync();
                return (int)id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task UpdateIntoOrderInfo(OrderInfo orderInfo)
        {
            try
            {
                await ConnectDataBase();
                string query = $"UPDATE dbo.OrderInfo SET " +
                    $"MedicineId={orderInfo.MedicineId}, OrderId={orderInfo.OrderId}, " +
                    $"Amount={orderInfo.Amount}, Cost={orderInfo.Cost.ToString().Replace(",", ".")} WHERE Id={orderInfo.Id}";
                SqlCommand command = new(query, Connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
