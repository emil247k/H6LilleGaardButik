using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using GaardButik.Server.Context;
using GaardButik.Server.Model;
using GaardButik.Shared.Command;
using Microsoft.EntityFrameworkCore;

namespace GaardButik.Server.Handler
{
    public class FakturaCreateCommandHandler : IFakturaCreateCommandHandler
    {
        private IDatabaseContext databaseContext;
        public FakturaCreateCommandHandler(IDatabaseContext databaseContext) 
        { 
            this.databaseContext = databaseContext;
        }


        public async Task<string> Handle(FakturaCreateCommand command)
        {
            var products = await databaseContext.Instance.Set<Product>().Include(x=> x.Type).Where(x => command.Products.Contains(x.Id)).ToListAsync();
            return GenerateWordFile(command.To, command.Address, products);
        }

        private string GenerateWordFile(string To, string Address, List<Product> products)
        {
            string templatePath = "./Templates/FakturaTemplate.docx";
            string outputPath = "./../var/Faktura.docx";

            System.IO.File.Copy(templatePath, outputPath, true);

            using (WordprocessingDocument doc = WordprocessingDocument.Open(outputPath, true))
            {
                var mainPart = doc.MainDocumentPart;
                var mergeFields = mainPart.RootElement.Descendants<FieldCode>();

                ReplaceMergeField(mergeFields, "ToName ", To);
                ReplaceMergeField(mergeFields, "Address", Address);

                var productRows = mainPart.RootElement.Descendants<TableRow>().Where(r => r.InnerText.Contains("MERGEFIELD Product")).ToList();

                foreach (var row in productRows)
                {
                    TableRow lastRow = row;
                    foreach (var product in products)
                    {
                        TableRow newRow = (TableRow)lastRow.CloneNode(true);
                        ReplaceMergeField(newRow.Descendants<FieldCode>(), "Product", product.Name);
                        ReplaceMergeField(newRow.Descendants<FieldCode>(), "Description", product.Type.Description);
                        ReplaceMergeField(newRow.Descendants<FieldCode>(), "Price", product.Price.ToString() ?? string.Empty);
                        lastRow.InsertAfterSelf(newRow);
                        lastRow = newRow;
                    }
                    row.Remove();
                }

                mainPart.Document.Save();
            }
            return outputPath;
        }

        private static void ReplaceMergeField(IEnumerable<FieldCode> mergeFields, string fieldName, string fieldValue)
        {
            var field = mergeFields.FirstOrDefault(f => f.Text.Contains(fieldName));
            if (field != null)
            {
                Run fieldRun = (Run)field.Parent;

                Run newRun = new Run(new Text(fieldValue));

                fieldRun.Parent.ReplaceChild(newRun, fieldRun);
            }
        }
    }
}
