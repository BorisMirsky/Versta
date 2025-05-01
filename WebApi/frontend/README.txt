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

   
1) не сохраняет ордер, если поле заметка пустое

2) Delete отвалился
При удалении на Сваггере всё чисто.
При удалении с фронта почему то дёргается метод getOneOrder.

3) стиль (габариты в ширину)
        
4) после создания переходить на oneorder?id=...  

5) Нужна обработка при переходе на страницу с false id
    service/getOne  - try\catch

######################################################################################

5) поиск и сортировка не работают 
  где причина не понимаю

6) roles                                           
   - manager (CRUD)
   - visitor (getOne, getAll)




