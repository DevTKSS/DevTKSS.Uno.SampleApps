namespace DevTKSS.Uno.Samples.MvuxGallery.Models.GalleryImages;
[Bindable]
public partial class GalleryImageService : IGalleryImageService
{
    private readonly ILocalizationService _localizationService;
    private readonly IStringLocalizer _stringlocalizer;
    public GalleryImageService(
        ILocalizationService localizationService,
        IStringLocalizer _stringLocalizer)
    {
        _localizationService = localizationService;
        _stringlocalizer = _stringLocalizer;
    }

    public async ValueTask<IImmutableList<GalleryImageModel>> GetGalleryImagesWithReswAsync(CancellationToken ct)
    {
       return await GetGalleryImagesAsync(ct);
    }
    public async ValueTask<IImmutableList<GalleryImageModel>> GetGalleryImagesWithoutReswAsync(CancellationToken ct)
    {
        string cultureString = _localizationService.CurrentCulture.TwoLetterISOLanguageName;
        var galleryImages = cultureString switch
        {
            "de" => await GetDEGalleryImagesAsync(ct),
            "en" => await GetENGalleryImagesAsync(ct),
            _ => await GetENGalleryImagesAsync(ct),
        };
        return galleryImages;
    }

    #region Get culture specific gallery imageDescription

    #region With resw
    private async ValueTask<IImmutableList<GalleryImageModel>> GetGalleryImagesAsync(CancellationToken ct)
    {
        await Task.Delay(TimeSpan.FromSeconds(2), ct);
        var galleryImages = new GalleryImageModel[]
        {
            new GalleryImageModel(
                Title: "Fluffy",
                ImageLocation: "ms-appx:///Assets/Images/img_20240531_141928.jpg",
                Description: _stringlocalizer["img_20240531_141928"]),
            new GalleryImageModel(
                Title: "Snowball",
                ImageLocation: "ms-appx:///Assets/Images/img_20230302_175758.jpg",
                Description: _stringlocalizer["img_20230302_175758"]),
            new GalleryImageModel(
                Title: "Buddy",
                ImageLocation: "ms-appx:///Assets/Images/img_20240602_130506.jpg",
                Description: _stringlocalizer["img_20240602_130506"]),
            new GalleryImageModel(
                Title: "Coco",
                ImageLocation: "ms-appx:///Assets/Images/img_20240721_130401.jpg",
                Description: _stringlocalizer["img_20240721_130401"]),
            new GalleryImageModel(
                Title: "Bunny",
                ImageLocation: "ms-appx:///Assets/Images/img_20240721_130831.jpg",
                Description: _stringlocalizer["img_20240721_130831"]),
            new GalleryImageModel(
                Title: "Thumper",
                ImageLocation: "ms-appx:///Assets/Images/img_20240721_132103.jpg",
                Description: _stringlocalizer["img_20240721_132103"]),
        }.ToImmutableList();
        return galleryImages;
    }

    #endregion
    
    #region Without resw
    #region German gallery descriptions
    private async ValueTask<IImmutableList<GalleryImageModel>> GetDEGalleryImagesAsync(CancellationToken ct)
    {
        // Simulate a delay to mimic data fetching
        await Task.Delay(TimeSpan.FromSeconds(2),ct);
        var galleryImages = new GalleryImageModel[]
        {
            new GalleryImageModel(
                Title: "Fluffy",
                ImageLocation: "ms-appx:///Assets/Images/img_20240531_141928.jpg",
                Description: "Ein kleiner Kuschelmeister, der es liebt, im Zentrum der aufmerksamkeit zu stehen und sanft gekrault zu werden."),
            new GalleryImageModel(
                Title: "Snowball",
                ImageLocation: "ms-appx:///Assets/Images/img_20230302_175758.jpg",
                Description: "Ein verspielter Wirbelwind, der mit seinen Hüpfern jeden Raum zum Leben erweckt und dabei immer ein Lächeln hervorruft."),
            new GalleryImageModel(
                Title: "Buddy",
                ImageLocation: "ms-appx:///Assets/Images/img_20240602_130506.jpg",
                Description: "Ein neugieriger Abenteurer, der ständig mit tapsigen Pfoten und seinem aufgeweckten Näschen die Welt erkundet."),
            new GalleryImageModel(
                Title: "Coco",
                ImageLocation: "ms-appx:///Assets/Images/img_20240721_130401.jpg",
                Description: "Ein kleiner Genießer, der sich nichts sehnlicher wünscht, als den ganzen Tag an frischem Grünzeug zu knabbern."),
            new GalleryImageModel(
                Title: "Bunny",
                ImageLocation: "ms-appx:///Assets/Images/img_20240721_130831.jpg",
                Description: "Ein absoluter Herzensbrecher, der sich mit einem einzigen Blick tief in die Herzen seiner Menschen schleicht."),
            new GalleryImageModel(
                Title: "Thumper",
                ImageLocation: "ms-appx:///Assets/Images/img_20240721_132103.jpg",
                Description: "Ein lebhafter Freigeist, der mit seinen lustigen Sprüngen und Hüpfern für pure Lebensfreude sorgt."),
        }.ToImmutableList();
        return galleryImages;
    }
    #endregion
    
    #region English gallery descriptions
    private async ValueTask<IImmutableList<GalleryImageModel>> GetENGalleryImagesAsync(CancellationToken ct)
    {
        // Simulate a delay to mimic data fetching
        await Task.Delay(TimeSpan.FromSeconds(2), ct);
        var galleryImages = new GalleryImageModel[]
        {
            new GalleryImageModel(
                Title: "Fluffy",
                ImageLocation: "ms-appx:///Assets/Images/img_20240531_141928.jpg",
                Description: "A little snuggle expert who loves curling up in blankets and soaking up gentle attention."),
            new GalleryImageModel(
                Title: "Snowball",
                ImageLocation: "ms-appx:///Assets/Images/img_20230302_175758.jpg",
                Description: "A playful bundle of energy who hops around spreading joy wherever they go."),
            new GalleryImageModel(
                Title: "Buddy",
                ImageLocation: "ms-appx:///Assets/Images/img_20240602_130506.jpg",
                Description: "A curious explorer, always investigating the world with tiny paws and an inquisitive nose."),
            new GalleryImageModel(
                Title: "Coco",
                ImageLocation: "ms-appx:///Assets/Images/img_20240721_130401.jpg",
                Description: "A little foodie who would happily spend all day nibbling on fresh treats."),
            new GalleryImageModel(
                Title: "Bunny",
                ImageLocation: "ms-appx:///Assets/Images/img_20240721_130831.jpg",
                Description: "A charming sweetheart who wins hearts with just one adorable glance."),
            new GalleryImageModel(
                Title: "Thumper",
                ImageLocation: "ms-appx:///Assets/Images/img_20240721_132103.jpg",
                Description: "A lively free spirit who bounces around spreading cheer and fun."),
            }.ToImmutableList();
        return galleryImages;
    }
    #endregion

    #endregion
    
    #endregion
}
