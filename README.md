# NorthSteelTask
**Задание:**
Имеется 3 поставщика, каждый из поставщиков может поставлять 2 вида груш и 2
вида яблок. Поставщики заранее сообщают свои цены на виды продукции на
определенный период поставок.
Необходимо: а) создать интерфейс приемки поставок от поставщиков. В одной
поставке от поставщика может быть несколько видов продукции.
б) создать отчет. За выбранный период показать поступление видов продукции по
поставщикам с итогами по весу и стоимости.
Требования: данные приложения должны сохранятся в БД (MS SQL или MY SQL),
клиентская часть на C#.
Ответ необходимо предоставить в виде исходных кодов программы +
работающее мини приложение.

Как запустить
---

Приложение требует предварительной конфигурации. В конфигурационном файле **appconfig.json** необходимо указать строку подключения к БД MSSQLServer. По умолчанию приложение требует уже созданной структуры БД. Предусмотрено создание содержимого и структуры базы из приложения. 

Параметры конфигурации
---
"ConnectionStrings": {
    "MainDB": "*Строка подключения к базе данных*"
  },
  
"ContextEnsureCreatedDeleted": true/false в зависимости от необходимости перегенирировать контекст базы из приложения. (Само собой это безумно опасно в текущей реализации, в реальной программе никто не будет сбрасывать базу данных из клиента.)
