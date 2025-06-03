                                         
                                              TODO        



                                        backend
1) Поиск
   - не работает 

2) сортировка (по элементу, по убыванию\возрастнаию) 
    - не работает

3) Код убрать из Програм и АутСервис и сделать файлы сеттингс и токенГенерейт
  ( для клеймов и токенов)
  https://metanit.com/sharp/aspnet6/13.2.php
   перенести создание токена в отдельный файл
   
4) Предупреждения по пакетам 

5)  Поменять на sqlite
    Добавить EnsureCreate ?
 

                                      frontend


6) где фронтенд для регистрации? Висит фраза *тут нет ничего*

7) logIn ok но отправляет на home и там висит *войдите под своим логином*

8) погонять по разделению функций в зависимости от группы


############################################################
Bardak666^&*       password for postgres db

CREATE TABLE users
(
    Id uuid PRIMARY KEY,         
    UserName CHARACTER VARYING(30),
    Name CHARACTER VARYING(30),
    Role CHARACTER VARYING(30),
    Password CHARACTER VARYING(30),
    Token CHARACTER VARYING(500),
    IsActive BOOLEAN
);

ALTER TABLE users ALTER COLUMN password TYPE varchar(500);


admin@gmail.com, adminpassword, adminname, admin
visitor2gmail.com, visitor2password, visitor2name, visitor
manager1@gmail, manager1password, manager1name, manager
petrov@gmail.com, petrovpassword, petrov, manager
