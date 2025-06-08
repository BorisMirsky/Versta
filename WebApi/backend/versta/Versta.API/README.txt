                                         
                                              TODO        


                                        _____backend_____
1)  Поменять на sqlite                                        ?
2) сделать миграцию (ensureCreated)                           ?


                                        _____frontend______

1) Kак заносить первого админа ?
2) admin -> allorders =-> error
3) allorders need to add   "|| 'visitor'"  to   " ... (currentRole === 'manager') ? ("
4) убрал ошибки, осталась одна 

                                         _____Общее______
   
1) Поиск  - не работает 
2) сортировка (по элементу, по убыванию\возрастнаию)  - не работает
3) На бекенде поиск работает. Сортировка скорее всего тоже.
   С фронта не доходит


          Работающий поиск и сортировка  C:\Users\Alexander\source\repos\Notes
front
1    Notes - аналог Service т.е. функции исполняющие запросы к серверу
      Там 2 метода - getNotes (с фильтрами) и creataNote
2    Filters - компонент с поиском и сортировкой
3    App  - родительский, всё собирает.

back
Вся функциональность в контроллере (нет разделения на слои)
Папка Контракты - можно глянуть

###################################################################################


admin       - только регистрирует юзеров
visitor     - ограниченная функциональность:
                           видит allorders,
                           oneorder без кнопок изменить\удалить,
                           neworder без кнопок изменить\удалить
manager     - максимальная функциональность (весь CRUD со всеми страницами)









############################################################
Bardak666^&*       password for postgres db

admin@gmail.com, adminpassword, adminname, admin
visitor2gmail.com, visitor2password, visitor2name, visitor        ?
manager1@gmail, manager1password, manager1name, manager           ?
petrov@gmail.com, petrovpassword, petrov, manager
chort@gandon.ru, chortpassword, Chort, visitor



{
  "email": "petrov@gmail.com",
  "password": "petrovpassword"
}

{
  "email": "chort@gandon.ru",
  "password": "chortpassword"
}

{
  "email": "admin@gmail.com",
  "password": "adminpassword"
}


{
  "email": "bert@mail.kz",
  "password": "bertpassword"
}

