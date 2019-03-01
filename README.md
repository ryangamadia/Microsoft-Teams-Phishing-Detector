# Microsoft Teams Phishing Detector
Devpost link: https://devpost.com/software/cybersecurity-graph-api-project (submitted to Microsoft Graph Security Hackathon March 2019).
This is a simple way to detect potential malicious links sent through messages on Microsoft Teams channels. Microsoft Teams code is forked from here: 
The algorithm uses the Google SafeBrowsing API to detect whether or not a link contained in a message leads to a potential security threat through phishing or malicious sites. 
The algorithm then leverages the Microsoft Graph API with the Security.ReadWrite function to alert the admin of the channel that a user has posted the unsafe link. 

# How to Use

As the current Microsoft Teams Graph APIs are only accessible by a tenant admin, to run the app, you'll need to sign in with an account with admin privileges.  Note that in most companies, you might not have these rights, nor the ability to grant yourself these rights, therefore you might benefit from a developer account through the [Office 365 Developer program](https://dev.office.com/devprogram).  

You'll need to register an app through the following process:

1. Sign into the [App Registration Portal](https://apps.dev.microsoft.com) using your personal, work or school account.
2. Choose 'Add an app'.
3. Enter a name for the app, and choose 'Create application'.
4. The registration page displays, listing the properties of your app.
   * Copy the Application Id. This is the unique identifier for your app.
5. Under 'Application Secrets', choose 'Generate New Password'.
   * Copy the password from the 'New password generated' dialog.
6. Under 'Platforms', choose 'Add platform'.
7. Choose 'Web'.
8. Make sure 'Allow Implicit Flow' check box is selected, and enter 'Redirect URI' e.g., http://localhost:55069/.  
   * The 'Allow Implicit Flow' option enables the hybrid flow. During authentication, this enables the app to receive both sign-in info (the id_token) and artifacts (in this case, an authorization code) that the app can use to obtain an access token.
9. Under 'Microsoft Graph Permissions', Add 'Group.ReadWrite.All' (Read and write all groups) and 'User.ReadWrite.All' (Read and write all users' full profile), and SecurityEvents.ReadWrite.All as Delegated and Application Permissions.
10. Choose Save.
11. Open "csharp-teams-sample.sln" (located in csharpteams folder) in Microsoft Visual Studio.
12. Get your appid & app secret from the previous section
13. Create Web.config.secrets (put it next to Web.config in source folder in csharpteams folder), and add in your appid and app secret:

```
<?xml version="1.0" encoding="utf-8"?>
  <appSettings >
    <add key="ida:AppId" value="xxxxx"/>
    <add key="ida:AppSecret" value="xxxxx"/>
  </appSettings>
```
14. In Solution Explorer, right-click the name of the Web application project for which you want to specify a Web server, and then click 'Properties'.
15. In the 'Properties' window, click the 'Web' tab.
16. Under 'Servers', update the 'Project Url' with the 'ida:RedirectUri' of your registered app.
17. Click 'Create Virtual Directory'
18. Save the file.
19. Build and run the sample.
20. Sign in with your account, and grant the requested permissions. Note you'll need to have appropriate elevated rights to run the app (Group.ReadWrite.All, User.ReadWrite.All, and SecurityEvents.ReadWrite.All)
21. To test, post a malicious link in the Post Message method. 
22. Go to teams.microsoft.com to see if alert message has been posted in the channel. 

