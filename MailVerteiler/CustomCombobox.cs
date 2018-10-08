using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


/// <summary>
/// Da es im Framework keine ImageComboBox gibt hatte ich einfach selber
/// eine geschrieben bzw. die vorhandene ComboBox erweitert.
/// Achtung: Man kann nur Items per Code hinzufügen also nicht im Designer,
/// da man im Designer kein ImageKey festlegen kann.
/// </summary>
/// <remarks>Tim Hartwig</remarks>

namespace MailVerteiler
{
    public class CustomCombobox : ComboBox
    {

        private ImageList mImageList = null;

        public CustomCombobox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        public ImageList ImageList
        {
            get { return mImageList; }
            set { mImageList = value; }
        }

        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index >= 0)
            {

                if (this.Items[e.Index] is ImageComboItem)
                {
                    if (mImageList != null)
                    {
                        ImageComboItem CurrItem = (ImageComboItem)this.Items[e.Index];

                        if (CurrItem.ImageIndex != -1)
                        {
                            this.ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, CurrItem.ImageIndex);
                            e.Graphics.DrawString(CurrItem.Text, CurrItem.Font,
                                new SolidBrush(CurrItem.ForeColor),
                                e.Bounds.Left + mImageList.ImageSize.Width, e.Bounds.Top);
                        }
                        else
                        {
                            e.Graphics.DrawString(CurrItem.Text, CurrItem.Font,
                                new SolidBrush(CurrItem.ForeColor),
                                e.Bounds.Left + mImageList.ImageSize.Width, e.Bounds.Top);
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left, e.Bounds.Top);
                }
            }
        }
    }


    public class ImageComboItem
    {
        private Color mForeColor = Color.Black;
        private int mImageIndex = -1;
        private object mTag = null;
        private string mText = "";
        private Font mFont;

        public ImageComboItem(string Text, Font Font, Color ForeColor)
        {
            mText = Text;
            mFont = Font;
            mForeColor = ForeColor;
        }

        public ImageComboItem(string Text, Font Font, Color ForeColor, int ImageIndex)
        {
            mText = Text;
            mFont = Font;
            mForeColor = ForeColor;
            mImageIndex = ImageIndex;
        }

        public Color ForeColor
        {
            get { return mForeColor; }
            set { mForeColor = value; }
        }

        public int ImageIndex
        {
            get { return mImageIndex; }
            set { mImageIndex = value; }
        }

        public object Tag
        {
            get { return mTag; }
            set { mTag = value; }
        }

        public string Text
        {
            get { return mText; }
            set { mText = value; }
        }

        public Font Font
        {
            get { return mFont; }
            set { mFont = value; }
        }

        public override string ToString()
        {
            return mText;
        }
    }

}