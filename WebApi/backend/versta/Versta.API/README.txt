                                         
                                              TODO        



                                        backend
1) �����
   - �� �������� 

2) ���������� (�� ��������, �� ��������\�����������) 
    - �� ��������

3) ��� ������ �� ������� � ��������� � ������� ����� �������� � �������������
  ( ��� ������� � �������)
  https://metanit.com/sharp/aspnet6/13.2.php
   ��������� �������� ������ � ��������� ����
   
4) �������������� �� ������� 

5)  �������� �� sqlite
    �������� EnsureCreate ?
 

                                      frontend


6) ��� �������� ��� �����������? ����� ����� *��� ��� ������*

7) logIn ok �� ���������� �� home � ��� ����� *������� ��� ����� �������*

8) �������� �� ���������� ������� � ����������� �� ������


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
