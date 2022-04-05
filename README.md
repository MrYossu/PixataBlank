# Blank Blazor project

Whenever I start a new project, I seem to spend far to long setting up the basic functionality that pretty much every project has.

In order to try and cut down on the amount of time this takes, I started this repository. The idea is that I (or you, or anyone) can download the code, make a few basic changes, and have a working Blazor server-side app with the following features...

- EF Core configured
- Authentication/authorisation implemented for admin and ordinary users using ASP.NET Identity
- Log in and log out configured
- Register new user configured - pending
- Forgotten email - pending
- Email configured and ready to use - pending

Any points marked "pending" are not yet complete, but hopefully will be as and when I have time.

## Usage

If you want to use this code as a starting point for your new project, you'll need to do the following...

1. Download the code as a zip file and unzip it
2. Rename the solution file to whatever you want
3. Open the solution file in a text editor and change `PixataBlank` to your new project's name
4. Rename the `PixataBlank.Web` folder to match the new project's name
5. Do a find-and-replace in all files of `PixataBlank` to whatever you want to call your new project. You can do this from Visual Studio, using `Edit -> Find & Replace -> Replace in Files` (or Ctrl-Shft-H for those who like keyboard shortcuts)
6. Open `appSettings.json` and change the email settings
7. Open `Program.cs` and change the details for the initial admin user. See the two TODO comments there
8. Add a logo for your app. The project is currently missing one, but if you add an image called `logo.png` to the `wwwwroot/images` folder, it should work fine. At the moment, this image is referenced from both `Areas/Identity/Pages/Shared/_IdentityLayout.cshtml` and `Areas/General/Shared/NavMenu.razor`, but I hope to fix that at some point

That should be enough to give you a working app!

If you don't log in, and click the Authed link in the side bar, you'll get sent to the log in page. If you are logged in, you'll see the (somewhat empty) page.

If you find any problems with this, or have any suggestions for improvements, please open a new issue.

## Things to do/investigate

This list is by no means exhaustive, but gives you an idea of what I intend to add, and what potential issues I need to clarify...

- Change the way the layout is specified for Identity pages, to reduce the amount of duplicate code between the two areas
- I need to check if there will be any conflicts with ports. As I'm cloning an existing repository, does that mean that each one will use the same port? I don't think so, but haven't played enough to check
- Same goes for the Guids in the solution file. Is it a problem if multiple solutions use the same Guids?
- Need to check th elegal and technical issues with the project depending on Telerik (see lower down)

## Dependencies

The project is set up to work the way I normally code, which is very likely to be different from the way you code. Feel free to hack it to your heart's content, but here are some tips as to what the project contains...

- I make use of several of [my own Nuget packages](https://www.nuget.org/packages?q=Pixata).
- I include a reference to [LanguageExt](https://github.com/louthy/language-ext/), as I can't imagine coding without it! Also, some of my own packages depend on it, and using them requires you to use it.
- The project currently makes use of the [Telerik UI for Blazor components](https://www.telerik.com/blazor-ui). I need to check if this will cause a problem for people who don't have a subscription for them.