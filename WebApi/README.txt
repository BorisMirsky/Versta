Тестовое задание компании 'Versta24'.
https://versta.io/hr/testfordevjun
Обычное задание, но расширенное и дополненное для демонстрации навыков.

В задании надо было сделать только POST & GET. Тут полный CRUD + дополнительная 
функциональность (поиск, сортировка, аутентификация и авторизация, и ещё разное)

Использованные технологии:
ASP.NET 9
Entity Framework
PostgreSQL
Next JS
Typescript
Ant design


Три группы пользователей:
- admin (только регистрирует новых юзеров)
- visitor (только просмотр данных)
- manager (весь CRUD)

По умолчанию в файле контекста в Versta.DataAccess создаётся БД с пользователями, по одному на роль:
admin@gmail.com, adminpassword
manager@gmail.com, managerpassword
visitor@gmail.com, visitorpassword

Чтобы заработало, надо добавить свой пароль на БД PostgreSQL в 'Versta.API.appsettings.json/appsettings.Development.json'



########       TODO      ########                                      

                           
1) AllOrders 'поиск & сортировка' отвалились!
   На бекенде (Swagger) - работают корректно.

2) Убрал отношение между сущностями Roles & Users.
   Вернуть.

3) Корректно, но неидеально отдаёт страницы при CRUD операциях и переходах.

4) При регистрации добавить проверку '@' в шаблоне

5) добавить тесты

6) добавить Cancellation token






            Убрать потом

########   логины\пароли для существующих юзеров в ordersdb    ###################

Bardak666^&*       password for postgres db

admin@gmail.com, adminpassword                                    OK!
visitor2gmail.com, visitor2password, visitor2name, visitor        ?
manager1@gmail, manager1password, manager1name, manager           NO!
petrov@gmail.com, petrovpassword, petrov, manager                 OK!
chort@gandon.ru, chortpassword, Chort, visitor





