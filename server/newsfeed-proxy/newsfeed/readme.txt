Server side code - RSS feed proxy to embedded resource in index.html

Der ønskes en simpel HTTP server skrevet i C#, med følgende funktionalitet:



1. Skal være baseret på System.Net.HttpListener
2. Skal kunne håndtere multiple samtidige requests
3. Konfigurabel port via app.config
4. /index.htm skal levere en side som beskrevet nedenfor
5. Indholdet af index.htm skal ligge som en embedded resource
6. /proxy?uri=<uri> skal lave et request til <uri> og returnere indholdet
a. Der må gerne vælges en anden sti, men der ønskes en begrundelse i så fald
b. Det er okay at nøjes med at understøtte XML svar

Der lægges vægt på strukturering af koden - både i forhold til komponentificering og udvidbarhed, men også testbarhed.


TO CLARIFY :-

Server.HtmlEncode ref. encoding embedded html
Localization - culture /number formatting?