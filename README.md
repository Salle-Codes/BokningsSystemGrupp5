# BokningsSystemGrupp5

Vid programmets start så presenteras en meny med valen:
- Visa Bokningar
- Boka sal/grupprum
- Redigera bokning
- Avboka
- Lägg till sal/grupprum
- Ta bort sal/grupprum
- Visa info om lokal

Inom menyvalen så kan användaren lägga till och ta bort grupprum eller salar,
boka med val av datum/tid/längd på bokning, hantera bokningarna genom att ändra tid/dag
eller avboka och även lista alla bokningar
med sorteringsalternativ för att sortera med eller utan rummets egenskaper eller lista årsvis.

Programmet begränsas just nu av att om en sal eller grupprum tas bort som har kvar aktiva bokningar
så ligger bokningarna kvar efter att salen/gruppgrummet har tagits bort. Detta har åtgärdats genom
en varning i metoden för att ta bort sal/grupprum.

Programmet är uppbyggt med hänsyn till goda objektorienterings-principer för robust och
strukturerad kod med relevanta klasser, metoder och objekt.
För att göra koden kortare och mer läsbar har vi använt oss av LINQ vid manipuleringen av listor.

Huvudansvar:
Hampus:
Json filhandering read och write, IBookable
metoder: Paus, Nullable, WriteList, Booking, bokningsal, bokninggrupprum, 
IdCheck
Properties och ctor på Sal och grupprum, SwitchCase i main
Victor:
metoder: List, Delete, DisplayRoomInfo, CancelBooking, PrintMenu
Ahmed:
metoder: ChangeBooking
Patrik:
metoder: New

Filformat och struktur:
Vi har valt att använda oss av JsonFil för att den ska kunna vara lättläslig, redigerbar
och mer praktisk att testa. Det kräver inte så stor mängd kod för att kunna ta användning av detta filformat.
Hela lokallistan sparas i Bokning.Json och programmet startas från Program.Cs/Bokningssystem