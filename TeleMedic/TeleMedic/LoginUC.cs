using iConfRTCModel;
using iConfRTCWinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeleMedic.Library;
using DeviceType = iConfRTCModel.DeviceType;

namespace TeleMedic
{
    public partial class LoginUC : UserControl
    {
        RTCControl mainRtc;

        public event EventHandler<EventArgs> OnStart;
        public LoginUC()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbMainAudioOutDevices.SelectedItem != null)
                {
                    mainRtc.SelectDevice(cbMainAudioOutDevices.SelectedItem.ToString(), DeviceType.AudioOut);
                    IniFile.IniWriteValue("device.ini", "Main", "AudioOut", cbMainAudioOutDevices.SelectedItem.ToString());
                }

                if (cbMainAudioDevices.SelectedItem != null)
                {
                    string selectedItem = cbMainAudioDevices.SelectedItem.ToString();
                    mainRtc.SelectDevice(selectedItem, DeviceType.AudioIn);
                    IniFile.IniWriteValue("device.ini", "Main", "AudioIn", selectedItem);
                    if (selectedItem.ToLower() == "disable")
                        mainRtc.MuteAudio(true);
                    else
                        mainRtc.MuteAudio(false);
                }
                if (cbMainVideoDevices.SelectedItem != null)
                {
                    string selectedItem = cbMainVideoDevices.SelectedItem.ToString();
                    mainRtc.SelectDevice(selectedItem, DeviceType.Video);
                    IniFile.IniWriteValue("device.ini", "Main", "Video", selectedItem);
                    if (selectedItem.ToLower() == "disable")
                        mainRtc.StopVideo();
                    else
                        mainRtc.StartVideo();
                }
              

                if (OnStart != null)
                    OnStart(this, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void UpdateMainDevice(DeviceEventArgs e)
        {
            switch (e.DeviceType)
            {
                case DeviceType.AudioOut:
                    {

                        AddItem(cbMainAudioOutDevices, new Device { id = "", label = "Disable" });

                        foreach (var dev in e.Devices)
                        {
                            AddItem(cbMainAudioOutDevices, dev);

                        }

                        //cbMainAudioOutDevices.SelectedIndex = 0;
                        string setting = IniFile.IniReadValue("device.ini", "Main", "AudioOut", "Disable");
                        cbMainAudioOutDevices.SelectedIndex = cbMainAudioOutDevices.FindStringExact(setting);
                    }

                    break;

                case DeviceType.AudioIn:
                    {

                        AddItem(cbMainAudioDevices, new Device { id = "", label = "Disable" });
                        foreach (var dev in e.Devices)
                        {
                            AddItem(cbMainAudioDevices, dev);

                        }

                        string setting = IniFile.IniReadValue("device.ini", "Main", "AudioIn", "Disable");
                        cbMainAudioDevices.SelectedIndex = cbMainAudioDevices.FindStringExact(setting);


                        //cbMainAudioDevices.SelectedIndex = 0;
                    }
                    break;

                //cbMainAudioDevices.DataSource = e.Devices;
                //cbMainAudioDevices.DisplayMember = "label";
                //cbMainAudioDevices.ValueMember = "Id";

                //break;
                case DeviceType.Video:
                    {
                        AddItem(cbMainVideoDevices, new Device { id = "", label = "Disable" });
                        foreach (var dev in e.Devices)
                        {
                            AddItem(cbMainVideoDevices, dev);
                        }

                        string setting = IniFile.IniReadValue("device.ini", "Main", "Video", "Disable");
                        cbMainVideoDevices.SelectedIndex = cbMainVideoDevices.FindStringExact(setting);

                    }
                    break;
            }
        }

        private void AddItem(ComboBox cb , Device dev)
        {
            if (cb.FindStringExact(dev.label) >= 0)
                return;
            ComboboxItem item = new ComboboxItem();
            item.Text = dev.label;
            item.Value = dev.id;
            cb.Items.Add(item);
        }

        internal void AddRtc(RTCControl mainRtc)
        {
            this.mainRtc = mainRtc;
        }

        private void cbMainVideoDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mainRtc.SelectDevice(cbMainVideoDevices.SelectedItem.ToString(), DeviceType.Video);

        }

        private void cbPatientVideoDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cam1Rtc.SelectDevice(cbPatientVideoDevices.SelectedItem.ToString(), DeviceType.Video);

        }
    }
}
