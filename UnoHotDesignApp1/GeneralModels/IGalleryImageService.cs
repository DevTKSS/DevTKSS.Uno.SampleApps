namespace UnoHotDesignApp1.GeneralModels;

public interface IGalleryImageService
{
    public ValueTask<IImmutableList<GalleryImageModel>> GetGalleryImagesWithoutReswAsync(CancellationToken ct);
    public ValueTask<IImmutableList<GalleryImageModel>> GetGalleryImagesWithReswAsync(CancellationToken ct);
}
