using AutoFixture;
using AutoMapper;
using Moq;
using SistemaVenda.Application.Services;
using SistemaVenda.Domain.Interfaces;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly MockRepository _mockRepository;

        private readonly Mock<IProdutoRepository> _mockProdutoRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ProductService _productService;

        private readonly Fixture _fixture;

        public ProductServiceTests()
        {
            _fixture = new Fixture();
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _productService = new ProductService(_mockProdutoRepository.Object, _mockMapper.Object);

            _mockProdutoRepository = new Mock<IProdutoRepository>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task CreateProduct_ReturnSucess()
        {
            // Arrange
            var product = _fixture.Create<Product>();
           
            // Act
            var result = await _productService.Create(product);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task DeleteProduct_ReturnSucess()
        {
            // Arrange
            var product = _fixture.Create<Product>();

            // Act
            var result = await _productService.Delete(product.Id);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task FindAllProduct_ReturnSucess()
        {
            // Arrange
            var products = _fixture.Create<IEnumerable<Product>>();

            // Act
            var result = await _productService.FindAll();

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task FindByIdProduct_ReturnSucess()
        {
            // Arrange
            var product = _fixture.Create<Product>();

            // Act
            var result = await _productService.FindById(product.Id);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task UpdateProduct_ReturnSucess()
        {
            // Arrange
            var product = _fixture.Create<Product>();

            // Act
            var result = await _productService.Update(product);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task UpdateReservationProduct_ReturnSucess()
        {
            // Arrange
            var product = _fixture.Create<Product>();


            // Act
            var result = await _productService.Update(product.Id, true);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }
    }
}
