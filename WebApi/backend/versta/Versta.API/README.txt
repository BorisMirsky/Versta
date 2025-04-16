backend работает корректно. Это проверено:
1) дебагом при взаимодействии с фронтендом.
2) Swagger - все 5 методов в порядке. 

Единственная проблема: при ручном обновлении данных (PUT) есть предупреждение (не ошибка)

Cannot write DateTime with Kind=Unspecified to PostgreSQL type 
timestamp with time zone', only UTC is supported.
 Note that it's not possible to mix DateTimes 
with different Kinds in an array, range, or multirange. (Parameter 'value')

Т.е. в поле ДатаВремя надо понять как менять значение. Сделаю немного позже.