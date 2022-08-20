# Gamepanel
Its first version working panel(under docker)
- How to install:
- !!!INSTALL SDK DOTNET AND ASP.NET!!!
- !!!INSTALL DOCKER!!!
- !!!Clone my repo 
~~~
git clone https://github.com/MihailRoot/Gamepanel.git
~~~

- 1)Download panel on windows(or ubuntu)
- 2)Download panelcontroller from panelcontroller(last realise)

Windows:
- 1)(I recommend you install sql server manager, but you can use mysql) and then you need to write your datas to file: Gamepanel/applications.json
- 2)In file Gamepanel\Views\Details.cs replace new WebSocket('ws://0.0.0.0:3000/'); on your server adress(where panelcontroller) 
- 3) Run dotner run in file ../Gamepanel/
