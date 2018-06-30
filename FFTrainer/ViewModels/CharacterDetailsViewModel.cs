using System;
using FFTrainer.Models;
using FFTrainer.Commands;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FFTrainer.Views;

namespace FFTrainer.ViewModels
{
    public class CharacterDetailsViewModel : BaseViewModel
    {
 
        public static CharacterDetails CharacterDetails { get => (CharacterDetails)model; set => model = value; }
        private RefreshEntitiesCommand refreshEntitiesCommand;
        public static string eOffset = "8";
        public static bool TestxD = false;
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
                var nameAddr = MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Name);
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
                if (!CharacterDetails.GposeMode.Activated)
                {
                    CharacterDetailsView2._gearSet.HeadGear = CharacterDetailsView2.ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.HeadPiece));
                    CharacterDetails.HeadSlot.value = CharacterDetailsView2.GearTupleToComma(CharacterDetailsView2._gearSet.HeadGear);
                    CharacterDetailsView2._gearSet.BodyGear = CharacterDetailsView2.ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Chest));
                    CharacterDetails.BodySlot.value = CharacterDetailsView2.GearTupleToComma(CharacterDetailsView2._gearSet.BodyGear);
                    CharacterDetailsView2._gearSet.HandsGear = CharacterDetailsView2.ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Arms));
                    CharacterDetails.ArmSlot.value = CharacterDetailsView2.GearTupleToComma(CharacterDetailsView2._gearSet.HandsGear);
                    CharacterDetailsView2._gearSet.LegsGear = CharacterDetailsView2.ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Legs));
                    CharacterDetails.LegSlot.value = CharacterDetailsView2.GearTupleToComma(CharacterDetailsView2._gearSet.LegsGear);
                    CharacterDetailsView2._gearSet.FeetGear = CharacterDetailsView2.ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Feet));
                    CharacterDetails.FeetSlot.value = CharacterDetailsView2.GearTupleToComma(CharacterDetailsView2._gearSet.FeetGear);
                    CharacterDetailsView2._gearSet.MainWep = CharacterDetailsView2.ReadWepTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Job));
                    CharacterDetails.WeaponSlot.value = CharacterDetailsView2.WepTupleToComma(CharacterDetailsView2._gearSet.MainWep);
                    CharacterDetailsView2._gearSet.EarGear = CharacterDetailsView2.ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Ear));
                    CharacterDetails.EarSlot.value = CharacterDetailsView2.GearTupleToComma(CharacterDetailsView2._gearSet.EarGear);
                    CharacterDetailsView2._gearSet.WristGear = CharacterDetailsView2.ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Wrist));
                    CharacterDetails.WristSlot.value = CharacterDetailsView2.GearTupleToComma(CharacterDetailsView2._gearSet.WristGear);
                    CharacterDetailsView2._gearSet.NeckGear = CharacterDetailsView2.ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Neck));
                    CharacterDetails.NeckSlot.value = CharacterDetailsView2.GearTupleToComma(CharacterDetailsView2._gearSet.NeckGear);
                    CharacterDetailsView2._gearSet.LRingGear = CharacterDetailsView2.ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.LFinger));
                    CharacterDetails.LFingerSlot.value = CharacterDetailsView2.GearTupleToComma(CharacterDetailsView2._gearSet.LRingGear);
                    CharacterDetailsView2._gearSet.RRingGear = CharacterDetailsView2.ReadGearTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.RFinger));
                    CharacterDetails.RFingerSlot.value = CharacterDetailsView2.GearTupleToComma(CharacterDetailsView2._gearSet.RRingGear);
                    CharacterDetailsView2._gearSet.OffWep = CharacterDetailsView2.ReadWepTuple(MemoryManager.GetAddressString(CharacterDetailsViewModel.baseAddr, Settings.Instance.Character.Offhand));
                    CharacterDetails.OffhandSlot.value = CharacterDetailsView2.WepTupleToComma(CharacterDetailsView2._gearSet.OffWep);
                }
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

                if (CharacterDetails.WeaponZ.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponZ), CharacterDetails.WeaponZ.GetBytes());
                else CharacterDetails.WeaponZ.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponZ));

                if (CharacterDetails.WeaponY.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponY), CharacterDetails.WeaponY.GetBytes());
                else CharacterDetails.WeaponY.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponY));

                if (CharacterDetails.WeaponX.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponX), CharacterDetails.WeaponX.GetBytes());
                else CharacterDetails.WeaponX.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.WeaponX));

                if (CharacterDetails.OffhandZ.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandZ), CharacterDetails.OffhandZ.GetBytes());
                else CharacterDetails.OffhandZ.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandZ));

                if (CharacterDetails.OffhandY.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandY), CharacterDetails.OffhandY.GetBytes());
                else CharacterDetails.OffhandY.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandY));

                if (CharacterDetails.OffhandX.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandX), CharacterDetails.OffhandX.GetBytes());
                else CharacterDetails.OffhandX.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandX));

                if (CharacterDetails.OffhandBlue.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandBlue), CharacterDetails.OffhandBlue.GetBytes());
                else CharacterDetails.OffhandBlue.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandBlue));

                if (CharacterDetails.OffhandGreen.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandGreen), CharacterDetails.OffhandGreen.GetBytes());
                else CharacterDetails.OffhandGreen.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandGreen));

                if (CharacterDetails.OffhandRed.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandRed), CharacterDetails.OffhandRed.GetBytes());
                else CharacterDetails.OffhandRed.value = mem.readFloat(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.OffhandRed));

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
                if (CharacterDetails.CameraHeight.freeze) mem.writeBytes(cameraHeight, CharacterDetails.CameraHeight.GetBytes());
                else CharacterDetails.CameraHeight.value = mem.readFloat(cameraHeight);

                if (CharacterDetails.CameraHeight2.freeze) mem.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraHeight), CharacterDetails.CameraHeight2.GetBytes());
                else CharacterDetails.CameraHeight2.value = mem.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraHeight));

                if (CharacterDetails.CameraYAMin.freeze) mem.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMin), CharacterDetails.CameraYAMin.GetBytes());
                else CharacterDetails.CameraYAMin.value = mem.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMin));

                if (CharacterDetails.CameraYAMax.freeze) mem.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMax), CharacterDetails.CameraYAMax.GetBytes());
                else CharacterDetails.CameraYAMax.value = mem.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraYAMax));

                if (CharacterDetails.FOV2.freeze) mem.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2), CharacterDetails.FOV2.GetBytes());
                else CharacterDetails.FOV2.value = mem.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.FOV2));

                if (CharacterDetails.CameraUpDown.freeze) mem.writeBytes(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraUpDown), CharacterDetails.CameraUpDown.GetBytes());
                else CharacterDetails.CameraUpDown.value = mem.readFloat(MemoryManager.GetAddressString(MemoryManager.Instance.CameraAddress, Settings.Instance.Character.CameraUpDown));

                if (CharacterDetails.Voices.freeze) mem.writeBytes(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Voices), CharacterDetails.Voices.GetBytes());
                else CharacterDetails.Voices.value = (byte)mem.readByte(MemoryManager.GetAddressString(baseAddr, Settings.Instance.Character.Voices));

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
        public static void Hahaxd()
        {
            var characterDetailsView = new CharacterDetailsView();
            var characterDetailsView2 = new CharacterDetailsView2();
            var characterDetailsView3 = new CharacterDetailsView3();
            if (CharacterDetails.MuscleTone.freezetest == true) { CharacterDetails.MuscleTone.freeze = true; CharacterDetails.MuscleTone.freezetest = false; characterDetailsView.MuscleCheck.IsChecked = true; }
            if (CharacterDetails.TailSize.freezetest == true) { CharacterDetails.TailSize.freeze = true; CharacterDetails.TailSize.freezetest = false; characterDetailsView.TailSizeCheck.IsChecked = true; }
            if (CharacterDetails.BustX.freezetest == true) { CharacterDetails.BustX.freeze = true; CharacterDetails.BustX.freezetest = false; characterDetailsView.BustXCheck.IsChecked = true; }
            if (CharacterDetails.BustY.freezetest == true) { CharacterDetails.BustY.freeze = true; CharacterDetails.BustY.freezetest = false; characterDetailsView.BustYCheck.IsChecked = true; }
            if (CharacterDetails.BustZ.freezetest == true) { CharacterDetails.BustZ.freeze = true; CharacterDetails.BustZ.freezetest = false; characterDetailsView.BustZCheck.IsChecked = true; }
            if (CharacterDetails.LipsBrightness.freezetest == true) { CharacterDetails.LipsBrightness.freeze = true; CharacterDetails.LipsBrightness.freezetest = false; characterDetailsView3.LipBright.IsChecked = true; }
            if (CharacterDetails.SkinBlueGloss.freezetest == true) { CharacterDetails.SkinBlueGloss.freeze = true; CharacterDetails.SkinBlueGloss.freezetest = false; characterDetailsView3.BlueGloss.IsChecked = true; }
            if (CharacterDetails.SkinGreenGloss.freezetest == true) { CharacterDetails.SkinGreenGloss.freeze = true; CharacterDetails.SkinGreenGloss.freezetest = false; characterDetailsView3.GreenGloss.IsChecked = true; }
            if (CharacterDetails.SkinRedGloss.freezetest == true) { CharacterDetails.SkinRedGloss.freeze = true; CharacterDetails.SkinRedGloss.freezetest = false; characterDetailsView3.RedGloss.IsChecked = true; }
            if (CharacterDetails.SkinBluePigment.freezetest == true) { CharacterDetails.SkinBluePigment.freeze = true; CharacterDetails.SkinBluePigment.freezetest = false; characterDetailsView3.SkinBlue.IsChecked = true; }
            if (CharacterDetails.SkinGreenPigment.freezetest == true) { CharacterDetails.SkinGreenPigment.freeze = true; CharacterDetails.SkinGreenPigment.freezetest = false; characterDetailsView3.SkinGreen.IsChecked = true; }
            if (CharacterDetails.SkinRedPigment.freezetest == true) { CharacterDetails.SkinRedPigment.freeze = true; CharacterDetails.SkinRedPigment.freezetest = false; characterDetailsView3.SkinRed.IsChecked = true; }
            if (CharacterDetails.HighlightBluePigment.freezetest == true) { CharacterDetails.HighlightBluePigment.freeze = true; CharacterDetails.HighlightBluePigment.freezetest = false; characterDetailsView3.HLBP.IsChecked = true; }
            if (CharacterDetails.HighlightGreenPigment.freezetest == true) { CharacterDetails.HighlightGreenPigment.freeze = true; CharacterDetails.HighlightGreenPigment.freezetest = false; characterDetailsView3.HLGP.IsChecked = true; }
            if (CharacterDetails.HighlightRedPigment.freezetest == true) { CharacterDetails.HighlightRedPigment.freeze = true; CharacterDetails.HighlightRedPigment.freezetest = false; characterDetailsView3.HLRP.IsChecked = true; }
            if (CharacterDetails.HairGlowBlue.freezetest == true) { CharacterDetails.HairGlowBlue.freeze = true; CharacterDetails.HairGlowBlue.freezetest = false; characterDetailsView3.HairBGCheck.IsChecked = true; }
            if (CharacterDetails.HairGlowGreen.freezetest == true) { CharacterDetails.HairGlowGreen.freeze = true; CharacterDetails.HairGlowGreen.freezetest = false; characterDetailsView3.HairGGCheck.IsChecked = true; }
            if (CharacterDetails.HairGlowRed.freezetest == true) { CharacterDetails.HairGlowRed.freeze = true; CharacterDetails.HairGlowRed.freezetest = false; characterDetailsView3.HairRGCheck.IsChecked = true; }
            if (CharacterDetails.HairGreenPigment.freezetest == true) { CharacterDetails.HairGreenPigment.freeze = true; CharacterDetails.HairGreenPigment.freezetest = false; characterDetailsView3.HairGreenP.IsChecked = true; }
            if (CharacterDetails.HairBluePigment.freezetest == true) { CharacterDetails.HairBluePigment.freeze = true; CharacterDetails.HairBluePigment.freezetest = false; characterDetailsView3.HairBlueP.IsChecked = true; }
            if (CharacterDetails.HairRedPigment.freezetest == true) { CharacterDetails.HairRedPigment.freeze = true; CharacterDetails.HairRedPigment.freezetest = false; characterDetailsView3.HairRedP.IsChecked = true; }
            if (CharacterDetails.Height.freezetest == true) { CharacterDetails.Height.freeze = true; CharacterDetails.Height.freezetest = false; characterDetailsView.HeightCheck.IsChecked = false; }
            if (CharacterDetails.WeaponGreen.freezetest == true) { CharacterDetails.WeaponGreen.freeze = true; CharacterDetails.WeaponGreen.freezetest = false; characterDetailsView2.Green.IsChecked = true; }
            if (CharacterDetails.WeaponBlue.freezetest == true) { CharacterDetails.WeaponBlue.freeze = true; CharacterDetails.WeaponBlue.freezetest = false; characterDetailsView2.Blue.IsChecked = true; }
            if (CharacterDetails.WeaponRed.freezetest == true) { CharacterDetails.WeaponRed.freeze = true; CharacterDetails.WeaponRed.freezetest = false; characterDetailsView2.Red.IsChecked = true; }
            if (CharacterDetails.WeaponZ.freezetest == true) { CharacterDetails.WeaponZ.freeze = true; CharacterDetails.WeaponZ.freezetest = false; characterDetailsView2.ScaleZ.IsChecked = true; }
            if (CharacterDetails.WeaponY.freezetest == true) { CharacterDetails.WeaponY.freeze = true; CharacterDetails.WeaponY.freezetest = false; characterDetailsView2.ScaleY.IsChecked = true; }
            if (CharacterDetails.WeaponX.freezetest == true) { CharacterDetails.WeaponX.freeze = true; CharacterDetails.WeaponX.freezetest = false; characterDetailsView2.ScaleX.IsChecked = true; }
            if (CharacterDetails.OffhandZ.freezetest == true) { CharacterDetails.OffhandZ.freeze = true; CharacterDetails.OffhandZ.freezetest = false; characterDetailsView2.ScaleZ2.IsChecked = true; }
            if (CharacterDetails.OffhandY.freezetest == true) { CharacterDetails.OffhandY.freeze = true; CharacterDetails.OffhandY.freezetest = false; characterDetailsView2.ScaleY2.IsChecked = true; }
            if (CharacterDetails.OffhandX.freezetest == true) { CharacterDetails.OffhandX.freeze = true; CharacterDetails.OffhandX.freezetest = false; characterDetailsView2.ScaleX2.IsChecked = true; }
            if (CharacterDetails.OffhandRed.freezetest == true) { CharacterDetails.OffhandRed.freeze = true; CharacterDetails.OffhandRed.freezetest = false; characterDetailsView2.Red2.IsChecked = true; }
            if (CharacterDetails.OffhandBlue.freezetest == true) { CharacterDetails.OffhandBlue.freeze = true; CharacterDetails.OffhandBlue.freezetest = false; characterDetailsView2.Blue2.IsChecked = true; }
            if (CharacterDetails.OffhandGreen.freezetest == true) { CharacterDetails.OffhandGreen.freeze = true; CharacterDetails.OffhandGreen.freezetest = false; characterDetailsView2.Green2.IsChecked = true; }
            if (CharacterDetails.RightEyeBlue.freezetest == true) { CharacterDetails.RightEyeBlue.freeze = true; CharacterDetails.RightEyeBlue.freezetest = false; characterDetailsView3.BluePigment2.IsChecked = true; }
            if (CharacterDetails.RightEyeGreen.freezetest == true) { CharacterDetails.RightEyeGreen.freeze = true; CharacterDetails.RightEyeGreen.freezetest = false; characterDetailsView3.GreenPigment2.IsChecked = true; }
            if (CharacterDetails.RightEyeRed.freezetest == true) { CharacterDetails.RightEyeRed.freeze = true; CharacterDetails.RightEyeRed.freezetest = false; characterDetailsView3.RedPigment2.IsChecked = true; }
            if (CharacterDetails.LeftEyeBlue.freezetest == true) { CharacterDetails.LeftEyeBlue.freeze = true; CharacterDetails.LeftEyeBlue.freezetest = false; characterDetailsView3.BEyePigment.IsChecked = true; }
            if (CharacterDetails.LeftEyeGreen.freezetest == true) { CharacterDetails.LeftEyeGreen.freeze = true; CharacterDetails.LeftEyeGreen.freezetest = false; characterDetailsView3.GEyePigment.IsChecked = true; }
            if (CharacterDetails.LeftEyeRed.freezetest == true) { CharacterDetails.LeftEyeRed.freeze = true; CharacterDetails.LeftEyeRed.freezetest = false; characterDetailsView3.REyePigment.IsChecked = true; }
            if (CharacterDetails.LipsB.freezetest == true) { CharacterDetails.LipsB.freeze = true; CharacterDetails.LipsB.freezetest = false; characterDetailsView3.BluePigment.IsChecked = true; }
            if (CharacterDetails.LipsG.freezetest == true) { CharacterDetails.LipsG.freeze = true; CharacterDetails.LipsG.freezetest = false; characterDetailsView3.GreenPigment.IsChecked = true; }
            if (CharacterDetails.LipsR.freezetest == true) { CharacterDetails.LipsR.freeze = true; CharacterDetails.LipsR.freezetest = false; characterDetailsView3.RedPigment.IsChecked = true; }
        }
        public static void Testxda()
        {
            var characterDetailsView = new CharacterDetailsView();
            var characterDetailsView2 = new CharacterDetailsView2();
            var characterDetailsView3 = new CharacterDetailsView3();
            if (CharacterDetails.MuscleTone.freeze == true) { CharacterDetails.MuscleTone.freeze = false; CharacterDetails.MuscleTone.freezetest = true; characterDetailsView.MuscleCheck.IsChecked = false; }
            if (CharacterDetails.TailSize.freeze == true) { CharacterDetails.TailSize.freeze = false; CharacterDetails.TailSize.freezetest = true; characterDetailsView.TailSizeCheck.IsChecked = false; }
            if (CharacterDetails.BustX.freeze == true) { CharacterDetails.BustX.freeze = false; CharacterDetails.BustX.freezetest = true; characterDetailsView.BustXCheck.IsChecked = false; }
            if (CharacterDetails.BustY.freeze == true) { CharacterDetails.BustY.freeze = false; CharacterDetails.BustY.freezetest = true; characterDetailsView.BustYCheck.IsChecked = false; }
            if (CharacterDetails.BustZ.freeze == true) { CharacterDetails.BustZ.freeze = false; CharacterDetails.BustZ.freezetest = true; characterDetailsView.BustZCheck.IsChecked = false; }
            if (CharacterDetails.LipsBrightness.freeze == true) { CharacterDetails.LipsBrightness.freeze = false; CharacterDetails.LipsBrightness.freezetest = true; characterDetailsView3.LipBright.IsChecked = false; }
            if (CharacterDetails.SkinBlueGloss.freeze == true) { CharacterDetails.SkinBlueGloss.freeze = false; CharacterDetails.SkinBlueGloss.freezetest = true; characterDetailsView3.BlueGloss.IsChecked = false; }
            if (CharacterDetails.SkinGreenGloss.freeze == true) { CharacterDetails.SkinGreenGloss.freeze = false; CharacterDetails.SkinGreenGloss.freezetest = true; characterDetailsView3.GreenGloss.IsChecked = false; }
            if (CharacterDetails.SkinRedGloss.freeze == true) { CharacterDetails.SkinRedGloss.freeze = false; CharacterDetails.SkinRedGloss.freezetest = true; characterDetailsView3.RedGloss.IsChecked = false; }
            if (CharacterDetails.SkinBluePigment.freeze == true) { CharacterDetails.SkinBluePigment.freeze = false; CharacterDetails.SkinBluePigment.freezetest = true; characterDetailsView3.SkinBlue.IsChecked = false; }
            if (CharacterDetails.SkinGreenPigment.freeze == true) { CharacterDetails.SkinGreenPigment.freeze = false; CharacterDetails.SkinGreenPigment.freezetest = true; characterDetailsView3.SkinGreen.IsChecked = false; }
            if (CharacterDetails.SkinRedPigment.freeze == true) { CharacterDetails.SkinRedPigment.freeze = false; CharacterDetails.SkinRedPigment.freezetest = true; characterDetailsView3.SkinRed.IsChecked = false; }
            if (CharacterDetails.HighlightBluePigment.freeze == true) { CharacterDetails.HighlightBluePigment.freeze = false; CharacterDetails.HighlightBluePigment.freezetest = true; characterDetailsView3.HLBP.IsChecked = false; }
            if (CharacterDetails.HighlightGreenPigment.freeze == true) { CharacterDetails.HighlightGreenPigment.freeze = false; CharacterDetails.HighlightGreenPigment.freezetest = true; characterDetailsView3.HLGP.IsChecked = false; }
            if (CharacterDetails.HighlightRedPigment.freeze == true) { CharacterDetails.HighlightRedPigment.freeze = false; CharacterDetails.HighlightRedPigment.freezetest = true; characterDetailsView3.HLRP.IsChecked = false; }
            if (CharacterDetails.HairGlowBlue.freeze == true) { CharacterDetails.HairGlowBlue.freeze = false; CharacterDetails.HairGlowBlue.freezetest = true; characterDetailsView3.HairBGCheck.IsChecked = false; }
            if (CharacterDetails.HairGlowGreen.freeze == true) { CharacterDetails.HairGlowGreen.freeze = false; CharacterDetails.HairGlowGreen.freezetest = true; characterDetailsView3.HairGGCheck.IsChecked = false; }
            if (CharacterDetails.HairGlowRed.freeze == true) { CharacterDetails.HairGlowRed.freeze = false; CharacterDetails.HairGlowRed.freezetest = true; characterDetailsView3.HairRGCheck.IsChecked = false; }
            if (CharacterDetails.HairGreenPigment.freeze == true) { CharacterDetails.HairGreenPigment.freeze = false; CharacterDetails.HairGreenPigment.freezetest = true; characterDetailsView3.HairGreenP.IsChecked = false; }
            if (CharacterDetails.HairBluePigment.freeze == true) { CharacterDetails.HairBluePigment.freeze = false; CharacterDetails.HairBluePigment.freezetest = true; characterDetailsView3.HairBlueP.IsChecked = false; }
            if (CharacterDetails.HairRedPigment.freeze == true) { CharacterDetails.HairRedPigment.freeze = false; CharacterDetails.HairRedPigment.freezetest = true; characterDetailsView3.HairRedP.IsChecked = false; }
            if (CharacterDetails.Height.freeze == true) { CharacterDetails.Height.freeze = false; CharacterDetails.Height.freezetest = true; characterDetailsView.HeightCheck.IsChecked = false; }
            if (CharacterDetails.WeaponGreen.freeze == true) { CharacterDetails.WeaponGreen.freeze = false; CharacterDetails.WeaponGreen.freezetest = true; characterDetailsView2.Green.IsChecked = false; }
            if (CharacterDetails.WeaponBlue.freeze == true) { CharacterDetails.WeaponBlue.freeze = false; CharacterDetails.WeaponBlue.freezetest = true; characterDetailsView2.Blue.IsChecked = false; }
            if (CharacterDetails.WeaponRed.freeze == true) { CharacterDetails.WeaponRed.freeze = false; CharacterDetails.WeaponRed.freezetest = true; characterDetailsView2.Red.IsChecked = false; }
            if (CharacterDetails.WeaponZ.freeze == true) { CharacterDetails.WeaponZ.freeze = false; CharacterDetails.WeaponZ.freezetest = true; characterDetailsView2.ScaleZ.IsChecked = false; }
            if (CharacterDetails.WeaponY.freeze == true) { CharacterDetails.WeaponY.freeze = false; CharacterDetails.WeaponY.freezetest = true; characterDetailsView2.ScaleY.IsChecked = false; }
            if (CharacterDetails.WeaponX.freeze == true) { CharacterDetails.WeaponX.freeze = false; CharacterDetails.WeaponX.freezetest = true; characterDetailsView2.ScaleX.IsChecked = false; }
            if (CharacterDetails.OffhandZ.freeze == true) { CharacterDetails.OffhandZ.freeze = false; CharacterDetails.OffhandZ.freezetest = true; characterDetailsView2.ScaleZ2.IsChecked = false; }
            if (CharacterDetails.OffhandY.freeze == true) { CharacterDetails.OffhandY.freeze = false; CharacterDetails.OffhandY.freezetest = true; characterDetailsView2.ScaleY2.IsChecked = false; }
            if (CharacterDetails.OffhandX.freeze == true) { CharacterDetails.OffhandX.freeze = false; CharacterDetails.OffhandX.freezetest = true; characterDetailsView2.ScaleX2.IsChecked = false; }
            if (CharacterDetails.OffhandRed.freeze == true) { CharacterDetails.OffhandRed.freeze = false; CharacterDetails.OffhandRed.freezetest = true; characterDetailsView2.Red2.IsChecked = false; }
            if (CharacterDetails.OffhandBlue.freeze == true) { CharacterDetails.OffhandBlue.freeze = false; CharacterDetails.OffhandBlue.freezetest = true; characterDetailsView2.Blue2.IsChecked = false; }
            if (CharacterDetails.OffhandGreen.freeze == true) { CharacterDetails.OffhandGreen.freeze = false; CharacterDetails.OffhandGreen.freezetest = true; characterDetailsView2.Green2.IsChecked = false; }
            if (CharacterDetails.RightEyeBlue.freeze == true) { CharacterDetails.RightEyeBlue.freeze = false; CharacterDetails.RightEyeBlue.freezetest = true; characterDetailsView3.BluePigment2.IsChecked = false; }
            if (CharacterDetails.RightEyeGreen.freeze == true) { CharacterDetails.RightEyeGreen.freeze = false; CharacterDetails.RightEyeGreen.freezetest = true; characterDetailsView3.GreenPigment2.IsChecked = false; }
            if (CharacterDetails.RightEyeRed.freeze == true) { CharacterDetails.RightEyeRed.freeze = false; CharacterDetails.RightEyeRed.freezetest = true; characterDetailsView3.RedPigment2.IsChecked = false; }
            if (CharacterDetails.LeftEyeBlue.freeze == true) { CharacterDetails.LeftEyeBlue.freeze = false; CharacterDetails.LeftEyeBlue.freezetest = true; characterDetailsView3.BEyePigment.IsChecked = false; }
            if (CharacterDetails.LeftEyeGreen.freeze == true) { CharacterDetails.LeftEyeGreen.freeze = false; CharacterDetails.LeftEyeGreen.freezetest = true; characterDetailsView3.GEyePigment.IsChecked = false; }
            if (CharacterDetails.LeftEyeRed.freeze == true) { CharacterDetails.LeftEyeRed.freeze = false; CharacterDetails.LeftEyeRed.freezetest = true; characterDetailsView3.REyePigment.IsChecked = false; }
            if (CharacterDetails.LipsB.freeze == true) { CharacterDetails.LipsB.freeze = false; CharacterDetails.LipsB.freezetest = true; characterDetailsView3.BluePigment.IsChecked = false; }
            if (CharacterDetails.LipsG.freeze == true) { CharacterDetails.LipsG.freeze = false; CharacterDetails.LipsG.freezetest = true; characterDetailsView3.GreenPigment.IsChecked = false; }
            if (CharacterDetails.LipsR.freeze == true) { CharacterDetails.LipsR.freeze = false; CharacterDetails.LipsR.freezetest = true; characterDetailsView3.RedPigment.IsChecked = false; }
        }
    }
}