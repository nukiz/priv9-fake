using Priv9.API.Setting.Subtypes.Helper;
using Priv9.API.Setting;
using Priv9.Cheat.Screen.Builder.Models.Util;
using Priv9.API.Module;
using Priv9.Cheat.Screen.Builder.Models.Tabs;
using Priv9.Cheat.Utils;
using Timer = System.Windows.Forms.Timer;
using Guna.UI2.WinForms;
using System.Drawing.Drawing2D;
using Priv9.API.Setting.Subtypes;

namespace Priv9.Cheat.Screen.Builder.Models.Components.Helpers
{
    /// <summary>
    /// Represents a Toggleable component.
    /// Can be either Bindable or Toggleable.
    /// </summary>
    /// <param name="Module"> The Module this component is associated with. </param>
    /// <param name="Setting"> The setting this component is associated with. </param>
    /// <param name="Tab"> The category this component is associated with. </param>
    /// <param name="Panel"> The panel this component is associated with. </param>
    /// <param name="X">The X position of the component. </param>
    /// <param name="Y">The Y position of the component. </param>
    internal class ToggleComponent(ModuleImpl Module, BindSetting Setting, CategoryTab Tab, Panel Panel, int X, int Y)
        : AbstractComponent<Setting<Bind>>(Tab, Setting)
    {
        private Guna2CustomGradientPanel CustomCheckbox = null!;
        private Guna2CustomGradientPanel BindPanel = null!;
        private Label BindLabel = null!, ModuleLabel = null!;
        private readonly Timer LABEL_TIMER = new();
        private bool IsEnabled = false;

        private readonly string Name = Module.GetName();

        public override void Draw()
        {
            ModuleLabel = new()
            {
                Name = Name,
                Text = Name.ToLower(),
                Location = new(X, Y),
                BackColor = Color.Transparent,
                ForeColor = Module.IsDangerous() ? Instances.DANGEROUS_COLOR : Color.White,
                AutoSize = false,
                Size = new(Name.Length * 9 + 5, 15),
                Font = new Font("Verdana", 8.75f)
            };

            if (Module.GetToggleMode() is ModuleImpl.ToggleMode.Bind)
            {
                BindPanel = new()
                {
                    BackColor = Instances.DARK_GRAY,
                    FillColor = Color.Transparent,
                    FillColor2 = Color.Transparent,
                    FillColor3 = Color.Transparent,
                    FillColor4 = Color.Transparent,
                    CustomBorderThickness = new(2),
                    CustomBorderColor = Color.FromArgb(55, 102, 91),
                    BorderStyle = DashStyle.Custom,
                    Size = new(80, 20)
                };

                BindLabel = new()
                {
                    Text = $"{Setting.Get().GetKey().ToString().ToLower()}",
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Verdana", 8.75f),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                BindPanel.Location = new(Panel.Size.Width - BindPanel.Size.Width - Module.GetName().Length + 1, Y - 2);
                BindPanel.MouseDown += OnClick;
                BindLabel.MouseDown += OnClick;
                BindPanel.Controls.Add(BindLabel);
                Panel.Controls.Add(BindPanel);
            } 
            else
            {
                CustomCheckbox = new()
                {
                    BackColor = Instances.DARK_GRAY,
                    FillColor = Color.Transparent,
                    FillColor2 = Color.Transparent,
                    FillColor3 = Color.Transparent,
                    FillColor4 = Color.Transparent,
                    CustomBorderThickness = new(2),
                    CustomBorderColor = Color.FromArgb(55, 102, 91),
                    BorderStyle = DashStyle.Custom,
                    Size = new(18, 18)
                };
                CustomCheckbox.Location = new(Panel.Size.Width - CustomCheckbox.Size.Width - Module.GetName().Length, Y);
                CustomCheckbox.MouseDown += OnClick;
                Panel.Controls.Add(CustomCheckbox);
            }
            Panel.Controls.Add(ModuleLabel);
            Panel.Height += 25;
        }

        public override void OnClick(object? sender, MouseEventArgs e)
        {
            IsEnabled = !IsEnabled;
            if (Module.GetToggleMode() == ModuleImpl.ToggleMode.Toggle)
            {
                if (CustomCheckbox != null)
                {
                    Module.Toggle();
                    CustomCheckbox.BackColor = IsEnabled
                        ? Color.FromArgb(70, 255, 255, 255)
                        : Instances.DARK_GRAY;
                }
            }
            else
            {
                if (!IsEnabled)
                {
                    BindLabel.Text = Module.BindSet.Get().GetKey().ToString().ToLower();
                    Module.SetListeningForBind(false);
                }

                if (e.Button == MouseButtons.Left)
                {
                    LABEL_TIMER.Interval = 1;
                    LABEL_TIMER.Tick += Listen;
                    LABEL_TIMER.Start();
                    BindLabel.Text = "...";
                    Module.SetListeningForBind(true);
                } 
                else if (e.Button == MouseButtons.Right)
                    Module.SetListeningForBind(false);
            }
        }

        private void Listen(object? sender, EventArgs e)
        {
            if (!Priv9Screen.GetKbController().IsListening())
                BindLabel.Text = Module.BindSet.Get().GetKey().ToString().ToLower();
        }
    }
}
