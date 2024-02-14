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

public partial class GoodsWin : Window
{
    public GoodsWin()
    {
        InitializeComponent();
        string fullTable = "SELECT * FROM Tovar";
        ShowTable(fullTable);
    }
    
    private List<Tovar> goods;
    string connStr = "server=127.0.0.1;database=avrora;port=3306;User Id=admn_us;password=Hazerd1234";
    private MySqlConnection conn;

    public void ShowTable(string sql)
    {
        goods = new List<Tovar>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var Client = new Tovar()
            {
                TovarID  = reader.GetInt32("TovarID"),
                Name = reader.GetString("Name"),
                Tip_izmerenia = reader.GetInt32("Tip_Izmereniaids"),
                Price = reader.GetInt32("Price")
            };
            goods.Add(Client);
        }
        conn.Close();
        DataGrid.ItemsSource = goods;
    }
    
    private void SearchGoods(object? sender, TextChangedEventArgs e)
    {
        var gds = goods;
        gds = gds.Where(x => x.Name.Contains(Search_Goods.Text)).ToList();
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
        string fullTable = "SELECT * FROM Tovar";
        ShowTable(fullTable);
        Search_Goods.Text = string.Empty;
    }

    private void Del(object? sender, RoutedEventArgs e)
    {
        try
        {
            Tovar usr = DataGrid.SelectedItem as Tovar;
            if (usr == null)
            {
                return;
            }
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM Tovar WHERE TovarID = " + usr.TovarID;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            goods.Remove(usr);
            ShowTable("SELECT * FROM Tovar ");
        }//SELECT TovarID,Tovar.Name,Tip_Izmerenia.Name,Price FROM Tovar JOIN Tip_Izmerenia ON Tovar.Tip_Izmereniaids = Tip_Izmerenia.Tip_izmereniaID
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private void AddData(object? sender, RoutedEventArgs e)
    {
        
        CRUD.CRUD_Goods add = new CRUD.CRUD_Goods();
        add.Show();
        this.Close();
    }

    private void Edit(object? sender, RoutedEventArgs e)
    {
        /*Book currenGoods = DataGrid.SelectedItem as Book;
        if (currenGoods == null)
            return;
        CRUD.CRUD_Goods edit = new  CRUD.CRUD_Goods(currenGoods, goods);
        edit.Show();
        this.Close();*/
    }
}