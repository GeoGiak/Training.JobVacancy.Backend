﻿namespace Adaptit.Training.JobVacancy.Data.Entities;

using System;

public class User
{
  public Guid Id { get; set; }

  public string Email { get; set; }

  public string Name { get; set; }

  public string LastName { get; set; }
}
