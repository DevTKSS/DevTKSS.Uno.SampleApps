namespace DevTKSS.Uno.Samples.MvuxGallery.Models.GalleryImages;

public interface IGalleryImageService
{
    public ValueTask<IImmutableList<GalleryImage>> GetGalleryImagesWithoutReswAsync(CancellationToken ct);
    public ValueTask<IImmutableList<GalleryImage>> GetGalleryImagesWithReswAsync(CancellationToken ct);
}
