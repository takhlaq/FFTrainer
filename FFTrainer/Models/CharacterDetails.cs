using System.Collections.ObjectModel;
using FFTrainer.Converters;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace FFTrainer.Models
{
    public class CharacterDetails : BaseModel
    {

        #region CharacterDetails Enums
        /// <summary>
        /// The Dyes of FFXIVr
        /// </summary>
        [TypeConverter(typeof(EnumDescriptionTypeConverter))]
        public enum Dyes
        {
            None = 0,
            [Description("Snow White Dye")] SnowWhiteDye,
            [Description("Ash Grey Dye")] AshGreyDye,
            [Description("Goobue Grey Dye")] xd1,
            [Description("Slate Grey Dye")] xd2,
            [Description("Charcoal Grey Dye")] xd3,
            [Description("Soot Black Dye")] xd4,
            [Description("Rose Pink Dye")] xd5,
            [Description("Lilac Purple Dye")] xd6,
            [Description("Rolanberry Red Dye")] xd7,
            [Description("Dalamud Red Dye")] xd8,
            [Description("Rolanberry Red Dye")] xd9,
            [Description("Rust Red Dye")] xd10,
            [Description("Wine Red Dye")] xd11,
            [Description("Coral Pink Dye")] xd12,
            [Description("Blood Red Dye")] xd13,
            [Description("Salmon Pink Dye")] xd14,
            [Description("Sunset Red Dye")] xd15,
            [Description("Mesa Red Dye")] xd16,
            [Description("Dark Brown Dye")] xd17,
            [Description("Chocolate Brown Dye")] xd18,
            [Description("Russet Brown Dye")] xd19,
            [Description("Kobold Brown Dye")] xd20,
            [Description("Cork Brown Dye")] xd21,
            [Description("Qiqirn Brown Dye")] xd22,
            [Description("Opo-opo Brown Dye")] xd23,
            [Description("Aldgoat Brown Dye")] xd24,
            [Description("Pumpkin Orange Dye")] xd25,
            [Description("Acorn Brown Dye")] xd26,
            [Description("Orcchard Brown Dye")] xd27,
            [Description("Chestnut Brown Dye")] xd28,
            [Description("Gobbiebag Brown Dye")] xd29,
            [Description("Shale Brown Dye")] xd30,
            [Description("Mole Brown Dye")] xd31,
            [Description("Loam Brown Dye")] xd32,
            [Description("Bone White Dye")] xd33,
            [Description("Ul Brown Dye")] xd34,
            [Description("Desert Yellow Dye")] xd35,
            [Description("Honey Yellow Dye")] xd36,
            [Description("Millioncorn Yellow Dye")] xd37,
            [Description("Coeurl Yellow Dye")] xd38,
            [Description("Cream Yellow Dye")] xd39,
            [Description("Halatali Yellow Dye")] xd40,
            [Description("Raisin Brown Dye")] xd41,
            [Description("Mud Brown Dye")] xd42,
            [Description("Sylph Green Dye")] xd43,
            [Description("Lime Green Dye")] xd44,
            [Description("Moss Green Dye")] xd45,
            [Description("Meadow Green Dye")] xd46,
            [Description("Olive Green Dye")] xd47,
            [Description("Marsh Green Dye")] xd48,
            [Description("Apple Green Dye")] xd49,
            [Description("Cactuar Green Dye")] xd50,
            [Description("Hunter Green Dye")] xd51,
            [Description("Ochu Green Dye")] xd52,
            [Description("Adamantoise Green Dye")] xd53,
            [Description("Nophica Green Dye")] xd54,
            [Description("Deepwood Green Dye")] xd55,
            [Description("Celeste Green Dye")] xd56,
            [Description("Turquoise Green Dye")] xd57,
            [Description("Morbol Green Dye")] xd58,
            [Description("Ice Blue Dye")] xd59,
            [Description("Sky Blue Dye")] xd60,
            [Description("Seafog Blue Dye")] xd61,
            [Description("Peacock Blue Dye")] xd62,
            [Description("Rhotano Blue Dye")] xd63,
            [Description("Corpse Blue Dye")] xd64,
            [Description("Ceruleum Blue Dye")] xd65,
            [Description("Woad Blue Dye")] xd66,
            [Description("Ink Blue Dye")] xd67,
            [Description("Raptor Blue Dye")] xd68,
            [Description("Othard Blue Dye")] xd69,
            [Description("Storm Blue Dye")] xd70,
            [Description("Void Blue Dye")] xd71,
            [Description("Royal Blue Dye")] xd72,
            [Description("Midnight Blue Dye")] xd73,
            [Description("Shadow Blue Dye")] xd74,
            [Description("Abyssal Blue Dye")] xd75,
            [Description("Lavender Purple Dye")] xd76,
            [Description("Gloom Purple Dye")] xd77,
            [Description("Currant Purple Dye")] xd78,
            [Description("Iris Purple Dye")] xd79,
            [Description("Grape Purple Dye")] xd80,
            [Description("Lotus Pink Dye")] xd81,
            [Description("Colibri Pink Dye")] xd82,
            [Description("Plum Purple Dye")] xd83,
            [Description("Regal Purple Dye")] xd84,
            [Description("Pure White Dye")] xd85=101,
            [Description("Jet Black Dye")] xd86,
            [Description("Pastel Pink Dye")] xd87,
            [Description("Dark Red Dye")] xd88,
            [Description("Dark Brown Dye")] xd89,
            [Description("Pastel Green Dye")] xd90,
            [Description("Dark Green Dye")] xd91,
            [Description("Pastel Blue Dye")] xd93,
            [Description("Dark Blue Dye")] xd94,
            [Description("Pastel Purple Dye")] xd95,
            [Description("Dark Purple Dye")] xd96,
            [Description("Metallic Silver Dye")] xd97,
            [Description("Metallic Gold Dye")] xd98,
            [Description("Metallic Red Dye")] xd99,
            [Description("Metallic Orange Dye")] xd100,
            [Description("Metallic Yellow Dye")] xd101,
            [Description("Metallic Green Dye")] xd102,
            [Description("Metallic Sky Blue Dye")] xd103,
            [Description("Metallic Blue Dye")] xd104,
            [Description("Metallic Purple Dye")] xd105,
        }
        /// <summary>
        /// The races of FFXIV
        /// </summary>
        [TypeConverter(typeof(EnumDescriptionTypeConverter))]
        public enum Races
        {
            Hyur = 1,
            Elezen,
            Lalafell,
            [Description("Miqo'te")]
            Miqote,
            Roegadyn,
            [Description("Au Ra")]
            AuRa
        }
        /// <summary>
        /// The Jobs of FFXIV
        /// </summary>
        [TypeConverter(typeof(EnumDescriptionTypeConverter))]
        public enum Jobs
        {
            Paladin = 201,
            Paladin2 = 205,
            Paladin3 = 208,
            Monk = 301,
            MonkCesti = 321,
            MonkKnuckles = 323,
            Warrior = 401,
            Warrior2= 402,
            Warrior3 = 403,
            Warrior4 = 406,
            Warrior5 = 410,
            Warrior6 = 411,
            Dragoon = 501,
            Dragoon2 = 503,
            Dragoon3 = 507,
            Dragoon4 = 510,
            Dragoon5 = 511,
            Dragoon6 = 514,
            Dragoon7 = 515,
            Dragoon8 = 517,
            Bard = 601,
            Bard2 = 603,
            Bard3 = 607,
            Bard4 = 608,
            Bard5 = 610,
            Bard6 = 611,
            Bard7 = 612,
            Bard8 = 613,
            Bard9 = 614,
            Bard10 = 615,
            [Description("White Mage Wands")] WHMW = 701,
            [Description("White Mage")]WHM = 801,
            [Description("White Mage-2")] WHM2 = 802,
            [Description("White Mage-3")] WHM3 = 805,
            [Description("White Mage-4")] WHM4 = 808,
            [Description("White Mage-5")] WHM5 = 809,
            [Description("White Mage-6")] WHM6 = 812,
            [Description("White Mage-7")]WHM7 = 814,
            [Description("Black Mage")]BLM = 1001,
            [Description("Black Mage-2")] BLM2 = 1007,
            [Description("Black Mage-3")] BLM3 = 1008,
            [Description("Black Mage-4")] BLM4 = 1009,
            [Description("Black Mage-5")] BLM5 = 1011,
            [Description("Dark Knight")]DRK = 1501,
            [Description("Dark Knight-2")] DRK2 = 1505,
            [Description("Scholar/Summoner")]Scholar = 1701,
            [Description("Scholar/Summoner 2")] Scholar2 = 1705,
            [Description("Scholar/Summoner 3")] Scholarx = 1717,
            Ninja = 1801,
            Ninja2 = 1803,
            Ninja3 = 1805,
            Machinist = 2001,
            Machinist2 = 2002,
            Machinist3 = 2006,
            Machinist4 = 2007,
            Machinist5 = 2009,
            Machinist6 = 2011,
            Machinist7 = 2020,
            Astrologian = 2101,
            Astrologian2 = 2110,
            Samurai = 2201,
            Samurai2 = 2202,
            Samurai3 = 2203,
            Samurai4 = 2204,
            Samurai5 = 2205,
            Samurai6 = 2209,
            Samurai7 = 2210,
            [Description("Red Mage")]RDM = 2301,
            [Description("Red Mage-2")] RDM2 = 2303,
            [Description("Red Mage-3")] RDM3 = 2304,
            [Description("Shield-NPC")] Shield = 8001,
            [Description("Sword-NPC")] SwordNPC = 8002,
            [Description("Sword2-NPC")] Sword2NPC = 8003,
            [Description("Warrior-NPC")] WarNPC = 8006,
            [Description("Warrior2-NPC")] War2NPC = 8007,
            [Description("Dragoon NPC")] DRGN = 8009,
            [Description("WHM NPC")] WHMN = 8012,
            [Description("WHM2 NPC")] WHMN2 = 8015,
            [Description("Special NPC")] SpecialxD = 8016,
            [Description("Warrior3 NPC")] Warx3 = 8018,
            [Description("Warrior4 NPC")] Warx4 = 8019,
            [Description("WHM3 NPC")] Whm3 = 8020,
            [Description("Sword3 NPC")] PLD2 = 8021,
            [Description("MCH NPC")] MCH = 8024,
            [Description("Sword4 NPC")] PLD3 = 8025,
            [Description("Warrior5 NPC")] Warx5 = 8028,
            [Description("Warrior6 NPC")] Warx6 = 8029,
            [Description("Warrior7 NPC")] Warx7 = 8033,
            Props = 9001,
            Scroll = 9013,
            [Description("Leaf Fan")] Leaffan = 9016,
            [Description("Maelstrom Flag")] MaelFlag = 9023,
            Bomb = 9030,
            Umbrella = 9032,
            Tanto = 9052,
            [Description("Pots/Food")] Pots = 9901,
        }
        /// <summary>
        /// The clans of FFXIV
        /// </summary>
        [TypeConverter(typeof(EnumDescriptionTypeConverter))]
        public enum Clans
        {
            Midlander = 1,
            Highlander,
            Wildwood,
            Duskwight,
            Plainsfolk,
            Dunesfolk,
            [Description("Seeker of the Sun")]
            Sunseeker,
            [Description("Keeper of the Moon")]
            Moonkeeper,
            [Description("Sea Wolves")]
            Seawolves,
            Hellsguard,
            Raen,
            Xaela
        }

        /// <summary>
        /// Genders enum
        /// </summary>
        public enum Genders
        {
            Male,
            Female
        }

        #endregion
        [JsonIgnore] private long size;
        [JsonIgnore]
        public long Size
        {
            get => size;
            set => size = value;
        }

        [JsonIgnore] private ObservableCollection<string> names;
        [JsonIgnore]
        public ObservableCollection<string> Names
        {
            get => names;
            set => names = value;
        }

        [JsonIgnore] private string selectedValue;
        [JsonIgnore]
        public string SelectedValue
        {
            get => selectedValue;
            set => selectedValue = value;
        }

        [JsonIgnore] private int selectedIndex;
        [JsonIgnore]
        public int SelectedIndex
        {
            get => selectedIndex;
            set => selectedIndex = value;
        }


        [JsonIgnore] public bool IsEnabled { get; set; }
        [JsonIgnore] public Address<float> GposeMode { get; set; }
        public Address<float> TailSize { get; set; }
        [JsonIgnore] public Address<string> Name { get; set; }
        public Address<Races> Race { get; set; }
        public Address<Clans> Clan { get; set; }
        public Address<Genders> Gender { get; set; }
        [JsonIgnore]  public Address<float> Wetness { get; set; }
        [JsonIgnore]  public Address<float> SWetness { get; set; }
        public Address<float> Height { get; set; }
        public Address<float> BustX { get; set; }
        public Address<float> BustY { get; set; }
        public Address<float> BustZ { get; set; }
        [JsonIgnore]  public Address<float> X { get; set; }
        [JsonIgnore]  public Address<float> Y { get; set; }
        [JsonIgnore]  public Address<float> Z { get; set; }
        public Address<byte> Head { get; set; }
        public Address<byte> Hair { get; set; }
        public Address<byte> TailType { get; set; }
        public Address<byte> HairTone { get; set; }
        public Address<byte> Highlights { get; set; }
        public Address<byte> HighlightTone { get; set; }
        public Address<byte> Skintone { get; set; }
        public Address<byte> FacialFeatures { get; set; }
        [JsonIgnore]  public static Address<int> Emote { get; set; }
        [JsonIgnore]  public static Address<float> EmoteSpeed1 { get; set; }
        [JsonIgnore]  public static Address<float> EmoteSpeed2 { get; set; }
        public Address<byte> Eye { get; set; }
        public Address<byte> RightEye { get; set; }
        public Address<byte> LeftEye { get; set; }
        public Address<byte> FacePaint { get; set; }
        public Address<byte> FacePaintColor { get; set; }
        public Address<byte> Nose { get; set; }
        public Address<byte> Lips { get; set; }
        public Address<byte> LipsTone { get; set; }
        public Address<byte> Voices { get; set; }
        [JsonIgnore] public Address<float> Rotation { get; set; }
        [JsonIgnore] public Address<float> Rotation2 { get; set; }
        [JsonIgnore] public Address<float> Rotation3 { get; set; }
        [JsonIgnore] public Address<float> Rotation4 { get; set; }
        [JsonIgnore] public Address<float> CameraHeight { get; set; }
        [JsonIgnore] public Address<float> CameraHeight2 { get; set; }
        [JsonIgnore] public Address<float> CamX { get; set; }
        [JsonIgnore] public Address<float> CamY { get; set; }
        [JsonIgnore] public Address<float> CamZ { get; set; }
        [JsonIgnore] public Address<float> Max { get; set; }
        [JsonIgnore] public Address<float> Min { get; set; }
        [JsonIgnore] public Address<float> CZoom { get; set; }
        [JsonIgnore] public Address<float> FOVC { get; set; }
        [JsonIgnore] public Address<float> FOVMAX { get; set; }
        public Address<float> MuscleTone { get; set; }
        public Address<Jobs> Job { get; set; }
        public Address<byte> WeaponBase { get; set; }
        public Address<byte> WeaponV { get; set; }
        public Address<Dyes> WeaponDye { get; set; }
        public Address<float> WeaponX { get; set; }
        public Address<float> WeaponY { get; set; }
        public Address<float> WeaponZ { get; set; }
        public Address<int> HeadPiece { get; set; }
        public Address<byte> HeadV { get; set; }
        public Address<Dyes> HeadDye { get; set; }
        public Address<int> Chest { get; set; }
        public Address<byte> ChestV { get; set; }
        public Address<Dyes> ChestDye { get; set; }
        public Address<int> Arms { get; set; }
        public Address<byte> ArmsV { get; set; }
        public Address<Dyes> ArmsDye { get; set; }
        public Address<int> Legs { get; set; }
        public Address<byte> LegsV { get; set; }
        public Address<Dyes> LegsDye { get; set; }
        public Address<int> Feet { get; set; }
        public Address<byte> FeetVa { get; set; }
        public Address<Dyes> FeetDye { get; set; }
        public Address<int> Ear { get; set; }
        public Address<byte> EarVa { get; set; }
        public Address<int> Neck { get; set; }
        public Address<byte> NeckVa { get; set; }
        public Address<int> Wrist { get; set; }
        public Address<byte> WristVa { get; set; }
        public Address<int> RFinger { get; set; }
        public Address<byte> RFingerVa { get; set; }
        public Address<int> LFinger { get; set; }
        public Address<byte> LFingerVa { get; set; }
        public Address<float> WeaponRed { get; set; }
        public Address<float> WeaponGreen { get; set; }
        public Address<float> WeaponBlue { get; set; }
        public Address<float> SkinRedPigment { get; set; }
        public Address<float> SkinGreenPigment { get; set; }
        public Address<float> SkinBluePigment { get; set; }
        public Address<float> SkinRedGloss { get; set; }
        public Address<float> SkinGreenGloss { get; set; }
        public Address<float> SkinBlueGloss { get; set; }
        public Address<float> HairRedPigment { get; set; }
        public Address<float> HairGreenPigment { get; set; }
        public Address<float> HairBluePigment { get; set; }
        public Address<float> HairGlowRed { get; set; }
        public Address<float> HairGlowGreen { get; set; }
        public Address<float> HairGlowBlue { get; set; }
        public Address<float> HighlightRedPigment { get; set; }
        public Address<float> HighlightGreenPigment { get; set; }
        public Address<float> HighlightBluePigment { get; set; }
        public Address<float> LeftEyeRed { get; set; }
        public Address<float> LeftEyeGreen { get; set; }
        public Address<float> LeftEyeBlue { get; set; }
        public Address<float> RightEyeRed { get; set; }
        public Address<float> RightEyeGreen { get; set; }
        public Address<float> RightEyeBlue { get; set; }
        public Address<float> LipsBrightness { get; set; }
        public Address<float> LipsR { get; set; }
        public Address<float> LipsB { get; set; }
        public Address<float> LipsG { get; set; }
        [JsonIgnore] public Address<float> CameraYAMin { get; set; }
        [JsonIgnore] public Address<float> FOV2 { get; set; }
        [JsonIgnore] public Address<float> CameraYAMax { get; set; }
        [JsonIgnore] public Address<float> CameraUpDown { get; set; }

        public CharacterDetails()
        {
            CameraUpDown = new Address<float>();
            Voices = new Address<byte>();
            CameraYAMin = new Address<float>();
            FOV2 = new Address<float>();
            CameraYAMax = new Address<float>();
            SkinRedPigment = new Address<float>();
            SkinGreenPigment = new Address<float>();
            SkinBluePigment = new Address<float>();
            SkinRedGloss = new Address<float>();
            SkinGreenGloss = new Address<float>();
            SkinBlueGloss = new Address<float>();
            HairRedPigment = new Address<float>();
            HairGreenPigment = new Address<float>();
            HairBluePigment = new Address<float>();
            HairGlowRed = new Address<float>();
            HairGlowGreen = new Address<float>();
            HairGlowBlue = new Address<float>();
            HighlightRedPigment = new Address<float>();
            HighlightGreenPigment = new Address<float>();
            HighlightBluePigment = new Address<float>();
            LeftEyeRed = new Address<float>();
            LeftEyeGreen = new Address<float>();
            LeftEyeBlue = new Address<float>();
            RightEyeRed = new Address<float>();
            RightEyeGreen = new Address<float>();
            RightEyeBlue = new Address<float>();
            LipsBrightness = new Address<float>();
            LipsR = new Address<float>();
            LipsG = new Address<float>();
            LipsB = new Address<float>();
            WeaponRed = new Address<float>();
            WeaponGreen = new Address<float>();
            WeaponBlue = new Address<float>();
            LFingerVa = new Address<byte>();
            LFinger = new Address<int>();
            RFingerVa = new Address<byte>();
            RFinger = new Address<int>();
            WristVa = new Address<byte>();
            Wrist = new Address<int>();
            NeckVa = new Address<byte>();
            Neck = new Address<int>();
            EarVa = new Address<byte>();
            Ear = new Address<int>();
            FeetDye = new Address<Dyes>();
            FeetVa = new Address<byte>();
            Feet = new Address<int>();
            LegsDye = new Address<Dyes>();
            LegsV = new Address<byte>();
            Legs = new Address<int>();
            ArmsDye = new Address<Dyes>();
            ArmsV = new Address<byte>();
            Arms = new Address<int>();
            ChestDye = new Address<Dyes>();
            ChestV = new Address<byte>();
            Chest = new Address<int>();
            HeadV = new Address<byte>();
            HeadDye = new Address<Dyes>();
            HeadPiece = new Address<int>();
            WeaponX = new Address<float>();
            WeaponY = new Address<float>();
            WeaponZ = new Address<float>();
            WeaponBase = new Address<byte>();
            WeaponV = new Address<byte>();
            WeaponDye = new Address<Dyes>();
            Job = new Address<Jobs>();
            MuscleTone = new Address<float>();
            Max = new Address<float>();
            Min = new Address<float>();
            CZoom = new Address<float>();
            FOVC = new Address<float>();
            FOVMAX = new Address<float>();
            CamX = new Address<float>();
            CamY = new Address<float>();
            CamZ = new Address<float>();
            CameraHeight = new Address<float>();
            CameraHeight2 = new Address<float>();
            GposeMode = new Address<float>();
            Wetness = new Address<float>();
            SWetness = new Address<float>();
            Height = new Address<float>();
            TailSize = new Address<float>();
            Name = new Address<string>();
            Head = new Address<byte>();
            Hair = new Address<byte>();
            Race = new Address<Races>();
            Clan = new Address<Clans>();
            Gender = new Address<Genders>();
            names = new ObservableCollection<string>();
            BustX = new Address<float>();
            BustY = new Address<float>();
            BustZ = new Address<float>();
            X = new Address<float>();
            Y = new Address<float>();
            Z = new Address<float>();
            Rotation = new Address<float>();
            Rotation2 = new Address<float>();
            Rotation3 = new Address<float>();
            Rotation4 = new Address<float>();
            HairTone = new Address<byte>();
            HairTone = new Address<byte>();
            Highlights = new Address<byte>();
            HighlightTone = new Address<byte>();
            Skintone = new Address<byte>();
            FacialFeatures = new Address<byte>();
            Eye = new Address<byte>();
            RightEye = new Address<byte>();
            LeftEye = new Address<byte>();
            FacePaint = new Address<byte>();
            FacePaintColor = new Address<byte>();
            Nose = new Address<byte>();
            Lips = new Address<byte>();
            LipsTone = new Address<byte>();
            TailType = new Address<byte>();
            Emote = new Address<int>();
            EmoteSpeed1 = new Address<float>();
            EmoteSpeed2 = new Address<float>();
        }
    }
}