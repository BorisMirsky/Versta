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



##############################################################################

Из пяти методов на фронтенде:
- работает: get all,  get one, post, delete
- делается: put

TODO

                       В 1ю очередь

1) понять и передалать поведение поля SpecialNote 

2) понять и передалать поведение поля Date (backend)
         (убрать таймзону при создании/отображении)

3) UpdateOrder - передавать данные в input правильно, надо так setFieldsValue     ?

5) Delete отвалился 

6) переделать чтобы после создания переходить на oneorder?id=...
   как тут получать id?


                      Во 2ю очередь

1) Возможность поиска на странице allorders

2) работа с ролями:
   - админ есть в системе по дефолту
   - он регит манагеров, они могут всё (get all, get one, delete, update, post)
   - просто юзеры только заходят и смотрят (get all, get one)

3) Нужна обработка при передаче отсутствующего айди






