# AntiPhish.NET
Discover possible phishing websites from within your application thanks to Phish.ai

## What is it?
AntiPhish.NET is a C# wrapper for the Phish.ai API. This API allows you to check a url and determine whether or not it's a phishing website or the real thing!

The wrapper works at it's core by using multithreaded HTTP requests to send and receive the verification information from Phish.ai.

## How to install?
AntiPhish.NET is packaged in NuGet, to utilize it just add it under your NuGet package manager in Visual Studio or in the Package Manager Console enter `Install-Package AntiPhish.NET`.

## How to use?
In your project that references AntiPhish.NET, all you have to do to validate a website is call `AntiPhish.IsPhishingSite(string urlToCheck)`. For example.
```
using AntiPhishNET;

private void VerifyWebsite(string url)
{
    Assert.That(AntiPhish.IsPhishingSite(url) == false);
}
```

## Caveats
The API can be a bit slow sometimes, perhaps it's an issue on my end or perhaps it's just because checking the site takes a couple seconds. The good news is all methods are multithreaded so while you shouldn't see any UI hangups, it could be slower to respond than most other APIs out there.

I will be actively working to optimize what I can on my end, but at some point it becomes more of an issue for Phish.ai.

## How to contribute
If you find any errors or want a certain feature don't hesitate to create an issue. And if you see an issue and want to take a stab at it by all means submit a PR so I can take a look at it.