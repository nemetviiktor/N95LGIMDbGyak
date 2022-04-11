<Query Kind="Statements">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c12aaaaa</ID>
    <NamingService>2</NamingService>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\ChinookDemoDb.sqlite</AttachFileName>
    <DisplayName>Demo database (SQLite)</DisplayName>
    <DriverData>
      <PreserveNumeric1>true</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.Sqlite</EFProvider>
      <MapSQLiteDateTimes>true</MapSQLiteDateTimes>
      <MapSQLiteBooleans>true</MapSQLiteBooleans>
    </DriverData>
  </Connection>
</Query>

var dbContext = this;

Customers.Dump();
Customers.Count().Dump();
Customers.Single(c => c.CustomerId == 2).Dump("ID 2");

dbContext.Customers.Count().Dump("Count");

Customer customer = new Customer()
{
	CustomerId = 10,
	LastName = "Thomas"
};

dbContext.SaveChanges();

dbContext.Customers.Count().Dump("Count");

customer.LastName = "Thomas";
dbContext.SaveChanges();

Customers.Single(x => x.CustomerId == customer.CustomerId).Dump();

