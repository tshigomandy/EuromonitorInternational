SELECT * FROM Vehicle
CREATE DATABASE VehicleInfo
Use VehicleInfo
CREATE TABLE Vehicle (id int primary key, model varchar(100), colour varchar(100), manufacturer varchar(100));
/*drop table SalesHistory*/
CREATE TABLE SalesHistory(year varchar(10), vehiclesSold int, id int Foreign Key References Vehicle(id));

Insert Into Vehicle
Values(1, '1 Series', 'white', 'BMW');
Insert Into SalesHistory
Values('2011', 2991, 1);
Insert Into SalesHistory
Values('2012', 3228, 1);
Insert Into SalesHistory
Values('2013', 7841, 1);
Insert Into SalesHistory
Values('2014', 8458, 1);
Insert Into SalesHistory
Values('2015', 7963, 1);
Insert Into SalesHistory
Values('2016', 5220, 1);
Insert Into SalesHistory
Values('2017', 7043, 1);
Insert Into SalesHistory
Values('2018', 5369, 1);
Insert Into SalesHistory
Values('2019', 3564, 1);
Insert Into SalesHistory
Values('2020', 3646, 1);

Insert Into Vehicle
Values(2, '2 Series', 'black', 'BMW');
Insert Into SalesHistory
Values('2011', 8540, 2);
Insert Into SalesHistory
Values('2012', 5274, 2);
Insert Into SalesHistory
Values('2013', 6995, 2);
Insert Into SalesHistory
Values('2014', 1618, 2);
Insert Into SalesHistory
Values('2015', 3754, 2);
Insert Into SalesHistory
Values('2016', 2048, 2);
Insert Into SalesHistory
Values('2017', 2715, 2);
Insert Into SalesHistory
Values('2018', 3626, 2);
Insert Into SalesHistory
Values('2019', 9052, 2);
Insert Into SalesHistory
Values('2020', 7605, 2);


Insert Into Vehicle
Values(3, '3 Series', 'black', 'BMW');
Insert Into SalesHistory
Values('2011', 6260, 3);
Insert Into SalesHistory
Values('2012', 9637, 3);
Insert Into SalesHistory
Values('2013', 5971, 3);
Insert Into SalesHistory
Values('2014', 2467, 3);
Insert Into SalesHistory
Values('2015', 7512, 3);
Insert Into SalesHistory
Values('2016', 9483, 3);
Insert Into SalesHistory
Values('2017', 7955, 3);
Insert Into SalesHistory
Values('2018', 5098, 3);
Insert Into SalesHistory
Values('2019', 9860, 3);
Insert Into SalesHistory
Values('2020', 9051, 3);


Insert Into Vehicle
Values(4, 'A Class', 'white', 'Mercedes');
Insert Into SalesHistory
Values('2011', 1508, 4);
Insert Into SalesHistory
Values('2012', 8137, 4);
Insert Into SalesHistory
Values('2013', 5572, 4);
Insert Into SalesHistory
Values('2014', 6820, 4);
Insert Into SalesHistory
Values('2015', 1387, 4);
Insert Into SalesHistory
Values('2016', 8517, 4);
Insert Into SalesHistory
Values('2017', 6608, 4);
Insert Into SalesHistory
Values('2018', 6790, 4);
Insert Into SalesHistory
Values('2019', 5956, 4);
Insert Into SalesHistory
Values('2020', 5847, 4);


Insert Into Vehicle
Values(5, 'B Class', 'grey', 'Mercedes');
Insert Into SalesHistory
Values('2011', 2991, 5);
Insert Into SalesHistory
Values('2012', 3228, 5);
Insert Into SalesHistory
Values('2013', 7841, 5);
Insert Into SalesHistory
Values('2014', 8458, 5);
Insert Into SalesHistory
Values('2015', 7963, 5);
Insert Into SalesHistory
Values('2016', 5220, 5);
Insert Into SalesHistory
Values('2017', 7043, 5);
Insert Into SalesHistory
Values('2018', 5369, 5);
Insert Into SalesHistory
Values('2019', 3564, 5);
Insert Into SalesHistory
Values('2020', 3646, 5);

Insert Into Vehicle
Values(6, 'Golf', 'white', 'VW');
Insert Into SalesHistory
Values('2011', 2767, 6);
Insert Into SalesHistory
Values('2012', 4174, 6);
Insert Into SalesHistory
Values('2014', 4398, 6);
Insert Into SalesHistory
Values('2015', 1584, 6);
Insert Into SalesHistory
Values('2016', 9484, 6);
Insert Into SalesHistory
Values('2017', 7953, 6);
Insert Into SalesHistory
Values('2018', 9934, 6);
Insert Into SalesHistory
Values('2019', 2575, 6);
Insert Into SalesHistory
Values('2020', 9300, 6);






/*sold models*/
Select v.model, SUM(s.vehiclesSold) AS 'Sold Models'
from Vehicle v
INNER JOIN SalesHistory s
ON v.id = s.id
GROUP BY v.model;

/*sold manufaturer*/
Select v.manufacturer, SUM(s.vehiclesSold) AS 'Manufaturer Who sold the most'
from Vehicle v
INNER JOIN SalesHistory s
ON v.id = s.id
GROUP BY v.manufacturer
ORDER BY SUM(s.vehiclesSold) DESC;

/*Average sold*/
Select AVG(s.vehiclesSold) AS 'Average Sold'
from Vehicle v
INNER JOIN SalesHistory s
ON v.id = s.id;

SELECT TOP 1 colour
from Vehicle
ORDER BY colour DESC






SELECT * FROM Vehicle 

