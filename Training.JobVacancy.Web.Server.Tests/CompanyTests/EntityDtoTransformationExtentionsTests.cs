﻿using Adaptit.Training.JobVacancy.Data.Entities;
using Adaptit.Training.JobVacancy.Web.Models.Dto.V2.Company;
using Adaptit.Training.JobVacancy.Web.Server.Extensions;

using FluentAssertions;

namespace Adaptit.Training.JobVacancy.Web.Server.Tests;
public class EntityDtoTransformationExtentionsTests
{
  [Theory]
  [MemberData(nameof(GetCompanyTestData))]
  public void Company_To_Dto_ReturnsCompanyDto(Company entity, CompanyDto expectedDto)
  {
    var dto = entity.ToDto();

    dto.Should().BeEquivalentTo(expectedDto);
  }

  public static IEnumerable<object[]> GetCompanyTestData()
  {
    yield return
    [
    new Company
      {
        Id = Guid.Parse("c3b510a2-40bd-4b77-85bf-1c871538efb8"),
        Name = "Tech Corp",
        Website = new Uri("https://www.techcorp.com"),
        Vat = "123456789",
        LogoUrl = new Uri("https://www.techcorp.com/logo.png"),
        Address = new Address
        {
          Country = "USA",
          City = "New York",
          Street = "5th Avenue",
          StreetNumber = "123",
          PostalCode = "10001"
        },
        Sponsored = true,
        TotalJobsAdvertised = 25,
        PhoneNumber = "+1-555-123-4567"
      },
      new CompanyDto
      {
        Id = Guid.Parse("c3b510a2-40bd-4b77-85bf-1c871538efb8"),
        Name = "Tech Corp",
        Website = new Uri("https://www.techcorp.com"),
        Vat = "123456789",
        LogoUrl = new Uri("https://www.techcorp.com/logo.png"),
        Address = new AddressDto
        {
          Country = "USA",
          City = "New York",
          Street = "5th Avenue",
          StreetNumber = "123",
          PostalCode = "10001"
        },
        Sponsored = true,
        TotalJobsAdvertised = 25,
        PhoneNumber = "+1-555-123-4567"
      }
    ];

    // Edge Case: Minimal Data
    yield return
    [
    new Company
      {
        Id = Guid.Empty,
        Name = string.Empty,
        Website = null,
        Vat = string.Empty,
        LogoUrl = null,
        Address = new Address
        {
          Country = string.Empty,
          City = string.Empty,
          Street = string.Empty,
          StreetNumber = string.Empty,
          PostalCode = string.Empty
        },
        Sponsored = false,
        TotalJobsAdvertised = 0,
        PhoneNumber = string.Empty
      },
      new CompanyDto
      {
        Id = Guid.Empty,
        Name = string.Empty,
        Website = null,
        Vat = string.Empty,
        LogoUrl = null,
        Address = new AddressDto
        {
          Country = string.Empty,
          City = string.Empty,
          Street = string.Empty,
          StreetNumber = string.Empty,
          PostalCode = string.Empty
        },
        Sponsored = false,
        TotalJobsAdvertised = 0,
        PhoneNumber = string.Empty
      }
    ];

    // Edge Case: Missing Optional Fields
    yield return
    [
    new Company
      {
        Id = Guid.Parse("c410fdcb-c276-4ac0-87fa-16ccc29825b1"),
        Name = "No Logo Inc.",
        Website = null,
        Vat = "987654321",
        LogoUrl = null,
        Address = new Address
        {
          Country = "Canada",
          City = "Toronto",
          Street = "Maple Street",
          StreetNumber = "456",
          PostalCode = "M5H 2N2"
        },
        Sponsored = false,
        TotalJobsAdvertised = 10,
        PhoneNumber = "+1-555-987-6543"
      },
      new CompanyDto
      {
        Id = Guid.Parse("c410fdcb-c276-4ac0-87fa-16ccc29825b1"),
        Name = "No Logo Inc.",
        Website = null,
        Vat = "987654321",
        LogoUrl = null,
        Address = new AddressDto
        {
          Country = "Canada",
          City = "Toronto",
          Street = "Maple Street",
          StreetNumber = "456",
          PostalCode = "M5H 2N2"
        },
        Sponsored = false,
        TotalJobsAdvertised = 10,
        PhoneNumber = "+1-555-987-6543"
      }
    ];
  }

}
