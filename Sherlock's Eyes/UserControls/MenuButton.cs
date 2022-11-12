/*
 * Project      : Sherlock's Eyes
 * Description  : Popup Menu Button User control.
 * Author       : Inoel Arifin
 * Date         : 2022-11-12
 * Module       : MenuButton.cs
 * 
 * Copyright (C) 2022 Inoel Arifin. All rights reserved.
 */

using System.ComponentModel;

namespace Sherlock_s_Eyes.UserControls
{
    public class MenuButton : Button
{

    // <DefaultValue(Nothing)>
    public ContextMenuStrip Menu
    {
        get
        {
            return m_Menu;
        }
        set
        {
            m_Menu = value;
        }
    }
    private ContextMenuStrip m_Menu = null;

    [DefaultValue(false)]
    public bool ShowMenuUnderCursor
    {
        get
        {
            return m_ShowMenuUnderCursor;
        }
        set
        {
            m_ShowMenuUnderCursor = value;
        }
    }
    private bool m_ShowMenuUnderCursor;

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        base.OnMouseDown(mevent);

        if (Menu != null && mevent.Button == MouseButtons.Left)
        {
            Point menuLocation;

            if (ShowMenuUnderCursor)
                menuLocation = mevent.Location;
            else
                menuLocation = new Point(0, Height);

            Menu.Show(this, menuLocation);
        }
    }

    protected override void OnKeyPress(KeyPressEventArgs mevent)
    {
        base.OnKeyPress(mevent);

        if (Menu != null && mevent.KeyChar == (char)Keys.Space)
            Menu?.Show(this, new Point(0, Height));
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        if (Menu != null)
        {
            int arrowX = ClientRectangle.Width - 14;
            int arrowY = (int)(ClientRectangle.Height / (double)2 - 1);

            Brush brush = Enabled ? SystemBrushes.ControlText : SystemBrushes.ButtonShadow;
            Point[] arrows = new Point[] { new Point(arrowX, arrowY), new Point(arrowX + 7, arrowY), new Point(arrowX + 3, arrowY + 4) };
            pevent.Graphics.FillPolygon(brush, arrows);
        }
    }
}
}
