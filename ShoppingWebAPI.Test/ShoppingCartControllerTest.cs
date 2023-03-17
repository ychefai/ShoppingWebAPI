using Microsoft.AspNetCore.Mvc;
using Moq;
using Shopping.Infrastructure;
using ShoppingWebAPI.Controllers;

namespace ShoppingWebAPI.Test
{
    public class ShoppingCartControllerTest
    {
        private readonly Mock<IShoppingCartRepository> _shoppingCartRepositoryMock;
        private readonly ShoppingCartController _controller;
        public ShoppingCartControllerTest()
        {
            _shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>();
            _controller = new ShoppingCartController(_shoppingCartRepositoryMock.Object);

        }


        [Fact]
        public void Get_ReturnsOkResult_WithAllItems()
        {
            // Arrange
            var items = new List<ShoppingItem>
            {
                new ShoppingItem { Id = Guid.NewGuid(), Name = "Item 1", Manufacturer = "Manufacturer1", Price = 10},
                new ShoppingItem { Id = Guid.NewGuid(), Name = "Item 2", Manufacturer = "Manufacturer2",  Price = 20 },
                new ShoppingItem { Id = Guid.NewGuid(), Name = "Item 3", Manufacturer = "Manufacturer3",  Price = 30 }
            };
            _shoppingCartRepositoryMock.Setup(repo => repo.GetAllItems()).Returns(items);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualItems = Assert.IsAssignableFrom<IEnumerable<ShoppingItem>>(okResult.Value);
            Assert.Equal(items.Count, actualItems.Count());
        }


        [Fact]
        public void Get_ReturnsNotFoundResult_WhenItemNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            _shoppingCartRepositoryMock.Setup(repo => repo.GetById(id)).Returns((ShoppingItem)null);

            // Act
            var result = _controller.Get(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_ReturnsOkResult_WhenItemFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            var item = new ShoppingItem { Id = id, Name = "Item 1", Manufacturer = "Manufacturer1", Price = 10 };
            _shoppingCartRepositoryMock.Setup(repo => repo.GetById(id)).Returns(item);

            // Act
            var result = _controller.Get(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualItem = Assert.IsType<ShoppingItem>(okResult.Value);
            Assert.Equal(item, actualItem);
        }

        [Fact]
        public void Post_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Name", "Name is required");
            var item = new ShoppingItem { Id = Guid.NewGuid(), Name = "", Manufacturer = "Manufacturer1", Price = 10 };

            // Act
            var result = _controller.Post(item);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

       
    }
}