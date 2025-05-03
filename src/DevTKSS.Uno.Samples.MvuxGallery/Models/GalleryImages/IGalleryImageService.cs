namespace DevTKSS.Uno.Samples.MvuxGallery.Models.GalleryImages;

public interface IGalleryImageService
{
    public ValueTask<IImmutableList<GalleryImageModel>> GetGalleryImagesWithoutReswAsync(CancellationToken ct);
    public ValueTask<IImmutableList<GalleryImageModel>> GetGalleryImagesWithReswAsync(CancellationToken ct);
}
