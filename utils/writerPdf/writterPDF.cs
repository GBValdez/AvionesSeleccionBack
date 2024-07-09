using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace AvionesBackNet.utils.writerPdf
{
    public class writterPDF
    {
        public Document document { get; set; }
        public writterPDF(PdfDocument pdf)
        {
            this.document = new Document(pdf);
        }
        public void title(string text)
        {
            document.Add(new Paragraph(text).SetFontSize(19).SetBold().SetMargin(0));
        }

        public void subtitle(string text)
        {
            document.Add(new Paragraph(text).SetFontSize(17).SetBold().SetMargin(0));
        }
        public void subtitle2(string text)
        {
            document.Add(new Paragraph(text).SetFontSize(13).SetMargin(0).SetBold());
        }
        public void text(string text)
        {
            document.Add(new Paragraph(text).SetFontSize(12).SetMargin(0));
        }
    }
}