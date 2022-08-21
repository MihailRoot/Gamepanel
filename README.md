# Gamepanel
Its first version working panel(under docker)
- How to install:
- !!!INSTALL SDK DOTNET AND ASP.NET!!!
~~~
https://dotnet.microsoft.com/en-us/download/visual-studio-sdks
~~~
- !!!INSTALL DOCKER ON LUNUX SERVER!!!
~~~
https://dotnet.microsoft.com/en-us/download/visual-studio-sdks
~~~
- !!!Clone my repo 
~~~
git clone https://github.com/MihailRoot/Gamepanel.git
~~~
- !!Install dotnet ef(for migrations to database ) and do them
~~~
- dotnet tool install --global dotnet-ef
- dotnet ef database update -Context  ServerContext  
- dotnet ef database update --context panelcontext
~~~
- 1)Download panel on windows(or ubuntu)
- 2)Download panelcontroller from panelcontroller(last realise)

Windows:
- 1)(I recommend you install sql server manager, but you can use mysql) and then you need to write your datas to file: Gamepanel/applications.json
- like  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=panel.Data;Trusted_Connection=True;MultipleActiveResultSets=true",
- 2)In file Gamepanel\Views\Details.cs replace new WebSocket('ws://0.0.0.0:3000/'); on your server adress(where panelcontroller) 
- 3)Run dotner run in file ../Gamepanel/

Links:
- sql server manager:
~~~
https://dotnet.microsoft.com/en-us/download/visual-studio-sdks
~~~


P.S its not complited info about panel, please wait,linux will be support soon
