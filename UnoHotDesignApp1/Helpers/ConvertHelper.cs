

namespace UnoHotDesignApp1.Helpers;
public partial class ConvertHelper
{

    public static Thickness ToThickness(double LeftValue, double TopValue = 0,double RightValue = 0,double BottomValue = 0)
    {
        return new Thickness(LeftValue,TopValue, RightValue, BottomValue);
    }

}
