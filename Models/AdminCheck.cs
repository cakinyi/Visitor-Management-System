// using Microsoft.Data.SqlClient;
// using System;
// using System.Collections.Generic;
// using System.Data;
// using System.Linq;
// using System.Threading.Tasks;

// namespace VisitorManagement.Models
// {
//     public class AdminCheck
//     {
//         SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=VMS;User ID=racrathi;Password=Rachit123*");
//         public int LoginCheck(AdminLogin ad)
//         {
//             SqlCommand com = new SqlCommand("Sp_Login", con);
//             com.CommandType = CommandType.StoredProcedure;
//             com.Parameters.AddWithValue("@Admin_id", ad.Admin_id);
//             com.Parameters.AddWithValue("@Password", ad.Ad_Password);
//             SqlParameter oblogin = new SqlParameter();
//             oblogin.ParameterName = "@Isvalid";
//             oblogin.SqlDbType = SqlDbType.Bit;
//             oblogin.Direction = ParameterDirection.Output;
//             com.Parameters.Add(oblogin);
//             con.Open();
//             com.ExecuteNonQuery();
//             int res = Convert.ToInt32(oblogin.Value);
//             con.Close();
//             return res;
//         }
//     }
// }
