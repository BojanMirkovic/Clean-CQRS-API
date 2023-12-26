//using Application.Queries.Cats.GetAllCats;
//using Domain.Models.AnimalModel;
//using FakeItEasy;
//using Infrastructure.Repositories.Cats;

//namespace Test.CatTests.QueryTest
//{
//    [TestFixture]
//    public class GetAllCatsTest
//    {
//        [Test]
//        public async Task Handle_Get_All_Cats_ReturnListAvCats()
//        {
//            List<Cat> cats = new List<Cat>
//            {
//                new Cat { Name = "Tom", Breed = "Domestic Cat", Weight = 3, LikesToPlay = false},
//                new Cat { Name = "Felix", Breed = "Domestic Cat", Weight = 4, LikesToPlay = true},
//            };

//            var catRepository = A.Fake<ICatRepository>();

//            var handler = new GetAllCatsQueryHandler(catRepository);

//            A.CallTo(() => catRepository.GetAllCats()).Returns(cats);

//            var command = new GetAllCatsQuery();

//            // Act
//            var result = await handler.Handle(command, CancellationToken.None);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.That(result, Is.InstanceOf<List<Cat>>()); // result is a list of Cat objects
//            Assert.That(result.Count, Is.EqualTo(cats.Count));
//            CollectionAssert.AreEqual(cats, result);//compare both lists directly for equality
//        }
//    }
//}

