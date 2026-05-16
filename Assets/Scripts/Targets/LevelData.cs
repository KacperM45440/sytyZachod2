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
    // Hard limity dla umieszczenia targetow to x: -6 do 6, y: -2 do 3

    // Dodajac dialog, mozna uzywac specjalnych znacznikow:
    // *tekst* - tekst wibrujacy, animowany. TYLKO RAZ NA WIERSZ
    // ^ - zwieksza rozmiar czcionki calego wiersza. UZYWAC NA POCZATKU WIERSZA

    public void Level0()
    {
        //Tutorial level:
        //Ma wprowadzic fabule i nauczyc grac

        enemySprite = enemies.cucumberWestern;
        levelSpeed = 0.8f;
        levelSpeedBoosted = 1.2f;
        List<TargetData> table = new()
        {
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop3Sec, spawnLocation = new Vector2(-2f, 0f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop3Sec, spawnLocation = new Vector2(0f, 0f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop3Sec, spawnLocation = new Vector2(2f, 0f), delay = 3f, spawnDelayBoost = true},

            new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUp, spawnLocation = new Vector2(-4f, -1f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUp, spawnLocation = new Vector2(-2f, -1f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUp, spawnLocation = new Vector2(0f, -1f), delay = 3f, spawnDelayBoost = true},

            new TargetData() { targetType = targetType.normal, animation = targetAnimation.upRight, spawnLocation = new Vector2(-2f, -1f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.upRight, spawnLocation = new Vector2(0, -1f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.upRight, spawnLocation = new Vector2(2f, -1f), delay = 3f, spawnDelayBoost = true},

            new TargetData() { targetType = targetType.normal, animation = targetAnimation.rightSpinny, spawnLocation = new Vector2(-2f, 0f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.rightSpinny, spawnLocation = new Vector2(0f, 0f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.rightSpinny, spawnLocation = new Vector2(2f, 0f), delay = 3f, spawnDelayBoost = true},
        };

        finishedTable = table;

        dialogueIntro.Add("Kogo my tu mamy...");
        dialogueIntro.Add("Potomstwo Karotenoidow przyslalo kolejny korzen do wyplewienia.");
        dialogueIntro.Add("Nigdy mnie nie zlapiesz. Ten 6-cio strzalowy rewolwer to za malo by trafic we wszystkie moje tarcze lewym przyciskiem myszy.");
        dialogueIntro.Add("Nawet Jacek Latarnia, ktory wymyslil sztuke przeladowywania prawym przyciskiem myszy lub spacja, nie dal mi rady.");
        dialogueIntro.Add("Ale doceniam twoja odwage. Dam ci jedna szanse z opcja restartow na pokazanie co potrafisz. Sprobuj mnie nie zawiesc.");

        dialogueMiddle.Add("Widze, ze wciaz pamietasz jak sie strzela.");
        dialogueMiddle.Add("Ale strzelanie to za malo. Kazdy szanujacy sie kowboj trafia przynajmniej w 60% wszystkich celow.");
        dialogueMiddle.Add("Nieliczni trafiaja w 80%. Nie chcesz wiedziec, jak koncza ich przeciwnicy...");
        dialogueMiddle.Add("Tak czy inaczej, nadal czeka cie druga runda. Zobaczymy czy nadazasz na przyspieszonej predkosci tarcz.");

        dialogueOutro.Add("Niezle. Kiedys beda z ciebie plony.");
        dialogueOutro.Add("Sprzatnalbym cie juz teraz, ale to nawet nie bylaby uczciwa walka.");
        dialogueOutro.Add("Znajdz mnie gdy bedziesz juz pelen sil. Uroczyscie dokoncze cie raz i na zawsze.");
        dialogueOutro.Add("Moze wtedy twoj rod przestanie mscic sie na mnie zamachowcami za dolara za kilogram...");
        dialogueOutro.Add("Tymczasem, lece na odlegla wyspe. Czeka mnie pewna 'owocna' wspolpraca. Bywaj.");
    }

    public void Level1()
    {
        enemySprite = enemies.banana;
        levelSpeed = 1f;
        levelSpeedBoosted = 1.8f;

        List<TargetData> table = new()
        {
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-4f, -2f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-2f, -1.5f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, -0.5f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(2.5f, 1.5f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, 3f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.triRight, spawnLocation = new Vector2(-4f, -2f), delay = 3f },

            new TargetData() { targetType = targetType.splat, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, 0f), delay = 0.5f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.triRight, spawnLocation = new Vector2(-6f, -1f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.triRight, spawnLocation = new Vector2(-6f, 2f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.triLeft, spawnLocation = new Vector2(6f, -2f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.triLeft, spawnLocation = new Vector2(6f, 1f), delay = 3f },

            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, 1f), delay = 0.5f },
            new TargetData() { targetType = targetType.splat, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, 3f), delay = 0.5f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, -2f), delay = 0.5f },
            new TargetData() { targetType = targetType.splat, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-4f, 0f), delay = 0.5f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, 0f), delay = 0.5f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-4f, 3f), delay = 2f },

            new TargetData() { targetType = targetType.splat, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-4f, 0f), delay = 0f },
            new TargetData() { targetType = targetType.splat, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, 0f), delay = 0f },
            new TargetData() { targetType = targetType.splat, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, 0f), delay = 3f },

            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-4f, -2f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-2f, 0f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, 2f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(2f, 0f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, -2f), delay = 0.5f, spawnDelayBoost = true },

            new TargetData() { targetType = targetType.splat, animation = targetAnimation.dblUp, spawnLocation = new Vector2(0f, 0f), delay = 1.5f }
        };

        finishedTable = table;

        dialogueIntro.Add("Hej, ty! Gapisz mi sie na...");
        dialogueIntro.Add("Ah, no tak! Przeciez to Szeryf Natka! Przyszedles w koncu rozbic nasz gang?");
        dialogueIntro.Add("Nic z tego! Takie sliskie typy jak my nigdy sie nie ugna pod twoim butem!");
        dialogueIntro.Add("Bahamskie podziemie! Poczuj potege ulicy! HWDGMO!");

        dialogueMiddle.Add("Argh! Przeciez wasze pistolety mialy byc tylko na pokaz!");
        dialogueMiddle.Add("A mowila matka: 'Bananek, ogarnij sie bo wiezienie to najlepsze co cie spotka!'");
        dialogueMiddle.Add("Tylko co ma zrobic mlody banan kiedy wszystko co fajne to zakazane?");
        dialogueMiddle.Add("Ale nic. Jak niezgodnie z prawem, to lewa strona jade! Patrz teraz!");

        dialogueOutro.Add("Uff... uff...");
        dialogueOutro.Add("Panie wladzo, moze sie jednak jakos dogadamy?");
    }

    public void Level2()
    {
        enemySprite = enemies.starFruit;
        levelSpeed = 1f;
        levelSpeedBoosted = 1.8f;

        List<TargetData> table = new()
        {
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblDown, spawnLocation = new Vector2(0f, 4f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.triRight, spawnLocation = new Vector2(-6f, 1.5f), delay = 0f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.triLeft, spawnLocation = new Vector2(6f, 1.5f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUpRight, spawnLocation = new Vector2(-2f, -2f), delay = 0f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUpLeft, spawnLocation = new Vector2(2f, -2f), delay = 3f },

            new TargetData() { targetType = targetType.shrink, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, 0f), delay = 2f },

            new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUp, spawnLocation = new Vector2(-6f, -2f), delay = 0f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUp, spawnLocation = new Vector2(-4.5f, -2f), delay = 0f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUp, spawnLocation = new Vector2(-3f, -2f), delay = 1.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(6f, -1f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(4f, -1f), delay = 0.5f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(2f, -1f), delay = 3f },

            new TargetData() { targetType = targetType.normal, animation = targetAnimation.quadLeft, spawnLocation = new Vector2(6f, 1.5f), delay = 0f },
            new TargetData() { targetType = targetType.shrink, animation = targetAnimation.quadRight, spawnLocation = new Vector2(-6f, 0f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.quadLeft, spawnLocation = new Vector2(6f, -1.5f), delay = 3f },

            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, -1.5f), delay = 0f },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, 0f), delay = 0f },
            new TargetData() { targetType = targetType.shrink, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(0f, 2f), delay = 3f },

            new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUp, spawnLocation = new Vector2(0f, -2.5f), delay = 0f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.rightSpinny, spawnLocation = new Vector2(-6f, 0.5f), delay = 0f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.leftSpinny, spawnLocation = new Vector2(6f, 0.5f), delay = 0f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.rightSpinny, spawnLocation = new Vector2(-2f, 3f), delay = 0f, spawnDelayBoost = true },
            new TargetData() { targetType = targetType.normal, animation = targetAnimation.leftSpinny, spawnLocation = new Vector2(2f, 3f), delay = 3f }
        };

        finishedTable = table;

        dialogueIntro.Add("Ahoj, szczurze ladowy!");
        dialogueIntro.Add("Na glebokie wody badz gotowy!");
        dialogueIntro.Add("Kapitana Karambola pokonac dzis nikt nie zdola!");

        dialogueMiddle.Add("Do stu beczek prochu!");
        dialogueMiddle.Add("Czy dla Kapitana, szacunku nie ma trochu?");
        dialogueMiddle.Add("Zaraz przemyje toba poklad!");

        dialogueOutro.Add("Nie uciekne... chocby sily ostatkiem...");
        dialogueOutro.Add("Kapitan zawsze idzie na dno ze swoim statkiem.");
    }

    public void Level3()
    {
        enemySprite = enemies.pineappleCoconut;
        levelSpeed = 1f;
        levelSpeedBoosted = 1.8f;

        List<TargetData> table = new()
        {
            new TargetData() { targetType = targetType.hole, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(-1.5f, 0f), delay = 0f },
            new TargetData() { targetType = targetType.shield, animation = targetAnimation.stop2Sec, spawnLocation = new Vector2(1.5f, 0f), delay = 3f },

            new TargetData() { targetType = targetType.hole, animation = targetAnimation.dblDownLeft, spawnLocation = new Vector2(-1f, 4f), delay = 0f },
            new TargetData() { targetType = targetType.shield, animation = targetAnimation.dblDown, spawnLocation = new Vector2(0f, 4f), delay = 0f },
            new TargetData() { targetType = targetType.hole, animation = targetAnimation.dblDownRight, spawnLocation = new Vector2(1f, 4f), delay = 3f },

            new TargetData() { targetType = targetType.hole, animation = targetAnimation.leftSpinny, spawnLocation = new Vector2(-3f, 1f), delay = 0f, spawnDelayBoost = true},
            new TargetData() { targetType = targetType.shield, animation = targetAnimation.rightSpinny, spawnLocation = new Vector2(-1.5f, 1f), delay = 1.5f, spawnDelayBoost = true},
            new TargetData() { targetType = targetType.shield, animation = targetAnimation.leftSpinny, spawnLocation = new Vector2(3f, -1f), delay = 0f, spawnDelayBoost = true},
            new TargetData() { targetType = targetType.hole, animation = targetAnimation.rightSpinny, spawnLocation = new Vector2(1.5f, -1f), delay = 3f },

            new TargetData() { targetType = targetType.hole, animation = targetAnimation.quadRight, spawnLocation = new Vector2(-6f, 4f), delay = 0f },
            new TargetData() { targetType = targetType.hole, animation = targetAnimation.quadRight, spawnLocation = new Vector2(-6f, 2.5f), delay = 0f },
            new TargetData() { targetType = targetType.hole, animation = targetAnimation.quadRight, spawnLocation = new Vector2(-6f, 1f), delay = 0f },
            new TargetData() { targetType = targetType.hole, animation = targetAnimation.quadRight, spawnLocation = new Vector2(-6f, -0.5f), delay = 0f },
            new TargetData() { targetType = targetType.hole, animation = targetAnimation.quadRight, spawnLocation = new Vector2(-6f, -2f), delay = 4f },

            new TargetData() { targetType = targetType.shield, animation = targetAnimation.quadLeft, spawnLocation = new Vector2(6f, 4f), delay = 1f, spawnDelayBoost = true},
            new TargetData() { targetType = targetType.shield, animation = targetAnimation.quadLeft, spawnLocation = new Vector2(5f, 2.5f), delay = 1f, spawnDelayBoost = true},
            new TargetData() { targetType = targetType.shield, animation = targetAnimation.quadLeft, spawnLocation = new Vector2(4f, 1f), delay = 0f, spawnDelayBoost = true},
            new TargetData() { targetType = targetType.shield, animation = targetAnimation.quadLeft, spawnLocation = new Vector2(4f, -0.5f), delay = 0f, spawnDelayBoost = true},
            new TargetData() { targetType = targetType.shield, animation = targetAnimation.quadLeft, spawnLocation = new Vector2(4f, -2f), delay = 3f },

            new TargetData() { targetType = targetType.shield, animation = targetAnimation.leftThenCircleUp, spawnLocation = new Vector2(-3f, -1f), delay = 0f, spawnDelayBoost = true},
            new TargetData() { targetType = targetType.hole, animation = targetAnimation.rightThenCircleUp, spawnLocation = new Vector2(3f, -1f), delay = 0f, spawnDelayBoost = true},
            new TargetData() { targetType = targetType.hole, animation = targetAnimation.leftThenCircleUp, spawnLocation = new Vector2(-1f, -1f), delay = 0f, spawnDelayBoost = true},
            new TargetData() { targetType = targetType.shield, animation = targetAnimation.rightThenCircleUp, spawnLocation = new Vector2(1f, -1f), delay = 3f },
        };

        finishedTable = table;

        dialogueIntro.Add("Czolem szeryfie! Jestesmy Pina!");
        dialogueIntro.Add("Colada!");
        dialogueIntro.Add("Najtwardsze!");
        dialogueIntro.Add("I najslodsze!");
        dialogueIntro.Add("Zbojcze siostry na bahamach!");
        dialogueIntro.Add("Co dwie tarcze, to nie jedna! Twoja wycieczka wlasnie dobiegla konca!");

        dialogueMiddle.Add("Rety!");
        dialogueMiddle.Add("Jejku!");
        dialogueMiddle.Add("Albo mam piasek we wlosach...");
        dialogueMiddle.Add("Albo ten szeryf sieje pociskami jak wsciekly!");
        dialogueMiddle.Add("Jak smiesz psuc nasze wakacje?! Zakopiemy cie!");

        dialogueOutro.Add("Colado?");
        dialogueOutro.Add("Pino?");
        dialogueOutro.Add("Zaszlo juz slonce...");
        dialogueOutro.Add("Nie slysze szumu fal...");
        dialogueOutro.Add("Zdaje sie... ze balowalysmy za dlugo...");
    }

    public void Level4()
    {
        enemySprite = enemies.dragonFruit;
        levelSpeed = 1f;
        levelSpeedBoosted = 1.8f;

        List<TargetData> table = new();
        finishedTable = table;

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.upRight, spawnLocation = new Vector2(-3f, -1f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.downRight, spawnLocation = new Vector2(0f, 2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(3f, 2f), delay = 1.5f });
        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.rightThenCircleUp, spawnLocation = new Vector2(-3f, 0f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.leftThenCircleDown, spawnLocation = new Vector2(3f, 0f), delay = 3f });

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblDown, spawnLocation = new Vector2(-5f, 2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(4f, 2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.upRight, spawnLocation = new Vector2(-3f, -1f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.upLeft, spawnLocation = new Vector2(3f, -1f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.dblUp, spawnLocation = new Vector2(5f, -1f), delay = 3f });

        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.dblLeft, spawnLocation = new Vector2(0f, 0f), delay = 0f });
        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.dblRight, spawnLocation = new Vector2(0f, -1.5f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop3Sec, spawnLocation = new Vector2(-3f, 1.5f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop3Sec, spawnLocation = new Vector2(0f, 1.5f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.stop3Sec, spawnLocation = new Vector2(3f, 1.5f), delay = 3f });

        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.downRight, spawnLocation = new Vector2(-5f, 2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.upLeft, spawnLocation = new Vector2(-3f, -1f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.downRight, spawnLocation = new Vector2(-1f, 2f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.upLeft, spawnLocation = new Vector2(1f, -1f), delay = 0.5f });
        table.Add(new TargetData() { targetType = targetType.normal, animation = targetAnimation.downRight, spawnLocation = new Vector2(3f, 2f), delay = 3f });

        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.dblUp, spawnLocation = new Vector2(-2f, -1f), delay = 0f });
        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.dblUp, spawnLocation = new Vector2(0f, 0f), delay = 0f });
        table.Add(new TargetData() { targetType = targetType.fast, animation = targetAnimation.dblUp, spawnLocation = new Vector2(2f, -1f), delay = 3f });

        dialogueIntro.Add("Watashi wa... Smo Chi O'Wochi...");
        dialogueIntro.Add("Jestem wyslannikiem klanu Pi-Tai.");
        dialogueIntro.Add("Twoj zywot jest ostatnia przeszkoda na drodze zawarcia sojuszu z Donem Korniszonem");
        dialogueIntro.Add("Dzisiaj zamierzam udowodnic Donowi swoja lojalnosc. Stawaj do walki!");

        dialogueMiddle.Add("Coz za potezny przeciwnik...");
        dialogueMiddle.Add("Pokonam cie nie tylko z obowiazku, ale i z przyjemnosci! Gin!");

        dialogueOutro.Add("Masaka...");
        dialogueOutro.Add("Co za... hanba!");
    }

    public void Level5()
    {
        List<TargetData> table = new();
        finishedTable = table;
    }
}