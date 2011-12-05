using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using System.Drawing;

namespace SPKTCore.Core
{
    [PluginFamily("Default")]
    public interface ICaptcha
    {
        string FamilyName { get; set; }
        string Text { get; set; }
        Bitmap Image { get; }
        int Width { get; set; }
        int Height { get; set; }
        void Dispose();
    }
}
