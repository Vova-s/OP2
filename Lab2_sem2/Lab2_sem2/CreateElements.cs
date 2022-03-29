using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Lab2_sem2
{
    class CreateElements
    {
        public static TextBox CreateTextBox(Grid grid, string name , HorizontalAlignment HA, VerticalAlignment VA, int margin1, int margin2, int width, int height, string text, Brush newcolor, Brush newcolor2) 
        {
            TextBox TextBox = new TextBox();
            TextBox.Name = name;
            TextBox.HorizontalAlignment = HA;
            TextBox.VerticalAlignment = VA;
            TextBox.Margin = new Thickness(margin1, margin2, 0, 0);
            TextBox.Width = width;
            TextBox.Height = height;
            TextBox.TextWrapping = TextWrapping.Wrap;
            TextBox.Text = text;
            TextBox.Background = newcolor;
            TextBox.BorderBrush = newcolor2;
            grid.Children.Add(TextBox);
            return TextBox;
        }

        public static Button CreateButton(Grid grid, string name, string content, HorizontalAlignment HA, VerticalAlignment VA, int margin1, int margin2, int width, int height, Brush newcolor, RoutedEventHandler handler)
        {
            Button button = new Button();
            button.Name = name;
            button.Content = content;
            button.HorizontalAlignment = HA;
            button.VerticalAlignment = VA;
            button.Margin = new Thickness(margin1, margin2, 0, 0);
            button.Width = width;
            button.Height = height;
            button.Background = newcolor;
            button.Click += handler;
            grid.Children.Add(button);
            return button;
        }
        public static Button CreateButton1(Grid grid, string name, string content, HorizontalAlignment HA, VerticalAlignment VA, int margin1, int margin2, int width, int height, FontWeight FW, int size, Brush newcolor,Brush newcolor1, RoutedEventHandler handler)
        {
            Button button = new Button();
            button.Name = name;
            button.Content = content;
            button.HorizontalAlignment = HA;
            button.VerticalAlignment = VA;
            button.Margin = new Thickness(margin1, margin2, 0, 0);
            button.Width = width;
            button.Height = height;
            button.Background = newcolor;
            button.FontWeight = FW;
            button.FontSize = size;
            button.Click += handler;
            button.BorderBrush = newcolor1;
            grid.Children.Add(button);
            return button;
        }

        public static Label CreateLabel(Grid grid, string content, HorizontalAlignment HA, VerticalAlignment VA, int margin1, int margin2, Brush newcolor,string fontfamily,FontWeight FW,int size)
        {
            Label label = new Label();
            label.Content = content;
            label.HorizontalAlignment = HA;
            label.VerticalAlignment = VA;
            label.Margin = new Thickness(margin1, margin2, 0, 0);
            label.Background = newcolor;
            label.FontFamily = new FontFamily(fontfamily);
            label.FontWeight = FW;
            label.FontSize = size;

            grid.Children.Add(label);
            return label;
        }
        public static ComboBox CreateComboBox(Grid grid, String name, String[] item_names, HorizontalAlignment h, VerticalAlignment v,int margin1, int margin2,int width,  int height,  SelectionChangedEventHandler handler)
        {
            ComboBox Combobox = new ComboBox();
            Combobox.Name = name;
            Combobox.HorizontalAlignment = h;
            Combobox.VerticalAlignment = v;
            Combobox.Margin = new Thickness(margin1, margin2, 0, 0);
            Combobox.Width = width;
            Combobox.Height = height;
            List<ListBoxItem> items = new List<ListBoxItem>();
            for (int i = 0; i < item_names.Length; i++)
            {
                ListBoxItem temp = new ListBoxItem();
                temp.Content = item_names[i];
                items.Add(temp);
            }
            Combobox.ItemsSource = items;
            Combobox.SelectionChanged += handler;
            grid.Children.Add(Combobox);
            return Combobox;
        }
    }
}
