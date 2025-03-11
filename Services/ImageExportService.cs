using CardGenerator.Entities;
using CardGenerator.Interfaces.Services;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace CardGenerator.Services;

public class ImageExportService : IImageExportService
{
    /// <inheritdoc />
    public void Export(Deck deck, string basePath, Entities.Font font)
    {
        ArgumentNullException.ThrowIfNull(deck);
        ArgumentNullException.ThrowIfNull(deck.Name);

        var folderPath = $"{basePath}/{deck.Name.Replace(".", "")}";
        var directory = Directory.CreateDirectory(folderPath);

        var cards = deck.Cards.ToList();
        for(var i = 0; i < cards.Count; i++)
        {
            var card = cards[i];
            var image = new Bitmap(897, 1497);

            using var graphics = Graphics.FromImage(image);

            graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, 897, 1497));

            var pen = new Pen(Color.Black, 5);
            var rect = new Rectangle(66, 66, 765, 1365);
            graphics.DrawRectangle(Pens.Black, rect);

            var titleRect = new Rectangle(66, 126, 765, 90);
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };
            graphics.DrawString(card.Title, new System.Drawing.Font(FontFamily.GenericSansSerif, 24), Brushes.Black, titleRect, stringFormat);

            using var cardImage = Image.FromStream(new MemoryStream(card.Image!.Bytes!));
            graphics.DrawImage(cardImage, new Rectangle(66, 246, 765, 765));

            image.Save($"{directory.FullName}/{card.Title!.Replace(" ", "")}.jpg");
        }
    }
}
