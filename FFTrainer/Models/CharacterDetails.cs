using System.Collections.ObjectModel;
using FFTrainer.Converters;
using System.ComponentModel;
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
            Monk = 301,
            MonkCesti = 321,
            MonkKnuckles = 323,
            Warrior = 401,
            Dragoon = 501,
            Bard = 601,
            [Description("White Mage")]
            WHM = 801,
            [Description("White Mage-2")]
            WHM2 = 814,
            [Description("Black Mage")]
            BLM = 1001,
            [Description("Dark Knight")]
            DRK = 1501,
            [Description("Scholar/Summoner")]
            Scholar = 1701,
            [Description("Scholar/Summoner 2")]
            Scholarx = 1717,
            Ninja = 1801,
            Machinist = 2001,
            Astrologian = 2101,
            Astrologian2 = 2110,
            Samurai = 2201,
            [Description("Red Mage")]
            RDM = 2301,
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
        private long size;
        public long Size
        {
            get => size;
            set => size = value;
        }

        private ObservableCollection<string> names;
        public ObservableCollection<string> Names
        {
            get => names;
            set => names = value;
        }

        private string selectedValue;
        public string SelectedValue
        {
            get => selectedValue;
            set => selectedValue = value;
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get => selectedIndex;
            set => selectedIndex = value;
        }

        public bool IsEnabled { get; set; }
        public Address<float> GposeMode { get; set; }
        public Address<float> TailSize { get; set; }
        public Address<string> Name { get; set; }
        public Address<Races> Race { get; set; }
        public Address<Clans> Clan { get; set; }
        public Address<Genders> Gender { get; set; }
        public Address<float> Wetness { get; set; }
        public Address<float> SWetness { get; set; }
        public Address<float> Height { get; set; }
        public Address<float> BustX { get; set; }
        public Address<float> BustY { get; set; }
        public Address<float> BustZ { get; set; }
        public Address<float> X { get; set; }
        public Address<float> Y { get; set; }
        public Address<float> Z { get; set; }
        public Address<byte> Head { get; set; }
        public Address<byte> Hair { get; set; }
        public Address<byte> TailType { get; set; }
        public Address<byte> HairTone { get; set; }
        public Address<byte> Highlights { get; set; }
        public Address<byte> HighlightTone { get; set; }
        public Address<byte> Skintone { get; set; }
        public Address<byte> FacialFeatures { get; set; }
        public static Address<int> Emote { get; set; }
        public static Address<float> EmoteSpeed1 { get; set; }
        public static Address<float> EmoteSpeed2 { get; set; }
        public Address<byte> Eye { get; set; }
        public Address<byte> RightEye { get; set; }
        public Address<byte> LeftEye { get; set; }
        public Address<byte> FacePaint { get; set; }
        public Address<byte> FacePaintColor { get; set; }
        public Address<byte> Nose { get; set; }
        public Address<byte> Lips { get; set; }
        public Address<float> Rotation { get; set; }
        public Address<float> Rotation2 { get; set; }
        public Address<float> Rotation3 { get; set; }
        public Address<float> Rotation4 { get; set; }
        public Address<float> CameraHeight { get; set; }
        public Address<float> CamX { get; set; }
        public Address<float> CamY { get; set; }
        public Address<float> CamZ { get; set; }
        public Address<float> Max { get; set; }
        public Address<float> Min { get; set; }
        public Address<float> CZoom { get; set; }
        public Address<float> FOVC { get; set; }
        public Address<float> FOVMAX { get; set; }
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

        public CharacterDetails()
        {
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
            TailType = new Address<byte>();
            Emote = new Address<int>();
            EmoteSpeed1 = new Address<float>();
            EmoteSpeed2 = new Address<float>();
        }
    }
}