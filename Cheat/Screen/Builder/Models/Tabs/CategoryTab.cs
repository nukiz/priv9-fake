using Priv9.API.Module;
using Priv9.Cheat.Screen.Builder.Models.Util;
using Guna.UI2.WinForms;
using DashStyle = System.Drawing.Drawing2D.DashStyle;
using Priv9.Cheat.Hacks.Other.Debug;
using Priv9.Cheat.Screen.Builder.Models.Components.Helpers;
using Priv9.Cheat.Hacks.Other.Test;
using Priv9.API.Setting.Subtypes;
using Priv9.Cheat.Core.Managers;
using Priv9.API.Setting.Subtypes.Helper;

namespace Priv9.Cheat.Screen.Builder.Models.Tabs
{
    internal class CategoryTab(Label Linked, Category Category) 
        : AbstractTab(Linked)
    {
        /// <summary>
        /// The label this CategoryTab represents.
        /// </summary>
        private readonly Label Linked = Linked;
        private readonly Category Category = Category;
        private Guna2CustomGradientPanel ComponentPanel;
        private Guna2CustomGradientPanel LabelPanel;

        public override void OnClick(object? sender, EventArgs? e)
        {
            foreach (AbstractTab tab in ScreenBuilder.GetInstance().Tabs)
            {
                if (((CategoryTab) tab).Linked != Linked)
                {
                    ((CategoryTab) tab).Linked.ForeColor = Color.DimGray;
                }
            }
            Linked.ForeColor = Color.White;
        }

        public override void Draw()
        {
            int BaseX = 4;
            int BaseHeight = 25;
            List<Panel> Panels = [];

            for (int i = 0; i < 4; i++)
            {
                ComponentPanel = new()
                {
                    Name = $"ComponentPanel{i}",
                    BackColor = Color.FromArgb(15, 255, 255, 255),
                    FillColor = Color.Transparent,
                    FillColor2 = Color.Transparent,
                    FillColor3 = Color.Transparent,
                    FillColor4 = Color.Transparent,
                    CustomBorderThickness = new(2),
                    CustomBorderColor = Color.FromArgb(30, 255, 255, 255),
                    BorderStyle = DashStyle.Custom,
                    Size = new(176, BaseHeight) // 176, 329 for full tab
                };

                LabelPanel = new()
                {
                    Name = $"LabelPanel{i}",
                    BackColor = Color.FromArgb(30, 255, 255, 255),
                    FillColor = Color.Transparent,
                    FillColor2 = Color.Transparent,
                    FillColor3 = Color.Transparent,
                    FillColor4 = Color.Transparent,
                    CustomBorderThickness = new(0),
                    BorderStyle = DashStyle.Custom,
                    Location = new(2, 0),
                    Size = new(173, 22) // 176, 329 for full tab
                };

                Label ComponentLabel = new()
                {
                    Name = "CompLabel",
                    Location = new(4, 4),
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    AutoSize = false,
                    Font = new("Verdana", 9f, FontStyle.Bold)
                };

                switch (i)
                { // 1 is skipped for some reason
                    case 0:
                        ComponentLabel.Text = "misc";
                        break;
                    case 2:
                        ComponentLabel.Text = "movement";
                        break;
                    case 3:
                        ComponentLabel.Text = "debug";
                        break;
                }
                LabelPanel.Controls.Add(ComponentLabel);
                ComponentPanel.Controls.Add(LabelPanel);
                ComponentLabel.Size = new(ComponentLabel.Text.Length * 10, 16);

                ComponentPanel.Location = new(BaseX += i > 1 ? ComponentPanel.Width + 2 : 0, 31);
                Panels.Add(ComponentPanel);
                ScreenBuilder.GetInstance().ComponentPanels.Add(ComponentPanel);
            }

            int baseY = 27;
            int count = 0; 
            ScreenBuilder.GetInstance().Components.Add(new ToggleComponent(Debug.GetInstance(), (BindSetting) Debug.GetInstance().BindSet, this, ComponentPanel, 4, baseY));
            ScreenBuilder.GetInstance().Components.Add(new EnumComponent<Debug.Mode>(Debug.GetInstance(), (ModeSetting<Debug.Mode>) Debug.GetInstance().ModeTest, this, ComponentPanel, 4, baseY += 25));
            ScreenBuilder.GetInstance().Components.Add(new ToggleComponent(Debug2.GetInstance(), (BindSetting) Debug2.GetInstance().BindSet, this, ComponentPanel, 4, baseY += 25));
            ScreenBuilder.GetInstance().Components.Add(new SliderComponent<int>(Debug.GetInstance(), (NumSetting<int>) Debug.GetInstance().NumberTest, this, ComponentPanel, 4, baseY += 35));

            foreach (ModuleImpl mod in Managers.MODULES.GetAll())
            {
                ScreenBuilder.GetInstance().Components.Add(new ToggleComponent(mod, (BindSetting)
                    mod.BindSet, this, ComponentPanel, 4, count > 0 ? baseY += 25 : baseY));
               
                for (int i = 0; i < mod.GetValues().Count; i++)
                {
                    IValue val = mod.GetValues()[i];

                    if (val.GetValueType().Equals(SettingValueType.Boolean))
                    {
                        
                    }
                    else if (val.GetValueType().Equals(SettingValueType.Numeric))
                    {
                        ScreenBuilder.GetInstance().Components.Add(new SliderComponent<int>(mod, (NumSetting<int>)val, this, ComponentPanel, 4, baseY += 35));
                    }
                    else if (val.GetValueType().Equals(SettingValueType.Enumerator))
                    {
                        // ScreenBuilder.GetInstance().Components.Add(new EnumComponent<>(mod, (ModeSetting<dynamic>) val, this, ComponentPanel, 4, baseY += 25));
                    }
                    else if (val.GetValueType().Equals(SettingValueType.Bind))
                    {
                        ScreenBuilder.GetInstance().Components.Add(new ToggleComponent(mod, (BindSetting)val, this, ComponentPanel, 4, baseY += 25));
                    }
                    else throw new ArgumentException("Invalid SettingValueType (doesn't exist)");
                }

                count++;
            }

            foreach (Panel panel in Panels)
                Priv9Screen.GetInstance().MainPanel.Controls.Add(panel);
        }

        public Category GetCategory() => Category;
    }
}
