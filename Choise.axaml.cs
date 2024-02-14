using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using avrora.Tables;

namespace avrora;

public partial class Choise : Window
{
    public Choise()
    {
        InitializeComponent();
    }

    private void Exit_OnClick(object? sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }
   
  

    private void Orders(object? sender, RoutedEventArgs e)
    {
        OrderWin ord = new OrderWin();
        this.Close();
        ord.Show();
    }

  

    private void Goods(object? sender, RoutedEventArgs e)
    {
        GoodsWin gds = new GoodsWin();
        this.Close();
        gds.Show();
    }

    private void Cust_OnClick(object? sender, RoutedEventArgs e)
    {
        Customers cst = new Customers();
        this.Close();
        cst.Show();
    }
}