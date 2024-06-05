using Priv9.API.Module;
using Priv9.API.Setting;
using Priv9.Cheat.Screen.Builder.Models.Tabs;
using Priv9.Cheat.Screen.Builder.Models.Util;
using Priv9.API.Setting.Subtypes;
using Guna.UI2.WinForms;
using Priv9.Cheat.Utils;
using DashStyle = System.Drawing.Drawing2D.DashStyle;
using Priv9.Cheat.Utils.Objects;

namespace Priv9.Cheat.Screen.Builder.Models.Components.Helpers
{
    internal class EnumComponent<T>
        (ModuleImpl Module, ModeSetting<T> Setting, CategoryTab Tab, Panel Panel, int X, int Y) 
        : AbstractComponent<Setting<T>>(Tab, Setting) 
        where T : Enum
    {
        private Guna2CustomGradientPanel EnumPanel = null!;
        private Label EnumLabel = null!, SettingLabel = null!;

        public override void Draw()
        {
            EnumPanel = new()
            {
                BackColor = Instances.DARK_GRAY,
                FillColor = Color.Transparent,
                FillColor2 = Color.Transparent,
                FillColor3 = Color.Transparent,
                FillColor4 = Color.Transparent,
                CustomBorderThickness = new(2),
                CustomBorderColor = Color.FromArgb(55, 102, 91),
                BorderStyle = DashStyle.Custom,
                Size = new(85, 20)
            };

            EnumLabel = new()
            {
                Text = $"{Setting.Get().ToString().ToLower()}",
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Verdana", 8.75f),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            SettingLabel = new()
            {
                Text = Setting.GetName(),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Location = new(X, Y),
                AutoSize = false,
                Size = new(Setting.GetName().Length * 9, 15),
                Font = new Font("Verdana", 8.75f)
            };

            EnumPanel.Location = new(Panel.Size.Width - EnumPanel.Size.Width - Module.GetName().Length, Y - 2);
            EnumPanel.MouseDown += OnClick;
            EnumLabel.MouseDown += OnClick;
            EnumPanel.Controls.Add(EnumLabel);
            Panel.Controls.Add(EnumPanel);
            Panel.Controls.Add(SettingLabel);
            Panel.Height += 25;
        }

        public override void OnClick(object? sender, MouseEventArgs e)
        {
            Setting.Set(ObjectUtil.Next(Setting.Get()));
            EnumLabel.Text = Setting.Get().ToString().ToLower(); 
        }
    }
}
