using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using YG;

public class Lange : MonoBehaviour
{
    public TextMeshProUGUI[] text;

    static string[][] words = new string[5][] {
    // Русский
    new string[] {
        "Скорость", "Емкость", "Количество", "Цена:", "Подсказка", "При нажатии на солнце, открывается древо прокачки",
        "Для открытия новых планет, необходимо прокачать все навыки уже открытых планет до максимума", "Добыча",
        "Вы были АФК  ", " мин", "Забрать", "Просмотреть рекламу за", "Реклама через ", "Таблица Лидеров", "Банк Кристаллов",
        "Предложения дня", "Апгрейды", "- АвтоКликер", "- x2 дохода", "- x2 скорость кораблей",
        "Время бонусов складывается\n\nПример:\n1 час + 5 мин = 65 мин", "час", "Венера", "Меркурий", "Марс", "Юпитер", "Сатурн",
        "Уран", "Нептун", "Земля", "Рука 2 уровня", "Добыча за клик + 1", "Рука 3 уровня", "Добыча за клик + 2", "Новая формула топлива",
        "Увеличенная скорость кораблей", "Дополнительный левый отсек", "Большая вместимость кораблей", "Рука 3 уровня", "Добыча за клик + 5",
        "Дополнительный правый отсек", "Большая вместимость кораблей", "Авто-Добыча", "Добыча руды вне игры", "Большая добыча",
        "Увеличить добычу руды", "Рука 4 уровня", "Увеличить добычу за клик на 10", "Скидка", "Уменьшить цены на улучшения",
        "Рука 5 уровня", "Увеличить добычу за клик на 100", "Быстрая добыча", "Увеличить скорость добычи руды", "Вложения",
        "Разблокировать возможность класть руду под процент", "Необходимо : Изучить все доступные улучшения",
        "Самая быстрая планета, Флеш в солнечной системе", "Горячая планета с атмосферой, будто парилка в сауне, и вечным дымом облаков серной кислоты",
        "Красный сосед с амбициями стать второй землей, где люди мечтают строить первые колонии",
        "Огромный гигант, владыка ветров и штормов, чья мощь сдерживает хаос в системе",
        "Планета с короной из ледяных колец, символ красоты и величия среди соседей",
        "Уникальный странник, который вращается на боку, как будто игнорирует общие правила",
        "Ледяной и глубокий, где бушуют сильнейшие в Солнечной системе штормы и тайны",
        "Космический шар с вечной вечеринкой на ее поверхности", "Вы были АФК", "Таланты", "Магазин", "сек"
    },

    // English
    new string[] {
        "Speed", "Capacity", "Quantity", "Price:", "Hint", "When you click on the sun, the skill tree opens",
        "To unlock new planets, you must upgrade all skills of already opened planets to the maximum", "Mining",
        "You were AFK  ", " min", "Claim", "Watch ad for", "Ad in ", "Leaderboard", "Crystal Bank",
        "Daily Offers", "Upgrades", "- AutoClicker", "- x2 income", "- x2 ship speed",
        "Bonus time is summed\n\nExample:\n1 hr + 5 min = 65 min", "hr", "Venus", "Mercury", "Mars", "Jupiter", "Saturn",
        "Uranus", "Neptune", "Earth", "Hand level 2", "Mining per tap + 1", "Hand level 3", "Mining per tap + 2",
        "New fuel formula", "Increased ship speed", "Additional left compartment", "Greater ship capacity", "Hand level 3",
        "Mining per tap + 5", "Additional right compartment", "Greater ship capacity", "Auto-Mining",
        "Mining while offline", "Big mining", "Increase ore mining", "Hand level 4", "Increase mining per tap by 10",
        "Discount", "Reduce upgrade prices", "Hand level 5", "Increase mining per tap by 100", "Fast mining",
        "Increase ore mining speed", "Investments", "Unlock the ability to deposit ore at interest",
        "Required: Learn all available upgrades", "The fastest planet, the Flash of the Solar System",
        "A hot planet with an atmosphere like a sauna, with eternal clouds of sulfuric acid",
        "Red neighbor with ambitions to become the second Earth, where people dream of building the first colonies",
        "Huge giant, lord of winds and storms, whose power restrains chaos in the system",
        "Planet crowned with icy rings, a symbol of beauty and grandeur among its neighbors",
        "A unique wanderer, which rotates on its side, as if ignoring the rules",
        "Icy and deep, where the strongest storms and mysteries of the Solar System rage",
        "A cosmic ball with an endless party on its surface", "You were AFK", "Talents", "Shop", "sec"
    },

    // Turkish
    new string[] {
        "Hız", "Kapasite", "Miktar", "Fiyat:", "İpucu", "Güneşe tıkladığınızda geliştirme ağacı açılır",
        "Yeni gezegenlerin kilidini açmak için, mevcut gezegenlerin tüm yeteneklerini son seviyeye çıkarmanız gerekiyor", "Kazanç",
        "AFK idiniz  ", " dk", "Topla", "Reklamı izle ve kazan", "Reklam ", "Lider Tablosu", "Kristal Bankası",
        "Günün Teklifleri", "Yükseltmeler", "- Otomatik Tıklayıcı", "- x2 gelir", "- x2 gemi hızı",
        "Bonus süresi toplanır\n\nÖrnek:\n1 saat + 5 dk = 65 dk", "saat", "Venüs", "Merkür", "Mars", "Jüpiter", "Satürn",
        "Uranüs", "Neptün", "Dünya", "El seviye 2", "Tık başına kazanç +1", "El seviye 3", "Tık başına kazanç +2",
        "Yeni yakıt formülü", "Artırılmış gemi hızı", "Ek sol bölme", "Daha büyük gemi kapasitesi", "El seviye 3",
        "Tık başına kazanç +5", "Ek sağ bölme", "Daha büyük gemi kapasitesi", "Otomatik Kazanç",
        "Oyunda değilken kazanç", "Büyük kazanç", "Kazancı artır", "El seviye 4", "Tık başına kazanç +10 artır",
        "İndirim", "Yükseltme fiyatlarını azalt", "El seviye 5", "Tık başına kazanç +100 artır", "Hızlı kazanç",
        "Kazanç hızını artır", "Yatırımlar", "Faizle cevher yatırma özelliğini aç",
        "Gerekli: Tüm mevcut yükseltmeleri öğren", "Güneş sisteminin en hızlı gezegeni - sistemin Flash'ı",
        "Atmosferi sauna gibi sıcak olan ve sürekli sülfürik asit bulutları olan gezegen",
        "Kırmızı komşu, ikinci Dünya olma hırsıyla insanların ilk kolonileri inşa etmeyi hayal ettiği yer",
        "Devasa dev, rüzgarların ve fırtınaların efendisi, gücü kaosu dizginliyor",
        "Buz halkalarla taçlandırılmış gezegen, komşuları arasında güzellik ve ihtişam sembolü",
        "Benzersiz bir gezgin, sanki kuralları umursamadan yana döner",
        "Buzlu ve derin, Güneş Sistemi'nde en güçlü fırtınaların ve sırların olduğu yer",
        "Yüzeyinde hiç bitmeyen bir parti olan kozmik küre", "AFK idiniz", "Yetenekler", "Mağaza",  "sn"
    },

    // Немецкий
    new string[] {
        "Geschwindigkeit", "Kapazität", "Menge", "Preis:", "Tipp", "Beim Klick auf die Sonne öffnet sich der Talentbaum",
        "Um neue Planeten freizuschalten, müssen alle Fähigkeiten bereits geöffneter Planeten auf das Maximum gebracht werden", "Abbau",
        "Du warst AFK  ", " Min", "Abholen", "Werbung ansehen für", "Werbung in ", "Bestenliste", "Kristallbank",
        "Tagesangebote", "Upgrades", "- AutoKlicker", "- x2 Einkommen", "- x2 Schiffsgeschwindigkeit",
        "Bonizeit wird addiert\n\nBeispiel:\n1 Std. + 5 Min = 65 Min", "Std.", "Venus", "Merkur", "Mars", "Jupiter", "Saturn",
        "Uranus", "Neptun", "Erde", "Hand Stufe 2", "Abbau pro Klick +1", "Hand Stufe 3", "Abbau pro Klick +2",
        "Neue Treibstoffformel", "Erhöhte Schiffsgeschwindigkeit", "Zusätzliches linkes Fach", "Größere Schiffskapazität", "Hand Stufe 3",
        "Abbau pro Klick +5", "Zusätzliches rechtes Fach", "Größere Schiffskapazität", "Auto-Abbau",
        "Abbau während Abwesenheit", "Großer Abbau", "Abbau steigern", "Hand Stufe 4", "Abbau pro Klick um 10 erhöhen",
        "Rabatt", "Upgrade-Preise senken", "Hand Stufe 5", "Abbau pro Klick um 100 erhöhen", "Schneller Abbau",
        "Abbaugeschwindigkeit erhöhen", "Investitionen", "Möglichkeit zum Erz-Investieren freischalten",
        "Erforderlich: Alle verfügbaren Upgrades lernen", "Schnellster Planet, das Flash der Sonnensystems",
        "Heißer Planet mit Sauna-Atmosphäre und ewigen Schwefelsäurewolken",
        "Roter Nachbar mit Ambitionen, die zweite Erde zu werden, wo Menschen von den ersten Kolonien träumen",
        "Riesiger Gigant, Herr der Winde und Stürme, dessen Macht das Chaos im System in Schach hält",
        "Planet mit eisigen Ringen als Krone, Symbol für Schönheit und Größe unter den Nachbarn",
        "Einzigartiger Wanderer, der sich seitlich dreht, als würde er die Regeln ignorieren",
        "Eisig und tief, wo die stärksten Stürme und Geheimnisse des Sonnensystems toben",
        "Kosmische Kugel mit ewiger Party auf der Oberfläche", "Du warst AFK", "Talente", "Geschäft", "Sek"
    },

    // Испанский
    new string[] {
        "Velocidad", "Capacidad", "Cantidad", "Precio:", "Consejo", "Al hacer clic en el sol, se abre el árbol de mejoras",
        "Para desbloquear nuevos planetas, necesitas mejorar al máximo todas las habilidades de los planetas desbloqueados", "Extracción",
        "Has estado AFK  ", " min", "Recoger", "Ver anuncio por", "Anuncio en ", "Tabla de Líderes", "Banco de Cristales",
        "Ofertas del día", "Mejoras", "- AutoClic", "- x2 ingresos", "- x2 velocidad de naves",
        "El tiempo de bonificación se suma\n\nEjemplo:\n1 h + 5 min = 65 min", "h", "Venus", "Mercurio", "Marte", "Júpiter", "Saturno",
        "Urano", "Neptuno", "Tierra", "Mano nivel 2", "Extracción por click +1", "Mano nivel 3", "Extracción por click +2",
        "Nueva fórmula de combustible", "Aumentada velocidad de naves", "Compartimiento izquierdo adicional", "Mayor capacidad de naves", "Mano nivel 3",
        "Extracción por click +5", "Compartimiento derecho adicional", "Mayor capacidad de naves", "Auto-Extracción",
        "Extracción mientras estás fuera", "Gran extracción", "Aumentar la extracción de minerales", "Mano nivel 4", "Aumentar extracción por click en 10",
        "Descuento", "Reducir precios de mejoras", "Mano nivel 5", "Aumentar extracción por click en 100", "Extracción rápida",
        "Aumentar velocidad de extracción de minerales", "Inversiones", "Desbloquear la posibilidad de poner mineral a interés",
        "Necesario: Aprender todas las mejoras disponibles", "El planeta más rápido: el Flash del sistema solar",
        "Planeta caliente con atmósfera de sauna y nubes eternas de ácido sulfúrico",
        "Vecino rojo con ambición de convertirse en la segunda Tierra, donde la gente sueña con construir las primeras colonias",
        "Gran gigante, señor de los vientos y tormentas, cuya fuerza mantiene a raya el caos del sistema",
        "Planeta coronado por anillos de hielo, símbolo de belleza y grandeza entre sus vecinos",
        "Viajero único que gira de lado, como si ignorara las reglas generales",
        "Helado y profundo, donde rugen las tormentas y misterios más poderosos del Sistema Solar",
        "Bola cósmica con una fiesta eterna en su superficie", "Has estado AFK", "Talentos", "Tienda", "seg"
    }
};
    public static string Text(int id)
    {
        string lang = YG2.lang;
        int idLang = 0;
        switch (lang)
        {
            case "ru": idLang = 0; break;
            case "en": idLang = 1; break;
            case "tr": idLang = 2; break;
            case "de": idLang = 3; break;
            case "es": idLang = 4; break;
        }
        return words[idLang][id];
    }

