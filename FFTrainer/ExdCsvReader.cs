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
        public Dictionary<int, Item> Items = null;
        public void MakeItemList()
        {
            Items = new Dictionary<int, Item>();
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
    }
}