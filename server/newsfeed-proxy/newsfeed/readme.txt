Server side code - RSS feed proxy to embedded resource in index.html

Der �nskes en simpel HTTP server skrevet i C#, med f�lgende funktionalitet:



1. Skal v�re baseret p� System.Net.HttpListener
2. Skal kunne h�ndtere multiple samtidige requests
3. Konfigurabel port via app.config
4. /index.htm skal levere en side som beskrevet nedenfor
5. Indholdet af index.htm skal ligge som en embedded resource
6. /proxy?uri=<uri> skal lave et request til <uri> og returnere indholdet
a. Der m� gerne v�lges en anden sti, men der �nskes en begrundelse i s� fald
b. Det er okay at n�jes med at underst�tte XML svar

Der l�gges v�gt p� strukturering af koden - b�de i forhold til komponentificering og udvidbarhed, men ogs� testbarhed.


TO CLARIFY :-

Server.HtmlEncode ref. encoding embedded html
Localization - culture /number formatting?