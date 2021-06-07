# EnergyCAP
A live website can be found hosted in Azure: https://ecap.azurewebsites.net/

To run locally, ensure you have created an OAuth Application in Github: https://github.com/settings/applications/new. Where both Homepage URL and Authorization callback URL should be the same.
Once you have created, make a copy of the ClientId and a generated ClientSecret and replace them in the appsettings.json file.

## Login
You can create a new username and password or a Github account to authenticate. This information will be stored in the database.
