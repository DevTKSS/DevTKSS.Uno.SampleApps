
namespace UnoHotDesignApp1.Helpers;
public partial class ConvertHelper //: DependencyObject, IValueConverter
{
    ///// <summary>
    ///// Identifies the <see cref="LeftValue"/> property.
    ///// </summary>
    //public static readonly DependencyProperty LeftValueProperty =
    //    DependencyProperty.Register(nameof(LeftValue), typeof(object), typeof(ConvertHelper), new PropertyMetadata(null));

    ///// <summary>
    ///// Identifies the <see cref="TopValue"/> property.
    ///// </summary>
    //public static readonly DependencyProperty TopValueProperty =
    //    DependencyProperty.Register(nameof(TopValue), typeof(object), typeof(ConvertHelper), new PropertyMetadata(null));

    ///// <summary>
    ///// Identifies the <see cref="RightValue"/> property.
    ///// </summary>
    //public static readonly DependencyProperty RightValueProperty =
    //    DependencyProperty.Register(nameof(RightValue), typeof(object), typeof(ConvertHelper), new PropertyMetadata(null));

    ///// <summary>  
    ///// Identifies the <see cref="BottomValue"/> property.  
    ///// </summary>  
    //public static readonly DependencyProperty BottomValueProperty =
    //   DependencyProperty.Register(nameof(BottomValue), typeof(object), typeof(ConvertHelper), new PropertyMetadata(null));

    ///// <summary>
    ///// Gets or sets the value to be returned when the type of the provided value matches <see cref="Type"/>.
    ///// </summary>
    //public object LeftValue
    //{
    //    get { return GetValue(LeftValueProperty); }
    //    set { SetValue(LeftValueProperty, value); }
    //}

    ///// <summary>
    ///// Gets or sets the value to be returned when the type of the provided value does not match <see cref="Type"/>.
    ///// </summary>
    //public object TopValue
    //{
    //    get { return GetValue(TopValueProperty); }
    //    set { SetValue(TopValueProperty, value); }
    //}

    ///// <summary>
    ///// Gets or sets the value to be returned when the type of the provided value matches <see cref="Type"/>.
    ///// </summary>
    //public object RightValue
    //{
    //    get { return GetValue(RightValueProperty); }
    //    set { SetValue(RightValueProperty, value); }
    //}

    ///// <summary>
    ///// Gets or sets the value to be returned when the type of the provided value matches <see cref="Type"/>.
    ///// </summary>
    //public object BottomValue
    //{
    //    get { return GetValue(BottomValueProperty); }
    //    set { SetValue(BottomValueProperty, value); }
    //}

    public static Thickness ToThickness(double LeftValue, double TopValue = 0,double RightValue = 0,double BottomValue = 0)
    {
        return new Thickness(LeftValue,TopValue, RightValue, BottomValue);
    }


    //public object Convert(object value, Type targetType, object parameter, string language)
    //{
    //    return new Thickness((double)LeftValue, (double)TopValue, (double)RightValue, (double)BottomValue);
    //}

    //public object ConvertBack(object value, Type targetType, object parameter, string language)
    //{
    //    throw new NotImplementedException();
    //}
}
