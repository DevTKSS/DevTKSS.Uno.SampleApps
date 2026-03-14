using Uno.Extensions.Reactive.Commands;

namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.ViewModels;

public partial record SimpleListModel
{
    #region Services
    private readonly IStringLocalizer _stringLocalizer;
    private readonly IGalleryImageService _galleryImageService;

    #endregion
    public SimpleListModel(
        IStringLocalizer stringLocalizer,
        IGalleryImageService galleryImageService
)
    {
        this._stringLocalizer = stringLocalizer;
        this._galleryImageService = galleryImageService;
    }

    public IListFeed<GalleryImage> GalleryImagesWithResw => ListFeed.Async(_galleryImageService.GetGalleryImagesWithReswAsync);

}



