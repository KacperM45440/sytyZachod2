using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetData
{
    public targetType targetType;
    public targetAnimation animation;
    public float delay;
    public Vector2 spawnLocation;
    public bool spawnDelayBoost = false;
}

public enum targetType : int
{
    normal = 0,
    shield = 1,
    hole = 2,
    shrink = 3,
    splat = 4,
    fast = 5
}

public class LevelData
{
    public List<TargetData> finishedTable;
    public List<string> dialogueIntro = new();
    public List<string> dialogueMiddle = new();
    public List<string> dialogueOutro = new();

    public enemies enemySprite;

    public float levelSpeed = 1f;
    public float levelSpeedBoosted = 2f;

    // W tej klasie przechowywane sa dane kazdego poziomu, typ, wlasciwosci, kolejnosc celow oraz przerwy pomiedzy nimi.
    // Hard limity dla umieszczenia targetów to x: -6 do 6, y: -2 do 3

    // Dodaj¹c dialog, mo¿na u¿yæ specjalnych znaczników:
    // *tekst* - tekst wibruj¹cy, animowany. TYLKO RAZ NA WIERSZ
    // ^ - zwiêksza rozmiar czcionki ca³ego wiersza. U¯YÆ NA POCZ¥TKU WIERSZA

    public void Level0()
    {
        //Tutorial level:
        //Ma wprowadziæ fabu³ê i nauczyæ graæ

        enemySprite = enemies.cucumberWestern;
        levelSpeed = 0.8f;
        levelSpeedBoosted = 1.2f;
        List<TargetData> table = new();

        table.Add(new TargetData() { targetType = targetType.shrink, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-3f, -2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblRight, spawnLocation = new Vector2(-3f, -2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(0f, 0.5f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblRight, spawnLocation = new Vector2(3f, 3f), delay = 1.5f });

        finishedTable = table;

        dialogueIntro.Add("Kogo my tu mamy...");
        dialogueIntro.Add("Potomstwo Karotenoidów przys³a³o kolejny korzeñ do wyplewienia.");
        dialogueIntro.Add("Nigdy mnie nie z³apiesz. Ten 6-cio strza³owy rewolwer to za ma³o by trafiæ we wszystkie moje tarcze lewym przyciskiem myszy.");
        dialogueIntro.Add("Nawet Jacek Latarnia, który wymyœli³ sztukê prze³adowywania prawym przyciskiem myszy lub spacj¹, nie da³ mi rady.");
        dialogueIntro.Add("Ale doceniam twoj¹ odwagê. Dam ci jedn¹ szansê z opcj¹ restartów na pokazanie co potrafisz. Spróbuj mnie nie zawieœæ.");

        dialogueMiddle.Add("Widzê, ¿e wci¹¿ pamiêtasz jak siê strzela.");
        dialogueMiddle.Add("Ale strzelanie to za ma³o. Ka¿dy szanuj¹cy siê kowboj trafia przynajmniej w 60% wszystkich celów.");
        dialogueMiddle.Add("Nieliczni trafiaj¹ w 80%. Nie chcesz wiedzieæ, jak koñcz¹ ich przeciwnicy...");
        dialogueMiddle.Add("Tak czy inaczej, nadal czeka ciê druga runda. Zobaczymy czy nad¹¿asz na przyspieszonej prêdkoœci tarcz.");

        dialogueOutro.Add("NieŸle. Kiedyœ bêd¹ z ciebie plony.");
        dialogueOutro.Add("Sprz¹tn¹³bym ciê ju¿ teraz, ale to nawet nie by³aby uczciwa walka.");
        dialogueOutro.Add("ZnajdŸ mnie gdy bêdziesz ju¿ pe³en si³. Uroczyœcie dokoñczê ciê raz i na zawsze.");
        dialogueOutro.Add("Mo¿e wtedy twój ród przestanie mœciæ siê na mnie zamachowcami za dolara za kilogram...");
        dialogueOutro.Add("Tymczasem, lecê na odleg³¹ wyspê. Czeka mnie pewna 'owocna' wspó³praca. Bywaj.");
    }

    public void Level1()
    {
        enemySprite = enemies.banana;
        levelSpeed = 1f;
        levelSpeedBoosted = 1.8f;

        List<TargetData> table = new();

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-4f, -2f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-2f, -1.5f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, -0.5f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(2.5f, 1.5f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, 3f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.triRight, spawnLocation = new Vector2(-4f, -2f), delay = 3f });

        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, 0f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.triRight, spawnLocation = new Vector2(-6f, -1f), delay = 0f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.triRight, spawnLocation = new Vector2(-6f, 2f), delay = 0f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.triLeft, spawnLocation = new Vector2(6f, -2f), delay = 0f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.triLeft, spawnLocation = new Vector2(6f, 1f), delay = 3f });

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, 1f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, 3f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, -2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-4f, 0f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, 0f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-4f, 3f), delay = 2f });

        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-4f, 0f), delay = 0f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, 0f), delay = 0f });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, 0f), delay = 3f });

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-4f, -2f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-2f, 0f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, 2f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(2f, 0f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, -2f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.splat, animation = targetAnimation.dblUp, spawnLocation = new Vector2(0f, 0f), delay = 1.5f });

        finishedTable = table;

        dialogueIntro.Add("Hej, ty! Gapisz mi siê na...");
        dialogueIntro.Add("Ah, no tak! Przecie¿ to Szeryf Natka! Przyszed³eœ w koñcu rozbiæ nasz gang?");
        dialogueIntro.Add("Nic z tego! Takie œliskie typy jak my nigdy siê nie ugn¹ pod twoim butem!");
        dialogueIntro.Add("Bahamskie podziemie! Poczuj potêgê ulicy! HWDGMO!");

        dialogueMiddle.Add("A³a! Przecie¿ wasze pistolety mia³y byæ tylko na pokaz!");
        dialogueMiddle.Add("A mówi³a matka: 'Bananek, ogarnij siê bo wiêzienie to najlepsze co ciê spotka!'");
        dialogueMiddle.Add("Tylko co ma zrobiæ m³ody banan kiedy wszystko co fajne to zakazane?");
        dialogueMiddle.Add("Ale nic. Jak niezgodnie z prawem, to lew¹ stron¹ jadê! Patrz teraz!");

        dialogueOutro.Add("Uff... uff...");
        dialogueOutro.Add("Panie w³adzo, mo¿e siê jednak jakoœ dogadamy?");
    }

    public void Level2()
    {
        enemySprite = enemies.starFruit;
        levelSpeed = 1f;
        levelSpeedBoosted = 1.8f;

        List<TargetData> table = new();

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblDown, spawnLocation = new Vector2(0f, 4f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.triRight, spawnLocation = new Vector2(-6f, 1.5f), delay = 0f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.triLeft, spawnLocation = new Vector2(6f, 1.5f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUpRight, spawnLocation = new Vector2(-2f, -2f), delay = 0f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUpLeft, spawnLocation = new Vector2(2f, -2f), delay = 3f });

        table.Add(new TargetData() { targetType = targetType.shrink, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, 0f), delay = 2f });

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUp, spawnLocation = new Vector2(-6f, -2f), delay = 0f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUp, spawnLocation = new Vector2(-4.5f, -2f), delay = 0f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUp, spawnLocation = new Vector2(-3f, -2f), delay = 1.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(6f, -1f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, -1f), delay = 0.5f, spawnDelayBoost = true });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(2f, -1f), delay = 3f });

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.quadLeft, spawnLocation = new Vector2(6f, 1.5f), delay = 0f });
        table.Add(new TargetData() { targetType = targetType.shrink, animation = targetAnimation.quadRight, spawnLocation = new Vector2(-6f, 0f), delay = 0f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.quadLeft, spawnLocation = new Vector2(6f, -1.5f), delay = 3f });

        finishedTable = table;

        dialogueIntro.Add("Ahoj, szczurze l¹dowy!");

        dialogueMiddle.Add("Do stu beczek prochu! Co za parszywa sztuka!");
        dialogueMiddle.Add("!");

        dialogueOutro.Add("...");
        dialogueOutro.Add("Kapitan zawsze idzie na dno ze swoim statkiem.");
    }

    public void Level3()
    {
        enemySprite = enemies.pineappleCoconut;
        levelSpeed = 1f;
        levelSpeedBoosted = 1.8f;

        List<TargetData> table = new();
        finishedTable = table;

        table.Add(new TargetData() { targetType = targetType.shield, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-4f, -2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.shield, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-2f, -1.5f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.shield, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, -0.5f), delay = 0.5f });
        
        table.Add(new TargetData() { targetType = targetType.hole, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(2.5f, 1.5f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.hole, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, 3f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.hole, animation = targetAnimation.triRight, spawnLocation = new Vector2(-4f, -2f), delay = 3f });

        dialogueIntro.Add("Czo³em szeryfie! Jesteœmy Pina!");
        dialogueIntro.Add("Colada!");
        dialogueIntro.Add("Najtwardsze!");
        dialogueIntro.Add("I najs³odsze!");
        dialogueIntro.Add("Zbójcze siostry na bahamach!");
        dialogueIntro.Add("Co dwie tarcze, to nie jedna! Twoja wycieczka w³aœnie dobieg³a koñca!");

        dialogueMiddle.Add("Rety!");
        dialogueMiddle.Add("Jejku!");
        dialogueMiddle.Add("Albo mam piasek we w³osach...");
        dialogueMiddle.Add("Albo ten szeryf sieje pociskami jak wœciek³y!");
        dialogueMiddle.Add("Jak œmiesz psuæ nasze wakacje?! Zakopiemy ciê!");

        dialogueOutro.Add("Colado?");
        dialogueOutro.Add("Pino?");
        dialogueOutro.Add("Zasz³o ju¿ s³oñce...");
        dialogueOutro.Add("Nie s³yszê szumu fal...");
        dialogueOutro.Add("Zdaje siê... ¿e balowa³yœmy za d³ugo...");
    }

    public void Level4()
    {
        enemySprite = enemies.dragonFruit;
        levelSpeed = 1f;
        levelSpeedBoosted = 1.8f;

        List<TargetData> table = new();
        finishedTable = table;

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUp, spawnLocation = new Vector2(-4f, -2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.dblUp, spawnLocation = new Vector2(-2f, -1.5f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.dblUp, spawnLocation = new Vector2(0f, -0.5f), delay = 0.5f });

        dialogueIntro.Add("Watashi wa... Smo Chi O'Wochi...");
        dialogueIntro.Add("Jestem wys³annikiem klanu Pi-Tai.");
        dialogueIntro.Add("Twój ¿ywot jest ostatni¹ przeszkod¹ na drodze zawarcia sojuszu z Donem Korniszonem");
        dialogueIntro.Add("Dzisiaj zamierzam udowodniæ Donowi swoj¹ lojalnoœæ. Stawaj do walki!");

        dialogueMiddle.Add("Có¿ za potê¿ny przeciwnik...");
        dialogueMiddle.Add("Pokonam ciê nie tylko z obowi¹zku, ale i z przyjemnoœci! Giñ!");

        dialogueOutro.Add("Masaka...");
        dialogueOutro.Add("Co za... hañba!");
    }

    public void Level5()
    {
        List<TargetData> table = new();
        finishedTable = table;
    }
}