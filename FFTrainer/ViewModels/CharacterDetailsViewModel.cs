using System;
using FFTrainer.Models;
using FFTrainer.Commands;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FFTrainer.ViewModels
{
    public class CharacterDetailsViewModel : BaseViewModel
    {
 
        public CharacterDetails CharacterDetails { get => (CharacterDetails)model; set => model = value; }
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
    }
}