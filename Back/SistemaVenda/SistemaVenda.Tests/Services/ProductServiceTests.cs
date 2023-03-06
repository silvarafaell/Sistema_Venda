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
            _mockMapper = new Mock<IMapper>();
            _mockProdutoRepository = new Mock<IProdutoRepository>();
            _productService = new ProductService(_mockProdutoRepository.Object, _mockMapper.Object);                
        }

        [Fact]
        public async Task CreateProduct_ReturnSucess()
        {
            // Arrange
            var product = _fixture.Create<Product>();

            _mockProdutoRepository.Setup(x => x.InsertAsync(product));

            // Act
            var result = await _productService.Create(product);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task CreateProduct_ReturnErro()
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

            _mockProdutoRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(product);

            // Act
            var result = await _productService.Delete(1);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task DeleteProduct_ReturnNotFound()
        {
            // Arrange
            var product = _fixture.Create<Product>();

            // Act
            var result = await _productService.Delete(product.Id);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotNull(result.Result);
            Assert.Null(result.Content);
            Assert.Equal(404, (int)result.StatusCode);
        }

        [Fact]
        public async Task FindAllProduct_ReturnSucess()
        {
            // Arrange
            var products = _fixture.Create<IEnumerable<Product>>();

            _mockProdutoRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _productService.FindAll();

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task FindAllProduct_ReturnNotFound()
        {
            // Arrange
            _mockProdutoRepository.Setup(x => x.GetAllAsync());

            // Act
            var result = await _productService.FindAll();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotNull(result.Result);
            Assert.Null(result.Content);
            Assert.Equal(404, (int)result.StatusCode);
        }

        [Fact]
        public async Task FindByIdProduct_ReturnSucess()
        {
            // Arrange
            var product = _fixture.Create<Product>();

            _mockProdutoRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(product);

            // Act
            var result = await _productService.FindById(1);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Theory]
        [InlineData(0)]
        public async Task FindByIdProduct_ReturnNotFound(int id)
        {
            // Arrange
            var product = _fixture.Create<Product>();

            _mockProdutoRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(product);

            // Act
            var result = await _productService.FindById(id);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotNull(result.Result);
            Assert.Null(result.Content);
            Assert.Equal(404, (int)result.StatusCode);
        }
    }
}
