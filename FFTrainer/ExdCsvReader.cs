using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using FFTrainer.Properties;
using GearTuple = System.Tuple<int, int, int>;
using WepTuple = System.Tuple<int, int, int, int>;
using Newtonsoft.Json;

namespace FFTrainer
{

    public class CharaMakeCustomizeFeature
    {
        public int Index { get; set; }
        public int FeatureID { get; set; }
        public System.Drawing.Bitmap Icon { get; set; }
    }
    public class GearSet
    {
        public GearTuple HeadGear { get; set; }
        public GearTuple BodyGear { get; set; }
        public GearTuple HandsGear { get; set; }
        public GearTuple LegsGear { get; set; }
        public GearTuple FeetGear { get; set; }
        public GearTuple EarGear { get; set; }
        public GearTuple NeckGear { get; set; }
        public GearTuple WristGear { get; set; }
        public GearTuple RRingGear { get; set; }
        public GearTuple LRingGear { get; set; }

        public WepTuple MainWep { get; set; }
        public WepTuple OffWep { get; set; }

        public byte[] Customize { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static GearSet FromJson(string json)
        {
            return JsonConvert.DeserializeObject<GearSet>(json);
        }
    }
    public class ExdCsvReader
    {
        public enum ItemType
        {
            Wep,
            Head,
            Body,
            Hands,
            Legs,
            Feet,
            Ears,
            Neck,
            Wrists,
            Ring
        }
        public class Item
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string ModelMain { get; set; }
            public string ModelOff { get; set; }
            public ItemType Type { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class Weather
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }
        public class Emote
        {
            public int Index { get; set; }
            public bool Realist { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
        public class Race
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }
        public class Tribe
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }
        public class Dye
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }
        public class TerritoryType
        {
            public int Index { get; set; }
            public WeatherRate WeatherRate { get; set; }
        }
        public class WeatherRate
        {
            public int Index { get; set; }
            public List<Weather> AllowedWeathers { get; set; }
        }
        public Dictionary<int, Item> Items = null;
        public Dictionary<int, Weather> Weathers = null;
        public Dictionary<int, WeatherRate> WeatherRates = null;
        public Dictionary<int, TerritoryType> TerritoryTypes = null;
        public Dictionary<int, Race> Races = null;
        public Dictionary<int, Tribe> Tribes = null;
        public Dictionary<int, Dye> Dyes = null;
        public Dictionary<int, Emote> Emotes = null;

        public void MakeItemList()
        {
            Items = new Dictionary<int, Item>();
            if (Properties.Settings.Default.Language == "English" || Properties.Settings.Default.Language == "Spanish")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.Item)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        while (!parser.EndOfData)
                        {
                            //Processing row
                            rowCount++;
                            string[] fields = parser.ReadFields();
                            int fCount = 0;

                            int index = 0;
                            var item = new Item();

                            if (rowCount == 1)
                                continue;

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 1)
                                {
                                    int.TryParse(field, out index);
                                }

                                if (fCount == 2)
                                {
                                    item.Name = field;
                                }

                                if (fCount == 17)
                                {
                                    int cat = int.Parse(field);
                                    switch (cat)
                                    {
                                        case 34:
                                            item.Type = ItemType.Head;
                                            break;
                                        case 35:
                                            item.Type = ItemType.Body;
                                            break;
                                        case 37:
                                            item.Type = ItemType.Hands;
                                            break;
                                        case 36:
                                            item.Type = ItemType.Legs;
                                            break;
                                        case 38:
                                            item.Type = ItemType.Feet;
                                            break;
                                        case 41:
                                            item.Type = ItemType.Ears;
                                            break;
                                        case 40:
                                            item.Type = ItemType.Neck;
                                            break;
                                        case 42:
                                            item.Type = ItemType.Wrists;
                                            break;
                                        case 43:
                                            item.Type = ItemType.Ring;
                                            break;
                                        default:
                                            item.Type = ItemType.Wep;
                                            break;
                                    }
                                }

                                if (fCount == 47)
                                {
                                    var tfield = field.Replace(" ", "");
                                    if (item.Type == ItemType.Wep)
                                    {
                                        item.ModelMain = tfield;
                                    }
                                    else
                                    {
                                        item.ModelMain = tfield;
                                    }
                                }

                                if (fCount == 48)
                                {
                                    var tfield = field.Replace(" ", "");
                                    if (item.Type == ItemType.Wep)
                                    {
                                        item.ModelOff = tfield;
                                    }
                                    else
                                    {
                                        item.ModelOff = tfield;
                                    }
                                }
                            }

