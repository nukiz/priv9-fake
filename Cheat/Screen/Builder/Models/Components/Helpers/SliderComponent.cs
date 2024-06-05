using Guna.UI2.WinForms;
using Priv9.API.Module;
using Priv9.API.Setting;
using Priv9.API.Setting.Subtypes;
using Priv9.Cheat.Screen.Builder.Models.Tabs;
using Priv9.Cheat.Screen.Builder.Models.Util;
using Priv9.Cheat.Utils;
using System.Numerics;
using DashStyle = System.Drawing.Drawing2D.DashStyle;

namespace Priv9.Cheat.Screen.Builder.Models.Components.Helpers
{
    internal class SliderComponent<N>
        (ModuleImpl Module, NumSetting<N> Setting, CategoryTab Tab, Panel Panel, int X, int Y)
            : AbstractComponent<Setting<N>>(Tab, Setting)
                where N : INumber<N>
    {
        private Guna2CustomGradientPanel SliderPanel = null!, ValuePanel = null!;
        private Label SettingLabel = null!, ValueLabel = null!;
        private bool IsDragging = false;
        private N Value = Setting.Get();
        private readonly N Min = Setting.GetMin(), Max = Setting.GetMax();
        private Point StartLocation;

        public override void Draw()
        {
            #region Control declarations
            SliderPanel = new()
            {
                BackColor = Instances.DARK_GRAY,
                FillColor = Color.Transparent,
                FillColor2 = Color.Transparent,
                FillColor3 = Color.Transparent,
                FillColor4 = Color.Transparent,
                CustomBorderThickness = new(2),
                CustomBorderColor = Color.FromArgb(55, 102, 91),
                BorderStyle = DashStyle.Custom,
                Size = new(Panel.Width - 10, 15),
            };
            SliderPanel.Location = new(X + 1, Y + SliderPanel.Height / 4 + 2);
            
            ValuePanel = new()
            {
                BackColor = Color.FromArgb(50, 97, 86),
                FillColor = Color.Transparent,
                FillColor2 = Color.Transparent,
                FillColor3 = Color.Transparent,
                FillColor4 = Color.Transparent,
                CustomBorderThickness = new(0),
                Size = new(Panel.Width - 10 - 4 + 1, 15 - 4),
                Location = new(2, 2)
            };
            
            SettingLabel = new()
            {
                Text = Setting.GetName().ToLower(),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                AutoSize = false,
                Size = new(Setting.GetName().Length * 9, 15),
                Font = new Font("Verdana", 8.75f)
            };
            SettingLabel.Location = new(X, Y - SettingLabel.Height + 2);

            ValueLabel = new()
            {
                Text = $"- {Setting.Get()}",
                BackColor = Color.Transparent,
                ForeColor = Instances.DARK_GRAY,
                AutoSize = false,
                Size = new(Setting.GetName().Length * 9, 15),
                Font = new Font("Verdana", 8.75f)
            };
            #endregion
            ValueLabel.Location = new(SettingLabel.Location.X + (int) (ValueLabel.Width / 1.5), SettingLabel.Location.Y);
            
            // SliderPanel.Location = new(Panel.Size.Width - SliderPanel.Size.Width - Module.GetName().Length, Y - 2);
            SliderPanel.MouseDown += OnClick;
            ValuePanel.MouseDown += OnClick;
            SliderPanel.MouseMove += OnMouseMove;
            ValuePanel.MouseMove += OnMouseMove;
            SliderPanel.MouseUp += OnMouseUp;
            ValuePanel.MouseUp += OnMouseUp;

            SliderPanel.Controls.Add(ValuePanel);
            Panel.Controls.Add(ValueLabel);
            Panel.Controls.Add(SliderPanel);
            Panel.Controls.Add(SettingLabel);
            Panel.Height += 40;
        }

        public override void OnClick(object? sender, MouseEventArgs e)
        {
            ValuePanel.Width = Math.Clamp(ValuePanel.Location.X + e.X, 0, Panel.Width - 14);
            IsDragging = true;
            StartLocation = e.Location;
        }

        private void OnMouseMove(object? sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                // width clamped from 0 to ~162
                ValuePanel.Width = Math.Clamp(ValuePanel.Location.X + e.X - 2, 0, Panel.Width - 14);

                if (Setting.Get().GetType().IsInstanceOfType(typeof(int)))
                {

                }
            }
        }

        private void OnMouseUp(object? sender, MouseEventArgs e)
        {
            IsDragging = false;
        }
    }
}
