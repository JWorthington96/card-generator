using System;
using System.IO;
using CardGenerator.Entities;
using CardGenerator.Interfaces.Services;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Quality;

namespace CardGenerator.Services;

/// <summary>
/// A service for exporting cards to a PDF file.
/// </summary>
public class PdfExportService : IPdfExportService
{
    private const double cardWidth = 62;
    private const double cardHeight = 90;
    private const double margin = 5;
    private const double padding = 5;

    /// <inheritdoc/>
    public void Export(Deck deck, string folderPath, Font font)
    {
        var pdf = new PdfDocument();
        var page = pdf.AddPage();
        page.Size = PageSize.A4;
        page.Orientation = PageOrientation.Landscape;

        var millimeterToPt = page.Width.Point / page.Width.Millimeter;

        var style = XFontStyleEx.Regular;
        if (font.IsBold && font.IsItalic) style = XFontStyleEx.BoldItalic;
        else if (font.IsUnderline) style = XFontStyleEx.Underline;
        else if (font.IsStrikethrough) style = XFontStyleEx.Strikeout;

        var xFont = new XFont(font.Family, font.Size, style);

        var marginPt = ToPoint(margin, millimeterToPt);
        var paddingPt = ToPoint(padding, millimeterToPt);

        var minX = marginPt;
        var minY = paddingPt;
        var width = page.Width.Point - 2 * marginPt;
        var height = page.Height.Point - 2 * marginPt;

        var bounds = new XRect(minX, minY, width, height);

        var cardWidthPt = ToPoint(cardWidth, millimeterToPt);
        var cardHeightPt = ToPoint(cardHeight, millimeterToPt);

        var thirdHeight = cardHeightPt * (2d / 3);

        var x = marginPt;
        var y = marginPt;
        foreach (var card in deck.Cards)
        {
            var cardRect = new XRect(x, y, cardWidthPt, cardHeightPt);

            // If out of bounds we move it to a new line
            if (!bounds.Contains(cardRect))
            {
                x = marginPt;
                y += cardHeightPt + paddingPt;
                cardRect = new XRect(x, y, cardWidthPt, cardHeightPt);
                // If its still out of bounds, stop drawing (end of page)
                // TODO: insert new page instead
                if (!bounds.Contains(cardRect))
                {
                    break;
                }
            }

            using var graphics = XGraphics.FromPdfPage(page);
            graphics.IntersectClip(cardRect);
            graphics.DrawRectangle(new XPen(XColors.Black, 4), cardRect);

            if (card.Image is not null)
            {
                using var stream = new BufferedStream(new MemoryStream(card.Image?.Bytes ?? []));
                var image = XImage.FromStream(stream);

                var desiredRect = new XRect(cardRect.X + paddingPt, cardRect.Y + paddingPt, cardRect.Width - 2 * paddingPt, cardRect.Height * (2d / 3) - 2 * paddingPt);
                var scale = GetScale(image.Size, desiredRect.Size);

                var imageRect = new XRect(image.Size);
                imageRect.Scale(scale, scale);

                imageRect.X += desiredRect.X;
                imageRect.Y += desiredRect.Y;
                imageRect.Intersect(desiredRect);
                graphics.DrawImage(image, imageRect);
            }

            var textRect = new XRect(cardRect.X + padding, cardRect.Y + thirdHeight, cardRect.Width - 2 * padding, thirdHeight);

            var formatter = new XTextFormatter(graphics)
            {
                Alignment = XParagraphAlignment.Center
            };
            formatter.DrawString(card.FlavourText ?? string.Empty, xFont, XBrushes.Black, textRect);

            x += cardWidthPt + paddingPt;
        }

        var filePath = $"{folderPath}/{deck.Name}.pdf";
        pdf.Save(filePath);
        PdfFileUtility.ShowDocument(filePath);
    }

    private static double ToPoint(double millimeter, double convertion) => millimeter * convertion;

    private static double GetScale(XSize size, XSize desiredSize) => Math.Max(desiredSize.Width / size.Width, desiredSize.Height / size.Height);
}
