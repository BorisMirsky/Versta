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

По умолчанию в файле контекста в Versta.DataAccess создаётся БД PostgreSQL с данными пользователей, по одному на роль:
[admin@gmail.com, adminpassword], 
[manager@gmail.com, managerpassword],
[visitor@gmail.com, visitorpassword].

После клонирования пользователю надо добавить свой пароль 
на БД PostgreSQL в 'Versta.API.appsettings.json/appsettings.Development.json'.





                                  TODO                                     

                           
1) Убрал отношения между сущностями Roles & Users.
   Возможно верну.

2) Корректно, но неидеально отдаёт страницы при некоторых переходах.

3) Добавить валидацию вводимых данных, хотя бы только на фронте.

4) Добавить тесты.

5) Добавить Cancellation token и, может быть, кнопку 'Отменить' в некоторых случаях.ы


