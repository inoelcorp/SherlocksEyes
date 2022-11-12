//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Security;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.VisualBasic;
//using System.ComponentModel;
//using Newtonsoft.Json.Linq;

//public class MenuButton : Button
//{

//    // <DefaultValue(Nothing)>
//    public ContextMenuStrip Menu
//    {
//        get
//        {
//            return m_Menu;
//        }
//        set
//        {
//            m_Menu = value;
//        }
//    }
//    private ContextMenuStrip m_Menu = null/* TODO Change to default(_) if this is not a reference type */;

//    [DefaultValue(false)]
//    public bool ShowMenuUnderCursor
//    {
//        get
//        {
//            return m_ShowMenuUnderCursor;
//        }
//        set
//        {
//            m_ShowMenuUnderCursor = value;
//        }
//    }
//    private bool m_ShowMenuUnderCursor;

//    protected override void OnMouseDown(MouseEventArgs mevent)
//    {
//        base.OnMouseDown(mevent);

//        if (Menu != null && mevent.Button == MouseButtons.Left)
//        {
//            Point menuLocation;

//            if (ShowMenuUnderCursor)
//                menuLocation = mevent.Location;
//            else
//                menuLocation = new Point(0, Height);

//            Menu.Show(this, menuLocation);
//        }
//    }

//    protected override void OnKeyPress(KeyPressEventArgs mevent)
//    {
//        base.OnKeyPress(mevent);

//        if (Menu != null && mevent.KeyChar == (char)Keys.Space)
//            Menu?.Show(this, new Point(0, Height));
//    }

//    protected override void OnPaint(PaintEventArgs pevent)
//    {
//        base.OnPaint(pevent);

//        if (Menu != null)
//        {
//            int arrowX = ClientRectangle.Width - 14;
//            int arrowY = (int)(ClientRectangle.Height / (double)2 - 1);

//            Brush brush = Enabled ? SystemBrushes.ControlText : SystemBrushes.ButtonShadow;
//            Point[] arrows = new Point[] { new Point(arrowX, arrowY), new Point(arrowX + 7, arrowY), new Point(arrowX + 3, arrowY + 4) };
//            pevent.Graphics.FillPolygon(brush, arrows);
//        }
//    }
//}
