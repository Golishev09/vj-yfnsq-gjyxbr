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

public partial class Customers : Window
{
    public Customers()
    {
        InitializeComponent();
        string fullTable = "SELECT * FROM Customers ";
        ShowTable(fullTable);
    }
    
    private List<cust> customers;
    string connStr = "server=10.10.1.24;database=abd8;port=3306;User Id=user_01;password=user01pro";
    private MySqlConnection conn;

    public void ShowTable(string sql)
    {
        customers = new List<cust>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var Customers = new cust()
            {
                Customer_id  = reader.GetInt32("Custmer_id"),
                Customer_name = reader.GetString("Customer_name"),
                Contact_number = reader.GetString("contact_number"),
                Email = reader.GetString("Email")
            };
            customers.Add(Customers);
        }
        conn.Close();
        DataGrid.ItemsSource = customers;
    }
    
    private void SearchCustomers(object? sender, TextChangedEventArgs e)
    {
        var cst = customers;
        cst = cst.Where(x => x.Customer_name.Contains(Search_Customers.Text)).ToList();
        DataGrid.ItemsSource = cst;
    }
    
    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        Choise back = new Choise();
        Close();
        back.Show(); 
    }

    private void Reset_OnClick(object? sender, RoutedEventArgs e)
    {
        string fullTable = "SELECT * from Customers";
        ShowTable(fullTable);
        Search_Customers.Text = string.Empty;
    }

    private void Del(object? sender, RoutedEventArgs e)
    {
        try
        {
            cust usr = DataGrid.SelectedItem as cust;
            if (usr == null)
            {
                return;
            }
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM Customers WHERE Custmer_id = " + usr.Customer_id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            customers.Remove(usr);
            ShowTable("SELECT * From Customers");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private void AddData(object? sender, RoutedEventArgs e)
    {/*
        Book newUser = new Book();
        CRUD.CRUD_Goods add = new CRUD.CRUD_Goods(newUser, goods);
        add.Show();
        this.Close();*/
    }

    private void Edit(object? sender, RoutedEventArgs e)
    {/*
        Book currenGoods = DataGrid.SelectedItem as Book;
        if (currenGoods == null)
            return;
        CRUD.CRUD_Goods edit = new  CRUD.CRUD_Goods(currenGoods, goods);
        edit.Show();
        this.Close();*/
    }
}