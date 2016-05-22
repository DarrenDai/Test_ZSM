using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ZSM.CMS.Presentation.Behaviors
{
    public class ListViewSort
    {
        #region Dependency Properties

        public static readonly DependencyProperty SortEnabledProperty =
            DependencyProperty.RegisterAttached("SortEnabled", typeof(bool), typeof(ListViewSort),
            new PropertyMetadata(OnSortEnabledChanged));

        public static readonly DependencyProperty SortByProperty =
            DependencyProperty.RegisterAttached("SortBy", typeof(string), typeof(ListViewSort),
            new PropertyMetadata(OnSortByChanged));

        #endregion

        #region Dependency Property Wraper

        public static bool GetSortEnabled(ListView listView)
        {
            return (bool)listView.GetValue(SortEnabledProperty);
        }

        public static void SetSortEnabled(ListView listView, bool value)
        {
            listView.SetValue(SortEnabledProperty, value);
        }

        public static string GetSortBy(GridViewColumn column)
        {
            if (column != null)
                return (string)column.GetValue(SortByProperty);

            return null;
        }

        public static void SetSortBy(GridViewColumn column, string propName)
        {
            if (column != null)
                column.SetValue(SortByProperty, propName);
        }

        #endregion

        #region properties changed event handler

        static void OnSortEnabledChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {
            var listview = dobj as ListView;
            if (listview != null)
            {
                if ((bool)e.NewValue)
                    listview.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(OnGridViewColumnHeaderClicked));
                else
                    listview.RemoveHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(OnGridViewColumnHeaderClicked));
            }
        }

        static void OnSortByChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {
            var column = dobj as GridViewColumn;
            var propName = (string)e.NewValue;

            var sortData = GetSortData(column);
            if (sortData == null)
                SetSortData(column, sortData = new SortData(propName));

            if (column.CellTemplate == null
                &&
                column.CellTemplateSelector == null)
            {
                var binding = new Binding(sortData.PropertyName);
                column.DisplayMemberBinding = binding;
            }
        }

        #endregion

        #region UI事件和辅助函数

        //GridViewColumn click event handler
        static void OnGridViewColumnHeaderClicked(object sender, RoutedEventArgs e)
        {
            var header = e.OriginalSource as GridViewColumnHeader;
            var listview = sender as ListView;
            SortData sortData;

            if (listview != null
                && header != null
                && listview.ItemsSource != null
                && header.Column != null
                && (sortData = GetSortData(header.Column)) != null)
            {
                UpdateSortDescription(CollectionViewSource.GetDefaultView(listview.ItemsSource),
                    sortData);
            }
        }

        //update SortDescription type
        static void UpdateSortDescription(ICollectionView view, SortData sortData)
        {
            var listCollec = view as ListCollectionView;
            var srcType = view.SourceCollection.GetType();
            if (listCollec == null || (!srcType.IsGenericType && !srcType.IsArray))
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(sortData.PropertyName, sortData.Direction));
            }
            else
            {
                Type targetType;
                if (srcType.IsArray)
                    targetType = srcType.GetElementType();
                else
                {
                    //targetType = srcType.GetGenericArguments()[0];
                    //var temp = view.SourceCollection[0];

                    targetType = view.CurrentItem.GetType();

                    //foreach (var item in view.SourceCollection)
                    //{

                    //}
                }
                listCollec.CustomSort = new ListItemComparer(sortData, targetType);
            }

            sortData.Direction = GetReverseDirection(sortData.Direction);
        }

        static ListSortDirection GetReverseDirection(ListSortDirection direction)
        {
            if (direction == ListSortDirection.Ascending)
                return ListSortDirection.Descending;
            return ListSortDirection.Ascending;
        }

        #endregion

        #region SortData

        public static readonly DependencyProperty SortDataProperty =
            DependencyProperty.RegisterAttached("SortData", typeof(SortData), typeof(ListViewSort),
                new FrameworkPropertyMetadata((SortData)null));

        static SortData GetSortData(DependencyObject d)
        {
            if (d == null)
                return null;

            return (SortData)d.GetValue(SortDataProperty);
        }

        static void SetSortData(DependencyObject d, SortData value)
        {
            if (d == null)
                return;

            d.SetValue(SortDataProperty, value);
        }

        #endregion

    }

    public class SortData
    {
        const char REVERSE_CHAR = '#';

        public SortData(string raw)
        {
            Direction = ListSortDirection.Ascending;
            PropertyName = raw;

            if (raw.Length > 0 && raw[0] == REVERSE_CHAR)
            {
                Direction = ListSortDirection.Descending;
                PropertyName = raw.Substring(1);
            }
        }

        public string PropertyName { get; private set; }

        public ListSortDirection Direction { get; set; }
    }

    public class ListItemComparer : Comparer<object>
    {
        Func<object, object> del;

        public ListSortDirection Direction { get; set; }

        public ListItemComparer(SortData sortdata, Type targetType)
        {
            del = CompileInstanceProperty(targetType, sortdata.PropertyName);
            Direction = sortdata.Direction;
        }

        public override int Compare(object x, object y)
        {
            var res = Comparer<object>.Default.Compare(del(x), del(y));
            if (Direction == ListSortDirection.Ascending)
                return res;
            return res * -1;
        }

        Func<object, object> CompileInstanceProperty(Type targetType, string propName)
        {
            try
            {
                var propInfo = targetType.GetProperty(propName, BindingFlags.Instance | BindingFlags.Public);
                if (propInfo == null)
                {
                    ApplicationContext.Current.Logger.Warn(String.Format("Can't find property：{0} when building comparer.", propName));
                    return null;
                    //throw new ArgumentException(String.Format("Can't find property：{0}", propName));
                }

                var paExp = System.Linq.Expressions.Expression.Parameter(typeof(object), null);
                var convertedExp = System.Linq.Expressions.Expression.Convert(paExp, targetType);
                var propExp = System.Linq.Expressions.Expression.Property(convertedExp, propInfo);
                var retExp = System.Linq.Expressions.Expression.Convert(propExp, typeof(object));

                return System.Linq.Expressions.Expression.Lambda<Func<object, object>>(retExp, paExp).Compile();
            }
            catch (Exception ex)
            {
                ApplicationContext.Current.Logger.Error("Compare property failed.", ex);
                return null;
            }
        }
    }
}
