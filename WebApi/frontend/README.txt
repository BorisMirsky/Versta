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

TODO

                       В 1ю очередь

3) Delete отвалился                                         BACKEND

4) стиль (габариты в ширину)

5) после создания переходить на oneorder?id=...

7) Нужна обработка при переходе на страницу с false id
    service/getOne  - try\catch

######################################################################################

5) поиск на странице allorders                                BACKEND

6) работа с ролями:                                            BACKEND
   - админ есть в системе по дефолту
   - он регит манагеров, они могут всё (get all, get one, delete, update, post)
   - просто юзеры только заходят и смотрят (get all, get one)




