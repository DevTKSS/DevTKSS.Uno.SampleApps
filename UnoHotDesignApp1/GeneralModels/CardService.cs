

namespace UnoHotDesignApp1.GeneralModels;
public class CardService : ICardService
{

    public async ValueTask<IImmutableList<CardModel>> GetCardsAsync(CancellationToken ct)
    {
        await Task.Delay(TimeSpan.FromSeconds(2), ct);
        var Cards = new CardModel[]
        {
            new CardModel(
                HeaderContent: "Elevated Card",
                MediaContent: "ms-appx:///Assets/Images/img_20240531_141928.jpg"),
            new CardModel(
                HeaderContent: "Filled Card",
                MediaContent: "ms-appx:///Assets/Images/img_20240602_130506.jpg"),
            new CardModel(
                HeaderContent: "Outlined Card",
                MediaContent: "ms-appx:///Assets/Images/img_20240721_130401.jpg"),
            new CardModel(
                HeaderContent: "Elevated Card",
                MediaContent: "ms-appx:///Assets/Images/img_20240721_130831.jpg"),
            new CardModel(
                HeaderContent: "Filled Card",
                MediaContent: "ms-appx:///Assets/Images/img_20240721_132103.jpg"),
            new CardModel(
                HeaderContent: "Outlined Card",
                MediaContent: "ms-appx:///Assets/Images/img_20230302_175758.jpg")
        };
        return Cards.ToImmutableList();
    }
}
public interface ICardService
{
    ValueTask<IImmutableList<CardModel>> GetCardsAsync(CancellationToken ct);
}
