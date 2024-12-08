using System.Diagnostics;
using Uno.Extensions.Reactive.UI;
namespace UnoHotDesignApp1.Presentation.UserControls;
[Bindable]
public sealed partial class GLFeedViewHeader : UserControl
{
   
    public GLFeedViewHeader()
    {
        
        this.InitializeComponent();

    }

    #region PersonPicture
    public static readonly DependencyProperty PersonPictureSourceProperty = DependencyProperty.Register(
        nameof(PersonPictureSource), typeof(string), typeof(GLFeedViewHeader), new PropertyMetadata(default(string)));


    public string PersonPictureSource
    {
        get => (string)GetValue(PersonPictureSourceProperty);
        set => SetValue(PersonPictureSourceProperty, value);
    }

    public static readonly DependencyProperty PictureWidthProperty = DependencyProperty.Register(
        nameof(PictureWidth), typeof(int), typeof(GLFeedViewHeader), new PropertyMetadata(default(int)));

    public int PictureWidth
    {
        get => (int)GetValue(PictureWidthProperty);
        set => SetValue(PictureWidthProperty, value);
    }

    //public static readonly DependencyProperty PictureVisibleProperty = DependencyProperty.Register(
    //    nameof(PictureVisible), typeof(Visibility), typeof(GLFeedViewHeader), new PropertyMetadata(default(Visibility)));

    //public Visibility? PictureVisible
    //{
    //    get => (Visibility)GetValue(PictureVisibleProperty);
    //    set => SetValue(PictureVisibleProperty, value);
    //}
    #endregion

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title), typeof(string), typeof(GLFeedViewHeader), new PropertyMetadata(default(string)));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

}
