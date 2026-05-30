using System;

using System.Data.SqlClient;

class Program

{

    static string conStr = "Server=ICS-LT-81RSBN3\\SQLEXPRESS01;Database=TrainDB;Trusted_Connection=True;";

    static void Main()

    {

        while (true)

        {

            Console.WriteLine("\n1.Admin\n2.Public\n3.Exit");

            int role = int.Parse(Console.ReadLine());

            if (role == 1) AdminLogin();

            else if (role == 2) PublicAuth();

            else break;

        }

    }

    //Admin

    static void AdminLogin()

    {

        Console.Write("Username: ");

        string u = Console.ReadLine();

        Console.Write("Password: ");

        string p = Console.ReadLine();

        if (u == "admin" && p == "1234")

            AdminMenu();

        else

            Console.WriteLine("Invalid Admin");

    }

    // Public

    static void PublicAuth()

    {

        Console.WriteLine("1.Login\n2.Register");

        int ch = int.Parse(Console.ReadLine());

        if (ch == 1) PublicLogin();

        else RegisterUser();

    }

    static void RegisterUser()

    {

        SqlConnection con = new SqlConnection(conStr);

        Console.Write("Username: ");

        string u = Console.ReadLine();

        Console.Write("Password: ");

        string p = Console.ReadLine();

        con.Open();

        SqlCommand cmd = new SqlCommand("INSERT INTO Users VALUES(@u,@p)", con);

        cmd.Parameters.AddWithValue("@u", u);

        cmd.Parameters.AddWithValue("@p", p);

        cmd.ExecuteNonQuery();

        con.Close();

        Console.WriteLine("Registered");

    }

    static void PublicLogin()

    {

        SqlConnection con = new SqlConnection(conStr);

        Console.Write("Username: ");

        string u = Console.ReadLine();

        Console.Write("Password: ");

        string p = Console.ReadLine();

        con.Open();

        SqlCommand cmd = new SqlCommand(

        "SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p", con);

        cmd.Parameters.AddWithValue("@u", u);

        cmd.Parameters.AddWithValue("@p", p);

        int count = (int)cmd.ExecuteScalar();

        con.Close();

        if (count > 0) PublicMenu();

        else Console.WriteLine("Invalid Login");

    }

    // Admin Menu

    static void AdminMenu()

    {

        while (true)

        {

            Console.WriteLine("\n1.Add Train\n2.Delete Train\n3.Cancel Train\n4.View All Trains\n5.Back");

            int ch = int.Parse(Console.ReadLine());

            if (ch == 1) AddTrain();

            else if (ch == 2) DeleteTrain();

            else if (ch == 3) CancelTrain();

            else if (ch == 4) ShowAllTrains();

            else break;

        }

    }

    // Public Menu

    static void PublicMenu()

    {

        while (true)

        {

            Console.WriteLine("\n1.View Trains\n2.Book Ticket\n3.Cancel Ticket\n4.Back");

            int ch = int.Parse(Console.ReadLine());

            if (ch == 1) ShowTrains();

            else if (ch == 2) BookTicket();

            else if (ch == 3) CancelTicket();

            else break;

        }

    }

    static void AddTrain()

