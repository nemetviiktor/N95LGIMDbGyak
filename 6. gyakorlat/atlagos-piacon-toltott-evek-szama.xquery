xquery version "3.0";

let $cars := for $x in doc("https://raw.githubusercontent.com/altova/XPath-XQuery-SQL-Tutorial/master/data/Cars.xml")/CarsDB/Car

let $val:=
for $c in $cars
    let $a:=xs:integer($c/YearTill)-xs:integer($c/YearFrom)
    return
        $a
    
return <Atlagos-piacon-toltott-evek-szama> {avg($val)} </Atlagos-piacon-toltott-evek-szama>