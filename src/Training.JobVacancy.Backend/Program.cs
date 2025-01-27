using Adaptit.Training.JobVacancy.Backend.Dto;
using Adaptit.Training.JobVacancy.Backend.Endpoints;
using Adaptit.Training.JobVacancy.WebModels;

using Microsoft.AspNetCore.Authentication.OpenIdConnect;

using Refit;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var bearerToken = builder.Configuration.GetValue<string>("FeedApi:Authorization");

builder.Services.AddSingleton<OpenIdConnectOptions>();
builder.Services.AddRefitClient<IFeedApi>()
	.ConfigureHttpClient(c =>
	{
		c.BaseAddress = new Uri("https://pam-stilling-feed.nav.no");
		c.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
	});

builder.Services.AddSingleton<List<Feed>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapFeedEndpoint();
app.MapFeedEntryEndpoint();

app.Run();
