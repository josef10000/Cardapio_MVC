using System.Net;
using Moq;
using System.Web.Mvc;

namespace Tests_do_projeto
{
    public class UnitTest1
    {
        [Fact]
        public async Task ObterCalorias_DeveRetornarView_CasoRespostaSejaSucesso()
        {
            // Arrange
            string descricao = "exemplo";
            var httpClientMock = new Mock<HttpClient>();
            httpClientMock
                .Setup(c => c.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("[{ 'descricao': 'exemplo', 'calorias': 100 }]"),
                });

            var controller = new CaloriasController
            {
                ControllerContext = new ControllerContext(),
                _httpClient = httpClientMock.Object
            };

            // Act

            // Assert
            var viewResult = Assert.IsType<ViewResult>(await controller.ObterCalorias(descricao));
            Assert.Equal("Calorias", viewResult.ViewName);
        }

        [Fact]
        public async Task ObterCalorias_DeveRetornarViewError_CasoRespostaNaoSejaSucesso()
        {
            // Arrange
            string descricao = "exemplo";
            var httpClientMock = new Mock<HttpClient>();
            httpClientMock
                .Setup(c => c.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest));

            var controller = new CaloriasController
            {
                ControllerContext = new ControllerContext(),
                _httpClient = httpClientMock.Object
            };

            // Act

            // Assert
            var viewResult = Assert.IsType<ViewResult>(await controller.ObterCalorias(descricao));
            Assert.Equal("Error", viewResult.ViewName);
        }
    }

    internal class CaloriasController
    {
        public ControllerContext ControllerContext { get; set; }
        public HttpClient _httpClient { get; set; }

        internal Task<object?> ObterCalorias(string descricao)
        {
            throw new NotImplementedException();
        }
    }
}
