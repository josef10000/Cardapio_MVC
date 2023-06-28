using CardapioMVC.Data;
using CardapioMVC.Models;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CardapioMVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApplicationDBContenx _db;

        public ProdutoController(ApplicationDBContenx db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ProdutoModel> produtos = _db.Produtos;

            return View(produtos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ProdutoModel produto = _db.Produtos.FirstOrDefault(x => x.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ProdutoModel produto = _db.Produtos.FirstOrDefault(x => x.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            _db.Produtos.Remove(produto);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cadastrar(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                _db.Produtos.Add(produto);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                _db.Produtos.Update(produto);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        public IActionResult ExportarExcel()
        {
            var produtos = _db.Produtos.ToList();

            if (produtos.Count == 0)
            {
                // Aqui você pode retornar uma mensagem de erro ou redirecionar para outra página
                return RedirectToAction("Index");
            }

            byte[] arquivoExcel = GerarArquivoExcel(produtos);

            // Retorna o arquivo para download
            return File(arquivoExcel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "lista_produtos.xlsx");
        }

        private byte[] GerarArquivoExcel(List<ProdutoModel> listaProdutos)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(memStream, SpreadsheetDocumentType.Workbook);
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Produtos" };
                sheets.Append(sheet);

                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                // Cabeçalhos das colunas
                Row headerRow = new Row();
                headerRow.Append(CreateCell("ID"));
                headerRow.Append(CreateCell("Nome"));
                headerRow.Append(CreateCell("Valor"));

                sheetData.AppendChild(headerRow);

                // Dados dos produtos
                foreach (var produto in listaProdutos)
                {
                    Row dataRow = new Row();
                    dataRow.Append(CreateCell(produto.Id.ToString()));
                    dataRow.Append(CreateCell(produto.Nome));
                    dataRow.Append(CreateCell(text: produto.Valor?.ToString("C")));

                    sheetData.AppendChild(dataRow);
                }

                worksheetPart.Worksheet.Save();

                workbookPart.Workbook.Save();

                // Fecha o documento
                spreadsheetDocument.Close();

                // Volta para o início do fluxo de memória para garantir que o arquivo seja lido a partir do início
                memStream.Position = 0;

                // Lê o conteúdo do fluxo de memória e retorna como um array de bytes
                byte[] arquivoExcel = memStream.ToArray();

                return arquivoExcel;
            }
        }

        private Cell CreateCell(string text)
        {
            return new Cell(new InlineString(new Text(text)));
        }
    }
}
