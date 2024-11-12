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




