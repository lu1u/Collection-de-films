using System;
using System.Windows.Forms;

/// <summary>
/// A utiliser de la facon suivante:
///  using( new CursorChange(Cursors.Wait))
///  {
///   ... traitement
///  }
/// </summary>
internal class CursorChanger : IDisposable
{
    private Cursor _ancien;

    public CursorChanger(Cursor cursor)
    {
        _ancien = Cursor.Current;
        Cursor.Current = cursor;
    }

    public void Dispose()
    {
        Cursor.Current = _ancien;
    }
}
