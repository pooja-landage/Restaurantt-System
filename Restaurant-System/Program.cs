using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantLogic;

namespace Reastaurant_System
{
    class Program
    {
        static SqlDataReader dr;
        static void Main(string[] args)
        {
                            char reply = 'y';

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("========================================================================================================================");
            Restaurant.CreateConnection();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t *********************************LOGIN FORM *************************** ");
            Console.Write("\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t\t\t\t      Enter UserName: ");
            string username = Console.ReadLine();
            Console.Write("\t\t\t\t      Enter Password:");
            string pass = Console.ReadLine();
            
            Console.ForegroundColor = ConsoleColor.White;
            if (Restaurant.Validation(username, pass) == true)
            {
                string constr = "Data source=DESKTOP-FLCVG6T;initial catalog=Restaurant;user=sa;password=Pooja@2708";
                SqlConnection con = new SqlConnection();
                con.ConnectionString = constr;

                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();

                con.Open();
                string query = "select Restname from Restaurant1 where RestStatus = 'y'";
                SqlCommand cmd = new SqlCommand(query, con);


                cmd = new SqlCommand(query, con);
                dr = cmd.ExecuteReader();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t ******************LIST OF ACTIVE RESTAURANT ******************** ");
                Console.ForegroundColor = ConsoleColor.Green;
                while (dr.Read())
                {
                    Console.Write("\t\t\t \n{0}\n ", dr[0]);
                }
                con.Close();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                Console.ForegroundColor = ConsoleColor.White;

                
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t\t=============================MAIN MENU===============================");
                    Console.WriteLine();
                    Console.WriteLine("\t\t\t\t\t\t1.SEARCH RESTAURANT");
                    Console.WriteLine("\t\t\t\t\t\t2.INSERT RESTAURANT");
                    Console.WriteLine("\t\t\t\t\t\t3.UPDATING RESTAURANT");
                    Console.WriteLine("\t\t\t\t\t\t4.DELETING RESTAURANT");


                    Console.WriteLine();
                    Console.Write("\t\t\t\t\t\t ENTER YOUR CHOICE:");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    int Restid;
                    string Restname;
                    string OpeningTime;
                    string ClosingTime;
                    string PhoneNo;
                    string RestAddress;
                    string Cusisine;
                    char RestStatus;

                    switch (choice)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("\t\t ENTER RESTAURANT NAME==\t\t");
                            Console.ForegroundColor = ConsoleColor.White;
                            Restname = Console.ReadLine();
                            Restaurant.Search(Restname);

                            break;
                        case 2:
                            Console.WriteLine("Enter the id Restaurant");
                            Restid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the name of Restaurant");
                            Restname = Console.ReadLine();
                            Console.WriteLine("Enter the Opening of Restaurant");
                            OpeningTime = Console.ReadLine();
                            Console.WriteLine("Enter the Closing of Restaurant");
                            ClosingTime = Console.ReadLine();
                            Console.WriteLine("Enter the Phoneno of Restaurant");
                            PhoneNo = Console.ReadLine();
                            Console.WriteLine("Enter the RestAdddress of Restaurant");
                            RestAddress = Console.ReadLine();
                            Console.WriteLine("Enter the Cusisine Restaurant");
                            Cusisine = Console.ReadLine();
                            Console.WriteLine("Enter the status of Restaurant");
                            RestStatus = Convert.ToChar(Console.ReadLine());
                            Restaurant.insertRest(Restid, Restname, OpeningTime, ClosingTime, PhoneNo, RestAddress, Cusisine, RestStatus);
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("\t\t\t\t*************************************************************************");
                            Console.WriteLine("\t\t\t\t\t\ta.Update  Name of Restaurant");
                            Console.WriteLine("\t\t\t\t\t\tb.Update Status of Restauran ");

                            Console.WriteLine();
                            Console.WriteLine("\t\t\t\t*************************************************************************");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.Write("\t\t\t\tEnter your choice=");
                            char c = Convert.ToChar(Console.ReadLine());
                            switch (c)
                            {
                                case 'a':
                                    Console.WriteLine("Enter the new name of Restaurant");
                                    Restname = Console.ReadLine();
                                    Console.WriteLine("Enter the id Restaurant");
                                    Restid = Convert.ToInt32(Console.ReadLine());
                                    Restaurant.UpdateName(Restname, Restid);

                                    break;

                                case 'b':


                                    Console.WriteLine("Enter the new name of Restaurant");
                                    Restname = Console.ReadLine();
                                    Console.WriteLine("Enter the New Status of Restaurant");
                                    RestStatus = Convert.ToChar(Console.ReadLine());
                                    Restaurant.UpdateName(  Restname, RestStatus);
                                    break;


                                default:
                                    Console.WriteLine("Invalid Choice");
                                    break;

                            }
                            break;

                        case 4:
                            Console.WriteLine("Enter the name of Restaurant");
                            Restname = Console.ReadLine();
                            Restaurant.DeleteRest(Restname);
                            

                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                           


                    }
                    


                }
                
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t        Login Failed!!!!!!");

            }

            Console.ReadLine();

        }
    }
}
