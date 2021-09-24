using System;
using System.Data.SqlClient;
namespace Functiondll
{
    public class Class1
    
    {
        public class Restaurant
        {
            static SqlConnection con;
            static SqlCommand cmd;
            static SqlDataReader dr;

            public static void CreateConnection()
            {

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("*******************************************CONNECTED TO THE DATABASE*************************************************");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("=====================================================================================================================");
                Console.WriteLine("\n");
                string constr = "Data source=DESKTOP-FLCVG6T;initial catalog=Restaurant;user=sa;password=Pooja@2708";
                con = new SqlConnection();

                con.ConnectionString = constr;
                //  con.Open();

            }



            public static bool Validation(string username, string password)
            {
                if (username == "Pooja" && password == "Pass@123")
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n");
                    Console.WriteLine("\t\t\t\t      Login Successfull!!!!!!!!");
                    return true;
                }
                else
                {
                    return false;

                }

            }
            public static void Search(string Restname)
            {
                con.Open();

                string query = "select * from Restaurant1 where Restname='" + Restname + "'";
                cmd = new SqlCommand(query, con);
                dr = cmd.ExecuteReader();
                Console.WriteLine("====================================================================");
                Console.WriteLine();
                Console.Write("Restaurant Deatails");
                while (dr.Read())
                {
                    Console.WriteLine();
                    Console.Write("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
                }
                Console.WriteLine();
                Console.WriteLine("=====================================================================");
                con.Close();

            }

            public static void insertRest(int Restid, string Restname, string OpeningTime, string ClosingTime, string PhoneNo, string RestAddress, string Cusisine, char RestStatus)
            {
                con.Open();
                string query = "SET IDENTITY_INSERT Restaurant1 ON insert into Restaurant1 values (" + Restid + ",'" + Restname + "','" + OpeningTime + "','" + ClosingTime + "','" + PhoneNo + "','" + RestAddress + "','" + Cusisine + "','" + RestStatus + "')";

                cmd = new SqlCommand(query, con);

                try
                {

                    cmd.ExecuteNonQuery();

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string msg = "Insert Error";
                    msg += ex.Message;

                }
                finally
                {
                    Console.WriteLine("Your Restaurant is add Successfully");
                    con.Close();
                }


            }

            public static void UpdateName(string Restname, int Restid)
            {
                con.Open();
                string query = "Update Restaurant1 set  RestName ='" + Restname + "'where Restid = " + Restid + "";
                cmd = new SqlCommand(query, con);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string msg = "Update Error";
                    msg += ex.Message;
                }
                finally
                {
                    Console.WriteLine("Your Restaurant updated Successfully");
                    con.Close();
                }
            }
            public static void UpdateStatus(char Reststatus, string Restname)
            {
                con.Open();
                string query = "Update Restaurant1 set  Reststatus ='" + Reststatus + "'where Restname = " + Restname + "";
                cmd = new SqlCommand(query, con);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string msg = "Update Error";
                    msg += ex.Message;
                }
                finally
                {
                    Console.WriteLine("Your Restaurant updated Successfully");
                    con.Close();
                }
                // con.Open();
                // string query = "Update Restaurant1 set Reststatus=@S where Restname=@Rn";
                // cmd = new SqlCommand(query, con);
                // cmd.Parameters.Add(new SqlParameter("S", Reststatus));
                // cmd.Parameters.Add(new SqlParameter("Rn", Restname));

                //     Console.WriteLine("Your Restaurant updated Successfully");
                //     con.Close();

            }

            public static void DeleteRest(string Restname)
            {
                con.Open();
                string query = "delete from Restaurant1 where RestName=" + Restname + "";
                cmd = new SqlCommand(query, con);
                // cmd.ExecuteNonQuery();

                try
                {

                    cmd.ExecuteNonQuery();

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string msg = "Delete Error";
                    msg += ex.Message;

                }
                finally
                {
                    Console.WriteLine("Your Restaurant Deleted Successfully");
                    con.Close();
                }

            }
        }
    }

}

