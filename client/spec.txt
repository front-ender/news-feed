Web client code

Siden skal have en tekstboks og en knap. Når der trykkes på knappen skal indholdet i tekstboksen sendes til /proxy?uri=<uri>, og svaret skal processeres på klientsiden så indholdet vises på passende måde.

I browseren implementeres en news ticker i valgfrit design. Browseren sættes i stand til via ajax requests periodisk at bede serveren om nyt feed indhold. Hvis der er nyt indhold vises dette i tickeren. Tickeren viser brugeren hvornår den sidst har efterspurgt data fra serveren.

Siden bør højst vise et fast antal historier. Dette betyder at der ved indsættelse af en ny historie muligvis skal fjernes en gammel.

Det er ønskværdigt at serveren kun returnerer historier, som browseren ikke tidligere har modtaget.


Ovenstående funktionalitet implementeres eksempelvis ved brug af javascript libraries såsom angularjs, jquery eller lignende.