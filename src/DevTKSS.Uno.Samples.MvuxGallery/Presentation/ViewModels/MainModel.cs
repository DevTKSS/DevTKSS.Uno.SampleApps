using Uno.Extensions.Reactive;

namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.ViewModels;
public partial record MainModel
{
    private readonly INavigator _navigator;
    private readonly ILocalizationService _localizationService;
    private readonly IStringLocalizer _stringLocalizer;

    public MainModel(
        IOptions<AppConfig> appInfo,
        INavigator navigator,
        ILocalizationService localizationService,
        IStringLocalizer stringLocalizer)
    {
        _navigator = navigator;
        _localizationService = localizationService;
        _stringLocalizer = stringLocalizer;

    }

    public IState<string> AppTitle => State<string>.Value(this, () => _stringLocalizer["ApplicationName"]);

}

