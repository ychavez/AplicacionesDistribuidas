using AutoMapper;
using Moq;
using Ordering.Application.Contracts;
using Ordering.Application.Features.Orders.Commands.Checkout;
using Ordering.Domain.Entities;

namespace Ordering.Test
{
    public class CheckoutTest
    {
        private readonly Mock<IGenericRepository<Order>> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CheckoutOrderCommandHandler _handler;
        public CheckoutTest()
        {
            _repositoryMock = new Mock<IGenericRepository<Order>>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CheckoutOrderCommandHandler(_mapperMock.Object, _repositoryMock.Object);

        }


        [Fact]
        public async Task Handle_ShouldCreateOrder()
        {
            // Arrange
            var request = new CheckoutOrderCommand()
            {
                AddressLine = "Av sempre viva",
                FirstName = "Yael",
                CardName = "Yael",
                CardNumber = "1023456",
                Country = "Mexico",
                CVV = "123",
                EmailAddress = "Yael@gmail.com",
                Expiration = "11/11",
                LastName = "Chavez",
                PaymentMethod = 1,
                State = "Jalisco",
                TotalPrice = 123,
                UserName = "YChavez",
                ZipCode = "112211"
            };

            var order = new Order { Id = 1 };

            _mapperMock.Setup(x => x.Map<Order>(request)).Returns(order);

            _repositoryMock.Setup(x => x.AddAsync(order)).ReturnsAsync(order);


            //Act
            var result = await _handler.Handle(request, CancellationToken.None);


            //Assert
            _mapperMock.Verify(x => x.Map<Order>(request), Times.Once); // verificamos que se haya ejecutado el mapeo
            _repositoryMock.Verify(x => x.AddAsync(order), Times.Once);
            Assert.Equal(1, result);

        }

    }
}
