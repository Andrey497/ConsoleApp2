create table key_words
(
id int Primary key IDENTITY(0,1) NOT NULL ,
word nvarchar(50),
context nvarchar(50)
)


create table place
(
id int Primary key IDENTITY(0,1) NOT NULL ,
place_name nvarchar(50),
place_adress nvarchar(100)
)

create table persons 
(
id int primary key identity(0,1) NOT NULL,
person_firstname nvarchar(50),
person_secondname nvarchar(50),
person_middlename nvarchar(50),
)
