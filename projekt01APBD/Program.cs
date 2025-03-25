using projekt01APBD;

// 1. STWORZENIE KONTENEROWCA DANEGO TYPU 2. ZAŁADOWANIE ŁADUNKU DO DANEGO KONTENERA
Console.WriteLine("Punkt 1 i punkt 2");
// a - Kontener na płyny
LKontener lk1 = new LKontener(200, 300, 200, 1000, true);
//lk1.Load(1500);
//lk1.Load(800);
lk1.Load(200);

// b - Kontener na gaz
GKontener gk1 = new GKontener(300, 200, 300, 1200, 800);
//gk1.Load(1300, 10);
//gk1.Load(200,900);
gk1.Load(300,200);

// c - Kontener chłodniczy
CKontener ck1 = new CKontener(350, 200, 300, 1000, 12);
foreach (string prod in ck1.getProductTypes()){
    Console.Write(prod + "  ");
}
Console.WriteLine();
//ck1.Load(200, "Chocolate");
//ck1.Load(1100, "Meat");
ck1.Load(800, "Meat");

// 3. Załadowanie kontenera na statek
Console.WriteLine("Punkt 3");
Kontenerowiec kontenerowiec1 = new Kontenerowiec(300, 10, 10000);
kontenerowiec1.AddKontener(lk1);
//kontenerowiec1.AddKontener(lk1);
kontenerowiec1.AddKontener(gk1);
kontenerowiec1.AddKontener(ck1);

// 4. Załadowanie listy kontenerów na statek
Console.WriteLine("Punkt 4");
LKontener lk2 = new LKontener(200, 300, 200, 1000, false);
lk2.Load(200);
GKontener gk2 = new GKontener(200, 100, 200, 1200, 800);
gk2.Load(200,200);
List<Kontener> listKonteners = new List<Kontener>{lk2, gk2};
kontenerowiec1.AddKonteners(listKonteners);

// 5. Usunięcie kontenera ze statku
Console.WriteLine("Punkt 5");
kontenerowiec1.RemoveKontener(gk2);
kontenerowiec1.RemoveKontener(gk2); // drugi raz usuwam ten sam

// 6. Rozładowanie kontenera
Console.WriteLine("Punkt 6");
lk2.Unload();
Console.WriteLine(lk2.ToString());
gk2.Unload();
Console.WriteLine(gk2.ToString());

// 7. Zastąpienie kontenera na statku o danym numerze innym kontenerem
Console.WriteLine("Punkt 7");
kontenerowiec1.Replace(gk2, lk1);
kontenerowiec1.Replace(gk1, lk1);
kontenerowiec1.Replace(gk1, gk2);

// 8. Możliwość przeniesienia kontenera między dwoma statkami
Console.WriteLine("Punkt 8");
Kontenerowiec kontenerowiec2 = new Kontenerowiec(300, 20, 20000);
lk1.ChangeKontenerowiec(kontenerowiec2);

// 9. Wypisanie informacji o danym kontenerze
Console.WriteLine("Punkt 9");
Console.WriteLine(ck1.ToString());
Console.WriteLine(lk1.ToString());
Console.WriteLine(gk1.ToString());

// 10. Wypisanie informacji o danym statku i jego ładunku
Console.WriteLine("Punkt 10");
Console.WriteLine(kontenerowiec1.ToString());
Console.WriteLine(kontenerowiec2.ToString());