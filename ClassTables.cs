using System;
using System.Runtime.InteropServices.JavaScript;

namespace avrora;



public class cust
{
    public int Customer_id { get; set; }
    public string Customer_name { get; set; }
    public string Contact_number { get; set; }
    public string Email { get; set; }

}

public class Tovar
{
    public int TovarID { get; set; }
    public string Name { get; set; }
    public int Tip_izmerenia { get; set; }
    public int Price { get; set; }
}

public class Book
{
    public int book_id { get; set; }
    public int Avtor_ids { get; set; }
    public string Name { get; set; }
    public DateTime Create_date { get; set; }
    public string avtor_name { get; set; }
}

public class Avtor
{
    public int avtor_id { get; set; }
    public string avtor_name { get; set; }
}

public class Extradion
{
    public int Extradion_id { get; set; }
    public int Book_ids { get; set; }
    public int Customer_ids { get; set; }
    public DateTime Date_extradion { get; set; }
    public string book_name { get; set; }
    public string customer_name { get; set; }
    
}



