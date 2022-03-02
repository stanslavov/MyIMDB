namespace MyIMDB.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using MyIMDB.Data.Common.Repositories;
    using MyIMDB.Data.Models;
    using Xunit;

    public class VotesServiceTests
    {
        [Fact]
        public async Task WhenAnUserVotesMoreThanOnceOnlyTheLastVoteShouldCount()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable);
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback((Vote vote) => list.Add(vote));

            var service = new VotesService(mockRepo.Object);

            await service.SetVoteAsync(1, "1", 1);
            await service.SetVoteAsync(1, "1", 5);
            await service.SetVoteAsync(1, "1", 5);
            await service.SetVoteAsync(1, "1", 5);
            await service.SetVoteAsync(1, "1", 5);

            Assert.Equal(1, list.Count);
            Assert.Equal(5, list.First().Value);
        }

        [Fact]
        public async Task WhenTwoUsersVoteForTheSameMovieTheAverageVoteShouldBeCorrect()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable);
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback((Vote vote) => list.Add(vote));

            var service = new VotesService(mockRepo.Object);

            await service.SetVoteAsync(2, "Gosho", 5);
            await service.SetVoteAsync(2, "Pesho", 1);
            await service.SetVoteAsync(2, "Gosho", 2);

            Assert.Equal(2, list.Count);
            Assert.Equal(1.5, service.GetAverageVote(2));
        }
    }
}
