-- Q1
select P.ProductName , C.CategoryName
from Products P inner join Categories C
on P.CategoryID = C.CategoryID;

--Q2
select O.OrderID, C.CompanyName
from Orders O inner join Customers C
on O.CustomerID = C.CustomerID;

--Q3
select p.ProductName, S.CompanyName
from Products P inner join Suppliers S
on P.SupplierID = S.SupplierID;

-- Q4
select O.OrderID, O.OrderDate, Concat(E.FirstName,E.LastName) as fullname
from Orders O inner join Employees E
on O.EmployeeID = E.EmployeeID;

--Q5
select O.OrderID, S.CompanyName
from Orders O inner join Customers C
on O.CustomerID = C.CustomerID
inner join Shippers S
on O.ShipVia = S.ShipperID
where C.Country = 'France';

--Q6
select C.CategoryName, Sum(P.UnitsInStock) as totalUnitInStock
from Categories C inner join Products P
on C.CategoryID = P.CategoryID
group by C.CategoryName;

--Q7
select C.CompanyName, sum(od.UnitPrice * od.Quantity) as totalMoney
from Orders O inner join [Order Details] od
on O.OrderID = od.OrderID
inner join Customers C
on O.CustomerID = C.CustomerID
group by C.CompanyName;


--Q8
select E.LastName, count(o.OrderID) as totalOrders
from Employees E inner join Orders O
on E.EmployeeID = O.EmployeeID
group by E.LastName;

--Q9
SELECT s.CompanyName,SUM(o.Freight) as totalFrieght
FROM Orders o
INNER JOIN Shippers s
ON o.ShipVia = s.ShipperID
GROUP BY s.CompanyName
ORDER BY totalFrieght DESC;

--Q10
select Top 5 P.ProductName , O.Quantity as quantity
from Products P 
inner join [Order Details] o
on p.ProductID = o.ProductID
group by p.ProductName, O.Quantity
order by O.Quantity desc;

--Q11
select ProductName
from Products 
where UnitPrice > (select avg(UnitPrice) from Products);

--Q12
select concat(e1.FirstName, e1.LastName) as EmployeeName
, concat(e2.FirstName, e2.LastName) as managerName
from Employees e1 left join Employees e2
on e1.ReportsTo = e2.EmployeeID;

--Q13
select C.CompanyName
from Customers C left join Orders O
on C.CustomerID = O.CustomerID
where O.OrderID is null;

--Q14
select O.OrderID , sum(od.Quantity) as totalValue
from Orders O inner join [Order Details] od
on O.OrderID = Od.OrderID
group by O.OrderID
having  sum(od.Quantity) > avg(od.Quantity) ;

--Q15
select distinct p.ProductName
from Products p
left join [Order Details] od 
    on p.ProductID = od.ProductID
left join Orders o 
    on od.OrderID = o.OrderID
    AND o.OrderDate > '1997-12-31'
where o.OrderID IS NULL ;

--Q17
select C.ContactName, S.SupplierID
from Customers C 
inner join Suppliers S
on C.City = S.City;