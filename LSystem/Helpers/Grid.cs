using System;
using System.Windows;
using System.Windows.Controls;
using OriginalGrid = System.Windows.Controls.Grid;

namespace LSystem.Helpers
{
    /* Example:
     * 
     * <Grid  Grid.Row="2" Grid.Column="1" 
     *        tk:Grid.RowDefinitions="Auto,*,Auto"
     *        tk:Grid.ColumnDefinitions="1*,2*,Auto">
     *     <Border Background="Red" tk:Grid.Cell="0,0" MinHeight="20" MinWidth="20"/>
     *     <Border Background="Blue" tk:Grid.Cell="1,1" MinHeight="20" MinWidth="20"/>
     *     <Border Background="Green" tk:Grid.Cell="2,2,2,1" MinHeight="20" MinWidth="20"/>
     * </Grid>
     * 
     */
    public class Grid
    {
        private static readonly GridLengthConverter s_GridLengthConverter = new GridLengthConverter();
        private static readonly char[] _separators = new[] { ',', ' ' };
        private const string _notSupportException = @"This AttachedProperty only supported of objects of type Grid";

        #region Columns
        public static string GetColumns(DependencyObject obj)
        {
            return (string)obj.GetValue(ColumnsProperty);
        }
        public static void SetColumns(DependencyObject obj, string value)
        {
            obj.SetValue(ColumnsProperty, value);
        }
        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.RegisterAttached("Columns", typeof(string), typeof(Grid), new PropertyMetadata(null, OnColumnDefinitionsChanged));

        private static void OnColumnDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is OriginalGrid grid)
            {
                var newValue = (string)e.NewValue;
                if (newValue == null) return;
                grid.ColumnDefinitions.Clear();
                var values = newValue.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var i in values)
                {
                    string value = i.Equals("A", StringComparison.OrdinalIgnoreCase) ? "Auto" : i;
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = (GridLength)s_GridLengthConverter.ConvertFromString(value) });
                }
            }
            else
            {
                throw new NotSupportedException(_notSupportException);
            }
        }
        #endregion

        #region Rows
        public static string GetRows(DependencyObject obj)
        {
            return (string)obj.GetValue(RowsProperty);
        }
        public static void SetRows(DependencyObject obj, string value)
        {
            obj.SetValue(RowsProperty, value);
        }
        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.RegisterAttached("Rows", typeof(string), typeof(Grid), new PropertyMetadata(null, OnRowDefinitionsChanged));

        private static void OnRowDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is OriginalGrid grid)
            {

                var newValue = (string)e.NewValue;
                if (newValue == null) return;
                grid.RowDefinitions.Clear();
                var values = newValue.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var i in values)
                {
                    string value = i.Equals("A", StringComparison.OrdinalIgnoreCase) ? "Auto" : i;
                    grid.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = (GridLength)s_GridLengthConverter.ConvertFromString(value)
                    });
                }
            }
            else
            {
                throw new NotSupportedException(_notSupportException);
            }
        }
        #endregion

        #region Cell
        public static string GetCell(DependencyObject obj)
        {
            return (string)obj.GetValue(CellProperty);
        }

        public static void SetCell(DependencyObject obj, string value)
        {
            obj.SetValue(CellProperty, value);
        }

        public static readonly DependencyProperty CellProperty =
            DependencyProperty.RegisterAttached("Cell", typeof(string), typeof(Grid), new PropertyMetadata(null, OnCellChanged));

        private static void OnCellChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null) return;
            if (e.NewValue is string str)
            {
                var tmpArr = str.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
                if (d is FrameworkElement fe)
                {
                    if (tmpArr.Length == 2)
                    {
                        if (int.TryParse(tmpArr[0], out var x) && int.TryParse(tmpArr[1], out var y))
                        {
                            OriginalGrid.SetColumn(fe, x);
                            OriginalGrid.SetRow(fe, y);
                        }
                        else
                        {
                            throw new ArgumentException("Can't parse values");
                        }

                    }
                    else if (tmpArr.Length == 4)
                    {
                        if (int.TryParse(tmpArr[0], out var column)
                            && int.TryParse(tmpArr[1], out var row)
                            && int.TryParse(tmpArr[2], out var columnSpan)
                            && int.TryParse(tmpArr[3], out var rowSpan))
                        {
                            OriginalGrid.SetColumn(fe, column);
                            OriginalGrid.SetRow(fe, row);
                            OriginalGrid.SetColumnSpan(fe, columnSpan);
                            OriginalGrid.SetRowSpan(fe, rowSpan);
                        }
                        else
                        {
                            throw new ArgumentException("Can't parse values");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Incorrect argument count for Cell value");
                    }
                }
            }
        }
        #endregion
    }
}