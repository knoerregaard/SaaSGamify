using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Newtonsoft.Json;
using saasgamify_taskfunc.Models;
namespace saasgamify_taskfunc
{
    class DAL
    {
        public static void SaveEventToDb(Event e) {
            //define the connection string of azure database.
            var cnString = "Server=tcp:saasgamify-server.database.windows.net,1433;Initial Catalog=saasgamify-db;Persist Security Info=False;User ID=saasgamifylogin;Password=saasgamify12345.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            //define the insert sql command, here I insert data into the student table in azure db.
            string cmdText = @"insert into Event (eventtitle, eventdescription) values(@eventtitle, @eventdescription)";


                using (SqlConnection con = new SqlConnection(cnString))
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@eventtitle", e.eventtitle);
                    cmd.Parameters.AddWithValue("@eventdescription", e.eventdescription);
                    
                    cmd.ExecuteNonQuery();
                    
                    con.Close();
                }

        }
    }
}
