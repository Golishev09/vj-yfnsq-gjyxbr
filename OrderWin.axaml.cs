using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows;

namespace avrora.Tables;

public partial class OrderWin : Window
{
    public OrderWin()
    {
        InitializeComponent();
        ShowTable(fullTable);
       
    }
    string fullTable = "Select Extradion_id,Book.Name,Customers.Customer_name,Date_Extradion from Extradion join Book on Extradion.Book_ids= Book.book_id join Customers on Extradion.Customer_ids = Customers.Custmer_id";

    private List<Extradion> orders;

    string connStr = "server=10.10.1.24;database=abd8;port=3306;User Id=user_01;password=user01pro";
    private MySqlConnection conn;

    public void ShowTable(string sql)
    {
        orders = new List<Extradion>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var Client = new Extradion()
            {
                Extradion_id = reader.GetInt32("Extradion_id"),
                book_name = reader.GetString("Name"),
                customer_name = reader.GetString("Customer_name"),
                Date_extradion = reader.GetDateTime("Date_Extradion")
            };
            orders.Add(Client);
        }
        conn.Close();
        DataGrid.ItemsSource = orders;
    }
    
    private void SearchGoods(object? sender, TextChangedEventArgs e)
    {
        var gds = orders;
        gds = gds.Where(x => x.customer_name.Contains(Search_Goods.Text)).ToList();
        DataGrid.ItemsSource = gds;
    }
    
    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        Choise back = new Choise();
        Close();
        back.Show(); 
    }

    private void Reset_OnClick(object? sender, RoutedEventArgs e)
    {
        ShowTable(fullTable);
        Search_Goods.Text = string.Empty;
    }

    private void Del(object? sender, RoutedEventArgs e)
    {
        try
        {
            Extradion usr = DataGrid.SelectedItem as Extradion;
            if (usr == null)
            {
                return;
            }
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM Extradion WHERE ID = " + usr.Extradion_id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            orders.Remove(usr);
            ShowTable(fullTable);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private void AddData(object? sender, RoutedEventArgs e)
    {
        Extradion newOrder = new Extradion();
        CRUD.CRUD_OrderWin add = new CRUD.CRUD_OrderWin(newOrder, orders);
        add.Show();
        this.Close();
    }

    private void Edit(object? sender, RoutedEventArgs e)
    {
        Extradion currenOrder = DataGrid.SelectedItem as Extradion;
        if (currenOrder == null)
            return;
        CRUD.CRUD_OrderWin edit = new  CRUD.CRUD_OrderWin(currenOrder, orders);
        edit.Show();
        this.Close();
    }

  
    
   
}