using System.Data.SqlClient;

namespace VideoGameStore
{

    public class Customer
    {
        private static string con = "server=DESKTOP-EMQBT1J\\ERIC_INSTANCE;database=DB;integrated security=true;";
        public string customerUsername { get; set; }
        public string customerPassword{ get; set; }
        public string customerName { get; set; }
        public string customerAddressNumberAndStreet { get; set; }
        public string customerAddressCity { get; set; }
        public string customerAddressState { get; set; }
        public int customerAddressZipCode { get; set; }
        public string customerPhoneNumber { get; set; }

        public Customer GetCustomer(string p_customerUsername)
        {
            var con = new SqlConnection(GetSQLCon());
            var success = true;
            var cmd = new SqlCommand("select * from tbl_customers where customerUsername=@p_customerUsername", con);
            cmd.Parameters.AddWithValue("@p_customerUsername", p_customerUsername);
            con.Open();
            var customer = new Customer();
            customer.customerUsername = p_customerUsername;
            var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                customer.customerName = Convert.ToString(rd[1]);
                customer.customerPassword = Convert.ToString(rd[2]);
                customer.customerAddressNumberAndStreet = Convert.ToString(rd[3]);
                customer.customerAddressCity = Convert.ToString(rd[4]);
                customer.customerAddressState = Convert.ToString(rd[5]);
                customer.customerAddressZipCode = Convert.ToInt32(rd[6]);
                customer.customerPhoneNumber = Convert.ToString(rd[7]);
            }
            else
            {
                success = false;
            }
            rd.Close();
            con.Close();
            if (!success) throw new Exception("Customer not found");
            return customer;
        }
        public bool AddCustomer(Customer p_customer)
        {
            var con = new SqlConnection(GetSQLCon());
            var success = true;
            var cmd = new SqlCommand("insert into tbl_customers values(@customerName,@customerPassword,@customerAddressNumberAndStreet,@customerAddressCity,@customerAddressState,@customerAddressZipCode,@customerPhoneNumber)", con);
            cmd.Parameters.AddWithValue("@customerName", p_customer.customerName);
            cmd.Parameters.AddWithValue("@customerPassword", p_customer.customerPassword);
            cmd.Parameters.AddWithValue("@customerAddressNumberAndStreet", p_customer.customerAddressNumberAndStreet);
            cmd.Parameters.AddWithValue("@customerAddressCity", p_customer.customerAddressCity);
            cmd.Parameters.AddWithValue("@customerAddressState", p_customer.customerAddressState);
            cmd.Parameters.AddWithValue("@customerAddressZipCode", p_customer.customerAddressZipCode);
            cmd.Parameters.AddWithValue("@customerPhoneNumber", p_customer.customerPhoneNumber);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                success = false;
            }
            con.Close();
            if (!success) throw new Exception("Unable to add customer");
            return true;
        }
        public bool UpdateCustomer(Customer p_customer)
        {
            var con = new SqlConnection(GetSQLCon());
            con.Open();

            var success = true;
            var cmd = new SqlCommand("select count(*) from tbl_customers where customerName=@customer", con);
            cmd.Parameters.AddWithValue("@customerUsername", p_customer.customerUsername);
            var num = (int)cmd.ExecuteScalar();
            if (num == 1)
            {
                try
                {
                    cmd = new SqlCommand("update tbl_customers set customerPassword=@customerPassword where customerName=@customerName", con);
                    cmd.Parameters.AddWithValue("@customerPassword", p_customer.customerPassword);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("update tbl_customers set customerAddressNumberAndStreet=@customerAddressNumberAndStreet where customerName=@customerName", con);
                    cmd.Parameters.AddWithValue("@customerAddressNumberAndStreet", p_customer.customerName);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("update tbl_customers set customerAddressCity=@customerAddressCity where customerName=@customerName", con);
                    cmd.Parameters.AddWithValue("@customerAddressCity", p_customer.customerAddressCity);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("update tbl_customers set customerAddressState=@customerAddressState where customerName=@customerName", con);
                    cmd.Parameters.AddWithValue("@customerAddressState", p_customer.customerAddressState);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("update tbl_customers set customerAddressZipCode=@customerAddressZipCode where customerName=@customerName", con);
                    cmd.Parameters.AddWithValue("@customerAddressZipCode", p_customer.customerAddressZipCode);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("update tbl_customers set customerAddressPhoneNumber=@customerAddressPhoneNumber where customerName=@customerName", con);
                    cmd.Parameters.AddWithValue("@customerPhoneNumber", p_customer.customerPhoneNumber);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    success = false;
                }
            }
            else
            {
                success = false;
            }
            con.Close();
            if (!success) throw new Exception("There was a problem updating customer information.");
            return true;
        }
        public bool DeleteCustomer(string p_customerUsername)
        {
            var con = new SqlConnection(GetSQLCon());
            var success = true;
            var cmd = new SqlCommand("delete from tbl_customers where customerUsername=@customerUsername", con);
            cmd.Parameters.AddWithValue("@customerUsername", p_customerUsername);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                success = false;
            }
            con.Close();
            if (!success) throw new Exception("Customer not found.");
            return true;
        }
        public static string GetSQLCon()
        {
            return con;
        }
    }
}
