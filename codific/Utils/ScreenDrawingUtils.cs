using Codific.Interfaces.Engine;

namespace Codific.Utils
{
    internal class ScreenDrawingUtils
    {
        ScreenDrawingUtils()
        {    
        }
        
        public static void DrawErrorMessage(IScreenDrawer drawer, string errorMessage)
        {
            drawer.ShowMessage($"-- ГРЕШКА: {errorMessage} --");
        }
    }
}
