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


        // Users
        public async Task<User> GetUserByLoginAndPasswodInUsers(string login, string password)
        {
            try
            {
                await ConnectDataBase();
                User User = new();
                string query = $"select * from dbo.Users where Login = '{login}' and Password = '{password}'";
                SqlCommand command = new(query, Connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows == false)
                {
                    return null;
                }
                while (await reader.ReadAsync())
                {
                    User.Id = Convert.ToInt32(reader["Id"]);
                    User.Login = reader["Login"].ToString();
                    User.Password = reader["Password"].ToString();
                    User.Role = (Role)Convert.ToInt32(reader["Role"]);
                    User.Phone = reader["Phone"].ToString();
                    User.Email = reader["Email"].ToString();
                    User.Birth = reader["Birth"].ToString();
                }
                return User;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // Medicines
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


        public async Task<Medicine> GetMedicineByIdFromMedicines(int medicineId)
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


        public async Task<int> CreateMedicineIntoMedicines(Medicine medicine)
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


        public async Task UpdateMedicineByIdIntoMedicines(Medicine medicine)
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


        public async Task DeleteMedicineByIdIntoMedicines(int id)
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


        // Brands
        public async Task<Brand> GetBrandByIdInBrands(int id)
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


        // Store
        public async Task<Store> GetStoreByMedicineIdFromStore(int medicineId)
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


        public async Task<int> CreateStoreIntoStore(Store store)
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


        public async Task UpdateStoreByMedicineIdIntoStore(Store store)
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


        public async Task UpdateAmountStoreByMedicineIdIntoStore(int medicineId, int amount)
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


        public async Task DeleteStoreByIdIntoStore(int id)
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


        // Order
        public async Task<int> CreateOrderIntoOrders(Order order)
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


        public async Task UpdateOrderIntoOrders(Order order)
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


        // OrderInfo
        public async Task<int> CreateOrderInfoIntoOrderInfo(OrderInfo orderInfo)
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


        public async Task UpdateOrderInfoIntoOrderInfo(OrderInfo orderInfo)
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
    }
}
