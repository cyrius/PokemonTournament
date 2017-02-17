using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using Newtonsoft.Json;

namespace BusinessLayer
{
    class Item{
        public string Font { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public string Align { get; set; }

    }


    public class PokemonPrinter : PrintDocument
    {
        public Font PrintFont { get; set; }
        public string PrintText { get; set; }
        private Brush brush;
        private StringFormat format = new StringFormat(StringFormatFlags.LineLimit);
        private static int curChar;

        public PokemonPrinter()
        {
            PrintText = String.Empty;
            PrintFont = new Font("Times New Roman", 12);

        }

        //public PokemonPrinter(string printer, string text, string font)
        //{
        //    PrinterSettings.PrinterName = printer;
        //    PrintText = text;
        //    PrintFont = new Font(font, 12);
        //}

        public PokemonPrinter(string printer, string jsonFile, string text)
        {
            PrinterSettings.PrinterName = printer;
            PrintText = text;
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                PrintFont = new Font(items[0].Font, items[0].Size);
                switch (items[0].Color){
                    case "red":
                        brush = Brushes.Red;
                        break;
                    case "yellow":
                        brush = Brushes.Yellow;
                        break;
                    case "green":
                        brush = Brushes.Green;
                        break;
                    case "blue":
                        brush = Brushes.Blue;
                        break;
                    case "orange":
                        brush = Brushes.Orange;
                        break;
                }
                switch (items[0].Align){
                    case "center":
                        format.Alignment = StringAlignment.Center;
                        break;
                    case "far":
                        format.Alignment = StringAlignment.Far;
                        break;
                    case "near":
                        format.Alignment = StringAlignment.Near;
                        break;
                }


                
            }
        }
        protected override void OnBeginPrint(PrintEventArgs e)
        {
            base.OnBeginPrint(e);

        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);
            int printHeight;
            int printWidth;
            int leftMargin;
            int rightMargin;
            int lines;
            int chars;

            printHeight = base.DefaultPageSettings.PaperSize.Height - base.DefaultPageSettings.Margins.Top - base.DefaultPageSettings.Margins.Bottom;
            printWidth = base.DefaultPageSettings.PaperSize.Width - base.DefaultPageSettings.Margins.Left - base.DefaultPageSettings.Margins.Right;
            leftMargin = base.DefaultPageSettings.Margins.Left;  //X
            rightMargin = base.DefaultPageSettings.Margins.Top;  //Y

            //Create a rectangle printing are for our document
            RectangleF printArea = new RectangleF(leftMargin, rightMargin, printWidth, printHeight);

            //Use the StringFormat class for the text layout of our document
           

            //Fit as many characters as we can into the print area
            e.Graphics.MeasureString(PrintText.Substring(RemoveZeros(ref curChar)), PrintFont, new SizeF(printWidth, printHeight), format, out chars, out lines);

            //Print the page
            e.Graphics.DrawString(PrintText.Substring(RemoveZeros(ref curChar)), PrintFont, brush, printArea, format);

            //Increase current char count
            curChar += chars;

            //Detemine if there is more text to print, if
            //there is the tell the printer there is more coming
            if (curChar < PrintText.Length)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                curChar = 0;
            }
        }

        public int RemoveZeros(ref int value)
        {
            //As 0 (ZERO) being sent to DrawString will create unexpected
            //problems when printing we need to search for the first
            //non-zero character in the string.
            while (PrintText[value] == 0)
            {
                value++;
            }
            return value;
        }
    }
}