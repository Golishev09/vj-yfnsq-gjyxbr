using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace avrora;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
   // string connectionString = "server=10.10.1.24;database=abd8;port=3306;User Id=user_01;password=user01pro";
    
    public void Authorization(object? sender, RoutedEventArgs e)
    {
       
            Choise choise = new Choise();
            Hide();
            choise.Show();
       
    }
    
    
    public void Exit_PR(object? sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    
}