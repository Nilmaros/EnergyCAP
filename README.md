# EnergyCAP
A live website can be found hosted in Azure: https://ecap.azurewebsites.net/

To run locally, ensure you have created an OAuth Application in Github: https://github.com/settings/applications/new. Where both Homepage URL and Authorization callback URL should be the same.
Once you have created it, make a copy of the ClientId and a generated ClientSecret and replace them in the appsettings.json file.

## Login
You can create a new username and password or a Github account to authenticate. This information will be stored in the database.

## Follow-up

The purpose of this section is to give an overview of the next steps for this solution.

### If a license contains "GPL"

The code currently selects the first license, if any, in the JSON response to the Github API. We would divide the exercise in the following:

1. Find a way to concatenate all licenses found, such as: "MIT, GPL, GNU", and showcast them in the front-end.
2. For repositories containing "GPL", extract the key phrases using the cognitive services from Microsoft: https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/KeyPhrases.
3. Search similar descriptions in non-starred repositories based on the key phrases from the previous step and store them.
4. Front-end should then show all starred repositories plus a drop-down of similar repositories for those containing "GPL" license.

### Improve username respositories on load

Instead of having to type in the username after authenticating, add extra logic in the Startup.cs so it also saves the Github username in the database when a new user is created, so when it loads it automatically loads this data.
