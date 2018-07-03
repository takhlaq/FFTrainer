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
        /// The Emote of FFXIV
        /// </summary>
        [TypeConverter(typeof(EnumDescriptionTypeConverter))]
        public enum Emotes
        {
            Idle = 3,
            Idle_2,
            Idle_3,
            Idle_4,
            [Description("Turning Left")] TurningLeft,
            [Description("Turning Right")] TurningRight,
            Walking = 13,
            [Description("Walking Left")] WalkingLeft,
            [Description("Walking Right")] WalkingRight,
            [Description("Walking Back")] WalkingBack,
            Run = 22,
            [Description("Running Left")] RunLeft,
            [Description("Running Right")] RunRight,
            Sprint = 30,
            [Description("Jump Start")] JumpStart,
            [Description("Jump Fall")] JumpFall,
            [Description("Jump Landing")] JumpLanding,
            [Description("Battle Idle Stance")] BattleIDle,
            [Description("Knee Suffering")] KneeSuffering = 37,
            [Description("Battle Walk")] BattleWalk = 41,
            [Description("Battle Run")] BattleRun = 50,
            [Description("Battle Sprint")] BattleSprint = 58,
            [Description("Battle Jump")] BattleJump,
            [Description("Battle Fall")] BattleFall,
            [Description("Battle Land")] BattleLand,
            Damaged,
            Dying = 66,
            [Description("Flinch with wince")] Flinch_With_Wince = 68,
            [Description("Flinch (Faster)")] Flinch,
            [Description("Flinch")] FlinchX = 71,
            [Description("Dying (Weapon Drawn)")] DyingW,
            Dead,
            Revive = 77,
            [Description("Weapon Guard")] WGuard,
            [Description("Shield Guard")] SGuard,
            [Description("Pickup Something")] PS = 81,
            [Description("Item Use")] IU = 85,
            [Description("Item Use (Weapon Drawn)")] IUW = 91,
            [Description("Fire IV - Part 1")] FIV1 = 94,
            [Description("Fire IV - Part 2")] FIV2,
            [Description("Begin Harp")] BH,
            [Description("Swift Harp Strumming")] BHS,
            [Description("Look Around")] LookA = 176,
            [Description("Chocobo Whistle")] CW = 179,
            [Description("Twister/Ballistic Death")] Twister = 196,
            [Description("Moonfaire Flares")] MFlare,
            [Description("Carry Upper/Ice Slip")] CUP = 200,
            Lookout = 209,
            Damaged2 = 217,
            Landing = 219,
            [Description("Kneeling Cheer/Success")] KCS = 253,
            [Description("Kneeling Disappointed/Failure")] KdS,
            Sparkling = 272,
            Planting = 296,
            [Description("Watering plants")] WP,
            [Description("Pulling up plants")] WPs,
            [Description("Placing sparkly fertilizer")] PSF,
            [Description("Summon Exploding Rocks")] SER = 340,
            [Description("Ring of Thorns")] ROT = 351,
            [Description("Imperial Salute")] IS = 587,
            [Description("Ice Sliding")] ISa = 602,
            Throw = 641,
            [Description("Sitting Down Chair")] SDC,
            Sitting,
            [Description("Getting Up from chair")] GUC,
            [Description("Sitting Down Ground")] SDG = 653,
            [Description("Getting Up from Ground")] GaUC = 655,
            [Description("Air Quotes")] AQ = 688,
            Angry = 690,
            Furious,
            [Description("Blow Kiss")] BK,
            Blush,
            Bow,
            Cheer,
            Clap,
            Beckon,
            Comfort,
            Cry,
            Dance,
            Grovel,
            Doubt,
            Doze,
            Fume,
            Goodbye,
            Wave,
            Huh,
            Joy,
            Happy,
            Kneel,
            Chuckle,
            Laugh,
            [Description("Lookout")] Lookout2,
            [Description("Examine Self")] ES,
            Me,
            No,
            Deny,
            Disappointed,
            Panic,
            Point,
            Poke,
            Pose,
            Congratulate,
            Psych,
            Salute,
            [Description("Flame Salute")] FS = 728,
            Shocked,
            Surprised,
            Rally,
            Soothe,
            Stretch = 734,
            Sulk,
            Think,
            Upset,
            Welcome,
            Yes,
            [Description("Thumbs Up")] TU,
            Huzzah,
            Pray,
            [Description("Surprised")] SurprisedX = 751,
            [Description("Doubtful Head Tilt")] Doubtfulh = 758,
            [Description("Standing, normal speech")] StandingNS = 763,
            [Description("Standing, short speech")] StandingNS2,
            [Description("Sitting, short speech")] StandingNS3,
            [Description("Thinking (Worry or doubt)")] Thinka,
            [Description("Raise Hand")] RHA,
            [Description("Excited Talking (Miqo'te)")] RHAxd,
            [Description("Salute")] Salute4,
            [Description("Fists in front headnod")] FHN,
            [Description("Fists to chest salute")] FH2N,
            [Description("Tataru shock into slump (Lala only)")] taae = 776,
            [Description("Leaning Forward Sniffling")] Sniffa = 780,
            [Description("Idle Stance")] IdleS = 783,
            [Description("Arms Crossed Standing")] ARCS,
            [Description("Standing one arm on hip")] ARCS2,
            [Description("Standing arms at hips")] ARCS3,
            [Description("Standing arms in front of crotch")] ARCS4,
            [Description("Sitting")] Sitting2,
            [Description("Chair Sit hands locked on lap")] Chairsit,
            [Description("Hunched forward at table")] Hunchedxd,
            [Description("Sitting looking up")] Sittingup,
            [Description("Sitting down animation")] Sittingup2,
            [Description("Sitting up animation")] Sittingup3,
            [Description("Sitting down on ground")] Sittingdownxd,
            [Description("Standing up from ground")] Swa,
            [Description("Conversing gesturing with 2 hands")] Conversexd2,
            [Description("Conversing with 1 hand gesturing")] Conversexd3,
            [Description("Conversing with 1 hand gesturing alternate")] Conversexd4,
            [Description("Conversing with 2 hands gesturing")] Conversexd5,
            [Description("Conversing while sitting")] Convers4exd5,
            [Description("Fake Conversing (No Lip Movement)")] Convers4exdf5,
            [Description("Slow lean forward while sitting")] Slowlean,
            [Description("Sitting,Leg Spread")] Slleeg,
            [Description("Sitting,Leaning Forward")] LeanedSit,
            Sleeping,
            [Description("Feminine Bench Sit")] FBench,
            [Description("Leaning on Wall")] Leaningon,
            [Description("Guard Standing Looking Around")] GroundS,
            [Description("Beckoning Crowd")] BeckonCrowdxd,
            [Description("Public Conversation")] SPC,
            [Description("Rack checking/Examining Wall")] Rackc,
            [Description("Checking Things")] SPC2,
            [Description("Maidy bow")] Maidybow,
            [Description("Hands in front (Weapon drawn)")] Hnsw,
            [Description("Knelt Praying")] Prayk,
            [Description("Hand on hip talking")] hont,
            Coaching,
            [Description("Sassy Stand/talk")] sassyt,
            [Description("Deflated Standing/Onlook")] Standingon,
            [Description("Eat (Weapon drawn)")] Eat,
            [Description("Drinking (Weapon drawn)")] Drinking,
            [Description("Sitting Thinking")] SITT,
            [Description("Hand on Right Wall")] HREe,
            [Description("Smug Spread legs, Sitting")] Smugspred = 825,
            [Description("Smug Spread legs, Drinking")] Smugspred2,
            [Description("Smug Lean")] Smuglean,
            [Description("Smug talking with hand on hip")] Smugtalking,
            [Description("Spear Action")] Spear1 = 831,
            [Description("Spear Action 2")] Spear2,
            [Description("Bow Action")] BowA,
            [Description("Bow Action 2")] BowA2,
            [Description("Bow Repair/Hand Holding?")] Bow3,
            [Description("Sitting Meditating")] SittingM,
            [Description("Meditating with one arm outstretched")] MeditatingO,
            [Description("Meditating with hand on face")] asdada,
            [Description("Beinding Down Graspp Picking")] grassa,
            [Description("Watering with no pot (Weapon Drawn)")] wewa,
            [Description("Leaning forward looking out")] wewea = 845,
            [Description("Tilling (Weapon Drawn)")] weweas,
            [Description("Repairing Wall (Weapon Drawn)")] Repairingwall,
            [Description("Adjusting Tall Object")] Tare,
            [Description("Standing holding something (weapon drawn)")] Tarree = 850,
            [Description("Sitting Reading? (weapon drawn)")] Tarreee = 851,
            [Description("Picking Petals? (weapon drawn)")] PickingP,
            [Description("Knelt Down Smashing things on ground (Weapon Drawn)")] KenltDownS,
            [Description("Upset, Pointing and talking")] UpsetT,
            [Description("Arms Behind Back")] Armsad,
            [Description("Dick grab (weapon drawn)")] Dick = 858,
            [Description("Lala Mixing Bowl (Lala only)")] Lalada = 860,
            [Description("Axe Stretch")] Laladaw,
            [Description("Stretching with a Sword/Spear (Weapon Drawn)")] Stretchingw2,
            [Description("Firing Gun (weapon drawn)")] WFiring,
            [Description("Angler (Weapon Drawn)")] Angler,
            [Description("Butt Swaying (Midlander/Miqo'te)")] Butts = 869,
            [Description("Come Hither (Midlander/Miqo'te)")] Buttss,
            Cheering = 873,
            Pushups = 879,
            Situps,
            Squats = 882,
            [Description("Yankee Sit")] Yankke = 884,
            [Description("Ladies Yankee Sit")] Yankkes,
            [Description("Holding Big object (Weapon Drawn)")] BigObject,
            [Description("Carring object on shoulder (Weapon Drawn)")] BigObject2,
            [Description("Lala Hammock (Lala Only)")] Hammock = 892,
            [Description("Leaf Fanning")] Fanning,
            [Description("Bath Stretching")] Fanning2,
            Tailor = 896,
            [Description("Shaking alchemy things (Weapon drawn)")] Alchemyth = 898,
            [Description("Smoking/Tobacco?")] Smoking = 910,
            [Description("Sitting Smoking/Tobacco?")] SmokingS,
            [Description("Fanning Face in the heat")] SmokingSfs,
            [Description("Handbills Look")] SmokingSfss,
            [Description("Prayer to Light")] PRayers,
            [Description("Smug Talking (Weapon Drawn)")] SmugTalk,
            [Description("Telling a Secret")] Tellsec = 922,
            [Description("Taking notes (Weapon Drawn)")] Tellsecs,
            [Description("Crying with face in hands")] CryingBoy,
            [Description("Ul'dah Dance")] Udance = 929,
            [Description("Sexy Bath")] Ubath = 930,
            [Description("Excaliming with a finger pointed up")] Ubaths = 933,
            [Description("Sitting out of breath, standing up")] Ubadths,
            [Description("Out of breath")] Ousxd = 936,
            [Description("Holding Ledger Counting (Weapon Drawn)")] Ousxdd,
            [Description("Outstretch both arms and lean forward")] Oudsxd = 950,
            [Description("Quick Coourteous halfbow")] Ousrxd = 957,
            [Description("Handover something from fannypack")] Ousrexd = 960,
            [Description("Bend over and huff")] Oussrexd = 961,
            [Description("Holding something and looking about (Weapon drawn)")] Hsa = 977,
            [Description("Counting things on table(Weapon Drawn)")] Hsaxd = 978,
            [Description("Seated, restrained")] Hsaxdd = 979,
            [Description("Mount Whistle")] Hsaexdd = 980,
            [Description("Laying Down 1")] Hsaexwdd = 981,
            [Description("Laying Down 2")] Hsaeexwdd = 982,
            Frightened,
            Frightened2 = 985,
            [Description("Bed in")] Bedin,
            [Description("Bed out(Dreaming)")] Bedout = 988,
            [Description("Bed out")] Bedoutxd,
            [Description("Search With Hands")] SearchHands,
            [Description("Hunched Talking")] SearchHandss = 992,
            [Description("Taken aback examining an object")] SearcxhHands = 994,
            [Description("Raise job crystal in air (Weapon drawn)")] SearcxhHandrs = 995,
            [Description("Stand like astatue holding something (Weapon drawn)")] SearcxhHdandrs = 996,
            [Description("Linkpearl Answer")] Linkpearla = 1002,
            [Description("Holding something (Weapon drawn)")] Linkpeearla = 1003,
            [Description("Ul'dahn Dance")] Linkpeeearla = 1004,
            [Description("Step Back")] Linkpereearla = 1005,
            [Description("Reading Book")] Linkpeereearla = 1006,
            [Description("Sitting, arms in front")] Linkpeereea33rla = 1007,
            [Description("Restrained, Standing")] Linkpeereddearla = 1008,
            [Description("Linkpearl, Speaking")] Linkpedereddearla = 1009,
            [Description("Haircut animation")] Linkpedereddearlae = 1012,
            [Description("Attention Arms Straight Down")] Linkpedereeddearlae = 1013,
            [Description("Knelt down looking about")] Linkpedereedde4arlae = 1014,
            [Description("Eating Contest")] Linkpedereedde4aerlae = 1016,
            [Description("Gird Up")] Linkpedereedde4eaerlae = 1022,
            [Description("Sitting, depressed")] Linkpedereredde4eaerlae = 1032,
            [Description("Gibbed (Must Exit Gpose)")] Linkpedereredde43eaerlae = 1033,
            [Description("Kneel")] Linkpederereddee43eaerlae = 1039,
            [Description("Fold Arms in disapproval")] Linkpe4derereddee43eaerlae = 1041,
            [Description("Raise arm in air (Weapon Drawn)")] Linkpe4derereddee4e3eaerlae = 1042,
            [Description("Jotting down notes (Weapon Drawn)")] Linkpe4derereddee4e3eaeerlae = 1043,
            [Description("Attention Poses (Odd?)")] Linkpee4derereddee4e3eaeerlae = 1045,
            [Description("Standing Pose 1")] StandP = 1052,
            [Description("Standing Pose 2")] StandP2 = 1053,
            [Description("Standing Pose 3")] StandP3 = 1054,
            [Description("Standing Pose 4")] StandP4 = 1055,
            [Description("Smoke Bomb")] Smokeb = 1058,
            [Description("Special Joy")] Smoke3b = 1059,
            [Description("Look at something in hand")] Smoke43b = 1061,
            [Description("Slow bow")] Smoke243b = 1062,
            [Description("Ecstatically examine object and cheer")] Smok4e243b = 1064,
            [Description("Sitting pose 1")] Smok4re243b = 1065,
            [Description("Sitting pose 2")] Smok4re2432b = 1066,
            [Description("Sitting on ground")] Smok4r3e2432b = 1067,
            [Description("Fast Whistle")] Smeok4re2432b = 1069,
            [Description("Examine Ledger (Weapon Drawn)")] Smok4re24r32b = 1070,
            [Description("Fist into Palm")] Smo3k4re24r32b = 1071,
            [Description("Maidy Idle")] Smo3k4re224r32b = 1072,
            [Description("Flamethrower from Crotch")] Smo3k4re224r4r523342sb = 1102,
            [Description("Freezethrower from Crotch")] Smo3k4re224r4r5w23342sb = 1103,
            [Description("Tank LB Start")] easa = 2232,
            [Description("Tank LB Loop")] eeasa = 2233,
            [Description("Melee LB Start")] eeasae = 2234,
            [Description("Melee LB Loop")] eerasae = 2235,
            [Description("Healer LB Start")] ederasae = 2236,
            [Description("Healer LB Loop")] ede4rasae = 2237,
            [Description("Caster LB Start")] edes4rasae = 2238,
            [Description("Caster LB Loop")] edese4rasae = 2239,
            [Description("Tank LB Lv1")] edese4reasae = 2240,
            [Description("Tank LB Lv2")] edese4reeasae = 2241,
            [Description("Tank LB Lv3")] edese24reasae = 2242,
            [Description("Melee LB Lv1")] edese4reaseae = 2243,
            [Description("Melee LB Lv2")] edeese4reaseae = 2244,
            [Description("Melee LB Lv3")] edese4rea3seae = 2245,
            [Description("Final Heaven LB Start")] edese4rea53seae = 2246,
            [Description("Final Heaven LB Loop")] edese4rea53seae3 = 2247,
            [Description("Healer LB Lv1")] edese4rea53seeae3 = 2248,
            [Description("Healer LB Lv2")] edese4rea53seeeae3 = 2249,
            [Description("Healer LB Lv3")] ede4se4rea53seeeae3 = 2250,
            [Description("Caster LB Lv1")] ede4se4rea353seeeae3 = 2251,
            [Description("Caster LB Lv2")] ede4se4rea3532seeeae3 = 2252,
            [Description("Caster LB Lv3")] ede4se4rea3532se2eeae3 = 2253,
            [Description("Pet")] ede4se4rea3532se22eeae3 = 3177,
            [Description("Hand Over")] ede4se4rea35332se22eeae3 = 3178,
            Idle3 = 3182,
            Idle4 = 3184,
            [Description("Bomb Dance")] ede4se4rea3533e2se22eeae3 = 3188,
            [Description("Slap")] ede4se4rea3533e22se22eeae3 = 3752,
            Hug,
            Embrace,
            [Description("Fist Bump")] ede4se4rea35332e2se22eeae3 = 3766,
            [Description("Moonlift Dance")] ede4s2e4rea35332e2se22eeae3 = 3773,
            [Description("Thavnairian Dance")] ede4s2e4srea35332e2se22eeae3 = 3775,
            [Description("Gold Dance")] ede4s2e4srea35332e2se223eeae3 = 3777,
            [Description("Battle Pose")] ede4s2e4srea35332e2s4e22eeae3 = 3778,
            [Description("Victory Pose")] ede4s2e4srea35332e2s4e22deeae3 = 3779,
            [Description("Restraint")] ede4s2e4srea35332e2s4ee22deeae3 = 3780,
            [Description("Restraint 2")] ede4s2e4srea35332e2s4ee222deeae3 = 3781,
            Sliding = 3785,
            Quake = 3786,
            [Description("DRK Swings")] ede4s2e4srea35332e2s4ee222deeaea3 = 3805,
            Struggle = 3903,
            Blow = 3904,
            Fly,
            Dizzy = 3907,
            [Description("Butterfly wings 2")] edeqes4rasa4ae = 3909,
            Roll = 3910,
            [Description("Honestly IDK?")] edeqes4ras4ae = 3917,
            [Description("Range LB Start")] edeqes4rasae = 3923,
            [Description("Range LB Loop")] edeqes4raqsae = 3924,
            [Description("Range LB Lv1")] edeqes4raswae = 3925,
            [Description("Range LB Lv2")] edeqes4rasw3ae = 3926,
            [Description("Warrior LB Lv3")] edeqes4rasw3aee = 3927,
            [Description("Dragoon LB Start")] edeqees4rasw3aee = 3928,
            [Description("Dragoon LB Loop")] edeqe3es4rasw3aee = 3929,
            [Description("Dragoon LB Lv3")] edeqe3e2s4rasw3aee = 3930,
            [Description("Ninja LB Start")] edeqe3e2s4rasw33aee = 3931,
            [Description("Ninja LB Loop")] edeqe3e22s4rasw33aee = 3932,
            [Description("Ninja LB Lv3")] edeqe3e22s4rasw33a2ee = 3933,
            [Description("Bard LB Start")] edeqe3e22s4rasw332a2ee = 3934,
            [Description("Bard LB Lv3")] edeqe3e22s4erasw33a2ee = 3935,
            [Description("Summoner LB Start")] edeqe3e22s4erasw33aw2ee = 3937,
            [Description("Summoner LB Loop")] edeqe3e22ss4erasw33aw2ee = 3938,
            [Description("Summoner LB Lv3")] edeqe3e22ss4erasw33aw2eqe = 3939,
            [Description("Scholar LB Start")] ed2eqe3e22ss4erasw33aw2eqe = 3940,
            [Description("Scholar LB Loop")] ed2eqe3e22ss4erasw33a2w2eqe = 3941,
            [Description("Scholar LB Lv3")] ed2eqe3e22ss4erasw33aw23eqe = 3942,
            [Description("Dark Knight LB Lv3")] ed2eqe3e22ss4erasw33aw223eqe = 3943,
            [Description("Machinist LB Start")] ed2eqe3e22ss4erasw33a4w223eqe = 3944,
            [Description("Machinist LB Loop")] ed2eqe3e22ss4erasw33ae4w223eqe = 3945,
            [Description("Machinist LB Lv3")] ed2eqe3e22ss4eras4w33ae4w223eqe = 3946,
            [Description("Astro LB Start")] ed2eqe3e22ss4eras4w33ae4w2233eqe = 3947,
            [Description("Astro LB Loop")] ed2eqe3e22ss4eras4w33ae34w2233eqe = 3948,
            [Description("Astro LB Lv3")] ed2eqde3e22ss4eras4w33ae34w2233eqe = 3949,
            [Description("GS Idle")] ed2eqde3e22ss4eras4w33ae34w2233seqe = 4070,
            [Description("GS Punching Idle")] ed2eqde3e22ss4eras4w33eae34w2233seqe = 4072,
            [Description("GS Punching Action")] ed2eqde3e22ss4eras4w33eae34w23233seqe = 4073,
            [Description("GS Hammer Idle")] ed2eqde3e22ss4eras4w33eae34w232e33seqe = 4074,
            [Description("GS Hammer Action")] ed2eqde3e22ss4eras4ew33eae34w232e33seqe = 4075,
            [Description("GS Basket Idle")] ed2eqde3e22ss4eras4ew33eae344w232e33seqe = 4076,
            [Description("GS Basket Action")] ed2eqwde3e22ss4eras4ew33eae344w232e33seqe = 4077,
            [Description("Triple Triad Idle")] ed2eqwde3e22sss4eras4ew33eae344w232e33seqe = 4079,
            [Description("Patting something?")] ed2eqwde3e22sss4eras4e1w33eae344wa2d32e33seqe = 4081,
            [Description("Picking up item")] ed2eqwde3e22sss4eras4ew33eae344wa2d32e33seqe = 4082,
            [Description("Taking Aether")] ed2eqwde3e22sss4eras4ew33eae344w2d32e33seqe = 4083,
            [Description("Carry up standing pose")] as3ff4544da = 4189,
            [Description("Standing Pose Hands on hips inspecting")] as3ff444da = 4193,
            [Description("Inspecting wounded")] as3f444da = 4199,
            [Description("Aiding wounded")] as3f4447da = 4200,
            [Description("Aiding wounded 2")] as3f44da = 4201,
            [Description("Wounded Standing")] as3f4da = 4204,
            [Description("Wounded Down on ground")] as3fda = 4206,
            [Description("Sleeping Pose")] asfda = 4208,
            Frightened3 = 4215,
            [Description("Chest Pain")] asda = 4222,
            [Description("Skill get")] asdda = 4225,
            Caution = 4227,
            [Description("Huh 2")] aswferffdd45453ddrda = 4229,
            [Description("Playing Harp")] aswferffdd5453ddrda = 4233,
            [Description("Playing Lords of Verminion")] aswferffdd545ddrda = 4234,
            [Description("Disagree 2")] aswferffdd55ddrda = 4236,
            [Description("Hand up!")] aswferffd55ddrda = 4241,
            [Description("Sundrop Dance!")] aswfrffd55ddrda = 4242,
            [Description("Special Huzzah!")] aswfrffd55drda = 4244,
            [Description("Interacting?")] aswfrfd55drda = 4255,
            [Description("Looking to the right")] aswfrd55drda = 4256,
            [Description("Looking to the left")] aswfrd5drda = 4257,
            [Description("Pointing 2?")] aswfrd5rda = 4259,
            Headache = 4260,
            [Description("Eureka(Without effects)")] aswfrd5da = 4262,
            [Description("Breath in Breath out")] aswfd5da = 4267,
            [Description("Fall Down")] aswdda = 4285,
            [Description("Godbert Squats")] aswd5da = 4286,
            [Description("Moogle Dance")] aswd56da = 4297,
            [Description("Casket Pose")] aswdada = 4304,
            [Description("Peep Stand")] asswdada = 4322,
            [Description("Peep Sit")] asswwdada = 4323,
            [Description("Moogle Dance")] asswwd2ada = 4673,
            Aback,
            Spectacles = 4676,
            Backflip = 4680,
            Eureka,
            [Description("MCH Flare")] asswwd2a2da = 4779,
            [Description("MCH Lazer Beam")] aSsswwd2a2da = 4780,
            [Description("Eastern Stretch")] aSsswwwd2a2da = 4781,
            [Description("Eastern Dance")] aSsswwwwd2a2da = 4783,
            [Description("Red Ranger Start")] aSesswwwwd2a2da = 4784,
            [Description("Red Ranger End/Loop")] aSesswwwwd2a32da = 4785,
            [Description("Black Ranger Start")] aSesswwww3d2a32da = 4786,
            [Description("Black Ranger End/Loop")] aSesswwww3ed2a32da = 4787,
            [Description("Black Ranger Start 2")] aSesswwww3d2ea32da = 4788,
            [Description("Black Ranger End/Loop 2")] aSeesswwww3ed2a32da = 4789,
            Haurchefant = 4790,
            Haurchefant2,
            [Description("Red Ranger Start 2")] aSesswwwww3d2a32da = 4792,
            [Description("Red Ranger End/Loop2")] aSesswwwww3d2a3s2da = 4793,
            [Description("Yellow Ranger Start")] aSesswaswwww3d2a32da = 4794,
            [Description("Yellow Ranger End/Loop")] aSessawwwww3d2a3s2da = 4795,
            [Description("Yellow Ranger Start 2")] aSesswaswwww3d2aq32da = 4796,
            [Description("Yellow Ranger End/Loop 2")] aSessawwwww3d2aq3s2da = 4797,
            [Description("Play-Dead Start")] aSessawwwww3d2aeq23s2da = 4798,
            [Description("Play-Dead End/Loop")] aSessawwwww3d2aeqq23s2da = 4799,
            [Description("Pretty Please")] aSessawwwww3d2aeqq423s2da = 4800,
            [Description("Diamond Dust (IceHeart Statue)")] aSessawwwww3d2aeqq423s2qda = 4802,
            [Description("Zantasuken (Odin Statue)")] aSessawwwww3d2qaeqq423s2qda = 4803,
            [Description("Pay Respects")] aSessawwwww3d2qaeqq2423s2qda = 4804,
            [Description("Water Float")] aSe3ssawwwww3d2qaeqq2423s2qda = 4806,
            [Description("Water Float Loop")] aSe3ssawwwww3d2qaesqq2423s2qda = 4807,
            [Description("Water Flip")] aSe3ssawwwww3d2qaeqqq2423s2qda = 4808,
            [Description("Moonlift Dance")] aSe3ssawwwww3d2qaeqqqq2423s2qda = 4810,
            Flex,
            [Description("Self Dote")] aSe3ssawwwww3d2qaaeqqqq2423s2qda = 4815,
            Dote,
            Songbird,
            [Description("Pretty Please (Head movement)")] aSe3ssawwwww3d2qqaaeqqqq2423s2qda = 4823,
            [Description("Goku Power Up")] aSe3ssawwwww3d2qqaaeqqq1q2423s2qda = 4825,
            [Description("Ground Glow")] aSe3ssawwwww3d2qqqaaeqqq1q2423s2qda = 4828,
            [Description("Eastern Bow")] aSe3ssawwwww3d2qqqaaeqqq1q2423sa2qda = 4829,
            Talking,
            [Description("Run Dodge Right")] aSe3ssawwwww3d2qqqaaeqqq1q24232sa2qda = 4908,
            [Description("Run Dodge Left")] aSe3ssawwwww3d2qqqaaeqqq1q24232sa2aqda = 4909,
            [Description("The Beatles Street Cross")] aSe3ssawwwww3d2qqqaaeqqqa1q24232sa2aqda = 4910,
            [Description("Swimming Idle")] fdsad = 4947,
            [Description("Swimming Turn Left")] fdsqad = 4948,
            [Description("Swimming Turn Right")] fdsqqad = 4949,
            [Description("Swimming Walk")] fdsqqaqd = 4950,
            [Description("Swimming Left")] fdqsqqaqd = 4951,
            [Description("Swimming Right")] fdqsqqqaqd = 4952,
            [Description("Swimming Backwards")] fdqs2qqqaqd = 4953,
            [Description("Swimming Forwards")] fdqs2qqqaaqd = 4954,
            [Description("Swimming Sprint Left")] fdqs2qqqaq3d = 4955,
            [Description("Swimming Sprint Right")] fdqs2qqwqaq3d = 4956,
            [Description("Swimming Sprint Start")] fdqs2eqqwqaq3d = 4957,
            [Description("Swimming Sprint Loop")] fdqs2eqqwqaqq3d = 4958,
            [Description("Swimming Sprint End")] fdqs2eqqwqqaqq3d = 4959,
            [Description("Swimming Fall End")] fdqs2eqqwqeqaqq3d = 4960,
            [Description("Exiting Underwater mode")] fdqs2eqqawqeqaqq3d = 4961,
            [Description("Weird Crawl Start")] fdqs2eqqawaqeqaqq3d = 4963,
            [Description("Swimming Death")] fdqs2eqqqawaqeqaqq3d = 4964,
            [Description("Swimming Death")] fdqs2eqqqawaqeqaqq3da,
            [Description("Swimming Death")] fdqs2eqqqawaqeqaqq3ds,
            [Description("Swimming Death")] fdqs2eqqqawaqeqaqq3df,
            [Description("Swimming under Idle")] fdqs2eqqqawaqeqaqqq3d,
            [Description("Swimming under Turn Left")] fdqs2eqqqawaqeqaqqq3da,
            [Description("Swimming under Turn Right")] fdqs2eqqqawaqeqaqqq3dasd,
            [Description("Swimming under Forwards")] fdqs2eqqqawaqeqaaqqq3da,
            [Description("Swimming under Left")] fdqs2eqqqawaqeqa4qqq3da,
            [Description("Swimming under Right")] fdqs2eqqqqawaqeqaqqq3da,
            [Description("Swimming under Backwards")] fdqs2eqqqawaqeqa1qqq3da,
            [Description("Swimming under Sprint")] fdqs2eqqqawaqeqaqqq3ada,
            [Description("Swimming under Left Sprint")] fdqs2eqqqawaqeqaqqq3adaf,
            [Description("Swimming under Right Sprint")] fdqs2eqqqawaqeqaqqq3adafa,
            [Description("Swimming under Sprint Start")] fdqs2eqqqqawaqeqaqqq3ada,
            [Description("Swimming under Upwards")] fdqs2eqqqqawaqeqaqqq3adad,
            [Description("Swimming under Downwards")] fdqs2eqqqqawfaqeqaqqq3adad,
            [Description("Crawl")] fdqs2eqqqqawfaqeqaqqq3a5dad = 4986,
            [Description("Interaction Start")] fdqs2eqqqqawfaqeqaqqq3ada = 4988,
            [Description("Interaction Loop")] fdqs2eqqqqawefaqeqaqqq3ada = 4989,
            [Description("Interaction End")] fdqs2eqqqqawefaqeqaqqq3aqda = 4990,
            [Description("Battle Stance & Looking")] fdqs2eqqqqawefaqeqawqqq3aqda = 4991,
            [Description("Samurai LB LV3 Start")] fdqs2eqqqqawefaqeqqawqqq3aqda = 5137,
            [Description("Samurai LB LV3 Loop")] fdqs2eqqqqawefaqefqqawqqq3aqda = 5138,
            [Description("Samurai LB LV3 End")] fdqs2eqqq2qawefaqefqqawqqq3aqda = 5139,
            [Description("Samurai LB LV3")] fdqs2eqqq2qawefaqe9fqqawqqq3aqda = 5178,
            [Description("RDM LB Start")] fdqs2eqqq2qawefaqe9fqqawqqqq3aqda = 5179,
            [Description("RDM LB Loop")] fdqs2eqqq2qawefaqe69fqqawqqqq3aqda = 5180,
            [Description("RDM LB LV3")] fdqs2eqqq2qawefaqqe69fqqawqqqq3aqda = 5181,
            [Description("Some weird shit")] fdqs2eqqq2qawefaqqe69fqrqawqqqq3aqda = 5286,
            [Description("Explaining Botharms upper bodyonly")] fdqs2eqqq2qawefaqqe69fqrqawqqaqq3aqda = 5464,
            [Description("Explaining 1arm upper bodyonly")] fdqs2eqqq2qawefaqqeq69fqrqawqqaqq3aqda = 5465,
            [Description("Explaining Botharms2 upper bodyonly")] fdqs2eqqq2qawefaqqe69efqrqawqqaqq3aqda = 5466,
            [Description("Finger wiggle+point upper bodyonly")] dfdqs2eqqq2qawefaqqe69fqrqawqqaqq3aqda = 5467,
            [Description("Onefinger talking upper bodyonly")] dfdqs2eqqq2qawefaqqe69fqrqawqqaqq3aqd6a = 5468,
            [Description("Lalafell+Racial? Think upper bodyonly")] dfdqs2eqqq2qawefaqqe69fqrqawqqaqq3aqgd6a = 5469,
            [Description("HandmMovement2 upper bodyonly")] dfdqs2eqqq2qawefaqqe69fqrqawqqafqq3aqgd6a = 5470,
            [Description("HandmMovement3 upper bodyonly")] dfdqs2eqqq2qawefaeqqe69fqrqawqqafqq3aqgd6a = 5471,
            [Description("Greet3 upper bodyonly")] dfdqs2eqqq2qawefaeqqe69fqrqawqqafaqq3aqgd6a = 5472,
            [Description("Shocked upper bodyonly")] dfdqs2eqqq2qawefaeqqe69fqrqawqqafaqq3agqgd6a = 5473,
            [Description("Present Item upper bodyonly")] dfdqs2eqqq2qaweafaeqqe69fqrqawqqafaqq3agqgd6a = 5474,
            [Description("Huh? upper bodyonly")] dfdqs2eqqq2qaweafaeqqe69feqrqawqqafaqq3agqgd6a = 5476,
            [Description("Get pumped upper bodyonly")] dfdqs2eqqq2qaweafaeqqe69freqrqawqqafaqq3agqgd6a = 5477,
            [Description("Floating talking")] axads = 5489,
            [Description("Floating Pointing")] aexads = 5490,
            [Description("Floating Searching")] aexaeds = 5491,
            [Description("Look at Item")] aex4aeds = 5521,
            [Description("Look left&right")] raex4aeds = 5522,
            [Description("Free Gifts")] raex4eaeds = 5534,
            [Description("Kneeling Wounded")] rarex4eaeds = 5535,
            [Description("Standing Wounded")] rarex4eaedrs = 5536,
            [Description("DJ/use Keyboard")] rarex4eaedars = 5540,
            [Description("Sit hands on righ leg")] rarex43eaedars = 5560,
            [Description("Push-up Start")] rarex43eaedrars = 5799,
            [Description("Push-up Loop")] rarex43eaeqdrars = 5800,
            [Description("Stomach Control Start")] rarex43eae1qdrars = 5801,
            [Description("Stomach Control Loop")] rarex43erae1qdrars = 5802,
            [Description("Sets of Squates")] rarex43eraea1qdrars = 5803,
            [Description("Breath in")] rarex43eraea1qdrqars = 5804,
            [Description("Attention Start")] rarex43eraea1qedrqars = 5805,
            [Description("Attention Loop")] rarex43eweraea1qedrqars = 5806,
            [Description("At Ease")] rarex43eweraeaa1qedrqars = 5808,
            Boxing = 5809,
            Converse = 5810,
            MountConverse = 5811,
            Lakshimi = 6124,
            [Description("Rabanastre Water Slide")] rarex43eweraeeaa1qed4rqars = 6126,
            [Description("Blowoff Start")] rarex43eweraeeaa1qed42rqars = 6127,
            [Description("Blowoff End")] rarex43eweraeeaa1qesad42rqars = 6128,
            Blowoff = 6133,
            Skydiving = 6139,
            [Description("Black Paint Brush")] rarex43eweraeeaar1qesad42rqars = 6140,
            [Description("Byakoo Holding you")] rarex43ewerqaeeaar1qesad42rqars = 6141,
            Painter1,
            Painter2,
            Painter3,
            Painter4,
            [Description("Sky Diving Blow Loop")] rarex453ewerqaeeaar1qesad42rqars = 6146,
            [Description("Sky Diving Dead Loop")] rarex453ewerqaeeaar51qesad42rqars = 6147,
            [Description("Sky Diving Blow")] rarex453ewerqaeeaar51qesad42rrqars = 6148,
            Painter5,
            [Description("Blow 2 Loop")] rarex453ewerqafeeaar51qesad42rrqars = 6153,
            Praying2 = 6219,
            Greetings = 6222,
            Elucidate = 6224,
            [Description("Chicken Dance")] rarex453ewerqaeeaar51qesads42rrqars = 6231,
            [Description("Lakshimi Dance (With Effects)")] rarex453ewerqareeaar51qesads42rrqars = 6242,
            [Description("Eastern Fighting")] rarex453ewerqareeaar51qesads542rrqars = 6249,
            [Description("Water Splash!")] rarex453ewerqareeaar51qesad5s542rrqars = 6252,
            [Description("Water Splash (In Water)!")] rarex453ewerqaree5aar51qesad5s542rrqars = 6255,
        }
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
        [JsonIgnore] public static Address<Emotes> EmoteX { get; set; }
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
        public Address<byte> EyeBrowType { get; set; }
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
        public Address<int> Job { get; set; }
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
        public Address<int> Offhand { get; set; }
        public Address<byte> OffhandBase { get; set; }
        public Address<byte> OffhandV { get; set; }
        public Address<Dyes> OffhandDye { get; set; }
        public Address<float> OffhandX { get; set; }
        public Address<float> OffhandY { get; set; }
        public Address<float> OffhandZ { get; set; }
        public Address<float> OffhandRed { get; set; }
        public Address<float> OffhandGreen { get; set; }
        public Address<float> OffhandBlue { get; set; }
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
        [JsonIgnore] public static Address<string> OffhandSlot { get; set; }
        [JsonIgnore] public static Address<string> LFingerSlot { get; set; }
        [JsonIgnore] public static Address<string> RFingerSlot { get; set; }
        [JsonIgnore] public static Address<string> NeckSlot { get; set; }
        [JsonIgnore] public static Address<string> WristSlot { get; set; }
        [JsonIgnore] public static Address<string> EarSlot { get; set; }
        [JsonIgnore] public static Address<string> WeaponSlot { get; set; }
        [JsonIgnore] public static Address<string> LegSlot { get; set; }
        [JsonIgnore] public static Address<string> FeetSlot { get; set; }
        [JsonIgnore] public static Address<string> HeadSlot { get; set; }
        [JsonIgnore] public static Address<string> BodySlot { get; set; }
        [JsonIgnore] public static Address<string> ArmSlot { get; set; }
        [JsonIgnore] public Address<byte> TimeControl { get; set; }
        [JsonIgnore] public Address<byte> Weather { get; set; }

        public CharacterDetails()
        {
            TimeControl = new Address<byte>();
            Weather = new Address<byte>();
            LFingerSlot = new Address<string>();
            RFingerSlot = new Address<string>();
            NeckSlot = new Address<string>();
            WristSlot = new Address<string>();
            EarSlot = new Address<string>();
            WeaponSlot = new Address<string>();
            OffhandSlot = new Address<string>();
            FeetSlot = new Address<string>();
            LegSlot = new Address<string>();
            BodySlot = new Address<string>();
            ArmSlot = new Address<string>();
            HeadSlot = new Address<string>();
            OffhandBase = new Address<byte>();
            OffhandV = new Address<byte>();
            EyeBrowType = new Address<byte>();
            OffhandDye = new Address<Dyes>();
            Offhand = new Address<int>();
            OffhandX = new Address<float>();
            OffhandY = new Address<float>();
            OffhandZ = new Address<float>();
            OffhandRed = new Address<float>();
            OffhandGreen = new Address<float>();
            OffhandBlue = new Address<float>();
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
            Job = new Address<int>();
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
            EmoteX = new Address<Emotes>();
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