
using Adaptit.Training.JobVacancy.Data;
using Adaptit.Training.JobVacancy.Data.Entities;
using Adaptit.Training.JobVacancy.Web.Server.Endpoints.V2;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Moq;

using Xunit;

using Assert = Xunit.Assert;

namespace Adaptit.Training.JobVacancy.Web.Server.Test;

using Adaptit.Training.JobVacancy.Web.Models.Dto.V2;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

public class Tests
{
  [SetUp]
  public void Setup()
  {
  }

  [Fact]
  public async Task GetJobAd_ShouldReturnJobAd()
  {
    // Arrange
    Guid jobAdId1 = Guid.NewGuid();
    Guid jobAdId2 = Guid.NewGuid();
    Guid jobAdId3 = Guid.NewGuid();

    var jobAds = new List<JobAd>
    {
      new() {Id = jobAdId1, Type = JobType.FullTime, SalaryRange = "10000", Description = "Java software engineer", Favorite = true, Location = "Athens", CreatedAt = DateTime.Now, ExpiresAt = DateTime.Now, Level = JobExperienceLevel.Entry},
      new() {Id = jobAdId2, Type = JobType.Contract, SalaryRange = "20000", Description = "Python developer", Favorite = true, Location = "Athens", CreatedAt = DateTime.Now, ExpiresAt = DateTime.Now, Level = JobExperienceLevel.Entry},
      new() {Id = jobAdId3, Type = JobType.FullTime, SalaryRange = "30000", Description = "Business analyst", Favorite = true, Location = "Athens", CreatedAt = DateTime.Now, ExpiresAt = DateTime.Now, Level = JobExperienceLevel.Entry}
    }.AsQueryable();

    var mockSet = new Mock<DbSet<JobAd>>();
        mockSet.As<IQueryable<JobAd>>().Setup(m => m.Provider).Returns(jobAds.Provider);
        mockSet.As<IQueryable<JobAd>>().Setup(m => m.Expression).Returns(jobAds.Expression);
        mockSet.As<IQueryable<JobAd>>().Setup(m => m.ElementType).Returns(jobAds.ElementType);
        mockSet.As<IQueryable<JobAd>>().Setup(m => m.GetEnumerator()).Returns(jobAds.GetEnumerator());

    var mockContext = new Mock<JobVacancyDbContext>(new DbContextOptions<JobVacancyDbContext>());
    mockContext.Setup(c => c.Set<JobAd>()).Returns(mockSet.Object);

    mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>()))
      .ReturnsAsync((object[] keyValues) => jobAds.FirstOrDefault(p => p.Id == (Guid)keyValues[0]));

    ILogger<V2JobAdEndpoints> logger = new Mock<ILogger<V2JobAdEndpoints>>().Object;

    // Act
    var result = await V2JobAdEndpoints.GetJobAd(jobAdId1, mockContext.Object, logger, CancellationToken.None);

    // Assert
    Console.WriteLine(result);

    Assert.IsType<OkResult>(result);
  }
}
