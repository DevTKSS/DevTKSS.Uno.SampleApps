namespace UnoHotDesignApp1.GeneralModels;
public class GalleryImageService : IGalleryImageService
{

    public async ValueTask<IImmutableList<GalleryImageModel>> GetGalleryImagesAsync(CancellationToken ct)
    {
        await Task.Delay(TimeSpan.FromSeconds(2), ct);
        var galleryImages = new GalleryImageModel[]
        {
            new GalleryImageModel(
                Title: "Elevated Card",
                ImageLocation: "ms-appx:///Assets/Images/img_20240531_141928.jpg",
                Description:""),
            new GalleryImageModel(
                Title: "Filled Card",
                ImageLocation: "ms-appx:///Assets/Images/img_20240602_130506.jpg",
                Description: ""),
            new GalleryImageModel(
                Title: "Outlined Card",
                ImageLocation: "ms-appx:///Assets/Images/img_20240721_130401.jpg",
                Description : ""),
            new GalleryImageModel(
                Title: "Elevated Card",
                ImageLocation: "ms-appx:///Assets/Images/img_20240721_130831.jpg", 
                Description : ""),
            new GalleryImageModel(
                Title: "Filled Card",
                ImageLocation: "ms-appx:///Assets/Images/img_20240721_132103.jpg",
                Description : ""),
            new GalleryImageModel(
                Title: "Outlined Card",
                ImageLocation: "ms-appx:///Assets/Images/img_20230302_175758.jpg",
                Description : ""),
        }.ToImmutableList();
        return galleryImages;
    }
}
public interface IGalleryImageService
{
    ValueTask<IImmutableList<GalleryImageModel>> GetGalleryImagesAsync(CancellationToken ct);
}
