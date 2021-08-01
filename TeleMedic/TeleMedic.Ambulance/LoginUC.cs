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

namespace TeleMedic.Ambulance
{
    public partial class LoginUC : UserControl
    {
        RTCControl mainRtc;
        RTCControl cam1Rtc;
        RTCControl cam2Rtc;

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
                if (cbCam1VideoDevices.SelectedItem != null)
                {
                    string selectedItem = cbCam1VideoDevices.SelectedItem.ToString();
                    cam1Rtc.SelectDevice(cbCam1VideoDevices.SelectedItem.ToString(), DeviceType.Video);
                    IniFile.IniWriteValue("device.ini", "Cam1", "Video", cbCam1VideoDevices.SelectedItem.ToString());
                    cam1Rtc.MuteAudio(true);
                    if (selectedItem.ToLower() == "disable")
                        cam1Rtc.StopVideo();
                    else
                        cam1Rtc.StartVideo();
                }
                if (cbCam2VideoDevices.SelectedItem != null)
                {
                    string selectedItem = cbCam2VideoDevices.SelectedItem.ToString();
                    cam2Rtc.SelectDevice(cbCam2VideoDevices.SelectedItem.ToString(), DeviceType.Video);
                    IniFile.IniWriteValue("device.ini", "Cam2", "Video", cbCam2VideoDevices.SelectedItem.ToString());
                    cam2Rtc.MuteAudio(true);
                    if (selectedItem.ToLower() == "disable")
                        cam2Rtc.StopVideo();
                    else
                        cam2Rtc.StartVideo();
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
                        cbMainAudioOutDevices.Items.Add(new ComboboxItem
                        {
                            Text = "Disable",
                            Value = ""
                        });

                        foreach (var dev in e.Devices)
                        {
                            ComboboxItem item = new ComboboxItem();
                            item.Text = dev.label;
                            item.Value = dev.id;
                            cbMainAudioOutDevices.Items.Add(item);
                        }

                        //cbMainAudioOutDevices.SelectedIndex = 0;
                        string setting = IniFile.IniReadValue("device.ini", "Main", "AudioOut", "Disable");
                        cbMainAudioOutDevices.SelectedIndex = cbMainAudioOutDevices.FindStringExact(setting);
                    }

                    break;

                case DeviceType.AudioIn:
                    {
                        cbMainAudioDevices.Items.Add(new ComboboxItem
                        {
                            Text = "Disable",
                            Value = ""
                        });
                        foreach (var dev in e.Devices)
                        {
                            ComboboxItem item = new ComboboxItem();
                            item.Text = dev.label;
                            item.Value = dev.id;
                            cbMainAudioDevices.Items.Add(item);
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
                        cbMainVideoDevices.Items.Add(new ComboboxItem
                        {
                            Text = "Disable",
                            Value = ""
                        });

                        foreach (var dev in e.Devices)
                        {
                            ComboboxItem item = new ComboboxItem();
                            item.Text = dev.label;
                            item.Value = dev.id;
                            cbMainVideoDevices.Items.Add(item);
                        }

                        string setting = IniFile.IniReadValue("device.ini", "Main", "Video", "Disable");
                        cbMainVideoDevices.SelectedIndex = cbMainVideoDevices.FindStringExact(setting);

                    }
                    break;
            }
        }

        internal void UpdateCam2Device(DeviceEventArgs e)
        {
            switch (e.DeviceType)
            {
                case DeviceType.Video:

                    cbCam2VideoDevices.Items.Add(new ComboboxItem
                    {
                        Text = "Disable",
                        Value = ""
                    });

                    foreach (var dev in e.Devices)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = dev.label;
                        item.Value = dev.id;
                        cbCam2VideoDevices.Items.Add(item);
                    }

                    string setting = IniFile.IniReadValue("device.ini", "Cam2", "Video", "Disable");
                    cbCam2VideoDevices.SelectedIndex = cbCam2VideoDevices.FindStringExact(setting);

                    //cbRoomVideoDevices.SelectedIndex = 0;

                    break;
            }
        }

        internal void UpdateCam1Device(DeviceEventArgs e)
        {
            switch (e.DeviceType)
            {
                case DeviceType.Video:

                    cbCam1VideoDevices.Items.Add(new ComboboxItem
                    {
                        Text = "Disable",
                        Value = ""
                    });

                    foreach (var dev in e.Devices)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = dev.label;
                        item.Value = dev.id;
                        cbCam1VideoDevices.Items.Add(item);
                    }

                    string setting = IniFile.IniReadValue("device.ini", "Cam1", "Video", "Disable");
                    cbCam1VideoDevices.SelectedIndex = cbCam1VideoDevices.FindStringExact(setting);

                    break;
            }
        }

        internal void AddRtc(RTCControl mainRtc, RTCControl cam1Rtc, RTCControl cam2Rtc)
        {
            this.mainRtc = mainRtc;
            this.cam1Rtc = cam1Rtc;
            this.cam2Rtc = cam2Rtc;
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
