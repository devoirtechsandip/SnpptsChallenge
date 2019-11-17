using System;
using System.Globalization;
using Xamarin.Forms;

namespace learn.Converters
{
	public class ItemSelectedEventArgsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var itemTappedEventArgs = value as SelectedItemChangedEventArgs;
			if (itemTappedEventArgs == null)
			{
				throw new ArgumentException("Expected value to be of type ItemTappedEventArgs", nameof(value));
			}
			return itemTappedEventArgs.SelectedItem;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		=> null;
	}
}
