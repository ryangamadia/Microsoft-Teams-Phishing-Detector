# Microsoft-Teams-Phishing-Detector
Devpost link: https://devpost.com/software/cybersecurity-graph-api-project.
This is a simple way to detect potential malicious links sent through messages on Microsoft Teams channels. Microsoft Teams code is forked from here: 
The algorithm uses the Google SafeBrowsing API to detect whether or not a link contained in a message leads to a potential security threat through phishing or malicious sites. 
The algorithm then leverages the Microsoft Graph API with the Security.ReadWrite function to alert the admin of the channel that a user has posted the unsafe link. 

# How to use
Register your app on the Azure Portal
