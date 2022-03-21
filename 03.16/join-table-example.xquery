xquery version "3.0";

let $cars := doc('https://raw.githubusercontent.com/altova/XPath-XQuery-SQL-Tutorial/master/data/Cars.xml')/CarsDB/Car

let $man := doc('https://raw.githubusercontent.com/altova/XPath-XQuery-SQL-Tutorial/master/data/Cars_Manufacturer_Countries.xml')/CCDB/CarCountry

for $res in (
for $c in $cars[Fuel eq "Diesel"], $m in $man
    where $c/Manufacturer eq $m/Manufacturer
    group by $country := $m/Country
    order by count($c/Model) descending
    return $country || count($c/Model)
    )[position() = 1 to 5]

return $res