         Ставится next
\frontend>npx create-next-app@latest
... project name? ... bookstore
typescript - yes
ESLint  - yes
tailwind css - no
use src directory - no
use app router - yes
customize default import alias - no


     Ставится antd
npm install antd --save


    Чтобы завелся запуск npm run dev надо в терминале (PowerShell разработччика):
Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy Unrestricted


    Добавить в tsconfig.json 
"compilerOptions": {
    "paths": { ..., 
      "react": [ "./node_modules/@types/react" ]
    }
 }


    Добавил как патч (React19 compatibility):
1) npm install @ant-design/v5-patch-for-react-19 --save
2) Import the compatibility package at the application entry:
          import '@ant-design/v5-patch-for-react-19';  


Авторизация с JWT. Сохранение в LocalStorage (не лучший вариант, но тут ок).


##############################################################################



TODO

   
1) Delete отвалился
При удалении на Сваггере всё чисто.
При удалении с фронта почему то вызывается метод getOneOrder.


2) поиск и сортировка с фронта не работают
   Поиск по городу отправки
   Сортировка - сначала новые\старые
   ###
   На сваггере 3 инпута: Search (поиск), SortItem (?), SortOrder (новый\старый)
   
  
3) Login, Registration --> Modal
    Invalid hook call. Hooks can only be called inside of the body of a function component. 
    This could happen for one of the following reasons:
  https://ru.legacy.reactjs.org/warnings/invalid-hook-call-warning.html

4) allorders - переделать поведение при несанкционированном доступе (не те роли либо незалогиненный)

4) Решить вопрос - как заносить первого админа (пока что вручную через админку постгреса)








   Авторизация с помощью JWT-токенов в клиенте JavaScript
   https://metanit.com/sharp/aspnet6/13.3.php
   ВАЖНЫЙ КУСОК, В ЛЮБОМ СЛУЧАЕ НАДО ИСПОЛЬЗОВАТЬ:
           // изменяем содержимое и видимость блоков на странице
           document.getElementById("userName").innerText = data.username;

Вся инфо (токен, содержащий клеймы - строки с данными) должна класться в куки.

https://www.youtube.com/watch?v=HGYEzLQ9mbw
на 5.00 - сделать также !

16.07 !

НАЧИНАЯ С 19.30 - как прикрутить токен к реквесту при обращении к странице
с атрибутом [Authorize]. !!!

