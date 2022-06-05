using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//word
using MsWord = Microsoft.Office.Interop.Word;

namespace WinFormsWordAuto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Запускаем вордовский процесс.
            var wordApp = new MsWord.Application();
            //MessageBox.Show("Word started");
            //wordApp.Visible = true;

            //1) Способ получить документ
            MsWord.Document doc = wordApp.Documents.Add();
            //2) способ получить документ
            // Во всех программах офиса использ Basic - нумерация с 1
            doc = wordApp.Documents[1];

            // в документе основная единица - ПАРАГРАФ (абзац)
            doc.Paragraphs.Add();
            doc.Paragraphs.Add();


            MsWord.Paragraph par1 = doc.Paragraphs[1];

            par1.Range.Text = "Привет! Ты долго спал " +DateTime.Now+"!";
            par1.Alignment = MsWord.WdParagraphAlignment.wdAlignParagraphCenter;
            par1.Range.Font.Name = "Times New Roman";
            par1.Range.Font.Size = 20;
            par1.Range.Font.Bold = 3;
            par1.Range.Font.Color = MsWord.WdColor.wdColorAqua;

            // добавление таблицы
            MsWord.Paragraph par2 = doc.Paragraphs[2];
            doc.Tables.Add(par2.Range, 3, 4, MsWord.WdDefaultTableBehavior.wdWord9TableBehavior);

            MsWord.Table table = doc.Tables[1];
            table.Borders[MsWord.WdBorderType.wdBorderTop]
                .LineStyle = MsWord.WdLineStyle.wdLineStyleDashDot;

            table.Borders[MsWord.WdBorderType.wdBorderHorizontal].Color = MsWord.WdColor.wdColorBrightGreen;

            string[] headers = { "Название", "кол-во", "стоимость", "Цена" };

            for (int i = 0; i < headers.Length; i++)
            {
                table.Cell(1, 1+i).Range.Text = headers[i];
            }

            var list = new List<ProductOrder>();
            list.Add(new ProductOrder("Молоко", 100, 10));
            list.Add(new ProductOrder("Сметана", 200, 10));
            list.Add(new ProductOrder("Колбаса", 300, 10));


            for (int i = 0; i < list.Count; i++)
            {
                table.Cell(1 + i, 1).Range.Text = list[i].Name;
                table.Cell(1 + i, 2).Range.Text = list[i].Price.ToString();
                table.Cell(1 + i, 3).Range.Text = list[i].Quantity.ToString();
                table.Cell(1 + i, 4).Range.Text = list[i].Cost.ToString();
            }
            doc.SaveAs2("E:\\SergPAv\\Программирование\\ура", MsWord.WdSaveFormat.wdFormatDocumentDefault);
            wordApp.Quit();
            //wordApp.PrintOut();
        }
    }
}
