# Blank Blazor project

Whenever I start a new project, I seem to spend far to long setting up the basic functionality that pretty much every project has.

In order to try and cut down on the amount of time this takes, I started this repository. The idea is that I (or you, or anyone) can download the code, make a few basic changes, and have a working Blazor server-side app with the following features...

- EF Core configured
- Authentication/authorisation implemented for admin and ordinary users using ASP.NET Identity
- Log in and log out configured
- Register new user configured - pending
- Forgotten email - pending
- Email configured and ready to use - pending
- Blazor reconnection is configured, so if the client loses the connection, it will try and reconnect, without the user having to refresh the page

Any points marked "pending" are not yet complete, but hopefully will be as and when I have time.

## Usage

If you want to use this code as a starting point for your new project, you'll need to do the following...

1. Download the code as a zip file and unzip it
2. Rename the solution file to whatever you want
3. Open the solution file in a text editor and change `PixataBlank` to your new project's name
4. Rename the `PixataBlank.Web` folder to match the new project's name
5. Do a find-and-replace in all files of `PixataBlank` to whatever you want to call your new project. You can do this from Visual Studio, using `Edit -> Find & Replace -> Replace in Files` (or Ctrl-Shft-H for those who like keyboard shortcuts)
6. Open `appSettings.json` and change the email settings
7. Open `Program.cs` and change the details for the initial admin user and the initial regular user (if you want to keep that). See the TODO comments there
8. Add a logo for your app. The project is currently missing one, but if you add an image called `logo.png` to the `wwwwroot/images` folder, it should work fine. At the moment, this image is referenced from both `Areas/Identity/Pages/Shared/_IdentityLayout.cshtml` and `Areas/General/Shared/NavMenu.razor`, but I hope to fix that at some point
9. In the Package Manager Console (inside VS), type `update-database`

That should be enough to give you a working app!

If you find any problems with this, or have any suggestions for improvements, please open a new issue.

### Authentication and authorisation

- If you are not logged in, and click either the `Authed` or `Admin only` links in the sidebar, you should get sent to the log in page. 
- If you are logged in, but as a regular user, then you will be able to access `Authed`, but will be shown a message when you try and access `Admin only`.

- If you are logged in as an admin user, you should be able to access both pages.

`NavMenu.razor` also includes two links that only show up when you are logged in, one when logged in as anyone, and another that only shows when logged in as admin. Neither of these have an `href` attribute, so you can't click them, but they are there in case you need them.

And no, the nav menu icons don't have any significance! I just picked random ones from the `IconsHelper` class.

### Note

And before you ask, yes this would be better if it were turned into a project template. However, I haven't managed to get this to work properly, so for the moment, this repository is what I'm using. Even when I do get the template creation working, I'll still keep this repository, to keep track of the code for the template.

## Things to do/investigate

This list is by no means exhaustive, but gives you an idea of what I intend to add, and what potential issues I need to clarify...

- Change the way the layout is specified for Identity pages, to reduce the amount of duplicate code between the two areas
- Same goes for the Guids in the solution file. Is it a problem if multiple solutions use the same Guids?

## Dependencies and other notes

The project is set up to work the way I normally code, which is very likely to be different from the way you code. Feel free to hack it to your heart's content, but here are some tips as to what the project contains...

- I make use of several of [my own Nuget packages](https://www.nuget.org/packages?q=Pixata).
- I include a reference to [LanguageExt](https://github.com/louthy/language-ext/), as I can't imagine coding without it! Also, some of my own packages depend on it, and using them requires you to use it.
- The project currently makes use of the [Telerik UI for Blazor components](https://www.telerik.com/blazor-ui). As far as I know, if you don't have a licence for this, you won't be able to use this project as it stands. However, you could undo the steps required to [add the Telerik Blazor components to an existing project](https://docs.telerik.com/blazor-ui/getting-started/server-blazor#step-2---add-the-telerik-blazor-components-to-an-existing-project), and revert it to a non-Telerik app.
- The `launchSettings.json` file has been excluded from source control. This means that when you get a copy of the repository, VS will create a new `launchSettings.json` file when you first run, which will ensure that you get a new port number. This avoids every project you base on this code will use a different port.