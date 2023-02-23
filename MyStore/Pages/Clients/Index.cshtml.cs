using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyStore.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();

        public object MessageBox { get; private set; }

        public void OnGet()
        {
            try
            {
                String Connectionstring = "Data Source=DESKTOP-JG9I0FI;Initial Catalog=MyStrore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(Connectionstring))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientinfo = new ClientInfo();
                                clientinfo.id = "" + reader.GetInt32(0);
                                clientinfo.name = reader.GetString(1);
                                clientinfo.email = reader.GetString(2);
                                clientinfo.phone = reader.GetString(3);
                                clientinfo.address = reader.GetString(4);
                                clientinfo.created_at = reader.GetDateTime(5).ToString();

                                listClients.Add(clientinfo);

                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Exception: ");
                
            }
        }
    }
    public class ClientInfo
    {
        public String id;
        public String name;
        public String email;
        public String phone;
        public String address;
    public String created_at;
}
}

