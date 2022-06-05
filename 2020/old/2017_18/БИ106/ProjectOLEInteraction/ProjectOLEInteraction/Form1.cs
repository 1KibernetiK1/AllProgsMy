using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MSWord = Microsoft.Office.Interop.Word;

namespace ProjectOLEInteraction
{
    public partial class Form1 : Form
    {
        private List<SaleRecord> cart;

        public Form1()
        {
            InitializeComponent();
            cart = new List<SaleRecord>();
            cart.Add(new SaleRecord("Хлеб",      40,  2));
            cart.Add(new SaleRecord("Молоко",    35,  1));
            cart.Add(new SaleRecord("Колбаса",   250, 1));
            cart.Add(new SaleRecord("Конфеты",   180, 2));
            cart.Add(new SaleRecord("Мороженое", 45,  3));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // запускаем приложение под нашим контролем
            var wordApp = new 
                MSWord.Application();
            // показываем приложение
            wordApp.Visible = true;
            // добавим документ
            MSWord.Document doc = wordApp.Documents.Add();
            // базовая единица в документе - АБЗАЦ
            MSWord.Paragraph par = doc.Paragraphs.Add();
            par.Range.Text = "Отчёт по продажам: "
                            +DateTime.Today.ToLongDateString();
            doc.Paragraphs.Add();
            doc.Paragraphs.Add();
            doc.Paragraphs.Add();
            par = doc.Paragraphs[1];
            // меняем шрифт 
            par.Range.Font.Name = "Times New Roman";
            par.Range.Font.Size = 15;
            par.Range.Font.Color = 
                MSWord.WdColor.wdColorBrightGreen;
            par.Alignment = 
                MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
            // ДОБАВИМ ТАБЛИЦУ:
            
            par = doc.Paragraphs[2];
            par.Range.Text = "Таблица \"Продажи\"";
            par = doc.Paragraphs[3];
            doc.Tables.Add(par.Range,5,4);
            MSWord.Table tab = doc.Tables[1];
            // стиль внутрен ГРАНИЦ...
            tab.Borders.InsideLineStyle
                = MSWord.WdLineStyle.wdLineStyleSingle;
            tab.Borders.InsideLineWidth = 
                MSWord.WdLineWidth.wdLineWidth150pt;
            tab.Borders.InsideColor 
                = MSWord.WdColor.wdColorRed;
            //------------------------------
            // стиль внешние границы
            tab.Borders.OutsideLineStyle
                = MSWord.WdLineStyle.wdLineStyleDouble;
            tab.Borders.OutsideLineWidth =
                MSWord.WdLineWidth.wdLineWidth075pt;
            tab.Borders.OutsideColor
                = MSWord.WdColor.wdColorGreen;
            // заносим данные о покупках:
            for (int i = 0; i < cart.Count; i++)
            {
                tab.Cell(2+i, 1).Range.Text = 
                    cart[i].Title;
                tab.Cell(2 + i, 2).Range.Text = 
                    cart[i].Price.ToString("C");
                tab.Cell(2 + i, 3).Range.Text =
                    cart[i].Amount.ToString("C");
                int sum = cart[i].Price * cart[i].Amount;
                tab.Cell(2 + i, 4).Range.Text =
                    sum.ToString("C");
            }



        }
    }
}
