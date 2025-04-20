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



Текущие проблемы:
1) передалать поведение поля SpecialNote 
2) убрать таймзону при создании Date (backend)
3) UpdateOrder - передавать данные в input правильно, надо так setFieldsValue
4) UpdateOrder & OneOrder: router.query - неправильно, делать через useSearchParams
5) Возможность поиска на странице allorders
6) работа с ролями:
   - админ есть в системе по дефолту
   - он регит манагеров, они могут всё (get all, get one, delete, update, post)
   - просто юзеры только заходят и смотрят (get all, get one)









