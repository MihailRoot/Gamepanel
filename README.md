# Gamepanel
Its first version working panel(under docker)
- How to install:
  - **!!!INSTALL SDK DOTNET AND ASP.NET!!!**
  - **!!!INSTALL DOCKER on linux server!!!**
  - **!!!Clone my repo** 
~~~
git clone https://github.com/MihailRoot/Gamepanel.git
~~~

- Download panel on windows(or ubuntu)
- Download panelcontroller from [panelcontroller](https://github.com/MihailRoot/panelcontroller)(last realise)

Windows:
- Enter your data to connect to the database in `Gamepanel/appsettings.json`. (I recommend using SQL Server Manager, but you can also use MySQL)
- In file `Gamepanel\Views\Details.cs` replace `new WebSocket('ws://0.0.0.0:3000/');` on your server adress(where panelcontroller) 
- Run `dotnet run` in folder `./Gamepanel`
