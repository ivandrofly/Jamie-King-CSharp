use northwind
select ProductName, ProductID from Products;
--select 5, ProductName, ProductID from Products;
--select ProductID +  ProductID from Products;
select ProductID +  ProductID as MyContraivValues from Products;
-- Note: 'as' is optinal

--# 3-4 SQL DISTINCT Within a SELECT - Retrieving Unique Values 
select distinct CategoryID
from Products

select CategoryID
from Products

select distinct SupplierID, CategoryID
from Products

--# 5 SQL WHERE
select *
from Products where UnitPrice > 30 and UnitsInStock < 10