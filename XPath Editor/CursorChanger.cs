using System;
using System.Windows.Forms;

namespace XPath_Editor
{
    internal class CursorChanger : IDisposable
    {
        private Cursor _ancien ;

        public CursorChanger(Cursor cursor)
        {
            _ancien = Cursor.Current ;
            Cursor.Current = cursor;
        }

        public void Dispose()
        {
            Cursor.Current = _ancien;
        }
    }
}