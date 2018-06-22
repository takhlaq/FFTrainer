using System;
using FFTrainer.Models;
using FFTrainer.Commands;
using System.ComponentModel;
namespace FFTrainer.ViewModels
{
    public class CharacterDetailsViewModel : BaseViewModel
    {
 
        public CharacterDetails CharacterDetails { get => (CharacterDetails)model; set => model = value; }
        private RefreshEntitiesCommand refreshEntitiesCommand;
        public static string eOffset = "8";
        public static string TestBust = Settings.Instance.Character.Body.Bust.ToString();
        public static string baseAddr = MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset);

        public RefreshEntitiesCommand RefreshEntitiesCommand
        {
            get => refreshEntitiesCommand;
        }
        public CharacterDetailsViewModel(Mediator mediator) : base(mediator)
        {
            model = new CharacterDetails();
            model.PropertyChanged += Model_PropertyChanged;
            refreshEntitiesCommand = new RefreshEntitiesCommand(this);
            // refresh the list initially
            this.Refresh();

            mediator.Work += Work;

            mediator.EntitySelection += (offset) => eOffset = offset;
        }
        /// <summary>
        /// Model property changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedIndex")
                mediator.SendEntitySelection(((CharacterDetails.SelectedIndex + 1) * 8).ToString("X"));
        }
        public void Refresh()
        {
            try
            {
                // get the array size
                CharacterDetails.Size = MemoryManager.Instance.MemLib.readLong(MemoryManager.Instance.BaseAddress);

                // clear the entity list
                CharacterDetails.Names.Clear();

                // loop over entity list size
                for (var i = 0; i < CharacterDetails.Size; i++)
                {
                    var addr = MemoryManager.GetAddressString(MemoryManager.Add(MemoryManager.Instance.BaseAddress, ((i + 1) * 8).ToString("X")), Settings.Instance.Character.Name);
                    var name = MemoryManager.Instance.MemLib.readString(addr);
                    if (name.IndexOf('\0') != -1)
                        name = name.Substring(0, name.IndexOf('\0'));
                    CharacterDetails.Names.Add(name);
                }

                // set the enable state
                CharacterDetails.IsEnabled = true;
                // set the index if its under 0
                if (CharacterDetails.SelectedIndex < 0)
                    CharacterDetails.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
        private void Work()
        {
            try
            {
                /*
                 *             MemoryManager.Instance.BaseAddress = baseAddr;
            MemoryManager.Instance.CameraAddress = CameraAddr;
            MemoryManager.Instance.EmoteAddress = EmoteAddr;
            MemoryManager.Instance.GposeAddress = GposeAddr;*/
                baseAddr = MemoryManager.Add(MemoryManager.Instance.BaseAddress, eOffset);
                var bodyBase = Settings.Instance.Character.Body.Base;
                var body = Settings.Instance.Character.Body;
                if (CharacterDetails.GposeMode.Activated) baseAddr = MemoryManager.Instance.GposeAddress;
                var bust = body.Bust;
                var mem = MemoryManager.Instance.MemLib;
                var height = MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.Height);
                var Wetness = MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.Wetness);
                var SWetness = MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.SWetness);
                var xAddr = MemoryManager.GetAddressString(baseAddr, body.Base, bust.Base, bust.X);
                var yAddr = MemoryManager.GetAddressString(baseAddr, body.Base, bust.Base, bust.Y);
                var zAddr = MemoryManager.GetAddressString(baseAddr, body.Base, bust.Base, bust.Z);
                var x = MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.Position.X);
                var y = MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.Position.Y);
                var z = MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.Position.Z);
                var head = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Head);
                var hair = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Hair);
                var rotation = MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.Position.Rotation);
                var rotation2 = MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.Position.Rotation2);
                var rotation3 = MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.Position.Rotation3);
                var rotation4 = MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.Position.Rotation4);
                var raceAddr = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Race);
                var clanAddr = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Clan);
                var genderAddr = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Gender);
                var nameAddr = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Name);
                var hairTone = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairTone);
                var highlights = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Highlights);
                var highlightTone = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HighlightTone);
                var skintone = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Skintone);
                var facialFeatures = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.FacialFeatures);
                var eye = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Eye);
                var rightEye = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RightEye);
                var leftEye = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LeftEye);
                var facePaint = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.FacePaint);
                var facePaintColor = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.FacePaintColor);
                var nose = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Nose);
                var lips = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Lips);
                var tailType = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.TailType);
                var cameraHeight = MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CameraHeight);
                var camX = MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamX);
                var camY = MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamY);
                var camZ = MemoryManager.GetAddressString(MemoryManager.Instance.GposeAddress, Settings.Instance.Character.CamZ);
                var max = MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Max);
                var min = MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.Min);
                var cZoom = MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CZoom);
                var fovC = MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVC);
                var fovMAX = MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOVMAX);
                var muscleTone = MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.MuscleTone);
                var JobAddr = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Job);

                if (CharacterDetails.LipsB.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LipsB), CharacterDetails.LipsB.GetBytes());
                else CharacterDetails.LipsB.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LipsB));

                if (CharacterDetails.LipsG.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LipsG), CharacterDetails.LipsG.GetBytes());
                else CharacterDetails.LipsG.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LipsG));

                if (CharacterDetails.LipsR.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LipsR), CharacterDetails.LipsR.GetBytes());
                else CharacterDetails.LipsR.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LipsR));

                if (CharacterDetails.LipsBrightness.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LipsBrightness), CharacterDetails.LipsBrightness.GetBytes());
                else CharacterDetails.LipsBrightness.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LipsBrightness));

                if (CharacterDetails.RightEyeBlue.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RightEyeBlue), CharacterDetails.RightEyeBlue.GetBytes());
                else CharacterDetails.RightEyeBlue.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RightEyeBlue));

                if (CharacterDetails.RightEyeGreen.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RightEyeGreen), CharacterDetails.RightEyeGreen.GetBytes());
                else CharacterDetails.RightEyeGreen.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RightEyeGreen));

                if (CharacterDetails.RightEyeRed.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RightEyeRed), CharacterDetails.RightEyeRed.GetBytes());
                else CharacterDetails.RightEyeRed.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RightEyeRed));
                if (CharacterDetails.LeftEyeBlue.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LeftEyeBlue), CharacterDetails.LeftEyeBlue.GetBytes());
                else CharacterDetails.LeftEyeBlue.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LeftEyeBlue));

                if (CharacterDetails.LeftEyeGreen.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LeftEyeGreen), CharacterDetails.LeftEyeGreen.GetBytes());
                else CharacterDetails.LeftEyeGreen.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LeftEyeGreen));

                if (CharacterDetails.LeftEyeRed.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LeftEyeRed), CharacterDetails.LeftEyeRed.GetBytes());
                else CharacterDetails.LeftEyeRed.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LeftEyeRed));

                if (CharacterDetails.HighlightBluePigment.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HighlightBluePigment), CharacterDetails.HighlightBluePigment.GetBytes());
                else CharacterDetails.HighlightBluePigment.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HighlightBluePigment));

                if (CharacterDetails.HighlightGreenPigment.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HighlightGreenPigment), CharacterDetails.HighlightGreenPigment.GetBytes());
                else CharacterDetails.HighlightGreenPigment.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HighlightGreenPigment));

                if (CharacterDetails.HighlightRedPigment.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HighlightRedPigment), CharacterDetails.HighlightRedPigment.GetBytes());
                else CharacterDetails.HighlightRedPigment.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HighlightRedPigment));

                if (CharacterDetails.HairGlowBlue.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairGlowBlue), CharacterDetails.HairGlowBlue.GetBytes());
                else CharacterDetails.HairGlowBlue.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairGlowBlue));

                if (CharacterDetails.HairGlowGreen.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairGlowGreen), CharacterDetails.HairGlowGreen.GetBytes());
                else CharacterDetails.HairGlowGreen.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairGlowGreen));

                if (CharacterDetails.HairGlowRed.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairGlowRed), CharacterDetails.HairGlowRed.GetBytes());
                else CharacterDetails.HairGlowRed.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairGlowRed));

                if (CharacterDetails.HairBluePigment.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairBluePigment), CharacterDetails.HairBluePigment.GetBytes());
                else CharacterDetails.HairBluePigment.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairBluePigment));

                if (CharacterDetails.HairGreenPigment.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairGreenPigment), CharacterDetails.HairGreenPigment.GetBytes());
                else CharacterDetails.HairGreenPigment.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairGreenPigment));

                if (CharacterDetails.HairRedPigment.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairRedPigment), CharacterDetails.HairRedPigment.GetBytes());
                else CharacterDetails.HairRedPigment.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HairRedPigment));

                if (CharacterDetails.SkinBlueGloss.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.SkinBlueGloss), CharacterDetails.SkinBlueGloss.GetBytes());
                else CharacterDetails.SkinBlueGloss.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.SkinBlueGloss));

                if (CharacterDetails.SkinGreenGloss.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.SkinGreenGloss), CharacterDetails.SkinGreenGloss.GetBytes());
                else CharacterDetails.SkinGreenGloss.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.SkinGreenGloss));

                if (CharacterDetails.SkinRedGloss.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.SkinRedGloss), CharacterDetails.SkinRedGloss.GetBytes());
                else CharacterDetails.SkinRedGloss.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.SkinRedGloss));

                if (CharacterDetails.SkinBluePigment.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.SkinBluePigment), CharacterDetails.SkinBluePigment.GetBytes());
                else CharacterDetails.SkinBluePigment.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.SkinBluePigment));

                if (CharacterDetails.SkinGreenPigment.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.SkinGreenPigment), CharacterDetails.SkinGreenPigment.GetBytes());
                else CharacterDetails.SkinGreenPigment.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.SkinGreenPigment));

                if (CharacterDetails.SkinRedPigment.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.SkinRedPigment), CharacterDetails.SkinRedPigment.GetBytes());
                else CharacterDetails.SkinRedPigment.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.SkinRedPigment));

                if (CharacterDetails.WeaponRed.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponRed), CharacterDetails.WeaponRed.GetBytes());
                else CharacterDetails.WeaponRed.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponRed));

                if (CharacterDetails.WeaponGreen.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponGreen), CharacterDetails.WeaponGreen.GetBytes());
                else CharacterDetails.WeaponGreen.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponGreen));


                if (CharacterDetails.WeaponBlue.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponBlue), CharacterDetails.WeaponBlue.GetBytes());
                else CharacterDetails.WeaponBlue.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponBlue));

                if (CharacterDetails.TailSize.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.TailSize), CharacterDetails.TailSize.GetBytes());
                else CharacterDetails.TailSize.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, bodyBase, Settings.Instance.Character.Body.TailSize));

                if (CharacterDetails.LFinger.freeze)
                {
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LFinger), CharacterDetails.LFinger.GetBytes());
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LFingerVa), CharacterDetails.LFingerVa.GetBytes());
                }
                else
                {
                    CharacterDetails.LFinger.value = (long)mem.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LFinger));
                    CharacterDetails.LFingerVa.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LFingerVa));
                }
                if (CharacterDetails.RFinger.freeze)
                {
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RFinger), CharacterDetails.RFinger.GetBytes());
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RFingerVa), CharacterDetails.RFingerVa.GetBytes());
                }
                else
                {
                    CharacterDetails.RFinger.value = (long)mem.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RFinger));
                    CharacterDetails.RFingerVa.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.RFingerVa));
                }
                if (CharacterDetails.Wrist.freeze)
                {
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Wrist), CharacterDetails.Wrist.GetBytes());
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WristVa), CharacterDetails.WristVa.GetBytes());
                }
                else
                {
                    CharacterDetails.Wrist.value = (long)mem.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Wrist));
                    CharacterDetails.WristVa.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WristVa));
                }
                if (CharacterDetails.Neck.freeze)
                {
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Neck), CharacterDetails.Neck.GetBytes());
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.NeckVa), CharacterDetails.NeckVa.GetBytes());
                }
                else
                {
                    CharacterDetails.Neck.value = (long)mem.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Neck));
                    CharacterDetails.NeckVa.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.NeckVa));
                }
                if (CharacterDetails.Ear.freeze)
                {
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Ear), CharacterDetails.Ear.GetBytes());
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.EarVa), CharacterDetails.EarVa.GetBytes());
                }
                else
                {
                    CharacterDetails.Ear.value = (long)mem.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Ear));
                    CharacterDetails.EarVa.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.EarVa));
                }

                if (CharacterDetails.Feet.freeze)
                {
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Feet), CharacterDetails.Feet.GetBytes());
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.FeetVa), CharacterDetails.FeetVa.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.FeetDye), CharacterDetails.FeetDye.GetBytes());
                }
                else
                {
                    CharacterDetails.Feet.value = (long)mem.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Feet));
                    CharacterDetails.FeetVa.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.FeetVa));
                    CharacterDetails.FeetDye.value = (CharacterDetails.Dyes)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.FeetDye));
                }

                if (CharacterDetails.Legs.freeze)
                {
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Legs), CharacterDetails.Legs.GetBytes());
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LegsV), CharacterDetails.LegsV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LegsDye), CharacterDetails.LegsDye.GetBytes());
                }
                else
                {
                    CharacterDetails.Legs.value = (long)mem.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Legs));
                    CharacterDetails.LegsV.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LegsV));
                    CharacterDetails.LegsDye.value = (CharacterDetails.Dyes)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.LegsDye));
                }

                if (CharacterDetails.Arms.freeze)
                {
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Arms), CharacterDetails.Arms.GetBytes());
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ArmsV), CharacterDetails.ArmsV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ArmsDye), CharacterDetails.ArmsDye.GetBytes());
                }
                else
                {
                    CharacterDetails.Arms.value = (long)mem.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Arms));
                    CharacterDetails.ArmsV.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ArmsV));
                    CharacterDetails.ArmsDye.value = (CharacterDetails.Dyes)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ArmsDye));
                }

                if (CharacterDetails.Chest.freeze)
                {
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Chest), CharacterDetails.Chest.GetBytes());
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ChestV), CharacterDetails.ChestV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ChestDye), CharacterDetails.ChestDye.GetBytes());
                }
                else
                {
                    CharacterDetails.Chest.value = (long)mem.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Chest));
                    CharacterDetails.ChestV.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ChestV));
                    CharacterDetails.ChestDye.value = (CharacterDetails.Dyes)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.ChestDye));
                }
                if (CharacterDetails.HeadPiece.freeze)
                {
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HeadDye), CharacterDetails.HeadDye.GetBytes());
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HeadV), CharacterDetails.HeadV.GetBytes());
                    mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HeadPiece), CharacterDetails.HeadPiece.GetBytes());
                }
                else
                {
                    CharacterDetails.HeadPiece.value = (long)mem.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HeadPiece));
                    CharacterDetails.HeadV.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HeadV));
                    CharacterDetails.HeadDye.value = (CharacterDetails.Dyes)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.HeadDye));
                }
                if (CharacterDetails.WeaponZ.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponZ), CharacterDetails.WeaponZ.GetBytes());
                else CharacterDetails.WeaponZ.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponZ));

                if (CharacterDetails.WeaponY.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponY), CharacterDetails.WeaponY.GetBytes());
                else CharacterDetails.WeaponY.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponY));

                if (CharacterDetails.WeaponX.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponX), CharacterDetails.WeaponX.GetBytes());
                else CharacterDetails.WeaponX.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponX));

                if (!CharacterDetails.Job.freeze)
                {
                    CharacterDetails.Job.value = (CharacterDetails.Jobs)MemoryManager.Instance.MemLib.read2Byte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Job));
                    CharacterDetails.WeaponBase.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponBase));
                    CharacterDetails.WeaponV.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponV));
                    CharacterDetails.WeaponDye.value = (CharacterDetails.Dyes)MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponDye));
                }

                else
                {
                    long xd = (long)CharacterDetails.Job.value;
                    MemoryManager.Instance.MemLib.writeMemory(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Job), "long", xd.ToString());
                  //  MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Job), CharacterDetails.Job.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponBase), CharacterDetails.WeaponBase.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponV), CharacterDetails.WeaponV.GetBytes());
                    MemoryManager.Instance.MemLib.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponDye), CharacterDetails.WeaponDye.GetBytes());
                }


                if (CharacterDetails.MuscleTone.freeze) mem.writeBytes(muscleTone, CharacterDetails.MuscleTone.GetBytes());
                else CharacterDetails.MuscleTone.value = mem.readFloat(muscleTone);

                if (CharacterDetails.FOVMAX.freeze)
                {
                    mem.writeBytes(fovMAX, CharacterDetails.FOVMAX.GetBytes());
                    mem.writeBytes(fovC, CharacterDetails.FOVC.GetBytes());
                }
                else
                {
                    CharacterDetails.FOVMAX.value = mem.readFloat(fovMAX);
                    CharacterDetails.FOVC.value = mem.readFloat(fovC);
                }

                if (CharacterDetails.CZoom.freeze) mem.writeBytes(cZoom, CharacterDetails.CZoom.GetBytes());
                else CharacterDetails.CZoom.value = mem.readFloat(cZoom);

                if (CharacterDetails.Min.freeze) mem.writeBytes(min, CharacterDetails.Min.GetBytes());
                else CharacterDetails.Min.value = mem.readFloat(min);

                if (CharacterDetails.Max.freeze) mem.writeBytes(max, CharacterDetails.Max.GetBytes());
                else CharacterDetails.Max.value = mem.readFloat(max);

                if (CharacterDetails.CamZ.freeze)mem.writeBytes(camZ, CharacterDetails.CamZ.GetBytes());
                else CharacterDetails.CamZ.value = mem.readFloat(camZ);

                if (CharacterDetails.CamY.freeze)
                {
                    mem.writeBytes(camY, CharacterDetails.CamY.GetBytes()); ;
                }
                else
                    CharacterDetails.CamY.value = mem.readFloat(camY);

                if (CharacterDetails.CamX.freeze)
                {
                    mem.writeBytes(camX, CharacterDetails.CamX.GetBytes()); ;
                }
                else
                    CharacterDetails.CamX.value = mem.readFloat(camX);

                if (CharacterDetails.CameraHeight.freeze)
                {
                    mem.writeBytes(cameraHeight, CharacterDetails.CameraHeight.GetBytes());;
                }
                else
                    CharacterDetails.CameraHeight.value = mem.readFloat(cameraHeight);

              /*  if (CharacterDetails.Emote.freeze)
                    mem.writeBytes(Emmote, CharacterDetails.Emote.GetBytes());
                else CharacterDetails.Emote.value = (long)mem.read2Byte(Emmote);*/
                if (CharacterDetails.TailType.freeze)
                    mem.writeBytes(tailType, CharacterDetails.TailType.GetBytes());
                else CharacterDetails.TailType.value = (byte)mem.readByte(tailType);

                if (CharacterDetails.HairTone.freeze)
                    mem.writeBytes(hairTone, CharacterDetails.HairTone.GetBytes());
                else CharacterDetails.HairTone.value = (byte)mem.readByte(hairTone);

                CharacterDetails.Highlights.value = (byte)mem.readByte(highlights);

                if (CharacterDetails.HighlightTone.freeze)
                    mem.writeBytes(highlightTone, CharacterDetails.HighlightTone.GetBytes());
                else CharacterDetails.HighlightTone.value = (byte)mem.readByte(highlightTone);

                if (CharacterDetails.Skintone.freeze)
                    mem.writeBytes(skintone, CharacterDetails.Skintone.GetBytes());
                else CharacterDetails.Skintone.value = (byte)mem.readByte(skintone);

                if (CharacterDetails.Lips.freeze)
                    mem.writeBytes(lips, CharacterDetails.Lips.GetBytes());
                else CharacterDetails.Lips.value = (byte)mem.readByte(lips);

                if (CharacterDetails.Nose.freeze)
                    mem.writeBytes(nose, CharacterDetails.Nose.GetBytes());
                else CharacterDetails.Nose.value = (byte)mem.readByte(nose);

                if (CharacterDetails.FacePaintColor.freeze)
                    mem.writeBytes(facePaintColor, CharacterDetails.FacePaintColor.GetBytes());
                else CharacterDetails.FacePaintColor.value = (byte)mem.readByte(facePaintColor);

                if (CharacterDetails.FacePaint.freeze)
                    mem.writeBytes(facePaint, CharacterDetails.FacePaint.GetBytes());
                else CharacterDetails.FacePaint.value = (byte)mem.readByte(facePaint);

                if (CharacterDetails.LeftEye.freeze)
                    mem.writeBytes(leftEye, CharacterDetails.LeftEye.GetBytes());
                else CharacterDetails.LeftEye.value = (byte)mem.readByte(leftEye);

                if (CharacterDetails.RightEye.freeze)
                    mem.writeBytes(rightEye, CharacterDetails.RightEye.GetBytes());
                else CharacterDetails.RightEye.value = (byte)mem.readByte(rightEye);

                if (CharacterDetails.Eye.freeze)
                    mem.writeBytes(eye, CharacterDetails.Eye.GetBytes());
                else CharacterDetails.Eye.value = (byte)mem.readByte(eye);

                if (CharacterDetails.FacialFeatures.freeze)
                    mem.writeBytes(facialFeatures, CharacterDetails.FacialFeatures.GetBytes());
                else CharacterDetails.FacialFeatures.value = (byte)mem.readByte(facialFeatures);

                if (CharacterDetails.Height.freeze) mem.writeBytes(height, CharacterDetails.Height.GetBytes());
                else CharacterDetails.Height.value = mem.readFloat(height);

                if (CharacterDetails.BustX.freeze)
                    mem.writeBytes(xAddr, CharacterDetails.BustX.GetBytes());
                else
                    CharacterDetails.BustX.value = mem.readFloat(xAddr);

                if (CharacterDetails.BustY.freeze)
                    mem.writeBytes(yAddr, CharacterDetails.BustY.GetBytes());
                else
                    CharacterDetails.BustY.value = mem.readFloat(yAddr);

                if (CharacterDetails.BustZ.freeze)
                    mem.writeBytes(zAddr, CharacterDetails.BustZ.GetBytes());
                else
                    CharacterDetails.BustZ.value = mem.readFloat(zAddr);
                if (CharacterDetails.X.freeze)
                    mem.writeBytes(x, CharacterDetails.X.GetBytes());
                else
                    CharacterDetails.X.value = mem.readFloat(x);
                if (CharacterDetails.Head.freeze)
                    mem.writeBytes(head, CharacterDetails.Head.GetBytes());
                else CharacterDetails.Head.value = (byte)mem.readByte(head);

                if (CharacterDetails.Hair.freeze) mem.writeBytes(hair, CharacterDetails.Hair.GetBytes());
                else CharacterDetails.Hair.value = (byte)mem.readByte(hair);
                if (CharacterDetails.Y.freeze) mem.writeBytes(y, CharacterDetails.Y.GetBytes());
                else CharacterDetails.Y.value = mem.readFloat(y);

                if (CharacterDetails.Z.freeze)
                    mem.writeBytes(z, CharacterDetails.Z.GetBytes());
                else
                    CharacterDetails.Z.value = mem.readFloat(z);
                if (CharacterDetails.Rotation.freeze)
                    mem.writeBytes(rotation, CharacterDetails.Rotation.GetBytes());
                else
                    CharacterDetails.Rotation.value = mem.readFloat(rotation);
                if (CharacterDetails.Rotation2.freeze)
                    mem.writeBytes(rotation, CharacterDetails.Rotation2.GetBytes());
                else
                    CharacterDetails.Rotation2.value = mem.readFloat(rotation2);
                if (CharacterDetails.Rotation3.freeze)
                    mem.writeBytes(rotation3, CharacterDetails.Rotation3.GetBytes());
                else
                    CharacterDetails.Rotation3.value = mem.readFloat(rotation3);
                if (CharacterDetails.Rotation4.freeze)
                    mem.writeBytes(rotation4, CharacterDetails.Rotation4.GetBytes());
                else
                    CharacterDetails.Rotation4.value = mem.readFloat(rotation4);
                if (!CharacterDetails.Race.freeze)
                    CharacterDetails.Race.value = (CharacterDetails.Races)MemoryManager.Instance.MemLib.readByte(raceAddr);
                else
                    MemoryManager.Instance.MemLib.writeBytes(raceAddr, CharacterDetails.Race.GetBytes());

                if (!CharacterDetails.Clan.freeze)
                    CharacterDetails.Clan.value = (CharacterDetails.Clans)MemoryManager.Instance.MemLib.readByte(clanAddr);
                else
                    MemoryManager.Instance.MemLib.writeBytes(clanAddr, CharacterDetails.Clan.GetBytes());

                if (!CharacterDetails.Gender.freeze)
                    CharacterDetails.Gender.value = (CharacterDetails.Genders)MemoryManager.Instance.MemLib.readByte(genderAddr);
                else
                    MemoryManager.Instance.MemLib.writeBytes(genderAddr, CharacterDetails.Gender.GetBytes());

                if (!CharacterDetails.Name.freeze)
                {
                    var nameX = MemoryManager.Instance.MemLib.readString(nameAddr);

                    if (nameX.IndexOf('\0') != -1)
                        nameX = nameX.Substring(0, nameX.IndexOf('\0'));
                    CharacterDetails.Name.value = nameX;
                }
                if (CharacterDetails.Wetness.Activated) MemoryManager.Instance.MemLib.writeMemory(Wetness, "float", "1");
                if (CharacterDetails.SWetness.Activated) MemoryManager.Instance.MemLib.writeMemory(SWetness, "float", "5");
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Oh no!");
                System.Windows.MessageBox.Show("Disabling " + this.GetType().Name, "Oh no!");
                mediator.Work -= Work;
            }
        }
    }
}