    private void OnEnable()
    {
        YG2.onSwitchLang += Reprint;
        Reprint(YG2.lang);
    }
    private void OnDisable()
    {
        YG2.onSwitchLang -= Reprint;
    }

    public void Reprint(string lang)
    {
        text[0].text = Text(0);  // "Скорость"
        text[1].text = Text(1);  // "Емкость"
        text[2].text = Text(0);  // "Скорость"
        text[3].text = Text(1);  // "Емкость"
        text[4].text = Text(2);  // "Количество"
        text[5].text = Text(3);  // "Цена:"
        text[6].text = Text(3);  // "Цена:"
        text[7].text = Text(3);  // "Цена:"
        text[8].text = Text(3);  // "Цена:"
        text[9].text = Text(3);  // "Цена:"
        text[10].text = Text(67);  // "Магазин" - если есть в массиве с таким индексом
        text[11].text = Text(14);  // "Банк Кристаллов"
        text[12].text = Text(15);  // "Предложения дня"
        text[13].text = Text(16);  // "Апгрейды"
        text[14].text = Text(17);  // "- АвтоКликер"
        text[15].text = Text(18);  // "- x2 дохода"
        text[16].text = Text(19);  // "- x2 скорость кораблей"
        text[17].text = Text(20);  // "Время бонусов складывается..."
        text[18].text = "5 " + Text(9);   // "мин"
        text[19].text = "5 " + Text(9);   // "мин"
        text[20].text = "5 " + Text(9);   // "мин"
        text[21].text = "1 " + Text(21);   // "час"
        text[22].text = "1 " + Text(21);   // "час"
        text[23].text = "1 " + Text(21);   // "час"
        text[24].text = Text(66);  // "Таланты"
        text[25].text = Text(13);  // "Таблица Лидеров"
        text[26].text = Text(3);   // "Цена:"
        text[27].text = Text(3);   // "Цена:"
        text[28].text = Text(11);  // "Просмотреть рекламу за"
        text[29].text = Text(7);   // "Добыча"
        text[30].text = Text(10);  // "Забрать"
        text[31].text = Text(4);   // "Подсказка"
        text[32].text = Text(5);   // "При нажатии на солнце, открывается древо прокачки"
        text[33].text = Text(6);   // "Для открытия новых планет, необходимо прокачать все навыки уже открытых планет до максимума"
    }
}
