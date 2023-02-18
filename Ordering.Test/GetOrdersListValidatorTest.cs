using Ordering.Application.Features.Orders.Queries.GetOrdersList;

namespace Ordering.Test
{
    public class GetOrdersListValidatorTest
    {

        private readonly GetOrdersListQueryValidator validationRules;
        public GetOrdersListValidatorTest()
        {
            validationRules = new();
        }

        [Theory]
        [InlineData("")]
        [InlineData("as")]
        [InlineData("asdfghjkloiuytrewqasd")]
        public void GetOrdersListQuery_ShouldHaveError(string userName) 
        {

            //Arrange
            var query = new GetOrdersListQuery() { UserName = userName };

            //Act
            var result = validationRules.Validate(query);


            //Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x => x.PropertyName == nameof(GetOrdersListQuery.UserName));
        
        }

        [Theory]
        [InlineData("aas")]
        [InlineData("sdfghjkloiuytrewqasd")]
        public void GetOrdersListQuery_ShouldNotHaveError(string userName)
        {

            //Arrange
            var query = new GetOrdersListQuery() { UserName = userName };

            //Act
            var result = validationRules.Validate(query);


            //Assert
            Assert.True(result.IsValid);
            Assert.DoesNotContain(result.Errors, x => x.PropertyName == nameof(GetOrdersListQuery.UserName));

        }

    }
}