                            Debug.WriteLine(item.Name + " - " + item.Type);
                            Items.Add(index, item);
                        }
                        Debug.WriteLine($"ExdCsvReader: {rowCount} items read");
                    }
                }
                catch (Exception exc)
                {
                    Items = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "Japanese")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.itemJP)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        while (!parser.EndOfData)
                        {
                            //Processing row
                            rowCount++;
                            string[] fields = parser.ReadFields();
                            int fCount = 0;

                            int index = 0;
                            var item = new Item();

                            if (rowCount == 1)
                                continue;

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 1)
                                {
                                    int.TryParse(field, out index);
                                }

                                if (fCount == 2)
                                {
                                    item.Name = field;
                                }

                                if (fCount == 17)
                                {
                                    int cat = int.Parse(field);
                                    switch (cat)
                                    {
                                        case 34:
                                            item.Type = ItemType.Head;
                                            break;
                                        case 35:
                                            item.Type = ItemType.Body;
                                            break;
                                        case 37:
                                            item.Type = ItemType.Hands;
                                            break;
                                        case 36:
                                            item.Type = ItemType.Legs;
                                            break;
                                        case 38:
                                            item.Type = ItemType.Feet;
                                            break;
                                        case 41:
                                            item.Type = ItemType.Ears;
                                            break;
                                        case 40:
                                            item.Type = ItemType.Neck;
                                            break;
                                        case 42:
                                            item.Type = ItemType.Wrists;
                                            break;
                                        case 43:
                                            item.Type = ItemType.Ring;
                                            break;
                                        default:
                                            item.Type = ItemType.Wep;
                                            break;
                                    }
                                }

                                if (fCount == 47)
                                {
                                    var tfield = field.Replace(" ", "");
                                    if (item.Type == ItemType.Wep)
                                    {
                                        item.ModelMain = tfield;
                                    }
                                    else
                                    {
                                        item.ModelMain = tfield;
                                    }
                                }

                                if (fCount == 48)
                                {
                                    var tfield = field.Replace(" ", "");
                                    if (item.Type == ItemType.Wep)
                                    {
                                        item.ModelOff = tfield;
                                    }
                                    else
                                    {
                                        item.ModelOff = tfield;
                                    }
                                }
                            }

                            Debug.WriteLine(item.Name + " - " + item.Type);
                            Items.Add(index, item);
                        }
                        Debug.WriteLine($"ExdCsvReader: {rowCount} items read");
                    }
                }
                catch (Exception exc)
                {
                    Items = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "German")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.ItemG)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        while (!parser.EndOfData)
                        {
                            //Processing row
                            rowCount++;
                            string[] fields = parser.ReadFields();
                            int fCount = 0;

                            int index = 0;
                            var item = new Item();

                            if (rowCount == 1)
                                continue;

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 1)
                                {
                                    int.TryParse(field, out index);
                                }

                                if (fCount == 2)
                                {
                                    item.Name = field;
                                }

                                if (fCount == 17)
                                {
                                    int cat = int.Parse(field);
                                    switch (cat)
                                    {
                                        case 34:
                                            item.Type = ItemType.Head;
                                            break;
                                        case 35:
                                            item.Type = ItemType.Body;
                                            break;
                                        case 37:
                                            item.Type = ItemType.Hands;
                                            break;
                                        case 36:
                                            item.Type = ItemType.Legs;
                                            break;
                                        case 38:
                                            item.Type = ItemType.Feet;
                                            break;
                                        case 41:
                                            item.Type = ItemType.Ears;
                                            break;
                                        case 40:
                                            item.Type = ItemType.Neck;
                                            break;
                                        case 42:
                                            item.Type = ItemType.Wrists;
                                            break;
                                        case 43:
                                            item.Type = ItemType.Ring;
                                            break;
                                        default:
                                            item.Type = ItemType.Wep;
                                            break;
                                    }
                                }

                                if (fCount == 47)
                                {
                                    var tfield = field.Replace(" ", "");
                                    if (item.Type == ItemType.Wep)
                                    {
                                        item.ModelMain = tfield;
                                    }
                                    else
                                    {
                                        item.ModelMain = tfield;
                                    }
                                }

                                if (fCount == 48)
                                {
                                    var tfield = field.Replace(" ", "");
                                    if (item.Type == ItemType.Wep)
                                    {
                                        item.ModelOff = tfield;
                                    }
                                    else
                                    {
                                        item.ModelOff = tfield;
                                    }
                                }
                            }

                            Debug.WriteLine(item.Name + " - " + item.Type);
                            Items.Add(index, item);
                        }
                        Debug.WriteLine($"ExdCsvReader: {rowCount} items read");
                    }
                }
                catch (Exception exc)
                {
                    Items = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "French")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.item_0_exh_fr)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        while (!parser.EndOfData)
                        {
                            //Processing row
                            rowCount++;
                            string[] fields = parser.ReadFields();
                            int fCount = 0;

                            int index = 0;
                            var item = new Item();

                            if (rowCount == 1)
                                continue;

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 1)
                                {
                                    int.TryParse(field, out index);
                                }

                                if (fCount == 2)
                                {
                                    item.Name = field;
                                }

                                if (fCount == 17)
                                {
                                    int cat = int.Parse(field);
                                    switch (cat)
                                    {
                                        case 34:
                                            item.Type = ItemType.Head;
                                            break;
                                        case 35:
                                            item.Type = ItemType.Body;
                                            break;
                                        case 37:
                                            item.Type = ItemType.Hands;
                                            break;
                                        case 36:
                                            item.Type = ItemType.Legs;
                                            break;
                                        case 38:
                                            item.Type = ItemType.Feet;
                                            break;
                                        case 41:
                                            item.Type = ItemType.Ears;
                                            break;
                                        case 40:
                                            item.Type = ItemType.Neck;
                                            break;
                                        case 42:
                                            item.Type = ItemType.Wrists;
                                            break;
                                        case 43:
                                            item.Type = ItemType.Ring;
                                            break;
                                        default:
                                            item.Type = ItemType.Wep;
                                            break;
                                    }
                                }

                                if (fCount == 47)
                                {
                                    var tfield = field.Replace(" ", "");
                                    if (item.Type == ItemType.Wep)
                                    {
                                        item.ModelMain = tfield;
                                    }
                                    else
                                    {
                                        item.ModelMain = tfield;
                                    }
                                }

                                if (fCount == 48)
                                {
                                    var tfield = field.Replace(" ", "");
                                    if (item.Type == ItemType.Wep)
                                    {
                                        item.ModelOff = tfield;
                                    }
                                    else
                                    {
                                        item.ModelOff = tfield;
                                    }
                                }
                            }

                            Debug.WriteLine(item.Name + " - " + item.Type);
                            Items.Add(index, item);
                        }
                        Debug.WriteLine($"ExdCsvReader: {rowCount} items read");
                    }
                }
                catch (Exception exc)
                {
                    Items = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
        }
        public Item GetItemName(int id)
        {
            if (Items.TryGetValue(id, out Item item))
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public void MakeWeatherList()
        {
            Weathers = new Dictionary<int, Weather>();
            if (Properties.Settings.Default.Language == "English" || Properties.Settings.Default.Language == "Spanish")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.weather_0_exh_en)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            Weather weather = new Weather();

                            //Processing row
                            rowCount++;
                            string[] fields = parser.ReadFields();
                            int fCount = 0;

                            weather.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 3)
                                {
                                    weather.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {weather.Name}");
                            Weathers.Add(weather.Index, weather);
                        }

                        Console.WriteLine($"{rowCount} weathers read");
                    }
                }

                catch (Exception exc)
                {
                    Weathers = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "German")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.weatherDE)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            Weather weather = new Weather();

                            //Processing row
                            rowCount++;
                            string[] fields = parser.ReadFields();
                            int fCount = 0;

                            weather.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 3)
                                {
                                    weather.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {weather.Name}");
                            Weathers.Add(weather.Index, weather);
                        }

                        Console.WriteLine($"{rowCount} weathers read");
                    }
                }

                catch (Exception exc)
                {
                    Weathers = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "Japanese")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.weatherJP)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            Weather weather = new Weather();

                            //Processing row
                            rowCount++;
                            string[] fields = parser.ReadFields();
                            int fCount = 0;

                            weather.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 3)
                                {
                                    weather.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {weather.Name}");
                            Weathers.Add(weather.Index, weather);
                        }

                        Console.WriteLine($"{rowCount} weathers read");
                    }
                }

                catch (Exception exc)
                {
                    Weathers = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "French")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.weather_0_exh_fr)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            Weather weather = new Weather();

                            //Processing row
                            rowCount++;
                            string[] fields = parser.ReadFields();
                            int fCount = 0;

                            weather.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 3)
                                {
                                    weather.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {weather.Name}");
                            Weathers.Add(weather.Index, weather);
                        }

                        Console.WriteLine($"{rowCount} weathers read");
                    }
                }

                catch (Exception exc)
                {
                    Weathers = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
        }

        public void MakeWeatherRateList()
        {
            if (Weathers == null)
                throw new Exception("Weathers has to be loaded for WeatherRates to be read");

            WeatherRates = new Dictionary<int, WeatherRate>();

            try
            {
                using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.weatherrate_exh)))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int rowCount = 0;
                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        WeatherRate rate = new WeatherRate();

                        rate.AllowedWeathers = new List<Weather>();

                        //Processing row
                        rowCount++;
                        string[] fields = parser.ReadFields();

                        rate.Index = int.Parse(fields[0]);

                        for (int i = 1; i < 17;)
                        {
                            int weatherId = int.Parse(fields[i]);

                            if (weatherId == 0)
                                break;

                            rate.AllowedWeathers.Add(Weathers[weatherId]);

                            i += 2;
                        }

                        WeatherRates.Add(rate.Index, rate);
                    }

                    Console.WriteLine($"{rowCount} weatherRates read");
                }
            }
            catch (Exception exc)
            {
                WeatherRates = null;
#if DEBUG
                throw exc;
#endif
            }
        }

        public void MakeTerritoryTypeList()
        {
            if (WeatherRates == null)
                throw new Exception("WeatherRates has to be loaded for TerritoryTypes to be read");

            TerritoryTypes = new Dictionary<int, TerritoryType>();

            try
            {
                using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.territorytype_exh)))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int rowCount = 0;
                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        TerritoryType territory = new TerritoryType();

                        //Processing row
                        rowCount++;
                        string[] fields = parser.ReadFields();
                        int fCount = 0;

                        territory.Index = int.Parse(fields[0]);

                        foreach (string field in fields)
                        {
                            fCount++;

                            if (fCount == 14)
                            {
                                if (field != "0")
                                    territory.WeatherRate = WeatherRates[int.Parse(field)];
                            }
                        }

                        TerritoryTypes.Add(territory.Index, territory);
                    }

                    Console.WriteLine($"{rowCount} TerritoryTypes read");
                }
            }
            catch (Exception exc)
            {
                TerritoryTypes = null;
#if DEBUG
                throw exc;
#endif
            }
        }
        public void RaceList()
        {
            Races = new Dictionary<int, Race>();
            if (Properties.Settings.Default.Language == "English" || Properties.Settings.Default.Language == "Spanish")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.raceEN)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Race race = new Race();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            race.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    race.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {race.Name}");
                            Races.Add(race.Index, race);
                        }

                        Console.WriteLine($"{rowCount} Races read");
                    }
                }

                catch (Exception exc)
                {
                    Races = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "Japanese")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.raceJP)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Race race = new Race();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            race.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    race.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {race.Name}");
                            Races.Add(race.Index, race);
                        }

                        Console.WriteLine($"{rowCount} Races read");
                    }
                }

                catch (Exception exc)
                {
                    Races = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "German")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.raceDE)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Race race = new Race();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            race.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    race.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {race.Name}");
                            Races.Add(race.Index, race);
                        }

                        Console.WriteLine($"{rowCount} Races read");
                    }
                }

                catch (Exception exc)
                {
                    Races = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "French")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.race_exh_fr)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Race race = new Race();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            race.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    race.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {race.Name}");
                            Races.Add(race.Index, race);
                        }

                        Console.WriteLine($"{rowCount} Races read");
                    }
                }

                catch (Exception exc)
                {
                    Races = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
        }
        public void TribeList()
        {
            Tribes = new Dictionary<int, Tribe>();
            if (Properties.Settings.Default.Language == "English" || Properties.Settings.Default.Language == "Spanish")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.tribe_exh_en)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Tribe tribe = new Tribe();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            tribe.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    tribe.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {tribe.Name}");
                            Tribes.Add(tribe.Index, tribe);
                        }

                        Console.WriteLine($"{rowCount} Tribes read");
                    }
                }

                catch (Exception exc)
                {
                    Tribes = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "Japanese")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.tribe_exh_ja)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Tribe tribe = new Tribe();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            tribe.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    tribe.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {tribe.Name}");
                            Tribes.Add(tribe.Index, tribe);
                        }

                        Console.WriteLine($"{rowCount} Tribes read");
                    }
                }

                catch (Exception exc)
                {
                    Tribes = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "German")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.tribe_exh_de)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Tribe tribe = new Tribe();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            tribe.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    tribe.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {tribe.Name}");
                            Tribes.Add(tribe.Index, tribe);
                        }

                        Console.WriteLine($"{rowCount} Tribes read");
                    }
                }

                catch (Exception exc)
                {
                    Tribes = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "French")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.tribe_exh_fr)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Tribe tribe = new Tribe();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            tribe.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 2)
                                {
                                    tribe.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {tribe.Name}");
                            Tribes.Add(tribe.Index, tribe);
                        }

                        Console.WriteLine($"{rowCount} Tribes read");
                    }
                }

                catch (Exception exc)
                {
                    Tribes = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
        }
        public void DyeList()
        {
            Dyes = new Dictionary<int, Dye>();
            if (Properties.Settings.Default.Language == "English" || Properties.Settings.Default.Language == "Spanish")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.stain_exh_en)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Dye dye = new Dye();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            dye.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 4)
                                {
                                    dye.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {dye.Name}");
                            Dyes.Add(dye.Index, dye);
                        }

                        Console.WriteLine($"{rowCount} Dyes read");
                    }
                }

                catch (Exception exc)
                {
                    Dyes = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "Japanese")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.stain_exh_ja)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Dye dye = new Dye();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            dye.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 4)
                                {
                                    dye.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {dye.Name}");
                            Dyes.Add(dye.Index, dye);
                        }

                        Console.WriteLine($"{rowCount} Dyes read");
                    }
                }

                catch (Exception exc)
                {
                    Dyes = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "German")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.stain_exh_de)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Dye dye = new Dye();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            dye.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 4)
                                {
                                    dye.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {dye.Name}");
                            Dyes.Add(dye.Index, dye);
                        }

                        Console.WriteLine($"{rowCount} Dyes read");
                    }
                }

                catch (Exception exc)
                {
                    Dyes = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
            if (Properties.Settings.Default.Language == "French")
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.stain_exh_fr)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Dye dye = new Dye();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            dye.Index = int.Parse(fields[0]);

                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 4)
                                {
                                    dye.Name = field;
                                }
                            }

                            Console.WriteLine($"{rowCount} - {dye.Name}");
                            Dyes.Add(dye.Index, dye);
                        }

                        Console.WriteLine($"{rowCount} Dyes read");
                    }
                }

                catch (Exception exc)
                {
                    Dyes = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
        }
        public void EmoteList()
        {
            Emotes = new Dictionary<int, Emote>();
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(new StringReader(Resources.actiontimeline)))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        int rowCount = 0;
                        parser.ReadFields();
                        while (!parser.EndOfData)
                        {
                            rowCount++;
                            Emote emote = new Emote();
                            //Processing row
                            string[] fields = parser.ReadFields();
                            int fCount = 0;
                            emote.Index = int.Parse(fields[0]);
                            foreach (string field in fields)
                            {
                                fCount++;

                                if (fCount == 8)
                                {
                                    emote.Name = field;
                                }
                            }
                            if (emote.Name.Contains("blownaway/")) { emote.Name = emote.Name.Remove(0, 10).ToString(); emote.Realist = true; }
                            if (emote.Name.Contains("normal/")){emote.Name = emote.Name.Remove(0, 7).ToString(); emote.Realist = true; }
                            if (emote.Name.Contains("gs/")) { emote.Name = emote.Name.Remove(0, 3).ToString(); emote.Realist = true; }
                            if (emote.Name.Contains("cardgame/")|| emote.Name.Contains("emote_sp/")) { emote.Name = emote.Name.Remove(0, 9).ToString(); emote.Realist = true; }
                            if (emote.Name.Contains("pc_contentsaction/")) { emote.Name = emote.Name.Remove(0, 18).ToString(); emote.Realist = true; }
                            if (emote.Name.Contains("ability/")) { emote.Name = emote.Name.Remove(0, 8).ToString(); emote.Realist = true; }
                            if (emote.Name.Contains("emote/")|| emote.Name.Contains("magic/") || emote.Name.Contains("event/") || emote.Name.Contains("music/")) { emote.Name=emote.Name.Remove(0, 6).ToString(); emote.Realist = true; }
                            if (emote.Name.Contains("event_base/")|| emote.Name.Contains("limitbreak/")){ emote.Name = emote.Name.Remove(0, 11).ToString(); emote.Realist = true; }
                            Console.WriteLine($"{rowCount} - {emote.Name}");
                            Emotes.Add(emote.Index, emote);
                        }
                        Console.WriteLine($"{rowCount} Emotes read");
                    }
                }

                catch (Exception exc)
                {
                    Emotes = null;
#if DEBUG
                    throw exc;
#endif
                }
            }
        }
    }
}