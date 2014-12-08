﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace SLS.Desktop.Converters
{
    /// <summary>Represents a chain of <see cref="IValueConverter"/>s to be executed in succession.</summary>
    /// <see cref="http://stackoverflow.com/a/8392590/1936631"/>
    [ContentProperty("Converters")]
    [ContentWrapper(typeof(ValueConverterCollection))]
    public class ChainConverter : IValueConverter
    {
        ValueConverterCollection _converters;
        /// <summary>Gets the converters to execute.</summary>
        public ValueConverterCollection Converters
        {
            get { return _converters ?? (_converters = new ValueConverterCollection()); }
        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var valueConverter in Converters)
            {
                value = valueConverter.Convert(value, targetType, parameter, culture);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>Represents a collection of <see cref="IValueConverter"/>s.</summary>
    public sealed class ValueConverterCollection : Collection<IValueConverter> { }
}
