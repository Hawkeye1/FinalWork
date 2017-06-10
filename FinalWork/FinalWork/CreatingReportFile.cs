using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AODL.Document.Export;
using AODL.Document.TextDocuments;
using AODL.Document.Content.Text;
using AODL.Document.Styles.Properties;
using AODL.Document.Content.Tables;
using System.Data;
using System.IO;
using iTextSharp.text.pdf;
using System.Collections;
using AODL.ExternalExporter.PDF.Document.ContentConverter;
using AODL.ExternalExporter.PDF.Document.StyleConverter;
using AODL.Document;
using AODL.Document.Styles;

namespace FinalWork
{
    public class CreatingReportFile
    {
        public void CreateOdtHtmlFile(Boolean Copy, DataTable[] Blanks, Double[] Fund, int type, string filepath, Int32[] Indexes, DateTime time)
        {
            TextDocument Document = new TextDocument();
            Document.Load("template//report.odt");
            int tableId = 0;
            Boolean find = false;

            for (int i = 0; i < Document.Content.Count; i++)
            {
                Paragraph p = Document.Content[i] as Paragraph;

                for (int j = 0; j < p.TextContent.Count; j++)
                {
                    string temp = p.TextContent[j].Text;

                    if (temp != null)
                    {
                        if (temp.Contains("date"))
                        {
                            temp = temp.Replace("date", time.ToString("d"));
                            FormatedText ft = p.TextContent[j] as FormatedText;
                            ft.Text = temp;
                            ft.TextContent[0].Text = temp;
                        }
                        else if (temp.Contains("month"))
                        {
                            temp = temp.Replace("month", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(time.Month - 1).ToLower());
                            FormatedText ft = p.TextContent[j] as FormatedText;
                            ft.Text = temp;
                            ft.TextContent[0].Text = temp;
                        }
                        else if (temp.Contains("table"))
                        {
                            find = true;
                            break;
                        }
                    }
                }

                if (find)
                {
                    break;
                }

                tableId++;
            }

            Document.Content.RemoveAt(tableId);

            int rowCount = Blanks[0].Rows.Count + Blanks[1].Rows.Count + Blanks[2].Rows.Count + 8;
            int currentRow = 0;

            if (Blanks[0].Rows.Count == 0)
            {
                rowCount -= 2;
            }
            if (Blanks[1].Rows.Count == 0)
            {
                rowCount -= 2;
            }
            if (Blanks[2].Rows.Count == 0)
            {
                rowCount -= 2;
            }

            Table table = TableBuilder.CreateTextDocumentTable(Document, "table", "table", rowCount, 4, 17, false, true);
            table.TableStyle.TableProperties.Align = TextAlignments.justify.ToString();
            table.ColumnCollection[0].ColumnStyle.ColumnProperties.Width = "1cm";
            table.ColumnCollection[1].ColumnStyle.ColumnProperties.Width = "6cm";
            table.ColumnCollection[2].ColumnStyle.ColumnProperties.Width = "6cm";
            table.ColumnCollection[3].ColumnStyle.ColumnProperties.Width = "4cm";

            Paragraph columnName1 = ParagraphBuilder.CreateStandardTextParagraph(Document);
            columnName1.TextContent.Add(new SimpleText(Document, "№"));
            table.Rows[currentRow].Cells[0].Content.Add(columnName1);
            Paragraph columnName2 = ParagraphBuilder.CreateStandardTextParagraph(Document);
            columnName2.TextContent.Add(new SimpleText(Document, "Ф.И.О."));
            table.Rows[currentRow].Cells[1].Content.Add(columnName2);
            Paragraph columnName3 = ParagraphBuilder.CreateStandardTextParagraph(Document);
            columnName3.TextContent.Add(new SimpleText(Document, "Должность"));
            table.Rows[currentRow].Cells[2].Content.Add(columnName3);
            Paragraph columnName4 = ParagraphBuilder.CreateStandardTextParagraph(Document);
            columnName4.TextContent.Add(new SimpleText(Document, "Размер премии (руб.)"));
            table.Rows[currentRow].Cells[3].Content.Add(columnName4);

            currentRow++;

            if (Blanks[0].Rows.Count != 0)
            {
                DataView dv = Blanks[0].DefaultView;
                dv.Sort = "[ФИО] ASC";
                DataTable Blank = dv.ToTable();

                Paragraph budget = ParagraphBuilder.CreateStandardTextParagraph(Document);
                SimpleText header = new SimpleText(Document, "По бюджетной форме");
                budget.TextContent.Add(header);
                budget.Style = Document.CommonStyles.Single(x => x.StyleName == "Заголовоктаблицы") as ParagraphStyle;
                table.Rows[currentRow].Cells[0].Content.Add(budget);

                // Сохраняем xml код ячеек которые будут объеднены,
                // чтобы удалить оставшуюся информацию после объединения

                String xmlCell1 = table.Rows[currentRow].Cells[1].Node.OuterXml;
                String xmlCell2 = table.Rows[currentRow].Cells[2].Node.OuterXml;
                String xmlCell3 = table.Rows[currentRow].Cells[3].Node.OuterXml;
                
                // Объединение ячеек
                table.Rows[currentRow].MergeCells(Document, 0, 4, true);

                // Удаление остаточных данных
                String innerXml = table.Rows[currentRow].Node.InnerXml;
                innerXml = innerXml.Replace(xmlCell1, "");
                innerXml = innerXml.Replace(xmlCell2, "");
                innerXml = innerXml.Replace(xmlCell3, "");
                table.Rows[currentRow].Node.InnerXml = innerXml;

                currentRow++;
                int budgetId = 1;

                foreach (DataRow row in Blank.Rows)
                {
                    Paragraph columnBudget1 = ParagraphBuilder.CreateStandardTextParagraph(Document);
                    columnBudget1.TextContent.Add(new SimpleText(Document, Convert.ToString(budgetId)));
                    table.Rows[currentRow].Cells[0].Content.Add(columnBudget1);
                    Paragraph columnBudget2 = ParagraphBuilder.CreateStandardTextParagraph(Document);
                    columnBudget2.TextContent.Add(new SimpleText(Document, row[Indexes[0]].ToString()));
                    table.Rows[currentRow].Cells[1].Content.Add(columnBudget2);
                    Paragraph columnBudget3 = ParagraphBuilder.CreateStandardTextParagraph(Document);
                    columnBudget3.TextContent.Add(new SimpleText(Document, row[Indexes[1]].ToString()));
                    table.Rows[currentRow].Cells[2].Content.Add(columnBudget3);
                    Paragraph columnBudget4 = ParagraphBuilder.CreateStandardTextParagraph(Document);
                    columnBudget4.TextContent.Add(new SimpleText(Document, row[Indexes[2]].ToString()));
                    table.Rows[currentRow].Cells[3].Content.Add(columnBudget4);

                    currentRow++;
                    budgetId++;
                }

                Paragraph result = ParagraphBuilder.CreateStandardTextParagraph(Document);
                result.TextContent.Add(new SimpleText(Document, "Итого по бюджетной форме:"));
                table.Rows[currentRow].Cells[0].Content.Add(result);
                Paragraph sum = ParagraphBuilder.CreateStandardTextParagraph(Document);
                sum.TextContent.Add(new SimpleText(Document, Fund[0].ToString()));
                table.Rows[currentRow].Cells[3].Content.Add(sum);

                // Сохраняем xml код ячеек которые будут объеднены,
                // чтобы удалить оставшуюся информацию после объединения

                xmlCell1 = table.Rows[currentRow].Cells[1].Node.OuterXml;
                xmlCell2 = table.Rows[currentRow].Cells[2].Node.OuterXml;

                // объединение ячеек
                table.Rows[currentRow].MergeCells(Document, 0, 3, true);

                // Удаление остаточных данных
                innerXml = table.Rows[currentRow].Node.InnerXml;
                innerXml = innerXml.Replace(xmlCell1, "");
                innerXml = innerXml.Replace(xmlCell2, "");

                // Перемещаем метку объедененной ячейки
                innerXml = innerXml.Replace("<table:covered-table-cell xmlns:table=\"urn:oasis:names:tc:opendocument:xmlns:table:1.0\" />", "");
                String mergedCellXml = table.Rows[currentRow].Cells[0].Node.OuterXml;
                innerXml = innerXml.Replace(mergedCellXml, mergedCellXml + 
                    "<table:covered-table-cell xmlns:table=\"urn:oasis:names:tc:opendocument:xmlns:table:1.0\" />");
                table.Rows[currentRow].Node.InnerXml = innerXml;

                currentRow++;
            }

            if (Blanks[1].Rows.Count != 0)
            {
                DataView dv = Blanks[1].DefaultView;
                dv.Sort = "[ФИО] ASC";
                DataTable Blank = dv.ToTable();

                Paragraph paid = ParagraphBuilder.CreateStandardTextParagraph(Document);
                SimpleText header = new SimpleText(Document, "По платной форме");
                paid.TextContent.Add(header);
                paid.Style = Document.CommonStyles.Single(x => x.StyleName == "Заголовоктаблицы") as ParagraphStyle;
                table.Rows[currentRow].Cells[0].Content.Add(paid);

                // Сохраняем xml код ячеек которые будут объеднены,
                // чтобы удалить оставшуюся информацию после объединения

                String xmlCell1 = table.Rows[currentRow].Cells[1].Node.OuterXml;
                String xmlCell2 = table.Rows[currentRow].Cells[2].Node.OuterXml;
                String xmlCell3 = table.Rows[currentRow].Cells[3].Node.OuterXml;

                // Объединение ячеек
                table.Rows[currentRow].MergeCells(Document, 0, 4, true);

                // Удаление остаточных данных
                String innerXml = table.Rows[currentRow].Node.InnerXml;
                innerXml = innerXml.Replace(xmlCell1, "");
                innerXml = innerXml.Replace(xmlCell2, "");
                innerXml = innerXml.Replace(xmlCell3, "");
                table.Rows[currentRow].Node.InnerXml = innerXml;

                currentRow++;
                int paidId = 1;

                foreach (DataRow row in Blank.Rows)
                {
                    Paragraph columnPaid1 = ParagraphBuilder.CreateStandardTextParagraph(Document);
                    columnPaid1.TextContent.Add(new SimpleText(Document, Convert.ToString(paidId)));
                    table.Rows[currentRow].Cells[0].Content.Add(columnPaid1);
                    Paragraph columnPaid2 = ParagraphBuilder.CreateStandardTextParagraph(Document);
                    columnPaid2.TextContent.Add(new SimpleText(Document, row[Indexes[0]].ToString()));
                    table.Rows[currentRow].Cells[1].Content.Add(columnPaid2);
                    Paragraph columnPaid3 = ParagraphBuilder.CreateStandardTextParagraph(Document);
                    columnPaid3.TextContent.Add(new SimpleText(Document, row[Indexes[1]].ToString()));
                    table.Rows[currentRow].Cells[2].Content.Add(columnPaid3);
                    Paragraph columnPaid4 = ParagraphBuilder.CreateStandardTextParagraph(Document);
                    columnPaid4.TextContent.Add(new SimpleText(Document, row[Indexes[2]].ToString()));
                    table.Rows[currentRow].Cells[3].Content.Add(columnPaid4);

                    currentRow++;
                    paidId++;
                }

                Paragraph result = ParagraphBuilder.CreateStandardTextParagraph(Document);
                result.TextContent.Add(new SimpleText(Document, "Итого по платной форме:"));
                table.Rows[currentRow].Cells[0].Content.Add(result);
                Paragraph sum = ParagraphBuilder.CreateStandardTextParagraph(Document);
                sum.TextContent.Add(new SimpleText(Document, Fund[1].ToString()));
                table.Rows[currentRow].Cells[3].Content.Add(sum);

                // Сохраняем xml код ячеек которые будут объеднены,
                // чтобы удалить оставшуюся информацию после объединения

                xmlCell1 = table.Rows[currentRow].Cells[1].Node.OuterXml;
                xmlCell2 = table.Rows[currentRow].Cells[2].Node.OuterXml;

                // объединение ячеек
                table.Rows[currentRow].MergeCells(Document, 0, 3, true);

                // Удаление остаточных данных
                innerXml = table.Rows[currentRow].Node.InnerXml;
                innerXml = innerXml.Replace(xmlCell1, "");
                innerXml = innerXml.Replace(xmlCell2, "");

                // Перемещаем метку объедененной ячейки
                innerXml = innerXml.Replace("<table:covered-table-cell xmlns:table=\"urn:oasis:names:tc:opendocument:xmlns:table:1.0\" />", "");
                String mergedCellXml = table.Rows[currentRow].Cells[0].Node.OuterXml;
                innerXml = innerXml.Replace(mergedCellXml, mergedCellXml +
                    "<table:covered-table-cell xmlns:table=\"urn:oasis:names:tc:opendocument:xmlns:table:1.0\" />");
                table.Rows[currentRow].Node.InnerXml = innerXml;

                currentRow++;
            }

            if (Blanks[2].Rows.Count != 0)
            {
                DataView dv = Blanks[2].DefaultView;
                dv.Sort = "[ФИО] ASC";
                DataTable Blank = dv.ToTable();

                Paragraph paragraph = ParagraphBuilder.CreateStandardTextParagraph(Document);
                SimpleText header = new SimpleText(Document, "По  §54");
                paragraph.TextContent.Add(header);
                paragraph.Style = Document.CommonStyles.Single(x => x.StyleName == "Заголовоктаблицы") as ParagraphStyle;
                table.Rows[currentRow].Cells[0].Content.Add(paragraph);

                // Сохраняем xml код ячеек которые будут объеднены,
                // чтобы удалить оставшуюся информацию после объединения

                String xmlCell1 = table.Rows[currentRow].Cells[1].Node.OuterXml;
                String xmlCell2 = table.Rows[currentRow].Cells[2].Node.OuterXml;
                String xmlCell3 = table.Rows[currentRow].Cells[3].Node.OuterXml;

                // Объединение ячеек
                table.Rows[currentRow].MergeCells(Document, 0, 4, true);

                // Удаление остаточных данных
                String innerXml = table.Rows[currentRow].Node.InnerXml;
                innerXml = innerXml.Replace(xmlCell1, "");
                innerXml = innerXml.Replace(xmlCell2, "");
                innerXml = innerXml.Replace(xmlCell3, "");
                table.Rows[currentRow].Node.InnerXml = innerXml;

                currentRow++;
                int paragraphId = 1;

                foreach (DataRow row in Blank.Rows)
                {
                    Paragraph columnParagraph1 = ParagraphBuilder.CreateStandardTextParagraph(Document);
                    columnParagraph1.TextContent.Add(new SimpleText(Document, Convert.ToString(paragraphId)));
                    table.Rows[currentRow].Cells[0].Content.Add(columnParagraph1);
                    Paragraph columnParagraph2 = ParagraphBuilder.CreateStandardTextParagraph(Document);
                    columnParagraph2.TextContent.Add(new SimpleText(Document, row[Indexes[0]].ToString()));
                    table.Rows[currentRow].Cells[1].Content.Add(columnParagraph2);
                    Paragraph columnParagraph3 = ParagraphBuilder.CreateStandardTextParagraph(Document);
                    columnParagraph3.TextContent.Add(new SimpleText(Document, row[Indexes[1]].ToString()));
                    table.Rows[currentRow].Cells[2].Content.Add(columnParagraph3);
                    Paragraph columnParagraph4 = ParagraphBuilder.CreateStandardTextParagraph(Document);
                    columnParagraph4.TextContent.Add(new SimpleText(Document, row[Indexes[2]].ToString()));
                    table.Rows[currentRow].Cells[3].Content.Add(columnParagraph4);

                    currentRow++;
                    paragraphId++;
                }

                Paragraph result = ParagraphBuilder.CreateStandardTextParagraph(Document);
                result.TextContent.Add(new SimpleText(Document, "Итого по §54:"));
                table.Rows[currentRow].Cells[0].Content.Add(result);
                Paragraph sum = ParagraphBuilder.CreateStandardTextParagraph(Document);
                sum.TextContent.Add(new SimpleText(Document, Fund[2].ToString()));
                table.Rows[currentRow].Cells[3].Content.Add(sum);

                // Сохраняем xml код ячеек которые будут объеднены,
                // чтобы удалить оставшуюся информацию после объединения

                xmlCell1 = table.Rows[currentRow].Cells[1].Node.OuterXml;
                xmlCell2 = table.Rows[currentRow].Cells[2].Node.OuterXml;

                // объединение ячеек
                table.Rows[currentRow].MergeCells(Document, 0, 3, true);

                // Удаление остаточных данных
                innerXml = table.Rows[currentRow].Node.InnerXml;
                innerXml = innerXml.Replace(xmlCell1, "");
                innerXml = innerXml.Replace(xmlCell2, "");

                // Перемещаем метку объедененной ячейки
                innerXml = innerXml.Replace("<table:covered-table-cell xmlns:table=\"urn:oasis:names:tc:opendocument:xmlns:table:1.0\" />", "");
                String mergedCellXml = table.Rows[currentRow].Cells[0].Node.OuterXml;
                innerXml = innerXml.Replace(mergedCellXml, mergedCellXml +
                    "<table:covered-table-cell xmlns:table=\"urn:oasis:names:tc:opendocument:xmlns:table:1.0\" />");
                table.Rows[currentRow].Node.InnerXml = innerXml;

                currentRow++;
            }

            Double totalFund = Fund[0] + Fund[1] + Fund[2];

            Paragraph total = ParagraphBuilder.CreateStandardTextParagraph(Document);
            total.TextContent.Add(new SimpleText(Document, "Итого:"));
            table.Rows[currentRow].Cells[0].Content.Add(total);
            Paragraph totalSum = ParagraphBuilder.CreateStandardTextParagraph(Document);
            totalSum.TextContent.Add(new SimpleText(Document, totalFund.ToString()));
            table.Rows[currentRow].Cells[3].Content.Add(totalSum);
            
            // Сохраняем xml код ячеек которые будут объеднены,
            // чтобы удалить оставшуюся информацию после объединения

            String finalXmlCell1 = table.Rows[currentRow].Cells[1].Node.OuterXml;
            String finalXmlCell2 = table.Rows[currentRow].Cells[2].Node.OuterXml;

            // объединение ячеек
            table.Rows[currentRow].MergeCells(Document, 0, 3, true);

            // Удаление остаточных данных
            String finalInnerXml = table.Rows[currentRow].Node.InnerXml;
            finalInnerXml = finalInnerXml.Replace(finalXmlCell1, "");
            finalInnerXml = finalInnerXml.Replace(finalXmlCell2, "");

            // Перемещаем метку объедененной ячейки
            finalInnerXml = finalInnerXml.Replace("<table:covered-table-cell xmlns:table=\"urn:oasis:names:tc:opendocument:xmlns:table:1.0\" />", "");
            String mergedFinalCellXml = table.Rows[currentRow].Cells[0].Node.OuterXml;
            finalInnerXml = finalInnerXml.Replace(mergedFinalCellXml, mergedFinalCellXml +
                "<table:covered-table-cell xmlns:table=\"urn:oasis:names:tc:opendocument:xmlns:table:1.0\" />");
            table.Rows[currentRow].Node.InnerXml = finalInnerXml;

            Document.Content.Insert(tableId, table);

            if (type != 3)
            {
                Document.SaveTo(filepath);
            }
            else
            {
                BaseFont baseFont = BaseFont.CreateFont(@"template\\TimesNewRoman.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 14);

                DefaultDocumentStyles defaultDocumentStyle;
                if (Document is AODL.Document.TextDocuments.TextDocument)
                    defaultDocumentStyle = DefaultDocumentStyles.Instance(
                        ((AODL.Document.TextDocuments.TextDocument)Document).DocumentStyles, Document);
                else
                {
                    throw new Exception("Unknown IDocument implementation.");
                }

                defaultDocumentStyle.Init();
                defaultDocumentStyle.DefaultTextFont = font;

                var doc = new iTextSharp.text.Document();
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                doc.Open();

                ArrayList al = MixedContentConverter.GetMixedPdfContent(Document.Content);

                foreach (Object obj in al)
                {
                    iTextSharp.text.IElement element = obj as iTextSharp.text.IElement;
                    doc.Add(element);
                }

                doc.Close();
            }

            if (Copy)
            {
                Directory.CreateDirectory("ReportsCopy");

                String name = "ReportsCopy//";
                name += DateTime.Now.ToString("g");
                name = name.Replace(".", "");
                name = name.Replace(" ", "");
                name = name.Replace(":", "");
                name += ".odt";

                Document.SaveTo(name);
            }
        }
    }
}