    {

        SqlConnection con = new SqlConnection(conStr);

        Console.Write("TrainNo: ");

        int no = int.Parse(Console.ReadLine());

        Console.Write("Name: ");

        string name = Console.ReadLine();

        Console.Write("From: ");

        string from = Console.ReadLine();

        Console.Write("To: ");

        string to = Console.ReadLine();


        Console.Write("Train Time (HH:mm): ");

        TimeSpan time = TimeSpan.Parse(Console.ReadLine());

        Console.Write("Sleeper Seats: ");

        int s = int.Parse(Console.ReadLine());

        Console.Write("2AC Seats: ");

        int a2 = int.Parse(Console.ReadLine());

        Console.Write("3AC Seats: ");

        int a3 = int.Parse(Console.ReadLine());

        Console.Write("Sleeper Charge: ");

        decimal sc = decimal.Parse(Console.ReadLine());

        Console.Write("2AC Charge: ");

        decimal ac2 = decimal.Parse(Console.ReadLine());

        Console.Write("3AC Charge: ");

        decimal ac3 = decimal.Parse(Console.ReadLine());

        SqlCommand cmd = new SqlCommand(

@"INSERT INTO TrainDetails 

(TrainNo, Name, FromStation, ToStation, TrainTime, SleeperAvail, AC2Avail, AC3Avail, SleeperCharge, AC2Charge, AC3Charge, IsDeleted)

VALUES 

(@no, @name, @from, @to, @time, @s, @a2, @a3, @sc, @ac2, @ac3, 0)", con);

        cmd.Parameters.AddWithValue("@no", no);

        cmd.Parameters.AddWithValue("@name", name);

        cmd.Parameters.AddWithValue("@from", from);

        cmd.Parameters.AddWithValue("@to", to);

        cmd.Parameters.AddWithValue("@time", time);

        cmd.Parameters.AddWithValue("@s", s);

        cmd.Parameters.AddWithValue("@a2", a2);

        cmd.Parameters.AddWithValue("@a3", a3);

        cmd.Parameters.AddWithValue("@sc", sc);

        cmd.Parameters.AddWithValue("@ac2", ac2);

        cmd.Parameters.AddWithValue("@ac3", ac3);

        con.Open();

        cmd.ExecuteNonQuery();

        con.Close();

        Console.WriteLine("Train Added");

    }

    static void ShowTrains()

    {

        SqlConnection con = new SqlConnection(conStr);

        Console.Write("Source: ");

        string from = Console.ReadLine();

        Console.Write("Destination: ");

        string to = Console.ReadLine();

        Console.Write("Travel Date: ");

        DateTime tdate = DateTime.Parse(Console.ReadLine());

        con.Open();

        SqlCommand cmd = new SqlCommand(

        "SELECT TrainNo,Name,FromStation,ToStation,TrainTime FROM TrainDetails WHERE FromStation=@f AND ToStation=@t AND IsDeleted=0", con);

        cmd.Parameters.AddWithValue("@f", from);

        cmd.Parameters.AddWithValue("@t", to);

        var dr = cmd.ExecuteReader();

        while (dr.Read())

        {

            Console.WriteLine($"{dr["TrainNo"]} | {dr["Name"]} | {dr["FromStation"]} -> {dr["ToStation"]} | Time: {dr["TrainTime"]}");

        }

        con.Close();

    }

    static void BookTicket()

    {

        SqlConnection con = new SqlConnection(conStr);

        Console.Write("TrainNo: ");

        int no = int.Parse(Console.ReadLine());

        Console.Write("Travel Date: ");

        DateTime tdate = DateTime.Parse(Console.ReadLine());

        con.Open();

        SqlCommand cmd = new SqlCommand(

        "SELECT * FROM TrainDetails WHERE TrainNo=@no AND IsDeleted=0", con);

        cmd.Parameters.AddWithValue("@no", no);

        var dr = cmd.ExecuteReader();

        if (dr.Read())

        {

            Console.WriteLine("\nClass Details:");

            Console.WriteLine($"1.Sleeper Seats:{dr["SleeperAvail"]} Price:{dr["SleeperCharge"]}");

            Console.WriteLine($"2.2AC Seats:{dr["AC2Avail"]} Price:{dr["AC2Charge"]}");

            Console.WriteLine($"3.3AC Seats:{dr["AC3Avail"]} Price:{dr["AC3Charge"]}");

            Console.Write("Choose Class: ");

            int cls = int.Parse(Console.ReadLine());

            Console.Write("Passengers(max 3): ");

            int p = int.Parse(Console.ReadLine());

            int avail = 0;

            decimal charge = 0;

            string cname = "";

            if (cls == 1)

            {

                avail = (int)dr["SleeperAvail"];

                charge = (decimal)dr["SleeperCharge"];

                cname = "Sleeper";

            }

            else if (cls == 2)

            {

                avail = (int)dr["AC2Avail"];

                charge = (decimal)dr["AC2Charge"];

                cname = "2AC";

            }

            else

            {

                avail = (int)dr["AC3Avail"];

                charge = (decimal)dr["AC3Charge"];

                cname = "3AC";

            }

            dr.Close();

            if (avail >= p)

            {

                decimal amt = p * charge;

                SqlCommand ins = new SqlCommand(

                "INSERT INTO BookingDetails(BookDate,TravelDate,TrainNo,TravelClass,Passengers,Amount) VALUES(GETDATE(),@tdate,@no,@cls,@p,@amt)", con);

                ins.Parameters.AddWithValue("@tdate", tdate);

                ins.Parameters.AddWithValue("@no", no);

                ins.Parameters.AddWithValue("@cls", cname);

                ins.Parameters.AddWithValue("@p", p);

                ins.Parameters.AddWithValue("@amt", amt);

                ins.ExecuteNonQuery();

                string update = cls == 1 ?

                "UPDATE TrainDetails SET SleeperAvail=SleeperAvail-@p WHERE TrainNo=@no"

                : cls == 2 ?

                "UPDATE TrainDetails SET AC2Avail=AC2Avail-@p WHERE TrainNo=@no"

                :

                "UPDATE TrainDetails SET AC3Avail=AC3Avail-@p WHERE TrainNo=@no";

                SqlCommand upd = new SqlCommand(update, con);

                upd.Parameters.AddWithValue("@p", p);

                upd.Parameters.AddWithValue("@no", no);

                upd.ExecuteNonQuery();

                Console.WriteLine("Booking Successful");

            }

        }

        con.Close();

    }

    static void CancelTicket()

    {

        SqlConnection con = new SqlConnection(conStr);

        Console.Write("BookingId: ");

        int id = int.Parse(Console.ReadLine());

        con.Open();

        int tno = 0;

        int passengers = 0;

        string cls = "";

        DateTime travelDate = DateTime.Now;

        decimal totalAmount = 0;

        SqlCommand cmd = new SqlCommand(

        "SELECT TrainNo,Passengers,TravelClass,TravelDate,Amount FROM BookingDetails WHERE BookingId=@id", con);

        cmd.Parameters.AddWithValue("@id", id);

        var dr = cmd.ExecuteReader();

        if (dr.Read())

        {

            tno = (int)dr["TrainNo"];

            passengers = (int)dr["Passengers"];

            cls = dr["TravelClass"].ToString();

            travelDate = Convert.ToDateTime(dr["TravelDate"]);

            totalAmount = (decimal)dr["Amount"];

        }

        else

        {

            Console.WriteLine("Invalid BookingId");

            con.Close();

            return;

        }

        dr.Close();

        int days = (travelDate.Date - DateTime.Today).Days;

        decimal perTicket = totalAmount / passengers;

        decimal refund = 0;

        if (days >= 3) refund = perTicket;

        else if (days >= 1) refund = perTicket * 0.5m;

        SqlCommand ins = new SqlCommand(

        "INSERT INTO Cancellation(BookingId,NoTickets,RefundAmt) VALUES(@id,1,@ref)", con);

        ins.Parameters.AddWithValue("@id", id);

        ins.Parameters.AddWithValue("@ref", refund);

        ins.ExecuteNonQuery();

        string updateAvail = cls == "Sleeper" ?

        "UPDATE TrainDetails SET SleeperAvail = SleeperAvail + 1 WHERE TrainNo=@no"

        : cls == "2AC" ?

        "UPDATE TrainDetails SET AC2Avail = AC2Avail + 1 WHERE TrainNo=@no"

        :

        "UPDATE TrainDetails SET AC3Avail = AC3Avail + 1 WHERE TrainNo=@no";

        SqlCommand upd = new SqlCommand(updateAvail, con);

        upd.Parameters.AddWithValue("@no", tno);

        upd.ExecuteNonQuery();

        SqlCommand reduce = new SqlCommand(

        "UPDATE BookingDetails SET Passengers = Passengers - 1 WHERE BookingId=@id", con);

        reduce.Parameters.AddWithValue("@id", id);

        reduce.ExecuteNonQuery();

        Console.WriteLine("1 Ticket Cancelled");

        Console.WriteLine("Refund = " + refund);

        con.Close();

    }


    static void ShowAllTrains()

    {

        SqlConnection con = new SqlConnection(conStr);

        con.Open();

        var dr = new SqlCommand(

        "SELECT TrainNo,Name,FromStation,ToStation,TrainTime FROM TrainDetails WHERE IsDeleted=0", con)

        .ExecuteReader();

        while (dr.Read())

        {

            Console.WriteLine($"{dr["TrainNo"]} | {dr["Name"]} | {dr["FromStation"]} -> {dr["ToStation"]} | Time: {dr["TrainTime"]}");

        }

        con.Close();

    }

    static void DeleteTrain()

    {

        SqlConnection con = new SqlConnection(conStr);

        Console.Write("TrainNo: ");

        int no = int.Parse(Console.ReadLine());

        con.Open();

        int count = (int)new SqlCommand(

        "SELECT COUNT(*) FROM BookingDetails WHERE TrainNo=@no", con)

        { Parameters = { new SqlParameter("@no", no) } }.ExecuteScalar();

        if (count > 0)

            Console.WriteLine("Cannot delete");

        else

        {

            new SqlCommand(

            "UPDATE TrainDetails SET IsDeleted=1 WHERE TrainNo=@no", con)

            { Parameters = { new SqlParameter("@no", no) } }.ExecuteNonQuery();

            Console.WriteLine("Deleted");

        }

        con.Close();

    }
    static void CancelTrain()

    {

        SqlConnection con = new SqlConnection(conStr);

        Console.Write("TrainNo: ");

        int no = int.Parse(Console.ReadLine());

        con.Open();

        new SqlCommand(

        "UPDATE TrainDetails SET SleeperAvail=0,AC2Avail=0,AC3Avail=0 WHERE TrainNo=@no", con)

        { Parameters = { new SqlParameter("@no", no) } }.ExecuteNonQuery();

        Console.WriteLine("Train Cancelled");

        con.Close();

    }

}
