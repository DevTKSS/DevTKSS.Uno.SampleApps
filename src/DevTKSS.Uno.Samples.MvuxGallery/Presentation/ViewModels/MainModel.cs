using Uno.Extensions.Reactive;

namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.ViewModels;
public partial record MainModel
{
    private readonly ILocalizationService _localizationService;
    private readonly IStringLocalizer _stringLocalizer;

    public MainModel(
        ILocalizationService localizationService,
        IStringLocalizer stringLocalizer)
    {
        _localizationService = localizationService;
        _stringLocalizer = stringLocalizer;

    }

    public IState<string> AppTitle => State<string>.Value(this, () => _stringLocalizer["ApplicationName"]);

}

