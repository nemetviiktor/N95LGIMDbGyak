xquery version "3.0";

declare function local:discount ($yearFrom) as xs:decimal? {
    let $currentYear := fn:year-from-date(current-date())
    return (xs:integer($currentYear - $yearFrom)) * 0.02
};

let $cars := doc('https://raw.githubusercontent.com/altova/XPath-XQuery-SQL-Tutorial/master/data/Cars.xml')/CarsDB/Car

for $c in $cars
    return $c/Model || (local:discount($c/YearFrom/text())*100)