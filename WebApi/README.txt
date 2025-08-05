Тестовое задание компании 'Versta24'.
https://versta.io/hr/testfordevjun
Обычное задание, но расширенное и дополненное для демонстрации навыков.



Использованные технологии:

ASP.NET 9
Entity Framework
PostgreSQL
Next JS
Typescript


Отличия от задания
В задании были только POST & GET,  тут полный CRUD + ещё функциональность 
(поиск, сортировка, аутентификация и авторизация)


Три группы пользователей:
- admin (только регистрирует новых юзеров)
- visitor (только просмотр данных - все заказы + каждый по отдельности)
- manager (весь CRUD)


#####################################################################

                                         
                             TODO        

     backend
Поменять БД на sqlite и положить её локально в проект.    
Либо сделать EnsureCreated                                

     frontend
1) Как гарантировать наличие единственного админа?
2) admin -> allorders =-> error
   И вообще надо ещё погонять распределение ролей на фронте, там неидеально
3) AllOrders 'поиск & сортировка' отвалились!
   На бекенде (Swagger) - работают корректно



####################### логины\пароли для существующих юзеров ###################

Bardak666^&*       password for postgres db

admin@gmail.com, adminpassword, adminname, admin
visitor2gmail.com, visitor2password, visitor2name, visitor        ?
manager1@gmail, manager1password, manager1name, manager           ?
petrov@gmail.com, petrovpassword, petrov, manager
chort@gandon.ru, chortpassword, Chort, visitor




