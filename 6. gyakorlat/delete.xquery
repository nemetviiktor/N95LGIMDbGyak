xquery version "3.0";

let $ett := doc('xml')/N95LGI

for $sz in $ett/szamla[@fk_ekod eq "e2"]
    return update delete $sz