using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ProdutoModelTests
    {
        [TestMethod]
        public void ProdutoModel_ValidProperties_ShouldPassValidation()
        {
            // Arrange
            var produto = new ProdutoModel
            {
                Id = 1,
                Nome = "Produto Teste",
                Kilos = "1kg",
                Valor = 10.99
            };

            var context = new ValidationContext(produto, null, null);
            var results = new System.Collections.Generic.List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(produto, context, results, true);

            // Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void ProdutoModel_InvalidProperties_ShouldFailValidation()
        {
            // Arrange
            var produto = new ProdutoModelTests();

            var context = new ValidationContext(produto, null, null);
            var results = new System.Collections.Generic.List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(produto, context, results, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("Digite o nome do produto", results[0].ErrorMessage);
            Assert.AreEqual("Digite o peso do produto", results[1].ErrorMessage);
            Assert.AreEqual("Digite o preço do produto", results[2].ErrorMessage);
        }
    }

    internal class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Kilos { get; set; }
        public double Valor { get; set; }
    }
}
