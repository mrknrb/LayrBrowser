using Microsoft.Web.WebView2.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

public  class TabGridMrk
{
   public Grid grid;
   public Grid grid2;
	      public TabGridMrk( )
        {
        var grid = new Grid();
        var grid2 = new Grid();
        Grid.SetRow(grid,0);
        Grid.SetColumn(grid,1);
        Grid.SetRow(grid2, 0);
        Grid.SetColumn(grid2, 1);
        for (int i = 0; i <20; i++)
        {
            
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions[i].Height = new GridLength(1, GridUnitType.Star);

            grid2.RowDefinitions.Add(new RowDefinition());
            grid2.RowDefinitions[i].Height = new GridLength(1, GridUnitType.Star);
        }
        for (int i = 0; i < 36; i++)
        {

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions[i].Width = new GridLength(1, GridUnitType.Star);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions[i].Width = new GridLength(1, GridUnitType.Star);

        }
        //grid cellák beillesztése
        for (int i = 0; i < 20; i++)
        {

            for (int e = 0; e < 36; e++)
            {
                var r = new Rectangle();
                r.Fill = Brushes.Black;
                r.Opacity = 0.1;
                Grid.SetRow( r,i);
                Grid.SetColumn(r,e);

                r.MouseEnter += new MouseEventHandler(gridEdit_MouseEnter);
                r.MouseLeave += new MouseEventHandler(gridEdit_MouseLeave);
                grid.Children.Add(r);

            }
        }
       
        grid.Background = Brushes.Transparent;
        grid2.ShowGridLines = true;
        grid2.Background = Brushes.Transparent;
        this.grid = grid;
        this.grid2 = grid2;

    }

  

        private static void gridEdit_MouseLeave(object sender, MouseEventArgs e)
            {
        var r = (Rectangle)sender;
        Console.WriteLine("leave"+ Grid.GetRow(r)+ Grid.GetColumn(r));
    }

            private static void gridEdit_MouseEnter(object sender, MouseEventArgs e)
            {
        var r = (Rectangle)sender;
        Console.WriteLine("enter" + Grid.GetRow(r) + Grid.GetColumn(r));
    }
 

}
