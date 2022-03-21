xquery version "3.0";

let $ett := doc('xml')/N95LGI

for $r in $ett/rendeles
return update insert
    <szamla fk_ekod="{$r/@fk_ekod}">
        <osszeg> {$r/osszeg} </osszeg>
        <etterem> {$r/@fk_ekod} </etterem>
    </szamla>
    into $ett